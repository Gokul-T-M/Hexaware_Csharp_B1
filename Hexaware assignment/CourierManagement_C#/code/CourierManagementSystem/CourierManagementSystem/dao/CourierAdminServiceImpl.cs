using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.exceptions;
using CourierManagementSystem.model;
using CourierManagementSystem.util;
using Microsoft.Data.SqlClient;


namespace CourierManagementSystem.dao
{
    class CourierAdminServiceImpl:CourierUserServiceImpl,ICourierAdminService
    {
        private SqlConnection con;
        public int AddCourierStaff(Employee obj)
        {
            con = DBConnUtil.GetConnection("appsettings.json");

            SqlCommand cmd = new SqlCommand("insert into tblEmployee values(@EmployeeID,@EmployeeName,@EmployeeEmail," +
                "@EmployeeContact,@EmployeeRole,@EmployeeSalary)", con);

            cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
            cmd.Parameters.AddWithValue("@EmployeeName", obj.EmployeeName);
            cmd.Parameters.AddWithValue("@EmployeeEmail", obj.EmployeeEmail);
            cmd.Parameters.AddWithValue("@EmployeeContact", obj.EmployeeContact);
            cmd.Parameters.AddWithValue("@EmployeeRole", obj.EmployeeRole);
            cmd.Parameters.AddWithValue("@EmployeeSalary", obj.EmployeeSalary);

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            if(rows==0)
            {
                Console.WriteLine("Cannot Add Employee");
                return -1;
            }
            
            return obj.EmployeeID;
        }

        

    }
}
