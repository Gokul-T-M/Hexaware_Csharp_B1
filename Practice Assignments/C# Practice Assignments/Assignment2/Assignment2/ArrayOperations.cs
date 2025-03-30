using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class ArrayOperations
    {

        public static void Execute()
        {
            Console.WriteLine("\nEnter the Size of Array: ");
            int Size = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[Size];
            int sum=0;
            int minElement = int.MaxValue;
            int maxElement = int.MinValue;

            Console.WriteLine("\nPlease Enter the values of Array Elements: ");

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
                sum += array[i];
                if(array[i] < minElement)minElement = array[i];
                if (array[i] > maxElement)maxElement = array[i];
            }

            Console.WriteLine("The Average of all elements in array is: {0}",sum/array.Length);
            Console.WriteLine("The Minimum element in the array is: {0}",minElement);
            Console.WriteLine("The Maximum element in the array is: {0}", maxElement);



        }
    }
}
