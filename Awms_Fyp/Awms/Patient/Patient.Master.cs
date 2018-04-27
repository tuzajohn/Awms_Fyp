using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Awms_Fyp.Awms.Patient
{
    public partial class Patient : System.Web.UI.MasterPage
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
            if (!string.IsNullOrEmpty(SV.ProfileImage))
            {
                piclink.Attributes.Add("style", "display:none;");
            }
            ImageLiteral.Text = $"<img src='../../Images/{SV.GetImage(SV.ProfileImage)}' alt='' class='img-responsive' />";
        }
    }
}