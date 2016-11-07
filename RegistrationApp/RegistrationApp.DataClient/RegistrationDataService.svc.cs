using RegistrationApp.DataAccess;
using RegistrationApp.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegistrationApp.DataClient
{
    public class RegistrationDataService : IRegistrationDataService
    {
        private EfData db = new EfData();

        public List<StudentDAO> GetStudents()
        {
            var students = new List<StudentDAO>();

            foreach (var st in db.GetStudents())
            {
                students.Add(DataMapper.MapToStudentDAO(st));
            }

            return students;
        }

    }
}
