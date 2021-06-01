using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem
{
    class Generator
    {
        public static void GenerateClasses()
        {
            DBOperations operations = new DBOperations();
            Random random = new Random();
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string[] lastNames = { "Ivanov", "Georgieva", "Dimitrova", "Vasilev", "Atanasova", "Petkov" };
            for (int i = 0; i < 5; i++)
            {
                int indexClassID = random.Next(0, 26);
                int indexLName = random.Next(0, 5);
                SchoolClass schClass = new SchoolClass(alphabet[indexClassID], lastNames[indexLName]);
                operations.CreateClass(schClass);
            }
        }
        public static void GenerateStudents()
        {
            DBOperations operations = new DBOperations();
            Random random = new Random();
            string[] firstNamesMales = { "Ivan", "Georgi", "Stefan", "Lubomir", "Kristian", "Ognyan", "Ivaylo" };
            string[] firstNamesFemales = { "Svetlana", "Ani", "Elena", "Katerina", "Ivana", "Valeria", "Lora" };
            string[] lastNamesMales = { "Ivanov", "Georgiev", "Dimitrov", "Kamenov", "Petrov", "Aleksandrov", "Iliev" };
            string[] lastNamesFemales = { "Ivanova", "Georgieva", "Arnaudova", "Aleksandrova", "Petkanova", "Ilieva", "Marinova" };
            double[] averageGrade = { 5.5, 4.33, 5.75, 3.40, 4, 5, 6, 3, 4.5, 3.75, 4.75 };
            var classID = operations.GetClassesID();
            for (int i = 0; i < 26; i++)
            {
                var sex = random.Next(2); //1=female 0=male
                var firstName = sex == 1 ? firstNamesFemales[random.Next(7)] : firstNamesMales[random.Next(7)];
                var lastName = sex == 1 ? lastNamesFemales[random.Next(7)] : lastNamesMales[random.Next(7)];
                var avGrade = averageGrade[random.Next(12)];
                var gradeID = classID[random.Next(classID.Count)];
                Student student = new Student(firstName, lastName, avGrade, gradeID);
                operations.CreateStudent(student);
            }
        }
    }
}
