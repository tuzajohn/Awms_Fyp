using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Customs;
using Project_Dll;

namespace Awms_Fyp.Awms.Doctor
{
    public partial class Appointment : System.Web.UI.Page
    {
        SessionVerification SV;
        Encryption enc;
        NavClass nav = new NavClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.LoginKey };
            Check();
            if (Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            try
            {
                var appId = Page.RouteData.Values["appid"].ToString();
                LoadAppointment(enc.DecryptString(appId, SV.LoginKey));
            }
            catch (Exception) { }
            Denied();
        }
        private void Check()
        {
            if (!SV.IsloggedIn)
            {
                Response.Redirect(nav.Logout);
            }
            else
            {
                if (SV.Status.ToLower() != "doctor")
                {
                    Response.Redirect(nav.Logout);
                }
            }
        }
        private void LoadAppointment(string appId)
        {
            var apps = new Project_Dll.Appointment(appId);
            var patientDetails = new User_details_view().Load_record_with(User_details_view_support.Column.Id, User_details_view_support.LogicalOperator.EQUAL_TO, apps.Patient_id);
            var doctor = new Doctor_view().Load_record_with(Doctor_view_support.Column.Id, Doctor_view_support.LogicalOperator.EQUAL_TO, apps.Doctor_id);
            var date = DateTime.Parse(apps.Schedule_date + " " + apps.Set_time);
            AppointmentLiteral.Text = $"{date.Year}/{date.Month}/{date.Day}/{date.Hour}/A{appId}/D{doctor.Id}";
            name.InnerText = patientDetails.Name;
            desc.InnerText = apps.Descritpion;
            address.InnerText = patientDetails.Address;
            dTime.InnerText = $"{DateTime.Parse($"{date}").ToLongDateString()} { apps.Set_time}";

        }
        private void Denied()
        {
            SendBtn.ServerClick += delegate
            {
                
                Response.Redirect(nav.DoctorHome);
            };
        }
    }
}