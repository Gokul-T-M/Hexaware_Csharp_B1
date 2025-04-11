﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DigitalAssetManagentSystem.util
{
    static class DBPropertyUtil
    {
        public static string getConnectionString(string filename)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(filename);
            IConfiguration config = builder.Build();

            string conStr = config.GetConnectionString("DefaultConnection");
            
            return conStr;
        }
    }
}
