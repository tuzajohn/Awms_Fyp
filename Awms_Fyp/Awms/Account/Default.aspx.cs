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
    public partial class Default : System.Web.UI.Page
    {
        Encryption enc;
        SessionVerification SV;
        NavClass nav = new NavClass();
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.LoginKey };
            LoginEvent();
            if(Session["message"] != null) { MessageLiteral.Text = Session["message"].ToString(); Session["message"] = null; }
        }

        public enum UserTypes { PATIENT, MANAGEMENT, DOCTOR };
        private void LoginEvent()
        {
            loginBtn.ServerClick += delegate
            {
                var redirectTo = string.Empty;
                redirectTo = nav.Index;
                var logins = new Login_table().Load_record_with(Login_table_support.Column.Username, Login_table_support.LogicalOperator.EQUAL_TO, userBox.Value);
                if (!string.IsNullOrEmpty(logins.Id))
                {
                    var d = enc.GetMD5(enc.StrongEncrypt(passBox.Value));
                    if (enc.GetMD5(enc.StrongEncrypt(passBox.Value)) == logins.Password.Replace("\r\n", ""))
                    {
                        var uDetails = new User_details().Load_record_with(User_details_support.Column.Id, User_details_support.LogicalOperator.EQUAL_TO, logins.Id);
                        Session["uid"] = logins.Id;
                        Session["name"] = uDetails.Fname + " " + uDetails.Lname;
                        Session["username"] = logins.Username;
                        Session["address"] = uDetails.Address;
                        Session["contact"] = uDetails.Contact;
                        Session["email"] = uDetails.Email;
                        Session["gender"] = uDetails.Gender;
                        Session["dob"] = uDetails.Dob;
                        Session["staus"] = uDetails.User_type;
                        var f = UserTypes.MANAGEMENT.ToString();
                        if (uDetails.User_type == UserTypes.MANAGEMENT.ToString().ToLower()) { redirectTo = nav.Dashboard; }
                        else if (uDetails.User_type == UserTypes.PATIENT.ToString().ToLower()) { redirectTo = nav.PatientHome; }
                        else if (uDetails.User_type == UserTypes.DOCTOR.ToString().ToLower()) { redirectTo = nav.DoctorHome; }
                        else { redirectTo = nav.Index; }                        
                    }
                    else { Session["message"] = elements.GetMesage("Wrong username or password!", HtmlElements.MessageType.INFO, HtmlElements.UserType.ALL); }
                }
                else { Session["message"] = elements.GetMesage("Wrong username or password!", HtmlElements.MessageType.INFO, HtmlElements.UserType.ALL); }
                Response.Redirect(redirectTo);
            };
        }

    }
}