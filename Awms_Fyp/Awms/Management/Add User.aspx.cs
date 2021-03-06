﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Awms_Fyp.Awms.Management
{
    public partial class Add_User : System.Web.UI.Page
    {
        SessionVerification SV;
        NavClass nav = new NavClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            SV = new SessionVerification();
            Check();
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
    }
}