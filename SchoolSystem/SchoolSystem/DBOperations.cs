using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SchoolSystem
{
    class DBOperations : IDBOperations
    {
        
        public SqlConnection Connection()
        {
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Acer\\OneDrive\\Desktop\\SchoolSystem\\SchoolSystem\\SchoolSystem\\SchoolSystem\\SchoolSystemDB.mdf;Integrated Security=True";
            return con;

        }

        public Student CreateStudent(Student student)
        {
            var con = Connection();
            con.Open();
           SqlCommand command= new SqlCommand($"INSERT INTO Students " +
                $"(FirstName, LastName, AverageGrade, ClassID)" +
                $" VALUES ('{student.FirstName}','{student.LastName}',{student.AverageGrade}," +
                $"'{student.StudentGrade}')",con);
            command.ExecuteNonQuery();
            return student;
        }

        public SchoolClass CreateClass(SchoolClass schClass)
        {
            var con = Connection();
            con.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO SchoolClasses " +
                $"(Id,Teacher)" +
                $" VALUES ('{schClass.ClassID}','{schClass.Teacher}')",con);
            command.ExecuteNonQuery();
            return schClass;
        }

        public double AverageGradePerClass()
        {
            throw new NotImplementedException();
        }

        public List<Student> SortByAverageGrade()
        {
            throw new NotImplementedException();
        }

        public List<Student> SortByName()
        {
            throw new NotImplementedException();
        }
    }
}
