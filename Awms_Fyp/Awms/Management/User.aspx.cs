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
    public partial class User : System.Web.UI.Page
    {
        SessionVerification SV;
        Encryption enc;
        NavClass nav = new NavClass();
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            enc = new Encryption() { Key = SV.LoginKey };
            Check();
            try
            {
                var Uid = Page.RouteData.Values["id"].ToString();
                LoadData(Uid);
            }
            catch (Exception) { }
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
        private void LoadData(string id)
        {
            id = enc.DecryptString(id, SV.LoginKey);
            var uDetails = new User_details(id);
            fname.InnerText = uDetails.Fname.ToUpper();
            lname.InnerText = uDetails.Lname.ToUpper();
            NameLiteral.Text = new User_details_view().Load_record_with(User_details_view_support.Column.Id, User_details_view_support.LogicalOperator.EQUAL_TO, id).Name;
            dob.InnerText = DateTime.Parse(uDetails.Dob).ToLongDateString();
            contact.InnerText = uDetails.Contact;
            userTpe.InnerHtml = uDetails.User_type.ToUpper();
            var s = new Speciality_table().Load_record_with(Speciality_table_support.Column.Doctor_id, Speciality_table_support.LogicalOperator.EQUAL_TO, uDetails.User_id).Speciality;
            speciality.InnerText = !string.IsNullOrEmpty(s) ? s.ToUpper() : "N/A";
            DisplayShift(id);
            var prof = SV.GetImage(new Profile_image_table().Load_record_with(Profile_image_table_support.Column.User_id, Profile_image_table_support.LogicalOperator.EQUAL_TO, id).Url);
            ProfPicLiteral.Text = $"<img src='../../images/{SV.GetImage(prof)}' alt='' class='img-responsive' />";
        }
        void DisplayShift(string docId)
        {
            var shifts = new Doctor_shift_table().Search_For(Doctor_shift_table_support.Column.Doctor_id, Doctor_shift_table_support.LogicalOperator.EQUAL_TO, docId);
            //ShiftTable.Text = elements.GetDoctShift(shifts);
        }

    }
}