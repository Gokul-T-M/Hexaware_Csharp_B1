using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagentSystem.model
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string AssetLocation { get; set; }
        public string AssetStatus { get; set; }
        public int OwnerId { get; set; }

        public Asset() { }

        public Asset(string assetName, string assetType, string serialNumber, DateTime purchaseDate, string assetLocation, string assetStatus, int ownerId)
        {
            AssetName = assetName;
            AssetType = assetType;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            AssetLocation = assetLocation;
            AssetStatus = assetStatus;
            OwnerId = ownerId;
        }

        public Asset(int assetId, string assetName, string assetType, string serialNumber, DateTime purchaseDate, string assetLocation, string assetStatus, int ownerId)
        {
            AssetId = assetId;
            AssetName = assetName;
            AssetType = assetType;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            AssetLocation = assetLocation;
            AssetStatus = assetStatus;
            OwnerId = ownerId;
        }
    }
}
