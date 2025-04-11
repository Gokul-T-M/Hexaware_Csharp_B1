using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalAssetManagentSystem.model;

namespace DigitalAssetManagentSystem.dao
{
    public interface IAssetManagementService
    {
        bool AddAsset(Asset asset);
        bool UpdateAsset(Asset asset);
        bool DeleteAsset(int assetId);
        bool AllocateAsset(int assetId, int employeeId, string allocationDate);
        bool DeAllocateAsset(int assetId, int employeeId, string returnDate);
        bool PerformMaintenance(int assetId, string maintenanceDate, string maintenanceDescription, double cost);
        bool ReserveAsset(int assetId, int employeeId, string reservationDate, string reservationStartDate, string reservationEndDate);
        bool WithdrawReservation(int reservationId);

    }
}
