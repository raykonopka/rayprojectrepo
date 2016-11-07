using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationWeb.Client
{
    public partial class student_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username.Text) ||
                string.IsNullOrWhiteSpace(Password.Text))
            {
                Message.Text = "Invalid Username Or Password";
            }

            else
            {
                Response.Redirect("~/student-registration.aspx");
            }
        }
    }
}