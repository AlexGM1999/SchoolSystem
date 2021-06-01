using System;

namespace SchoolSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("First name");
            string fName = Console.ReadLine();
            Console.WriteLine("Last name");
            string lName = Console.ReadLine();
            Console.WriteLine("Average grade");
            decimal aGrade = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Student class");
            char stClass = char.Parse(Console.ReadLine());

            Student st = new Student(fName, lName, aGrade, stClass);*/
            DBOperations operations = new DBOperations();
            // operations.CreateStudent(st);
            /*Console.WriteLine("class");
            char stClass = char.Parse(Console.ReadLine());
            Console.WriteLine("teacher name");
            string teacher = Console.ReadLine();
            SchoolClass schClass = new SchoolClass(stClass, teacher);
            DBOperations dbop = new DBOperations();
            dbop.CreateClass(schClass);*/

            /*    Console.WriteLine("Sort By Average grade of every strudent in class");
                char classID = char.Parse(Console.ReadLine());
                foreach(var l in operations.SortByAverageGrade(classID))
                {
                    Console.WriteLine(l.ToString());
                }*/
            /*      Console.WriteLine("get average grade per class");
                  char classID = char.Parse(Console.ReadLine());
                  Console.WriteLine("The average grade for Class {0} is: ",classID);
                  Console.WriteLine(operations.AverageGradePerClass(classID));*/

            /* Console.WriteLine("Select class to see students sorted by name");
             char classID = char.Parse(Console.ReadLine());
             foreach (var l in operations.SortByName(classID))
             {
                 Console.WriteLine(l.ToString());
             }*/

            /*foreach (var classes  in operations.DisplayAllClasses())
            {
                Console.WriteLine(classes);
            }*/           
            Generator.GenerateStudents();

        }
    }
}
