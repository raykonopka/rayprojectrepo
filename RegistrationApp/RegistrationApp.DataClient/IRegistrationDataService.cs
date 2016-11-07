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

    [ServiceContract]
    public interface IRegistrationDataService
    {

        [OperationContract]
        List<StudentDAO> GetStudents();
    }

}
