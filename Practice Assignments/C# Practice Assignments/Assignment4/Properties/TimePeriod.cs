using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class TimePeriod
    {
        private double seconds=3600+1800;

        public double Hours
        {
            get { return seconds / 3600; }
            set { seconds = value * 3600;  } 
        }
    }
}
