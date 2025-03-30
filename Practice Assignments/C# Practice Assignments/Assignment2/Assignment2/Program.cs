namespace Assignment2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Swap Numbers");
            Console.WriteLine("2. Print Number Four Times");
            Console.WriteLine("3. Find Day from Number");
            Console.WriteLine("4. Array Operations");
            Console.WriteLine("5. Marks Processing");
            Console.WriteLine("6. Copy Array");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SwapNumbers.Execute();
                    break;
                case 2:
                    PrintNumbers.Execute();
                    break;
                case 3:
                    DayFinder.Execute();
                    break;
                case 4:
                    ArrayOperations.Execute();
                    break;
                case 5:
                    MarksProcessing.Execute();
                    break;
                case 6:
                    ArrayCopy.Execute();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

}
