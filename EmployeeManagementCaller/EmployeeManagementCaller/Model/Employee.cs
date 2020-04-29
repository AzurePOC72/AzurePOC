using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EmployeeManagementCaller.Model
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpId { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
