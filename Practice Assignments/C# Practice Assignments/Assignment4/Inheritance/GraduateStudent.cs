using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class GraduateStudent : Student
    {
        public GraduateStudent(int rollNo, string name, string studentClass, int semester, string branch) 
        : base(rollNo, name, studentClass, semester, branch)
        {

        }
        public override void DisplayDetails()
        {
            Console.WriteLine("----Displaying Details of Graduate Student----\n");
            Console.WriteLine($"Roll Number: {RollNo}");
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Class: {StudentClass}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Student Branch: {Branch}");

            // foreach (int mark in Marks)
            // {
            //     Console.WriteLine(mark + "\n");
            // }
        }
    }
}
