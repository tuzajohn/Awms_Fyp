using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Awms_Fyp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("default", "", "~/Awms/Account/Default.aspx");
            routes.MapPageRoute("login", "login", "~/Awms/Account/Default.aspx");
            routes.MapPageRoute("register", "register", "~/Awms/Account/Register.aspx");
            routes.MapPageRoute("logout", "logout", "~/Awms/Account/Logout.aspx");
            routes.MapPageRoute("doctor_home", "doctor/home", "~/Awms/Doctor/Default.aspx");
            routes.MapPageRoute("doctor_appointment", "doctor/appointment/{appid}", "~/Awms/Doctor/Appointment.aspx");
            routes.MapPageRoute("doctor_password", "doctor/password", "~/Awms/Doctor/Password.aspx");
            routes.MapPageRoute("doctor_username", "doctor/username", "~/Awms/Doctor/Username.aspx");
            routes.MapPageRoute("management_dashboard", "management/dashboard", "~/Awms/management/Default.aspx");
            routes.MapPageRoute("management_doctor_new", "management/doctor/new", "~/Awms/management/Add Doctor.aspx");
            routes.MapPageRoute("management_doctor_new_details", "management/doctor/new/details", "~/Awms/management/Doctor Detail.aspx");
            routes.MapPageRoute("management_password", "management/password", "~/Awms/management/Password.aspx");
            routes.MapPageRoute("management_username", "management/username", "~/Awms/management/Username.aspx");
            routes.MapPageRoute("management_new", "management/admin/new", "~/Awms/management/Add User.aspx");
            routes.MapPageRoute("management_user", "management/user/{id}", "~/Awms/management/User.aspx");
            routes.MapPageRoute("management_profile_picture", "management/picture", "~/Awms/management/Picture.aspx");
            routes.MapPageRoute("patient_home", "home", "~/Awms/Patient/Default.aspx");
            routes.MapPageRoute("patient_password", "password", "~/Awms/Patient/Password.aspx");
            routes.MapPageRoute("patient_username", "username", "~/Awms/Patient/Username.aspx");
            routes.MapPageRoute("patient_picture", "picture", "~/Awms/Patient/Picture.aspx");
            routes.MapPageRoute("about", "about", "~/Awms/About.aspx");

        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}