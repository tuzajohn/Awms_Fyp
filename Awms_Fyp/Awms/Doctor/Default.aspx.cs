using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Dll;

namespace Awms_Fyp.Awms.Doctor
{
    public partial class Default : System.Web.UI.Page
    {
        HtmlElements elements = new HtmlElements();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["message"] = elements.GetMesage("Default info", HtmlElements.MessageType.INFO, HtmlElements.UserType.DOCTOR);
        }
    }
}