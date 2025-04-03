using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class DayScholar : IStudent
    {
        public int StudentId { get; }
        public string Name { get; }
        public double Fees { get; }

        public DayScholar(int studentId, string name, double fees)
        {
            StudentId = studentId;
            Name = name;
            Fees = fees;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"\n----DayScholar Details----\nStudent Id: {StudentId}\nStudent Name: {Name}\nFees: {Fees}");
        }
    }
}
