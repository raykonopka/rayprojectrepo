using RegistrationWeb.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationWeb.Client
{
    public partial class student_registration_status : System.Web.UI.Page
    {
        private int userIdFromCookie;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            GetSchedules();

            getBookmarks();
        }

        protected void DropCourse_Click(object sender, EventArgs e)
        {
            var data = new DataService();

            int selected;
            Int32.TryParse(registeredList.SelectedItem.Text, out selected);

            data.dropFromSession(userIdFromCookie, selected);
            RegMsg.Text = "Course dropped.";
            RegMsg.Visible = true;
        }


        protected void RegisterBookmark_Click(object sender, EventArgs e)
        {
            var data = new DataService();

            int selected;
            Int32.TryParse(bookmarkedList.SelectedItem.Text, out selected);

            data.registerStudent(userIdFromCookie, selected);
            BkMsg.Text = "Course registered";
            BkMsg.Visible = true;
        }


        protected void RemoveBookmark_Click(object sender, EventArgs e)
        {
            var data = new DataService();

            int selected;
            Int32.TryParse(bookmarkedList.SelectedItem.Text, out selected);

            var stdBookmarks = data.getBookmarks().Where(bk => bk.StudentUserId.Equals(userIdFromCookie));
            var matchingBookmarks = stdBookmarks.Where(bk => bk.SessionId.Equals(selected));

            data.removeBookmark(matchingBookmarks.First());

            BkMsg.Text = "Bookmark removed";
            BkMsg.Visible = true;
        }


        private void GetSchedules()
        {
            var data = new DataService();
            registeredList.Items.Clear();

            var allSchedules = data.GetSchedules();
            var matchingSchedules = allSchedules.Where(sch => sch.StudentId.Equals(userIdFromCookie));

            foreach (var schedule in matchingSchedules)
            {
                registeredList.Items.Add(schedule.CourseSessionId.ToString());
            }
        }


        private void getBookmarks()
        {
            var data = new DataService();
            bookmarkedList.Items.Clear();

            var allBookmarks = data.getBookmarks();
            var matchingBookmamrks = allBookmarks.Where(bk => bk.StudentUserId.Equals(userIdFromCookie));

            foreach (var bookmark in matchingBookmamrks)
            {
                bookmarkedList.Items.Add(bookmark.SessionId.ToString());
            }
        }
    }
}