namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Chair chair1 = new Chair("Brown", 12.5, "Foam");
            BookShelf shelf1 = new BookShelf("White", 30.0, "Teak");

            chair1.OrderDetails();
            shelf1.OrderDetails();
        }
    }
}
