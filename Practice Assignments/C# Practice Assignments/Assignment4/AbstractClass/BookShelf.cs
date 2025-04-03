using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class BookShelf : Furniture
    {
        private string _woodType;

        public BookShelf(string color,double weight,string woodType) : base(color,weight)
        {
            _woodType = woodType;
        }
        public override void OrderDetails()
        {
            Console.WriteLine($"\n----BookShelf Details----\nWeight: {Weight}\nColor: {Color}\nwood type : {_woodType} ");
        }
    }
}
