using System;

namespace SchoolSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            DBOperations operations = new DBOperations();

            operations.CleanDB();
            Generator.GenerateClasses();
            Generator.GenerateStudents();

            foreach (var c in operations.DisplayAllClasses())
            {
                Console.WriteLine(c.ToString() + "\n");
            }

            while (true)
            {
                Console.WriteLine("Choose an option:\nChoose class to get average grade of it: 1 \n" +
               "Choose class to get its students sorted by average grade: 2\n" +
               "Choose class to get its students sorted by name: 3\n" +
               "Quit: 4");

                int mode;
                try
                {
                    mode = int.Parse(Console.ReadLine());

                }
                catch(FormatException e)
                {
                    Console.WriteLine("\nChoose a valid option\n");
                    continue;
                }

                if (mode == 4)
                    break;

                switch (mode)
                {
                    case 1:
                        Console.WriteLine("Select class:");
                        char classIDAverageGrade = char.Parse(Console.ReadLine());
                        Console.WriteLine("Average grade {0}\n",operations.AverageGradePerClass(classIDAverageGrade));
                        break;
                    case 2:
                        Console.WriteLine("Select class:");
                        char classIDStudentsSortedbyGrade = char.Parse(Console.ReadLine());
                        Console.WriteLine("Students sorted by Grade (DESC):");
                        foreach(var student in operations.SortByAverageGrade(classIDStudentsSortedbyGrade))
                        {
                            Console.WriteLine(student.ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("Select class:");
                        char classIDStudentsSortedbyName = char.Parse(Console.ReadLine());
                        Console.WriteLine("Students sorted by Name (ASC):");
                        foreach (var student in operations.SortByName(classIDStudentsSortedbyName))
                        {
                            Console.WriteLine(student.ToString());
                        }
                        break;
                }
            }






        }
    }
}
