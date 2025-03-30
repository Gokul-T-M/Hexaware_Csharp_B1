using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class SwapNumbers
    {
        public static void Execute()
        {
            Console.WriteLine("---- Program to Swap Two Numbers ----\n");

            Console.WriteLine("Enter First number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter Second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nThe entered Numbers are:");
            Console.WriteLine($"num1: {num1} \nnum2: {num2}");

            Swap(ref num1, ref num2);

            Console.WriteLine("\nThe Swapped Numbers are:");
            Console.WriteLine($"num1: {num1} \nnum2: {num2}");
        }

        public static void Swap(ref int num1, ref int num2)
        {
            int tempNum;
            tempNum = num1;
            num1 = num2;
            num2 = tempNum;

            Console.WriteLine("\nNumbers in num 1 and num 2 are Swapped");
        }

    }
}
