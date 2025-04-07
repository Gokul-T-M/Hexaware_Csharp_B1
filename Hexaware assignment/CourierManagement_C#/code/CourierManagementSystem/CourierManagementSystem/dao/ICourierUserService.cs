using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.model;

namespace CourierManagementSystem.dao
{
    interface ICourierUserService
    {
        public string PlaceOrder(Courier courier);
        public string GetOrderStatus(string trackingNumber);
        public bool CancelOrder(string trackingNumber);

        public List<Courier> GetAssignedOrder(int employeeId);

        public List<Courier> RetrieveDeliveryHistory(string trackingNumber);

        public Dictionary<int, decimal> GenerateRevenueReportByLocationId();

    }


}
