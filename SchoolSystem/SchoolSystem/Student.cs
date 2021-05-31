using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem
{
    class Student
    {
        private string firstName;
        private string lastName;
        private int averageGrade;

        public Student(string fName, string lName, int aGrade)
        {
            FirstName = fName;
            LastName = lName;
            AverageGrade = aGrade;
        }

        public int AverageGrade { get => averageGrade; set => averageGrade = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
    }
}
