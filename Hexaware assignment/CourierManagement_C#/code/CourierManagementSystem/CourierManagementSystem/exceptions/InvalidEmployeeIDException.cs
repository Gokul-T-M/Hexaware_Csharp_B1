using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.exceptions
{
    class InvalidEmployeeIDException:Exception
    {
        public InvalidEmployeeIDException(string msg) : base(msg) { }

    }
}
