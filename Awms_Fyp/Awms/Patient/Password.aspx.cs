using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;
using Customs;

namespace Awms_Fyp.Awms.Patient
{
    public partial class Password : System.Web.UI.Page
    {
        SessionVerification SV;
        NavClass nav = new NavClass();
        Encryption enc;
        HtmlElements elements = new HtmlElements();
        RegExpression reg = new RegExpression();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.LoginKey };
            Check();
            if (Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
            ChangePassHandler();
        }
        private void Check()
        {
            if (!SV.IsloggedIn)
            {
                Response.Redirect(nav.Logout);
            }
            else
            {
                if (SV.Status.ToLower() != "patient")
                {
                    Response.Redirect(nav.Logout);
                }
            }
        }
        private void ChangePassHandler()
        {
            savePassBtn.ServerClick += delegate
            {
                var logins = new Login_table().Load_record_with(Login_table_support.Column.Id, Login_table_support.LogicalOperator.EQUAL_TO, SV.Uid);
                if (enc.GetMD5(enc.StrongEncrypt(oldPass.Value)) == logins.Password)
                {
                    if (newPass.Value == newRepPass.Value)
                    {
                        var (check, result) = reg.IsPassword(newPass.Value);
                        if (check)
                        {
                            logins.Password = enc.GetMD5(enc.StrongEncrypt(newPass.Value));
                            Session["message"] = elements.GetMesage("Password changed successfully!", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.PATIENT);
                        }
                        else { Session["message"] = elements.GetMesage(result, HtmlElements.MessageType.INFO, HtmlElements.UserType.PATIENT); }
                    }
                    else { Session["message"] = elements.GetMesage("Passwords don't match!", HtmlElements.MessageType.ERROR, HtmlElements.UserType.PATIENT); }
                }
                else { Session["message"] = elements.GetMesage("Wrong password!", HtmlElements.MessageType.ERROR, HtmlElements.UserType.PATIENT); }
                Response.Redirect(nav.PatientPassword);
            };
        }
    }
}