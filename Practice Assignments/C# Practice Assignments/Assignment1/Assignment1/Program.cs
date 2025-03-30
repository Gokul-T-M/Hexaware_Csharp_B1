namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool Flag = true;

            while (Flag)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("Please choose a Question Number: ");
                Console.WriteLine();
                Console.WriteLine("1.Write a C# Sharp program to accept two integers and check whether they are equal or not.");
                Console.WriteLine("2. Write a C# Sharp program to check whether a given number is positive or negative.");
                Console.WriteLine("3. Write a C# Sharp program that takes two numbers as input and performs all operations (+,-,*,/) on them and displays the result of that operation.");
                Console.WriteLine("4. Write a C# Sharp program that prints the multiplication table of a number as input.");
                Console.WriteLine("5.  Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.");
                Console.WriteLine("6. Exit");
                Console.WriteLine();


                if(!int.TryParse(Console.ReadLine(), out int Choice))
                {
                    Console.WriteLine("---- Please enter a valid number between 1 and 6 ----");
                    continue;
                }

                switch (Choice)
                {
                    case 1:
                        CheckEqual();
                        break;

                    case 2:
                        CheckPositive();
                        break;

                    case 3:
                        Operations();
                        break;

                    case 4:
                        MultiplicationTable();
                        break;

                    case 5:
                        CustomSum();
                        break;

                    case 6:
                        Flag = false;
                        break;

                    default:
                        Console.WriteLine("Please enter appropriate Question number");
                        break;

                    }
                }

                static void CheckEqual()
                {
                    Console.WriteLine("Enter First number A: ");
                    int A = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Second number B: ");
                    int B = Convert.ToInt32(Console.ReadLine());

                    if (A == B)
                    {
                        Console.WriteLine($"{A} and {B} are Equal");
                    }
                    else Console.WriteLine($"{A} and {B} are Not Equal");

                }


                static void CheckPositive()
                {
                    Console.WriteLine("Enter a Number: ");
                    int A = Convert.ToInt32(Console.ReadLine());

                    if (A > 0)
                    {
                        Console.WriteLine($"{A} is Positive");
                    }
                    else if (A == 0)
                    {
                    Console.WriteLine($"{A} is Neither Positive nor Negative");
                    } 
                    else Console.WriteLine($"{A} is Negative");
                }


                static void Operations()
                {
                    Console.WriteLine("Enter Number A: ");
                    int A = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Operator: ");
                    char Operator = Convert.ToChar(Console.ReadLine());

                    Console.WriteLine("Enter Number B: ");
                    int B = Convert.ToInt32(Console.ReadLine());

                    switch (Operator)
                    {
                        case '+':
                            Console.WriteLine($"sum of {A} and {B} is: {A + B}");
                            break;

                        case '-':
                            Console.WriteLine($"sum of {A} and {B} is: {A - B}");
                            break;

                        case '*':
                            Console.WriteLine($"sum of {A} and {B} is: {A * B}");
                            break;

                        case '/':
                            Console.WriteLine($"sum of {A} and {B} is: {A / B}");
                            break;

                        default:
                            Console.WriteLine("Please Enter a Valid Operator");
                            break;
                    }
                }


                static void MultiplicationTable()
                {

                    Console.WriteLine("Enter the Number to be Multiplied");
                    int Num = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the number of times to be multiplied:");
                    int NumOfTimes = Convert.ToInt32(Console.ReadLine());

                    for (int i = 1; i <= NumOfTimes; i++)
                    {
                        Console.WriteLine($"{i}*{Num} = {i * Num}");
                    }

                }

                static void CustomSum()
                {
                    Console.WriteLine("Enter number A: ");
                    int A = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter number B: ");
                    int B = Convert.ToInt32(Console.ReadLine());

                    if (A == B) Console.WriteLine($"The custom Sum of {A} and {B} is: {(A + B) * 3}");
                    else Console.WriteLine($"The Custom Sum of {A} and {B} is: {A + B}");

                }


        }


    }
}
