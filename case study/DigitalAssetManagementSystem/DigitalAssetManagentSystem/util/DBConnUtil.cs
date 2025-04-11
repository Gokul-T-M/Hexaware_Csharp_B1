using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DigitalAssetManagentSystem.util
{
    static class DBConnUtil
    {
        public static SqlConnection GetConnection(string filename)
        {
            try
            {
                string? conStr = DBPropertyUtil.getConnectionString(filename);
                return new SqlConnection(conStr);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Cannot Create Connection Object: "+e.Message);
                return null;
            }

        }
    }
}
