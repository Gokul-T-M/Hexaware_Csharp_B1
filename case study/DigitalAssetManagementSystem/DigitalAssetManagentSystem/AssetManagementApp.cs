using DigitalAssetManagentSystem.dao;
using DigitalAssetManagentSystem.exceptions;
using DigitalAssetManagentSystem.model;
using Microsoft.IdentityModel.Tokens;

namespace DigitalAssetManagentSystem
{
    internal class AssetManagementApp
    {
        static IAssetManagementService service = new AssetManagementServiceImpl();

        static void Main(string[] args)
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("\n==== Digital Asset Management System ====");
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("2. Update Asset");
                Console.WriteLine("3. Delete Asset");
                Console.WriteLine("4. Allocate Asset");
                Console.WriteLine("5. Deallocate Asset");
                Console.WriteLine("6. Perform Maintenance");
                Console.WriteLine("7. Reserve Asset");
                Console.WriteLine("8. Withdraw Reservation");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: 
                        AddAsset();
                        break;

                    case 2:
                        UpdateAsset(); 
                        break;

                    case 3: 
                        DeleteAsset(); 
                        break;

                    case 4:
                        AllocateAsset(); 
                        break;

                    case 5:
                        DeAllocateAsset(); 
                        break;

                    case 6:
                        PerformMaintenance(); 
                        break;

                    case 7:
                        ReserveAsset(); 
                        break;

                    case 8:
                        WithdrawReservation(); 
                        break;

                    case 9:
                        Console.WriteLine("Exit...");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.Please enter a valid choice in(1 - 9)");
                        break;
                }
            }
        }
        
      
      
        static void AddAsset()
        {
            Console.Write("Asset Name: ");
            string assetName = Console.ReadLine();
            Console.Write("Asset Type: ");
            string assetType = Console.ReadLine();
            Console.Write("Serial Number: ");
            string serialNumber = Console.ReadLine();
            Console.Write("Purchase Date (yyyy-mm-dd): ");
            DateTime purchaseDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Asset Location: ");
            string assetLocation = Console.ReadLine();
            Console.Write("Asset Status: ");
            string assetStatus = Console.ReadLine();
            Console.Write("Owner ID: ");
            int ownerId = Convert.ToInt32(Console.ReadLine());

            Asset asset = new Asset(assetName, assetType, serialNumber, purchaseDate, assetLocation, assetStatus, ownerId);
            Console.WriteLine(service.AddAsset(asset) ? "Asset added." : "Failed to add asset.");

        }

        static void UpdateAsset()
        {
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Asset Name: ");
            string assetName = Console.ReadLine();
            Console.Write("Asset Type: ");
            string assetType = Console.ReadLine();
            Console.Write("Serial Number: ");
            string serialNumber = Console.ReadLine();
            Console.Write("Purchase Date (yyyy-mm-dd): ");
            DateTime purchaseDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Asset Location: ");
            string assetLocation = Console.ReadLine();
            Console.Write("Asset Status: ");
            string assetStatus = Console.ReadLine();
            Console.Write("Owner ID: ");
            int ownerId = Convert.ToInt32(Console.ReadLine());

            Asset asset = new Asset(assetId, assetName, assetType, serialNumber, purchaseDate, assetLocation, assetStatus, ownerId);
            Console.WriteLine(service.UpdateAsset(asset) ? "Asset updated." : "Failed to update asset.");
        }

        static void DeleteAsset()
        {
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            try
            {
                service.DeleteAsset(assetId);
                Console.WriteLine("Asset deleted.");
            }
            catch (AssetNotFoundException ex)
            {
                Console.WriteLine(ex.Message); 
            }

        }

        static void AllocateAsset()
        {
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Allocation Date (yyyy-mm-dd): ");
            string allocationDate = Console.ReadLine();


            Console.WriteLine(service.AllocateAsset(assetId, employeeId, allocationDate) ? "Allocated." : "Allocation failed.");
        }

        static void DeAllocateAsset()
        {
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Return Date (yyyy-mm-dd): ");
            string returnDate = Console.ReadLine();

            Console.WriteLine(service.DeAllocateAsset(assetId, employeeId, returnDate) ? "Deallocated." : "Failed.");
        }

        static void PerformMaintenance()
        {
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Maintenance Date (yyyy-mm-dd): ");
            string date = Console.ReadLine();
            Console.Write("Description: ");
            string? description = Console.ReadLine();
            Console.Write("Cost: ");
            string? maintenanceCost = Console.ReadLine();
            double cost =(String.IsNullOrEmpty(maintenanceCost))? 0: Convert.ToDouble(maintenanceCost);

            Console.WriteLine(service.PerformMaintenance(assetId, date, description, cost) ? "Maintenance recorded." : "Failed.");
        }

        static void ReserveAsset()
        {
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Reservation Date (yyyy-mm-dd): ");
            string reservationDate = Console.ReadLine();
            Console.Write("Start Date (yyyy-mm-dd): ");
            string startDate = Console.ReadLine();
            Console.Write("End Date (yyyy-mm-dd): ");
            string endDate = Console.ReadLine();

            Console.WriteLine(service.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate) ? "Reserved." : "Failed.");
        }

        static void WithdrawReservation()
        {
            Console.Write("Reservation ID: ");
            int reservationId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(service.WithdrawReservation(reservationId) ? "Withdrawn." : "Failed.");
        }
    }
}
