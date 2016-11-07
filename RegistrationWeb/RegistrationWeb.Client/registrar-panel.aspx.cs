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
    public partial class registrar_panel : System.Web.UI.Page
    {
        private int userIdFromCookie;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if user logged in using correct login URL
            if (!IsPostBack)
            {
                if (Request.UrlReferrer == null)
                {
                    Response.Redirect("~/registrar-login.aspx");
                }

                else if (!Request.UrlReferrer.ToString().Contains("registrar-login.aspx"))
                {
                    Response.Redirect("~/registrar-login.aspx");
                }
            }

            //Look for user info cookie
            HttpCookie myCookie = new HttpCookie("RegistrarUserInfo");
            myCookie = Request.Cookies["RegistrarUserInfo"];

            if (myCookie != null)
            {
                string[] cookieInfo = myCookie.Value.Split('=');
                Int32.TryParse(cookieInfo[1], out userIdFromCookie);
            }

            //If there is no cookie found with proper user info, send back to corresponding login screen
            else
            {
                Response.Redirect("~/registrar-login.aspx");
            }
        }

        protected void AddCourse_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            CourseDAO newCourse = new CourseDAO { Title = CourseName.Text, DepartmentId = (Int32.Parse(DepartmentID.Text)), Credits = (Int32.Parse(CreditHours.Text)) };
            bool added = data.addCourse(newCourse);

            if (added)
            {
                courseAddMsg.Text = "Course was added.";
            }
            else
            {
                courseAddMsg.Text = "Course was not able to be added.";
            }
        }


        protected void RemoveCourse_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            CourseDAO cancelCourse = new CourseDAO { Id = (Int32.Parse(CourseID.Text)) };
            bool removed = data.cancelCourse(cancelCourse);

            if (removed)
            {
                courseAddMsg.Text = "Course was removed.";
            }
            else
            {
                courseAddMsg.Text = "Course was not able to be removed.";
            }
        }



        protected void AddStudent_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            StudentDAO newStudent = new StudentDAO { StudentName = StudentName.Text, MajorId = (Int32.Parse(MajorID.Text)) };
            bool added = data.addStudent(newStudent);

            if (added)
            {
                AddStMsg.Text = "Student was added.";
            }
            else
            {
                AddStMsg.Text = "Student was not able to be added.";
            }
        }


        protected void RemoveStudent_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            StudentDAO removeStudent = new StudentDAO { Id = (Int32.Parse(StudentID.Text)) };
            bool removed = data.removeStudent(removeStudent);

            if (removed)
            {
                RemoveStMsg.Text = "Student was removed.";
            }
            else
            {
                RemoveStMsg.Text = "Student was not able to be removed.";
            }
        }


        protected void GetSchedule_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            List<CourseSessionDAO> coursesScheduled = new List<CourseSessionDAO>();
            coursesScheduled = data.GetStudentSchedule(Int32.Parse(StudentIDSch.Text));
            var allCourses = data.GetCourses();

            List<CourseDAO> matchingCourses = new List<CourseDAO>();

            if (coursesScheduled.Count > 0)
            {
                SchMsg.Text = "Acquired schedules.";

                foreach (CourseSessionDAO cs in coursesScheduled)
                {
                    var matchingCs = allCourses.Where(c => c.Id.Equals(cs.CourseId));
                    matchingCourses.Add(matchingCs.First());
                }

                foreach (CourseDAO c in matchingCourses)
                {
                    studentScheduleDrop.Items.Add(c.Title);
                }
            }
            else
            {
                SchMsg.Text = "Was not able to acquire schedules.";
            }
        }


        protected void GetEnrollment_Click(object sender, EventArgs e)
        {
            var data = new DataService();
            List<StudentDAO> students = data.GetEnrolledStudents(Int32.Parse(SessionForEnrollment.Text));

            if (students.Count() > 0)
            {
                enrollmentMsg.Text = "Students acquired.";

                foreach (StudentDAO st in students)
                {
                    sessionEnrollmentDrop.Items.Add(st.StudentName);
                }
            }
            else
            {
                enrollmentMsg.Text = "No students enrolled in course.";
            }
        }
    }
}