using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;
using Customs;

namespace Awms_Fyp.Awms.Management
{
    public partial class Username : System.Web.UI.Page
    {
        SessionVerification SV;
        NavClass nav = new NavClass();
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            Check();
            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            ChangeUsernameHandler();
        }
        private void Check()
        {
            if (!SV.IsloggedIn)
            {
                Response.Redirect(nav.Logout);
            }
            else
            {
                if (SV.Status.ToLower() != "management")
                {
                    Response.Redirect(nav.Logout);
                }
            }
        }
        private void ChangeUsernameHandler()
        {
            saveUserBtn.ServerClick += delegate
            {
                var logins = new Login_table().Load_record_with(Login_table_support.Column.Username, Login_table_support.LogicalOperator.EQUAL_TO, newusername.Value);
                if (string.IsNullOrEmpty(logins.Id))
                {
                    if (oldusername.Value == SV.Username)
                    {
                        logins.updateField("username", newusername.Value, SV.Uid);
                        Session["message"] = elements.GetMesage("Username has been changed!", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.ALL);
                    }
                    else { Session["message"] = elements.GetMesage("Wrong username!", HtmlElements.MessageType.ERROR, HtmlElements.UserType.ALL); }
                }
                else { Session["message"] = elements.GetMesage("Username not accepted!", HtmlElements.MessageType.ERROR, HtmlElements.UserType.ALL); }
                Response.Redirect(nav.ManUsername);
            };
        }
    }
}