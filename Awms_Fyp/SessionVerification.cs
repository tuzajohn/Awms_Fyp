using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Awms_Fyp
{
    public class SessionVerification : System.Web.UI.Page
    {
        public string LoginKey => "&*>w!@~g";
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Dob { get; set; }
        public string Uid { get; set; }
        public string Gender { get; set; }
        public string ProfileImage { get; set; }
        public string Status { get; set; }
        public bool IsloggedIn { get; set; }
        public SessionVerification()
        {
            try
            {
                Uid = Session["uid"].ToString();
                Status = Session["staus"].ToString();
                Name = Session["name"].ToString();
                Username = Session["username"].ToString();
                Address = Session["address"].ToString();
                Contact = Session["contact"].ToString();
                Email = Session["email"].ToString();
                Gender = Session["gender"].ToString();
                Dob = Session["dob"].ToString();
                ProfileImage = Session["image"].ToString();
            }
            catch (Exception) { }
            Check();
        }
        private void Check()
        {
            switch (string.IsNullOrEmpty(Uid))
            {
                case true: IsloggedIn = false; break;
                default: IsloggedIn = true; break;
            }
        }
        public string GetImage(string itemUrl)
        {
            switch (string.IsNullOrEmpty(itemUrl))
            {
                case true: itemUrl = "noimage.jpg"; break;
                default: break;
            }
            if (File.Exists(Server.MapPath($"~/Images/{itemUrl}"))) return "/" + itemUrl;
            else { return "noimage.jpg"; }
        }
    }
    public class NavClass
    {
        #region Logins
        public string Index => "~/login";
        public string Logout => "~/logout";
        public string Register => "~/register";
        #endregion
        #region Management
        public string Dashboard => "~/management/dashboard";
        public string ManNewDoctor => "~/management/doctor/new";
        public string ManNewDoctorDetails => "~/management/doctor/new/details";
        public string ManPassword => "~/management/password";
        public string ManUsername => "~/management/username";
        public string ManPicture => "~/management/picture";
        public string ManNewUser => "~/management/admin/new";
        #endregion
        #region Patient
        public string PatientHome => "~/home";
        public string PatientPassword => "~/password";
        public string PatientUsername => "~/username";
        public string PatientPicture => "~/picture";
        #endregion
        #region Doctor
        public string DoctorHome => "~/doctor/home";
        public string DoctorAppointment => "~/doctor/appointment";
        public string DoctorPassword => "~/doctor/password";
        public string DoctorUsername => "~/doctor/username";
        #endregion
    }
}