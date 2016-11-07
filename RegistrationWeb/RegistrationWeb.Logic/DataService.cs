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

    }
}
