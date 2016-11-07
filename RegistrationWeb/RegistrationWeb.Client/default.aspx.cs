using RegistrationWeb.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationWeb.Client
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void StudentLogin_Click(object sender, EventArgs e)
        {
            //redirect
            Response.Redirect("~/student-login.aspx");
        }

        protected void RegistrarLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/registrar-login.aspx");
        }
    }
}