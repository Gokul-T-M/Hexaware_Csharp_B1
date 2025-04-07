using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.model
{
    public class CourierServices
    {
        public int ServiceID { get; set; }
        public string? ServiceName {get;set;}
        public decimal? ServiceCost { get; set; }

        public CourierServices(int serviceID, string? serviceName, decimal? serviceCost)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServiceCost = serviceCost;
        }
    }
}
