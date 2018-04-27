using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Awms_Fyp.Awms.Doctor
{
    public partial class Appointment : System.Web.UI.Page
    {
        SessionVerification SV;
        NavClass nav = new NavClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            Check();
            if (Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
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
        private void Denied()
        {
            SendBtn.ServerClick += delegate
            {
                
                Response.Redirect(nav.DoctorHome);
            };
        }
    }
}