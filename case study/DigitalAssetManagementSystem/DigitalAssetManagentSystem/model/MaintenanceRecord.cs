using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagentSystem.model
{
    public class MaintenanceRecord
    {
        public int MaintenanceId { get; set; }
        public int AssetId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string MaintenanceDescription { get; set; }
        public decimal? Cost { get; set; }

        public MaintenanceRecord() { }

        public MaintenanceRecord(int assetId, DateTime maintenanceDate, string maintenanceDescription, decimal? cost)
        {
            AssetId = assetId;
            MaintenanceDate = maintenanceDate;
            MaintenanceDescription = maintenanceDescription;
            Cost = cost;
        }

        public MaintenanceRecord(int maintenanceId, int assetId, DateTime maintenanceDate, string maintenanceDescription, decimal? cost)
        {
            MaintenanceId = maintenanceId;
            AssetId = assetId;
            MaintenanceDate = maintenanceDate;
            MaintenanceDescription = maintenanceDescription;
            Cost = cost;
        }
    }
}
