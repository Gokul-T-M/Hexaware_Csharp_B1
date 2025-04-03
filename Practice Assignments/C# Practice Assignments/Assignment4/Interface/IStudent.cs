using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interface
{
    interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        double Fees { get; }

        void ShowDetails();
       
    }
}
