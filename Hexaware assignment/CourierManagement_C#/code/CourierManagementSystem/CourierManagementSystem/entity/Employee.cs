using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.model
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? EmployeeContact { get; set; } 
        public string? EmployeeRole { get; set; }
        public decimal EmployeeSalary { get; set; }

        public Employee(int employeeId, string? employeeName, string? employeeEmail, string? employeeContact, string? employeeRole, decimal employeeSalary)
        {
            EmployeeID = employeeId;
            EmployeeName = employeeName;
            EmployeeEmail = employeeEmail;
            EmployeeContact = employeeContact;
            EmployeeRole = employeeRole;
            EmployeeSalary = employeeSalary;
        }

        public override string ToString()
        {
            return $"Employee ID: {EmployeeID}, " +
                   $"Name: {EmployeeName}, " +
                   $"Email: {EmployeeEmail}, " +
                   $"Contact: {EmployeeContact}, " +
                   $"Role: {EmployeeRole}, " +
                   $"Salary: {EmployeeSalary}";
        }


    }


}
