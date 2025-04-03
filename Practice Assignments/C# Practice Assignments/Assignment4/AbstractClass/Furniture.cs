using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    abstract class Furniture
    {
        protected string Color;
        protected double Weight;

        public abstract void OrderDetails();

        public Furniture(string color, double weight)
        {
            this.Color = color;
            this.Weight = weight;
        }

    }
}
