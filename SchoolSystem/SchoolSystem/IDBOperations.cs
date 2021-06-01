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
        public double AverageGradePerClass();
        public List<Student> SortByAverageGrade();
        public List<Student> SortByName();
    }
}
