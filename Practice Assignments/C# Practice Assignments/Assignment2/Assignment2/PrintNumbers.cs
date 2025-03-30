using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class PrintNumbers
    {
        public static void Execute()
        {
            Console.WriteLine("Enter a Digit for Printing the Pattern");
            int digit = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <=1; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}",digit);
                Console.WriteLine("{0}{0}{0}{0}", digit);
            }
        } 
    }
}
