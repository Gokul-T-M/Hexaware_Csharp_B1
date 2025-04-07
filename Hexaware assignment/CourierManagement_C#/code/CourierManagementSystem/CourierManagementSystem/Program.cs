using CourierManagementSystem.dao;
using CourierManagementSystem.exceptions;
using CourierManagementSystem.model;

namespace CourierManagementSystem
{
    internal class Program
    {

        private ICourierUserService _userService = new CourierUserServiceImpl();
        private ICourierAdminService _adminService = new CourierAdminServiceImpl();


        static void Main(string[] args)
        {
            Program program = new Program();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n==== Courier Management System ====");
                Console.WriteLine("1. Place a Courier Order");
                Console.WriteLine("2. Track Courier Status");
                Console.WriteLine("3. Cancel a Courier Order");
                Console.WriteLine("4. Add Courier Staff");
                Console.WriteLine("5. View Assigned Orders for Employee");
                Console.WriteLine("6. Retrieve Delivery History by Tracking Number");
                Console.WriteLine("7. Generate Revenue Report by Location ID");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        program.PlaceOrder();
                        break;
                    case "2":
                        program.GetOrderStatus();
                        break;
                    case "3":
                        program.CancelOrder();
                        break;
                    case "4":
                        program.AddCourierStaff();
                        break;
                    case "5":
                        program.GetAssignedOrders();
                        break;
                    case "6":
                        program.RetrieveDeliveryHistory();
                        break;
                    case "7":
                        program.GenerateRevenueReportByLocationId();
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Exiting the system. Thank you!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }



        private void PlaceOrder()
        {
            Console.WriteLine("Enter CourierId: ");
            int courierId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter sender name:");
            string? senderName = Console.ReadLine();

            Console.WriteLine("Enter sender address:");
            string? senderAddress = Console.ReadLine();

            Console.WriteLine("Enter receiver name:");
            string? receiverName = Console.ReadLine();

            Console.WriteLine("Enter receiver address:");
            string? receiverAddress = Console.ReadLine();

            Console.WriteLine("Enter weight:");
            decimal courierWeight = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter status:");
            string? courierStatus = Console.ReadLine();

            Console.WriteLine("Enter Tracking Number:");
            string? trackingNumber = Console.ReadLine();

            Console.WriteLine("Enter delivery date (yyyy-mm-dd):");
            DateTime deliveryDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter user ID:");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter employee Id");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            

            Console.WriteLine("Enter service Id");
            int serviceId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter location ID:");
            int locationId = Convert.ToInt32(Console.ReadLine());

            Courier courier = new Courier(courierId, senderName, senderAddress, receiverName, receiverAddress, courierWeight, courierStatus, trackingNumber, deliveryDate, userId, employeeId, serviceId, locationId);


            Console.WriteLine(_userService.PlaceOrder(courier));

        }

        private void GetOrderStatus()
        {
            Console.WriteLine("Enter the Tracking number to retrieve Courier Status: ");
            String trackingNumber = Console.ReadLine();

            try
            {
                string orderStatus = _userService.GetOrderStatus(trackingNumber);
                Console.WriteLine($"The Order status for Tracking number: {trackingNumber} is: {orderStatus}");
            }
            catch (TrackingNumberNotFoundException te)
            {
                Console.WriteLine(te.Message);
            }
   
        }

        private void CancelOrder()
        {
            Console.WriteLine("Enter the tracking number for cancelling the order: ");
            string trackingNumber = Console.ReadLine();
            try
            {
                if(_userService.CancelOrder(trackingNumber))Console.WriteLine("The Order is Cancelled! ");
            }
            catch(TrackingNumberNotFoundException te)
            {
                Console.WriteLine(te.Message);
            }

        }

        private void AddCourierStaff()
        {
            Console.WriteLine("Enter the EmployeeId: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Employee Name: ");
            string? employeeName = Console.ReadLine();

            Console.WriteLine("Enter the Employee email: ");
            string? employeeEmail = Console.ReadLine();

            Console.WriteLine("Enter the Employee Contact: ");
            string? employeeContact = Console.ReadLine();

            Console.WriteLine("Enter the Employee Role: ");
            string? employeeRole = Console.ReadLine();

            Console.WriteLine("Enter the Employee Salary: ");
            decimal employeeSalary = Convert.ToDecimal(Console.ReadLine());

            Employee e = new Employee(employeeId, employeeName, employeeEmail, employeeContact, employeeRole, employeeSalary);

            int EmployeeId = _adminService.AddCourierStaff(e);

            if(EmployeeId!=-1)Console.WriteLine($"Courier Staff of EmployeeID {EmployeeId} added successfully");

        }

        private void GetAssignedOrders()
        {
            Console.WriteLine("Enter the Employee Id to List orders assigned: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            try
            {
                List<Courier> assignedOrders = _userService.GetAssignedOrder(employeeId);

                foreach (var assignedOrder in assignedOrders)
                {
                    Console.WriteLine("CourierID : " + assignedOrder.CourierID + " SenderName : " + assignedOrder.SenderName + " ReceiverName : " + assignedOrder.ReceiverName + " EmployeeID : " + assignedOrder.EmployeeID);
                }
            }
            catch(InvalidEmployeeIDException ieid)
            {
                Console.WriteLine(ieid.Message);
            }
            
            
        }

        private void RetrieveDeliveryHistory()
        {
            try 
            { 
                Console.WriteLine("Enter the Tracking Number to view delivery history: ");
                string trackingNumber = Console.ReadLine();

           
                List<Courier> historyList = _userService.RetrieveDeliveryHistory(trackingNumber);

                foreach (var courier in historyList)
                {
                    Console.WriteLine("CourierID: " + courier.CourierID +
                                      " SenderName: " + courier.SenderName +
                                      " ReceiverName: " + courier.ReceiverName +
                                      " Status: " + courier.CourierStatus +
                                      " DeliveryDate: " + courier.DeliveryDate);
                }
            }
            catch (TrackingNumberNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GenerateRevenueReportByLocationId()
        {
            Dictionary<int, decimal> revenueReport = _userService.GenerateRevenueReportByLocationId();

            Console.WriteLine("\n--- Revenue by Location ID ---");
            foreach (var entry in revenueReport)
            {
                Console.WriteLine($"Location ID: {entry.Key}, Revenue: {entry.Value}");
            }
        }




    }
}
