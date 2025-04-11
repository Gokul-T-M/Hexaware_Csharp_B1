using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagentSystem.model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public string ReservationStatus { get; set; }

        public Reservation() { }

        public Reservation(int assetId, int employeeId, DateTime reservationDate, DateTime reservationStartDate, DateTime reservationEndDate, string reservationStatus)
        {
            AssetId = assetId;
            EmployeeId = employeeId;
            ReservationDate = reservationDate;
            ReservationStartDate = reservationStartDate;
            ReservationEndDate = reservationEndDate;
            ReservationStatus = reservationStatus;
        }

        public Reservation(int reservationId, int assetId, int employeeId, DateTime reservationDate, DateTime reservationStartDate, DateTime reservationEndDate, string reservationStatus)
        {
            ReservationId = reservationId;
            AssetId = assetId;
            EmployeeId = employeeId;
            ReservationDate = reservationDate;
            ReservationStartDate = reservationStartDate;
            ReservationEndDate = reservationEndDate;
            ReservationStatus = reservationStatus;
        }
    }
}
