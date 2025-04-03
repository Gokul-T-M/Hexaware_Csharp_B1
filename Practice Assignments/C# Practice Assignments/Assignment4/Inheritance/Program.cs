namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(101,"Gokul","10rd Standard",2,"Bio-Math");
            student.DisplayDetails();
            student.GetMarks();
            student.DisplayResult();

            GraduateStudent graduateStudent = new GraduateStudent(1001,"Rahul","3rd year ECE-B",6,"ECE");
            graduateStudent.DisplayDetails();
            graduateStudent.GetMarks();
            graduateStudent.DisplayResult();

        }

    }
}
