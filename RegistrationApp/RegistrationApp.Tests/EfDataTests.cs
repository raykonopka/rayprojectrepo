using RegistrationApp.DataAccess;
using RegistrationApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RegistrationApp.Tests
{

    public class EfDataTests
    {
        #region Student Tests
        [Fact]
        public void Test_RegisterStudent()
        {
            var data = new EfData();
            int studentIdToRegister = 1;
            int sessionId = 1;

            //Make sure student is not already registered.
            data.DropFromSession(studentIdToRegister, sessionId);

            var actual = data.RegisterStudent(studentIdToRegister, sessionId);
            Assert.True(actual);

            //Remove any test data
            data.DropFromSession(studentIdToRegister, sessionId);
        }


        [Fact]
        public void Test_DropFromSession()
        {
            var data = new EfData();
            int studentIdToDrop = 1;
            int sessionId = 1;

            //Make sure student is already registered.
            data.RegisterStudent(studentIdToDrop, sessionId);

            var actual = data.DropFromSession(studentIdToDrop, sessionId);
            Assert.True(actual);
        }


        [Fact]
        public void Test_AddCourseBookmark()
        {
            var data = new EfData();
            int bookmarkStudentId = 1;
            int bookmarkSessionId = 1;

            var actual = data.AddCourseBookmark(bookmarkStudentId, bookmarkSessionId);
            Assert.True(actual);

            //Remove test data
            CourseBookmark bookmarkToRemove = new CourseBookmark { studentId = bookmarkStudentId, courseSessionId = bookmarkSessionId };
            data.RemoveCourseBookmark(bookmarkToRemove);
        }


        [Fact]
        public void Test_RemoveCourseBookmark()
        {
            var data = new EfData();
            int bookmarkStudentId = 1;
            int bookmarkSessionId = 1;

            //Add test bookmark
            data.AddCourseBookmark(bookmarkStudentId, bookmarkSessionId);

            CourseBookmark bookmarkToRemove = new CourseBookmark { studentId = bookmarkStudentId, courseSessionId = bookmarkSessionId };
            var actual = data.RemoveCourseBookmark(bookmarkToRemove);

            Assert.True(actual);
        }
        #endregion


        #region Course Tests
        [Fact]
        public void Test_CancelCourse()
        {
            var data = new EfData();
            Course courseToCancel = new Course { Title = "Analysis of Algorithms", Credits = 3, DepartmentId = 1 };

            //Add test course
            data.InsertCourse(courseToCancel);

            var actual = data.CancelCourse(courseToCancel);
            Assert.True(actual);
        }


        [Fact]
        public void Test_UpdateSessionTime()
        {
            var data = new EfData();
            TimeSpan startTime = new TimeSpan(0, 15, 25, 00);
            TimeSpan endTime = new TimeSpan(0, 17, 00, 00);
            CourseSession sessionToUpdate = new CourseSession { CourseId = 1, Professor = "Bob Smith", Capacity = 40, DaysInSession = "TH", StartTime = startTime, EndTime = endTime };

            //Add test session
            data.InsertSession(sessionToUpdate);

            TimeSpan newStartTime = new TimeSpan(0, 10, 45, 00);
            TimeSpan newEndTime = new TimeSpan(0, 12, 00, 00);
            var actual = data.UpdateSessionTime(newStartTime, newEndTime, sessionToUpdate.Id);

            Assert.True(actual);

            //Remove any test data
            data.RemoveSession(sessionToUpdate);
        }


        [Fact]
        public void Test_UpdateSessionCapacity()
        {
            var data = new EfData();
            TimeSpan startTime = new TimeSpan(0, 15, 25, 00);
            TimeSpan endTime = new TimeSpan(0, 17, 00, 00);
            CourseSession sessionToUpdate = new CourseSession { CourseId = 1, Professor = "Bob Smith", Capacity = 40, DaysInSession = "TH", StartTime = startTime, EndTime = endTime };

            //Add test session
            data.InsertSession(sessionToUpdate);

            int updatedCapacity = 50;
            var actual = data.UpdateSessionCapacity(updatedCapacity, sessionToUpdate.Id);

            Assert.True(actual);

            //Remove any test data
            data.RemoveSession(sessionToUpdate);
        }
        #endregion

    }
}
