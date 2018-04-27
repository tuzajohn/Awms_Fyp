using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Customs;
using Project_Dll;

namespace Awms_Fyp.Awms.Account
{
    public partial class Register : System.Web.UI.Page
    {
        RegExpression reg = new RegExpression();
        Encryption enc;
        SessionVerification SV;
        HtmlElements elements = new HtmlElements();
        NavClass nav = new NavClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.LoginKey };
            RegisterHandler();
        }
        private void RegisterHandler()
        {
            regBtn.ServerClick += delegate
            {
                var redirect = string.Empty;
                redirect = nav.Register;
                var logins = new Login_table().Load_record_with(Login_table_support.Column.Username, Login_table_support.LogicalOperator.EQUAL_TO, userBox.Value);
                if (string.IsNullOrEmpty(logins.Id))
                {
                    if (passBox.Value == rePass.Value)
                    {
                        var (check, result) = reg.IsPassword(passBox.Value);
                        if (check)
                        {
                            var uDetails = new User_details();
                            logins.insert(userBox.Value, enc.GetMD5(enc.StrongEncrypt(passBox.Value)), DateTime.Now.ToString("dd-MM-yyyy"), "3");
                            uDetails.insert(logins.Id, fnameBox.Value, lname.Value, emailBox.Value, addressBox.Value, contactBox.Value, genderSelect.Value, dob.Value, "patient");
                            Session["message"] = elements.GetMesage($"Welcome {uDetails.Fname} {uDetails.Lname}, you can now login.", HtmlElements.MessageType.SUCCESS, HtmlElements.UserType.ALL);
                            redirect = nav.Index;
                        }
                        else { Session["message"] = elements.GetMesage(result, HtmlElements.MessageType.INFO, HtmlElements.UserType.ALL); }
                    }
                    else { Session["message"] = elements.GetMesage("Passwords do not match!", HtmlElements.MessageType.INFO, HtmlElements.UserType.ALL); }
                }
                else { Session["message"] = elements.GetMesage("Username is not available!", HtmlElements.MessageType.INFO, HtmlElements.UserType.ALL); }
                Response.Redirect(redirect);
            };
        }
    }
}