using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;

namespace Awms_Fyp.Awms.Management
{
    public partial class Add_Doctor : System.Web.UI.Page
    {
        SessionVerification SV;
        NavClass nav = new NavClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            Check();
            RegDoctor();
        }
        private void Check()
        {
            if (!SV.IsloggedIn) { Response.Redirect(nav.Logout); }
            else { if (SV.Status.ToLower() != "management") { Response.Redirect(nav.Logout); } }
        }
        private void RegDoctor()
        {
            NxtBtn.ServerClick += delegate
            {
                if (!IsEmpty(fnameBox.Value) && !IsEmpty(emailBox.Value) && !IsEmpty(contactBox.Value) && !IsEmpty(lname.Value)
                    && !IsIndexZero(professionSelect.Value)
                    && !IsEmpty(dob.Value)
                    && !IsIndexZero(genderSelect.Value)
                    && !IsEmpty(addressBox.Value))
                {
                    Session["fname"] = fnameBox.Value;
                    Session["lname"] = lname.Value;
                    Session["email"] = emailBox.Value;
                    Session["contact"] = contactBox.Value;
                    Session["profession"] = professionSelect.Value;
                    Session["date"] = dob.Value;
                    Session["gender"] = genderSelect.Value;
                    Session["address"] = addressBox.Value;
                    Response.Redirect(nav.ManNewDoctorDetails);
                }
                Session["message"] = new HtmlElements().GetMesage("Fields can not be empty!", HtmlElements.MessageType.ERROR, HtmlElements.UserType.MANAGEMENT);
                Response.Redirect(nav.ManNewDoctor);
            };
        }
        bool IsEmpty(string txt)
        {
            var k = false;
            if (string.IsNullOrEmpty(txt)) { k = true; }
            return k;
        }
        bool IsIndexZero(string select)
        {
            var k = false;
            if (select.ToLower() == "profession" || select.ToLower() == "gender")
            {
                k = true;
            }
            return k;
        }
    }
}