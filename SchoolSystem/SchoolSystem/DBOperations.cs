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
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Students " +
                     $"(FirstName, LastName, AverageGrade, ClassID)" +
                     $" VALUES ('{student.FirstName}','{student.LastName}',{student.AverageGrade}," +
                     $"'{student.StudentGrade}')", con);
                command.ExecuteNonQuery();
                return student;
            }
            finally
            {
                con.Close();
            }
        }

        public SchoolClass CreateClass(SchoolClass schClass)
        {
            var con = Connection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO SchoolClasses " +
                    $"(Id,Teacher)" +
                    $" VALUES ('{schClass.ClassID}','{schClass.Teacher}')", con);
                command.ExecuteNonQuery();
                return schClass;
            }
            finally
            {
                con.Close();
            }
        }

        public double AverageGradePerClass(char classID)
        {
            double sumGrades=0;
            double averageGrade;
            List<double> avGradeList = new List<double>();
            var con = Connection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand($"SELECT AverageGrade FROM Students " +
                    $"WHERE ClassID='{classID}'", con);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var avGradePerStudent = reader.GetDouble(0);
                    avGradeList.Add(avGradePerStudent);
                }
                foreach (var grade in avGradeList)
                {
                    sumGrades += grade;
                }
                averageGrade = sumGrades / avGradeList.Count;
                return averageGrade;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Student> SortByAverageGrade(char classID)
        {
            List<Student> students = new List<Student>();
            var con = Connection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand($"SELECT* FROM Students " +
                    $" WHERE ClassID='{classID}' " +
                    $"ORDER BY (AverageGrade) DESC", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student entity = new Student((string)reader["FirstName"],
                        (string)reader["LastName"], (double)reader["AverageGrade"],
                        char.Parse((string)reader["ClassID"]));

                    students.Add(entity);
                }
                return students;
            }
            finally
            {
                con.Close();
            }

        }

        public List<Student> SortByName(char classID)
        {
            List<Student> students = new List<Student>();
            var con = Connection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand($"SELECT* FROM Students " +
                    $" WHERE ClassID='{classID}' " +
                    $"ORDER BY (FirstName) ASC", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student entity = new Student((string)reader["FirstName"],
                        (string)reader["LastName"], (double)reader["AverageGrade"],
                        char.Parse((string)reader["ClassID"]));

                    students.Add(entity);
                }
                return students;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> DisplayAllClasses()
        {
            List<string> classes = new List<string>();
            var con = Connection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) AS StudentCount," +
                    $" SchoolClasses.Id, SchoolClasses.Teacher FROM Students " +
                    $"INNER JOIN SchoolClasses ON Students.ClassID = SchoolClasses.Id " +
                    $"GROUP BY SchoolClasses.Id, SchoolClasses.Teacher", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    classes.Add($" Class: {reader["Id"]}, Teacher: {reader["Teacher"]}, " +
                        $"Student count: {reader["StudentCount"]} ");
                }
                return classes;
            }
            finally
            {
                con.Close();
            }
        }
        public List<char> GetClassesID()
        {
            List<char> classesID = new List<char>();
            var con = Connection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand($"SELECT DISTINCT(Id) AS classes FROM SchoolClasses", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    classesID.Add(char.Parse((string)reader["classes"]));
                }
                return classesID;
            }
            finally
            {
                con.Close();
            }
        }
        public void CleanDB()
        {
            var con = Connection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Students",con);
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM SchoolClasses";
                command.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
