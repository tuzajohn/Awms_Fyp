using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Awms_Fyp.Awms.Doctor
{
    public partial class Doctor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["message"] != null)
            {
                MessageLiteral.Text = Session["message"].ToString();
            }
        }
    }
}