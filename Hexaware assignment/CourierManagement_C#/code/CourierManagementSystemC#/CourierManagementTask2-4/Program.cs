using System.Collections;
using System.Globalization;

namespace CourierManagementTask2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Courier Management System");
            Console.WriteLine("Enter Question Number to Run (1 to 15): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Question1();
                    break;
                case 2:
                    Question2();
                    break;
                case 3:
                    Question3();
                    break;
                case 4:
                    Question4();
                    break;
                case 5:
                    Question5();
                    break;
                case 6:
                    Question6();
                    break;
                case 7:
                    Question7();
                    break;
                case 8:
                    Question8();
                    break;
                case 9:
                    Question9();
                    break;
                case 10:
                    Question10();
                    break;
                case 11:
                    Question11();
                    break;
                case 12:
                    Question12();
                    break;
                case 13:
                    Question13();
                    break;
                case 14:
                    Question14();
                    break;
                case 15:
                    Question15();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        private static void Question1()
        {
            //  Write a program that checks whether a given order is delivered or not based on its status (e.g.,
            //  "Processing," "Delivered," "Cancelled"). Use if-else statements for this.


            Console.WriteLine("Enter the order status (Processing, Delivered, Cancelled) : ");
            string? status = Console.ReadLine();

            if (status == null)
            {
                Console.WriteLine("Please Enter a valid status in (Processing,Delivered or Cancelled");

            }
            else if (status.Equals("Processing", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order is Processing and is not delivered");
            }
            else if (status.Equals("Delivered", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order is delivered");
            }
            else if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The order is Cancelled");
            }
            else
            {
                Console.WriteLine("Please Enter a Valid Status!");
            }

        }

        private static void Question2()
        {
            // 2. Implement a switch-case statement to categorize parcels based on their weight into "Light,"
            // "Medium," or "Heavy."

            Console.WriteLine("Enter the Courier Weight: ");
            double CourierWeight = Convert.ToDouble(Console.ReadLine());

            switch (CourierWeight)
            {

                case <= 0:
                    Console.WriteLine("Weight Cannot be less than Zero");
                    break;
                case <= 1.5:
                    Console.WriteLine("Light Weight");
                    break;
                case <= 2.5:
                    Console.WriteLine("Medium Weight");
                    break;
                case >= 2.5:
                    Console.WriteLine("Heavy Weight");
                    break;
                default:
                    Console.WriteLine("Please Enter Correct Value");
                    break;

            }

        }

        private static void Question3()
        {
            // 3. Implement User Authentication 1. Create a login system for employees and customers using Java
            // control flow statements.

            Dictionary<string, string> customers = new Dictionary<string, string>();
            customers.Add("gokul@gmail.com", "pass#12");

            Dictionary<string, string> employees = new Dictionary<string, string>();
            employees.Add("vignesh@gmail.com", "vicky007");

            Console.WriteLine("Choose 1 or 2: ");
            Console.WriteLine("1.User/customer");
            Console.WriteLine("2.Employee");
            string choice = Console.ReadLine();

            Console.WriteLine("Please Enter your Email ID: ");
            string emailId = Console.ReadLine();
            Console.WriteLine("Please Enter your Password ");
            string password = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    if (customers.ContainsKey(emailId) && customers[emailId] == password)
                    {
                        Console.WriteLine("Customer login successfull");
                    }
                    else
                    {
                        Console.WriteLine("invalid userId or Password");
                    }
                    break;

                case "2":

                    if (employees.ContainsKey(emailId) && employees[emailId] == password)
                    {
                        Console.WriteLine("Employee login successfull");
                    }
                    else
                    {
                        Console.WriteLine("invalid userId or Password");
                    }
                    break;

                default:
                    Console.WriteLine("Please Enter a valid Choice in(1 or 2)");
                    break;


            }

        }

        private static void Question4()
        {
            // 4. Implement Courier Assignment Logic 1. Develop a mechanism to assign couriers to shipments based
            // on predefined criteria(e.g., proximity, load capacity) using loops.

            string[] couriers = { "karthick", "Sam", "Ravi" };
            string[] areas = { "Chennai", "Mumbai", "Chennai" };
            int[] capacities = { 100, 80, 60 };
            int[] loads = { 30, 20, 50 }; 

            string shipmentArea = "Chennai";
            int shipmentWeight = 20;

            bool assigned = false;

            for (int i = 0; i < couriers.Length; i++)
            {
                if (areas[i] == shipmentArea && (loads[i] + shipmentWeight <= capacities[i]))
                {
                    Console.WriteLine($"Shipment assigned to {couriers[i]}");
                    loads[i] += shipmentWeight; 
                    assigned = true;
                    break; 
                }
            }

            if (!assigned)
                Console.WriteLine("No courier available for this shipment.");

        }

        private static void Question5()
        {
            Console.WriteLine("Enter the name of Customer:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the number of orders");
            int ordercount = int.Parse(Console.ReadLine());

            string[] orders = new string[ordercount];

            for (int i = 0; i < orders.Length; i++)
            {
                Console.Write($"Order no{i + 1}:");
                orders[i] = Console.ReadLine();
            }
            Console.WriteLine($"\nOrders for customer {name}");
            for (int i = 0; i < orders.Length; i++)
            {
                Console.WriteLine($"orders {i + 1}:{orders[i]}");
            }

        }


        private static void Question6()
        {
            int start = 1;
            int destination = 10;

            while (start <= destination)
            {
                Console.WriteLine($"The Courier has reached destination number : {start}");
                start++;
            }
        }

        private static void Question7()
        {
            List<string> location = new List<string>();
            string choice;
            string loc;

            do
            {
                Console.WriteLine("Enter current location: ");
                loc = Console.ReadLine();
                location.Add(loc);

                Console.WriteLine("Do you want to continue Adding Tracking history? (yes/No)");
                choice = Console.ReadLine();

            } while (choice == "yes");


            Console.WriteLine($"The tracking history is:");

            foreach (string item in location)
            {
                Console.WriteLine(item);
            }
        }

        private static void Question8()
        {
            int[] CourierLocation = { 10, 5, 8 };

            Console.WriteLine("Enter the location of new order to find the nearest courier location: ");
            int orderLocation = Convert.ToInt32(Console.ReadLine());

            int minIndex = -1;
            int min = int.MaxValue;

            for (int i = 0; i < CourierLocation.Length; i++)
            {
                if (Math.Abs(CourierLocation[i] - orderLocation) < min)
                {
                    min = Math.Abs(CourierLocation[i] - orderLocation);
                    minIndex = i;
                }
            }

            Console.WriteLine($"Index of nearest available Courier is: {minIndex + 1} with a distance of {min}");

        }

        private static void Question9()
        {
            string[,] parcels = {
            { "TRK123", "In Transit" },
            { "TRK456", "Out for Delivery" },
            { "TRK789", "Delivered" }
            };

            Console.Write("Enter tracking number: ");
            string input = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < parcels.GetLength(0); i++)
            {
                if (parcels[i, 0].Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Status: Parcel {parcels[i, 1]}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Tracking number not found.");
            }
        }

        private static void Question10()
        {
            Console.Write("Enter data to validate: ");
            string data = Console.ReadLine();

            Console.Write("Enter type (name/address/phone): ");
            string detail = Console.ReadLine();

            if (detail == "name")
            {
                bool valid = true;

                if (!char.IsUpper(data[0]))
                    valid = false;

                foreach (char c in data)
                {
                    if (!char.IsLetter(c))
                        valid = false;
                }

                Console.WriteLine(valid ? "Valid Name" : "Invalid Name");
            }
            else if (detail == "address")
            {
                bool valid = true;

                foreach (char c in data)
                {
                    if (!(char.IsLetterOrDigit(c) || c == ' ' || c == ','))
                        valid = false;
                }

                Console.WriteLine(valid ? "Valid Address" : "Invalid Address");
            }
            else if (detail == "phone")
            {
                bool valid = data.Length == 12 && data[3] == '-' && data[7] == '-';
                Console.WriteLine(valid ? "Valid Phone" : "Invalid Phone");
            }
            else
            {
                Console.WriteLine("Invalid type entered.");
            }
        }

        private static void Question11()
        {
            Console.Write("Enter street: ");
            string street = Console.ReadLine();

            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            Console.Write("Enter state: ");
            string state = Console.ReadLine();

            Console.Write("Enter zip code: ");
            string zip = Console.ReadLine();

            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            street = ti.ToTitleCase(street.ToLower());
            city = ti.ToTitleCase(city.ToLower());
            state = ti.ToTitleCase(state.ToLower());

            if (zip.Length == 6 && int.TryParse(zip, out _))
            {
                Console.WriteLine("\nFormatted Address:");
                Console.WriteLine($"{street}, {city}, {state} - {zip}");
            }
            else
            {
                Console.WriteLine("Invalid zip code. It should be 6 digits.");
            }
        }

        private static void Question12()
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Order Number: ");
            string orderNo = Console.ReadLine();

            Console.Write("Enter Delivery Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Expected Delivery Date (dd-mm-yyyy): ");
            string deliveryDate = Console.ReadLine();

            Console.WriteLine("\n--- Order Confirmation Email ---");
            Console.WriteLine($"Dear {name},");
            Console.WriteLine($"Your order #{orderNo} has been successfully placed.");
            Console.WriteLine($"It will be delivered to: {address}");
            Console.WriteLine($"Expected Delivery Date: {deliveryDate}");
            Console.WriteLine("Thank you for choosing our service!");
        }

        private static void calculateShippingCost(string source, string destination, int distance, double weight)
        {
            double cost = (distance * 5) + (weight * 10);

            Console.WriteLine($"\nShipping from {source} to {destination}");
            Console.WriteLine($"Total shipping cost: {cost}");
        }
        private static void Question13()
        {
            Console.Write("Enter source location: ");
            string source = Console.ReadLine();

            Console.Write("Enter destination location: ");
            string destination = Console.ReadLine();

            Console.Write("Enter distance (in km): ");
            int distance = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter weight (in kg): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            calculateShippingCost(source, destination, distance, weight);
        }


        private static string generatePassword(int length)
        {
            string digits = "0123456789";
            string special = "!@#$%^&*";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "abcdefghijklmnopqrstuvwxyz";


            string allCharacters = upper + lower + digits + special;
            Random rand = new Random();
            string password = "";

            for (int i = 0; i < length; i++)
            {
                int index = rand.Next(allCharacters.Length);
                password += allCharacters[index];
            }

            return password;
        }
        private static void Question14()
        {
            Console.Write("Enter desired password length: ");
            int length = Convert.ToInt32(Console.ReadLine());

            string password = generatePassword(length);
            Console.WriteLine("Generated Password: " + password);
        }


        private static void Question15()
        {
            List<string> addresses = new List<string>
            {
            "10 Gandhi Road",
            "22 Nehru Street",
            "22 Nehru St",
            "45 Patel Nagar",
            "78 Anna Salai",
            "91 MG Avenue",
            "91 mg ave"
            };

            for (int i = 0; i < addresses.Count; i++)
            {
                for (int j = i + 1; j < addresses.Count; j++)
                {

                    string addr1 = addresses[i].ToLower();
                    string addr2 = addresses[j].ToLower();

                    if (addr1.Contains(addr2) || addr2.Contains(addr1))
                    {
                        Console.WriteLine($"Similar addresses are :\n\n \"{addresses[i]}\" \nand\n \"{addresses[j]}\"\n");
                    }
                }
            }


        }



    }
}
