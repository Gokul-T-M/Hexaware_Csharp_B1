using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class MarksProcessing
    {
        public static void Execute()
        {

            int[] array = new int[10];
            int sum = 0;
            int minElement = int.MaxValue;
            int maxElement = int.MinValue;

            Console.WriteLine("\nPlease Enter the values of Array Elements: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
                sum += array[i];
                if (array[i] < minElement) minElement = array[i];
                if (array[i] > maxElement) maxElement = array[i];
            }

            Console.WriteLine("\nThe Average of all elements in array is: {0}", sum / array.Length);
            Console.WriteLine("\nThe Minimum element in the array is: {0}", minElement);
            Console.WriteLine("\nThe Maximum element in the array is: {0}", maxElement);

            Array.Sort(array);
            Console.WriteLine("\nAscending: {0}", string.Join(',',array));
            Array.Reverse(array);
            Console.WriteLine("\nDescending: "+ string.Join(',',array));

        }
    }
}
