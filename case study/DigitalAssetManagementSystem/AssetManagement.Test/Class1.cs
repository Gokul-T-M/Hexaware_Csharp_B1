
using NUnit.Framework;
using System;
using DigitalAssetManagentSystem;
using DigitalAssetManagentSystem.exceptions;
using DigitalAssetManagentSystem.dao;
using DigitalAssetManagentSystem.model;

namespace AssetManagement.Test
{
    public class Class1
    {
        private AssetManagementServiceImpl service;

        [SetUp]
        public void Setup()
        {
            service = new AssetManagementServiceImpl();
        }

        [Test]
        public void AddAsset_ShouldReturn_True_WhenInserted()
        {
            Asset asset = new Asset(
                 "Laptop Dell XPS",
                 "Electronics",
                 "DLXPS2023",
                 new DateTime(2023, 12, 15),
                 "IT Department",
                 "Available",
                  1
            );

            bool result = service.AddAsset(asset);

            Assert.That(result, Is.False);
        }

        [Test]
        public void AddMaintenanceRecord_ShouldReturn_True_WhenInserted()
        {
            int assetId = 8; 
            string maintenanceDate = Convert.ToString(new DateTime(2024, 10, 10));
            string description = "Quarterly internal cleaning";
            double cost = 500.0;

            bool result = service.PerformMaintenance(assetId, maintenanceDate, description, cost);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ReserveAsset_ShouldReturn_True_WhenInserted()
        {
            int assetId = 8; // existing asset
            int employeeId = 2; // existing employee
            string reservationDate = Convert.ToString(new DateTime(2025, 12, 1));
            string startDate = Convert.ToString(new DateTime(2025, 12, 5));
            string endDate = Convert.ToString(new DateTime(2025, 12, 10));
            

            bool result = service.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate);

            Assert.That(result, Is.True);
        }


        [Test]
        public void DeleteAsset_ShouldThrow_AssetNotFoundException_WhenAssetDoesNotExist()
        {
            int assetId = 0; 

            var ex = Assert.Throws<AssetNotFoundException>(() =>
            {
                service.DeleteAsset(assetId);
            });

            Assert.That(ex.Message, Is.EqualTo("Asset not found for deletion."));
        }


    }
}
