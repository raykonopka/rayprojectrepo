using RegistrationApp.DataAccess;
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
        public void Test_GetStudents()
        {
            var data = new EfData();
            var actual = data.GetStudents();
            Assert.NotNull(actual);
        }


        [Fact]
        public void Test_InsertStudent()
        {
            var data = new EfData();
            var expected = new Student() { StudentName = "StudentNameTest", MajorId = 1 };

            var actual = data.InsertStudent(expected);

            Assert.True(actual);
        }


        [Fact]
        public void Test_RegisterStudent()
        {
            var data = new EfData();
            int studentIdToRegister = 1;
            int courseIdToRegister = 1;
            var actual = data.registerStudent(studentIdToRegister, courseIdToRegister);

            Assert.True(actual);
        }
        #endregion
    }
}
