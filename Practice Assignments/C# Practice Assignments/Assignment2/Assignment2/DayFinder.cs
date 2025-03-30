using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    enum Days
    {
        sunday = 1,
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday
    }
    class DayFinder
    {
        public static void Execute()
        {
            Console.WriteLine("Please enter the Day Number");
            int dayNumber = Convert.ToInt32(Console.ReadLine());

            if (Enum.IsDefined(typeof(Days), dayNumber)) 
            {
                Console.WriteLine($"The Day is {(Days)dayNumber}");
            }
            else
            {
                Console.WriteLine("Please enter a valid day number between 1 to 7");
            }
        }
    }
}
