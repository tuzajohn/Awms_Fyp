using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;

namespace Awms_Fyp.Awms.Management
{
    public partial class Default : System.Web.UI.Page
    {
        SessionVerification SV;
        NavClass nav = new NavClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            Check();
            Load_();
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
        void Load_()
        {
            var d = string.Empty;
            var index = 0;
            var allDetails = new User_details_view().getAllRecords();
            foreach (var person in allDetails)
            {
                index++;
                var age = (Math.Floor((DateTime.Now - DateTime.Parse(person.Dob)).TotalSeconds / 31556952)).ToString();
                d += Table(index.ToString(), person.Name, IfEmpty(person.Contact), age, person.User_type, IfEmpty(person.Speciality));
            }
            UserLiteral.Text = d;
        }
        string IfEmpty(string txt)
        {
            if (string.IsNullOrEmpty(txt)) { return "N/A"; }
            return txt;
        }
        string Table(string index, string name, string contact, string age, string type, string profession)
        {
            var d = string.Empty;
            d = $"<tr><td>{index}</td><td>{name}</td><td>{contact}</td><td>{age}</td><td>{type}</td><td>{profession}</td></tr>";
            return d;
        }

    }
}