using RegistrationWeb.Logic;
using RegistrationWeb.Logic.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationWeb.Client
{
    public partial class student_registration : System.Web.UI.Page
    {
        private int userIdFromCookie;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer == null)
                {
                    Response.Redirect("~/student-login.aspx");
                }

                else if (!Request.UrlReferrer.ToString().Contains("student-login.aspx"))
                {
                    Response.Redirect("~/student-login.aspx");
                }
            }

                //Look for user info cookie
                HttpCookie myCookie = new HttpCookie("StudentUserInfo");
                myCookie = Request.Cookies["StudentUserInfo"];

                if (myCookie != null)
                {
                    string[] cookieInfo = myCookie.Value.Split('=');
                    Int32.TryParse(cookieInfo[1], out userIdFromCookie);
                }

                //If there is no cookie found with proper user info, send back to corresponding login screen
                else
                {
                    Response.Redirect("~/student-login.aspx");
                }

            GetCourses();
        }
        


        protected void RegistrationStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/student-registration-status.aspx");
        }


        protected void CourseSelect_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            var allCourses = data.GetCourses();
            var matchingCourses = allCourses.Where(c => c.Title.Equals(courseList.SelectedItem.Text));

            if (matchingCourses.Count() > 0)
            {
                GetClasses(matchingCourses.First().Id);
                classList.Visible = true;
                ClassClick1.Visible = true;
                ClassClick2.Visible = true;
                Status.Visible = true;
            }

            else
            {
                errorCourses.Text = "No classes available for selected course.";
                errorCourses.Visible = true;
            }
        }


        protected void ClassRegister_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            int sessionId;

            if (classList.SelectedItem.Text.Count() > 0)
            {
                Int32.TryParse(classList.SelectedItem.Text, out sessionId);
                data.registerStudent(userIdFromCookie, sessionId);

                Status.Text = "Student registered for class.";
                Status.Visible = true;
            }

            else
            {
                Status.Text = "No class selected";
                Status.Visible = true;
            }
        }


        protected void ClassBookmark_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            int sessionId;

            if (classList.SelectedItem.Text.Count() > 0)
            {
                Int32.TryParse(classList.SelectedItem.Text, out sessionId);

                BookmarkedSessionDAO newBookmark = new BookmarkedSessionDAO {StudentUserId = userIdFromCookie, SessionId = sessionId };
                data.addBookmark(newBookmark);

                Status.Text = "Class bookmark has been added.";
                Status.Visible = true;
            }

            else
            {
                Status.Text = "No class selected";
                Status.Visible = true;
            }
        }


        private void GetCourses()
        {
            var data = new DataService();
            courseList.Items.Clear();

            foreach (var course in data.GetCourses())
            {
                courseList.Items.Add(course.Title);
            }
        }


        private void GetClasses(int courseId)
        {
            var data = new DataService();
            classList.Items.Clear();

            var allSessions = data.GetSessions();
            var matchingSessions = allSessions.Where(s => s.CourseId.Equals(courseId));

            foreach (var session in matchingSessions)
            {
                classList.Items.Add(session.Id.ToString());
            }
        }

    }
}