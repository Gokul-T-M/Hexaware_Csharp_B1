using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Chair : Furniture
    {
        private string _cushionType;

        public Chair(string color, double weight, string cushionType) : base(color, weight)
        {
            _cushionType = cushionType;
        }
        public override void OrderDetails()
        {
            Console.WriteLine($"\n----Chair Details----\nWeight: {Weight}\nColor: {Color}\ncushion type: {_cushionType}");
        }
    }
}
