using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.model;

namespace CourierManagementSystem.entity
{
    public class CourierCompany
    {
        public string CompanyName { get; set; }
        public List<Courier> CourierDetails { get; set; }
        public List<Employee> EmployeeDetails { get; set; }
        public List<Location> LocationDetails { get; set; }

        public CourierCompany(string companyName)
        {
            CompanyName = companyName;
            CourierDetails = new List<Courier>();
            EmployeeDetails = new List<Employee>();
            LocationDetails = new List<Location>();
        }

     

    }
}
