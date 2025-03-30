using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class ArrayCopy
    {
        public static void Execute()
        {
            Console.WriteLine("Enter the Size of Array: ");
            int Size = Convert.ToInt32(Console.ReadLine());

            int[] originalArray = new int[Size];
            int[] copyArray = new int[Size];

            for(int i = 0; i < Size; i++)
            {
                Console.WriteLine($"Enter element to be inserted at index {i} :");
                originalArray[i] = Convert.ToInt32(Console.ReadLine());

            }

            for (int i = 0; i < copyArray.Length; i++)
            {
                copyArray[i] = originalArray[i];
            }

            Console.WriteLine("The copied array is: ");
            
            for(int i = 0;i<copyArray.Length;i++)
            {
                Console.Write(copyArray[i]+" ");
            }


        }
    }
}
