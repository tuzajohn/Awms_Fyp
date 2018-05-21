using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Awms_Fyp.Awms.Patient
{
    public partial class Grid : System.Web.UI.Page
    {
        SessionVerification sv;
        protected void Page_Load(object sender, EventArgs e)
        {
            sv = new SessionVerification();
            var s = new Shift(sv.ShiftFilePath);
            var table = s.ConvertToDataTable("shift");
            GridView1.Visible = true;
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}