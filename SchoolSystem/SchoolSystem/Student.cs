using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem
{
    class Student
    {
        private string firstName;
        private string lastName;
        private decimal averageGrade;
        private char studentGrade;

        public Student(string firstName, string lastName, decimal averageGrade, char studentGrade)
        {
            FirstName = firstName;
            LastName = lastName;
            AverageGrade = averageGrade;
            StudentGrade = studentGrade;
        }

        public decimal AverageGrade { get => averageGrade; set => averageGrade = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public char StudentGrade { get => studentGrade; set => studentGrade = value; }
    }
}
