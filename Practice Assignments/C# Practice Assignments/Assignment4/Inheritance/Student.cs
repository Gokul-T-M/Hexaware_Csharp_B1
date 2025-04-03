using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Student
    {
        protected int RollNo;
        protected string Name;
        protected string StudentClass;
        protected int Semester;
        protected string Branch;
        protected int[] Marks = new int[5];

        public Student(int rollNo, string name, string studentClass, int semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            StudentClass = studentClass;
            Semester = semester;
            Branch = branch;
        }

        public void GetMarks()
        {
            Console.WriteLine("------Enter the marks of the Student------");

            for(int i=0;i<5;i++)
            {
                Console.Write($"Enter the marks of Stduent in subject {i+1}: ");
                Marks[i] = Convert.ToInt32(Console.ReadLine());
            }

        }

        public void DisplayResult()
        {
           
            bool failed = false;
            int sum = 0;

            for(int i=0;i<Marks.Length;i++)
            {
                if (Marks[i]<35)failed = true;break;
                sum += Marks[i];
            }

            Console.WriteLine(sum);

            Console.WriteLine("--------------Result--------------");
            if (failed) Console.WriteLine(" Failed in one or more subjects");
            else if ((sum / Marks.Length) < 50) Console.WriteLine(" Failed due to average less than 50");
            else Console.WriteLine("Passed !");
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("----Displaying Details of Student----\n");
            Console.WriteLine($"Roll Number: {RollNo}");
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Class: {StudentClass}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Student Branch: {Branch}");

            // foreach(int mark in Marks)
            // {
            //     Console.WriteLine(mark+"\n");
            // }
        }


    }
}
