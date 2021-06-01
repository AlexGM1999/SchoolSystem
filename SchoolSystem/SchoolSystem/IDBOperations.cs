using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace SchoolSystem
{
    interface IDBOperations
    {
        public SqlConnection Connection();
        public Student CreateStudent(Student student);
        public SchoolClass CreateClass(SchoolClass schoolClass);
        public double AverageGradePerClass(char classID);
        public List<Student> SortByAverageGrade(char classID);
        public List<Student> SortByName(char classID);

        public List<string> DisplayAllClasses();
        public List<char> GetClassesID();
        public void CleanDB();
    }
}
