using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.exceptions
{
    class TrackingNumberNotFoundException : Exception
    {
        public TrackingNumberNotFoundException(string msg) : base(msg) { }
    }
}
