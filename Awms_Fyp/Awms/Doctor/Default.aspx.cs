using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;
using Customs;

namespace Awms_Fyp.Awms.Doctor
{
    public partial class Default : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        SessionVerification SV;
        Encryption enc;
        NavClass nav = new NavClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.LoginKey };
            Check();
            LoadAppointments();
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
        void LoadAppointments()
        {
            var d = string.Empty;
            var index = 0;

            var Apps = new Project_Dll.Appointment().Search_For(Appointment_support.Column.Doctor_id, Appointment_support.LogicalOperator.EQUAL_TO, SV.Uid,
                Appointment_support.Relation.AND, Appointment_support.Column.Schedule_date, Appointment_support.LogicalOperator.GREATER_THAN_OR_EQUAL_TO, DateTime.Now.ToString("yyyy-MM-dd"));
            foreach (var app in Apps)
            {
                if(app.Status != "pending") { continue; }
                index++;
                var patient = new Patient_view().Load_record_with(Patient_view_support.Column.Id, Patient_view_support.LogicalOperator.EQUAL_TO, app.Patient_id);
                d += $"<tr><td>{index}</td><td><a href='../../doctor/appointment/{enc.EncryptString(app.Id, SV.LoginKey)}'>{patient.Name}</a></td><td>{app.Descritpion}</td><td>{app.Schedule_date}</td><td>{app.Set_time}</td></tr>";
            }
            NewAppointmentsLiteral.Text = index.ToString();
            AppLiteral.Text = d;
        }
    }
}