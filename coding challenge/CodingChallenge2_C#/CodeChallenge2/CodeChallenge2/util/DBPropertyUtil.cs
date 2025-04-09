using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CourierManagementSystem.util
{
    static class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(fileName);
            IConfiguration config = builder.Build();

            string conStr = config.GetConnectionString("DefaultConnection");


            return conStr;
        }
    }
}
