namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IStudent dayScholar = new DayScholar(101, "Alice", 15000);
            IStudent resident = new Resident(102, "Bob", 15000, 5000);


            dayScholar.ShowDetails();
            resident.ShowDetails();
        }
    }
}
