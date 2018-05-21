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
            GridView1.DataSource = new ShiftHandler().GetTable(new List<string> { SV.Uid }, false);
            GridView1.DataBind();
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

            var Apps = new Project_Dll.Appointment().getAllRecords().Where(a => a.Doctor_id == SV.Uid && DateTime.Parse(a.Schedule_date) >= DateTime.Now).ToList();
            foreach (var app in Apps)
            {
                if(app.Status != "pending") { continue; }
                index++;
                var patient = new Patient_view().getAllRecords().Where(p => p.Id == app.Patient_id).FirstOrDefault();
                d += $"<tr><td>{index}</td><td><a href='../../doctor/appointment?appid={enc.EncryptString(app.Id, SV.LoginKey)}'>{patient.Name}</a></td><td>{app.Descritpion}</td><td>{app.Schedule_date}</td><td>{app.Set_time}</td></tr>";
            }
            NewAppointmentsLiteral.Text = index.ToString();
            AppLiteral.Text = d;
        }
    }
}