using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Resident : IStudent
    {
        public int StudentId { get; }
        public string Name { get; }
        public double Fees { get; }
        
        public double AccomodationFees { get; }

        public Resident(int studentId,string name,double fees,double accomodationFees)
        {
            StudentId = studentId;
            Name = name;
            Fees = fees;
            AccomodationFees = accomodationFees;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"\n----Resident Details----\nStudent Id: {StudentId}\nStudent Name: {Name}\nFees: {Fees}\nAccomodation Fees: {AccomodationFees}");
        }

    }
}
