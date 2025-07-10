using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{

    public class Controller
    {

        private MySqlConnection conn;

        public Controller()
        {
            string connectionString = "Server=localhost;database=Sampledb;Uid=root;pwd='';";
            conn = new MySqlConnection(connectionString);

        }
        // MySqlConnection conn;


        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            conn.Open();
            string query = "Select * from students";
            var cmd = new MySqlCommand(query, conn);
            // cmd.Parameters.AddWithValue("@id", id);
            // MySqlDataReader data = cmd.ExecuteReader();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                string name = reader["Name"].ToString();
                int age = Convert.ToInt32(reader["Age"]);
                string department = reader["department"].ToString();
                students.Add(new Student(
                    Id: id,
                    Name: name,
                    Age: age,
                    department: department
                ));

                // Console.WriteLine($"ID: {id}, Name: {name}, Age: {age}");
            }
        
            conn.Close();
            return students;
        }
        public List<Student> GetStudent(int id)
        {
            List<Student> students = new List<Student>();
            conn.Open();
            string query = "Select * from students where id=@id";
            var cmd = new MySqlCommand(query, conn);
             cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader data = cmd.ExecuteReader();
            if (data.Read())
            {
                students.Add(
                    new Student
                    {
                        Id = Convert.ToInt32(data["id"]),
                        Name = data["name"].ToString(),
                        Age = Convert.ToInt32(data["age"]),
                        department = data["department"].ToString()

                    });
            }
            conn.Close();
            return students;
        }

        public void AddStudent(Student student)
        {
            conn.Open();
            string query = "INSERT INTO students (id,name, age, department) VALUES (@id,@name, @age, @department)";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@age", student.Age);
            cmd.Parameters.AddWithValue("@department", student.department);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Student added successfully");
            conn.Close();
        }

        public void DeleteStudent(int id)
        {
            conn.Open();
            string query = "DELETE FROM students WHERE id=@id";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Student added successfully");
            conn.Close();
        }
        public void UpdateStudent(Student student)
        {
            conn.Open();
            string query = "UPDATE students SET name=@name, age=@age, department=@department WHERE id=@id";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", student.Id);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@age", student.Age);
            cmd.Parameters.AddWithValue("@department", student.department);
           if(cmd.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Student updated successfully");
            }
            else
            {
                Console.WriteLine("Student not updated successfully");
            }
                conn.Close();
        }

        public void CloseConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
