using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Awms_Fyp.Awms
{
    public partial class Main : System.Web.UI.MasterPage
    {
        SessionVerification SV;
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            var uri = Request.Url.AbsoluteUri;
            var domain = uri.Replace(uri.Substring(uri.IndexOf(Request.Url.AbsolutePath)), "");
            StyleScript(domain);
            Check();
        }
        private void Check()
        {
            if (!string.IsNullOrEmpty(SV.Uid))
            {
                logIn.Style.Add("display", "none");
                logI1.Style.Add("display", "none");
                logOut.Style.Remove("display");
                logO1.Style.Remove("display");
            }
            else
            {
                logIn.Style.Remove("display");
                logI1.Style.Remove("display");
                logOut.Style.Add("display", "none");
                logO1.Style.Add("display", "none");
            }
        }
        private void StyleScript(string domain)
        {
            var styles = $@"
            <link rel='shortcut icon' href='{domain}/Styles/assets/img/favicon.png?v=3'>
            <link rel='stylesheet' href='{domain}/Styles/assets/css/preload.min.css' />
            <link rel='stylesheet' href='{domain}/Styles/assets/css/plugins.min.css' />
            <link rel='stylesheet' href='{domain}/Styles/assets/css/style.light-blue-500.min.css' />
            <script src='{domain}/Styles/assets/js/jquery-2.2.3.min.js'></script>
            <link href='{domain}/Styles/assets/css/layout-datatables.css' rel='stylesheet' type='text/css' />";
            var java = $@"
            <script src='{domain}/Styles/assets/js/plugins.min.js'></script>
            <script src='{domain}/Styles/assets/js/app.min.js'></script>
            <script src='{domain}/Styles/assets/js/index.js'></script>
            <script type='text/javascript' src='{domain}/Styles/assets/js/jquery.dataTables.min.js'></script>
            <script type='text/javascript' src='{domain}/Styles/assets/js/dataTables.tableTools.min.js'></script>
            <script type='text/javascript' src='{domain}/Styles/assets/js/dataTables.bootstrap.js'></script>";
            StylesSheetLiteral.Text = styles;
            JavaScript.Text = java;
        }
    }
}