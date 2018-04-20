using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;

namespace Awms_Fyp.Awms.Management
{
    public partial class Management : System.Web.UI.MasterPage
    {
        SessionVerification SV;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            LoadDetails();
        }
        void LoadDetails()
        {
            user_linksLiteral.Text = SV.Name;
            ImageLiteral.Text = $"<img src='../../Images/{SV.GetImage(SV.ProfileImage)}' alt='' class='img-responsive' />";
        }
    }
}