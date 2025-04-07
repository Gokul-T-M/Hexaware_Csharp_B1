using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace CourierManagementSystem.util
{
    static class DBConnUtil
    {
        public static SqlConnection? GetConnection(string fileName)
        {
            try
            {
                string? conString = DBPropertyUtil.GetConnectionString(fileName);
                return new SqlConnection(conString);
            }
            catch(InvalidOperationException e) 
            {
                Console.WriteLine("Cannot create connection object " + e.Message);
                return null;
            }
            
            
        }
    }
}
