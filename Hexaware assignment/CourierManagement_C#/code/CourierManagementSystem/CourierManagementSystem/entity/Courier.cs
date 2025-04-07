using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace CourierManagementSystem.model
{
    public class Courier
    {
        private static int _nextCourierId = 112;
        public int CourierID { get; set; }
        public string? SenderName { get; set; }
        public string? SenderAddress { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverAddress { get; set; }
        public decimal? CourierWeight { get; set; }
        public string? CourierStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime? DeliveryDate { get; set; }

        //Foreign keys
        public int? UserID { get; set; }  
        public int? EmployeeID { get; set; }
        public int? ServiceID { get; set; } 
        public int? LocationID { get; set; }

        public Courier() { }
        public Courier(int courierId,string? senderName, string? senderAddress, string? receiverName, string? receiverAddress, decimal courierWeight, string? courierStatus, string? trackingNumber, DateTime deliveryDate, int userId,int employeeId,int serviceId,int locationId)
        {
            CourierID = courierId;
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            CourierWeight = courierWeight;
            CourierStatus = courierStatus;
            TrackingNumber = trackingNumber;
            DeliveryDate = deliveryDate;
           
            UserID = userId;
            EmployeeID = employeeId;
            ServiceID = serviceId;
            LocationID = locationId;

        }

        public override string ToString()
        {
            return $"CourierID: {CourierID}\n" +
                   $"Sender Name: {SenderName}\n" +
                   $"Sender Address: {SenderAddress}\n" +
                   $"Receiver Name: {ReceiverName}\n" +
                   $"Receiver Address: {ReceiverAddress}\n" +
                   $"Courier Weight: {CourierWeight} kg\n" +
                   $"Courier Status: {CourierStatus}\n" +
                   $"Tracking Number: {TrackingNumber}\n" +
                   $"Delivery Date: {DeliveryDate?.ToString("dd-MM-yyyy")}\n" +
                   $"UserID: {UserID}\n" +
                   $"EmployeeID: {EmployeeID}\n" +
                   $"ServiceID: {ServiceID}\n" +
                   $"LocationID: {LocationID}";
        }


    }
}
