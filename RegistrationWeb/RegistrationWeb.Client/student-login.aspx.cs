using RegistrationWeb.Logic;
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
                Message.Text = "No entry for either username or password.";
            }

            else
            {
                var data = new DataService();

                var studentUsers = data.GetStudentUsers();
                var matchingUsername = studentUsers.Where(su => su.Username.Equals(Username.Text));
                var matchingPassword = matchingUsername.Where(mu => mu.UserPassword.Equals(Password.Text));

                if (matchingPassword.Count() == 1)
                {
                    //Remove any existing cookies
                    if (Request.Cookies["StudentUserInfo"] != null)
                    {
                        HttpCookie myCookie = new HttpCookie("StudentUserInfo");
                        myCookie.Expires = DateTime.Now.AddDays(-1d);
                        Response.Cookies.Add(myCookie);
                    }

                    //Add cookie with registrar user id
                    HttpCookie studentCookie = new HttpCookie("StudentUserInfo");
                    studentCookie["StudentUserId"] = matchingPassword.First().Id.ToString();
                    studentCookie.Expires = DateTime.Now.AddDays(1d);
                    Response.Cookies.Add(studentCookie);

                    Response.Redirect("~/student-registration.aspx");
                }

                else
                {
                    Message.Text = "Invalid username or password.";
                }
            }

        }
    }
}