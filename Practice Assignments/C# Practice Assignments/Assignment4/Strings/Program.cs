namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StringLength();
            //StringReverse();
            IsSame();
        }

        static void StringLength()
        {
            Console.WriteLine("Enter the String to calculate its length: ");
            string ? str = Console.ReadLine();
            Console.WriteLine($"The length of {str} is : {str.Length}");
        }

        static void StringReverse()
        {
            Console.WriteLine("Enter the String to Reverse: ");
            string ? str = Console.ReadLine();

            if(str.Length == 0)
            {
                Console.WriteLine("Please enter a valid string! ");
                return;
            }
            
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(arr);
        }

        static void IsSame()
        {
            start:
            Console.WriteLine("\nEnter two words to check if they are same: ");
            string? word1= Console.ReadLine();
            string? word2= Console.ReadLine();

            if(String.IsNullOrEmpty(word1) || String.IsNullOrEmpty(word2))
            {
                Console.WriteLine("\nPlease Enter a valid string !");
                goto start;
            }

            if (word1.Equals(word2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nThe words {0} and {1} are same",word1,word2);
            }
            else
            {
                Console.WriteLine("\nThe words {0} and {1} are Not same",word1,word2);
            }
        }
    }
}
