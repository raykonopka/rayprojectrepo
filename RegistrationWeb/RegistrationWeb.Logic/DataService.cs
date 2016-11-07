using RegistrationWeb.Logic.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWeb.Logic
{
    public class DataService
    {
        private RegistrationDataServiceClient regDataClient = new RegistrationDataServiceClient();

        public List<StudentDAO> GetStudents()
        {
            return regDataClient.GetStudents().ToList();
        }

        public List<StudentUserDAO> GetStudentUsers()
        {
            return regDataClient.GetStudentsUsers().ToList();
        }

        public List<RegistrarUserDAO> GetRegistrarUsers()
        {
            return regDataClient.GetRegistrarUsers().ToList();
        }

        public List<CourseDAO> GetCourses()
        {
            return regDataClient.GetCourses().ToList();
        }

        public List<CourseSessionDAO> GetSessions()
        {
            return regDataClient.GetSessions().ToList();
        }

        public bool registerStudent(int stId, int sId)
        {
            return regDataClient.RegisterStudent(stId, sId);
        }

        public bool dropFromSession(int stId, int sId)
        {
            return regDataClient.DropFromSession(stId, sId);
        }

        public List<BookmarkedSessionDAO> getBookmarks()
        {
            return regDataClient.GetBookmarks().ToList();
        }


        public bool addBookmark(BookmarkedSessionDAO bmToAdd)
        {
            return regDataClient.AddCourseBookmark(bmToAdd);
        }

        public bool removeBookmark(BookmarkedSessionDAO bmToRemove)
        {
            return regDataClient.RemoveCourseBookmark(bmToRemove);
        }


        public List<ScheduleDAO> GetSchedules()
        {
            return regDataClient.GetSchedules().ToList();
        }


        public bool addCourse(CourseDAO cToAdd)
        {
            return regDataClient.InsertCourse(cToAdd);
        }

        public bool cancelCourse(CourseDAO cToRemove)
        {
            return regDataClient.CancelCourse(cToRemove);
        }


        public bool addStudent(StudentDAO stToAdd)
        {
            return regDataClient.InsertStudent(stToAdd);
        }

        public bool removeStudent(StudentDAO stToRemove)
        {
            return regDataClient.RemoveStudent(stToRemove);
        }



        public List<CourseSessionDAO> GetStudentSchedule(int studentId)
        {
            List<CourseSessionDAO> courseList = new List<CourseSessionDAO>();
            courseList = regDataClient.GetStudentSchedule(studentId).ToList();

            return courseList;
        }


        public List<StudentDAO> GetEnrolledStudents(int sessionId)
        {
            List<StudentDAO> studentList = new List<StudentDAO>();
            studentList = regDataClient.ListEnrolledStudents(sessionId).ToList();

            return studentList;
        }
    }
}
