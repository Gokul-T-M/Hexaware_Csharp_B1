using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagentSystem.model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string EmployeePassword { get; set; }

        public Employee() { }

        public Employee(string employeeName, string department, string email, string employeePassword)
        {
            EmployeeName = employeeName;
            Department = department;
            Email = email;
            EmployeePassword = employeePassword;
        }

        public Employee(int employeeId, string employeeName, string department, string email, string employeePassword)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Department = department;
            Email = email;
            EmployeePassword = employeePassword;
        }

    }
}
