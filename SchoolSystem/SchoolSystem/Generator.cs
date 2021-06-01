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
            string[] lastNames = { "Ivanov", "Georgieva", "Dimitrova", "Vasilev", "Atanasova","Petkov"};
            for (int i = 0; i < 5; i++)
            {
                int indexClassID = random.Next(0, 26);
                int indexLName = random.Next(0,5);
                SchoolClass schClass = new SchoolClass(alphabet[indexClassID], lastNames[indexLName]);
                operations.CreateClass(schClass);
            }
        }
    }
}
