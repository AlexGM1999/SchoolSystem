using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSystem
{
    class SchoolClass
    {
        private char classID;
        private string teacher;

        public SchoolClass(char classID, string teacher)
        {
            ClassID = classID;
            Teacher = teacher;
        }

        public char ClassID { get => classID; set => classID = value; }
        public string Teacher { get => teacher; set => teacher = value; }
    }
}
