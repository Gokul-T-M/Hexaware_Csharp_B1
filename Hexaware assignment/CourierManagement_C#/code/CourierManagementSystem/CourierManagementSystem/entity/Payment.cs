using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.model
{
    class Payment
    {
        public int PaymentID { get; set; }
        public int? CourierID { get; set; }
        public int? LocationID { get; set; }
        public int? EmployeeID { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }

        public Payment(int paymentID, int? courierID, int? locationID, int? employeeID, decimal? amount, DateTime? paymentDate)
        {
            PaymentID = paymentID;
            CourierID = courierID;
            LocationID = locationID;
            EmployeeID = employeeID;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        public override string ToString()
        {
            return $"Payment ID: {PaymentID}, " +
                   $"Courier ID: {CourierID}, " +
                   $"Location ID: {LocationID}, " +
                   $"Employee ID: {EmployeeID}, " +
                   $"Amount: {Amount}, " +
                   $"Payment Date: {PaymentDate}";
        }

    }
}
