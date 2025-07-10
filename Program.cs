using MySql.Data.MySqlClient;
using System;
using System.Runtime.InteropServices;
namespace DbConnection
{
       class Program
    {
        static void Main(string[] args)
        {

            Controller s1=new Controller();
            List<Student> result=new List<Student>();

            //s1.AddStudent(new Student
            //{
            //    Id = 4,
            //    Name = "John Doe",
            //    Age = 20,
            //    department = "Computer Science"
            //});
            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Student Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Get All Students");
                Console.WriteLine("3. Get Student by Id");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter the choice: ");
                
                choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Id of Student:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        //result = s1.GetStudents(id);
                        Console.WriteLine("Enter the Name of Student:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the Age of Student:");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Dept of Student:");
                        string department = Console.ReadLine();
                        Student student1 = new Student(id, name, age, department);
                        s1.AddStudent(student1);
               
                        break;
                     case 2:
                        result = s1.GetStudents();
                        foreach (var item in result)
                        {
                            Console.WriteLine($"ID: {item.Id}, Name: {item.Name},Age: {item.Age},Department: {item.department}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id of Student to fetch:");
                        int fetchId1 = Convert.ToInt32(Console.ReadLine());
                        result=s1.GetStudent(fetchId1);
                        foreach (var item in result)
                        {
                            Console.WriteLine($"ID: {item.Id}, Name: {item.Name},Age: {item.Age},Department: {item.department}");
                        }

                        break;
                    case 4:
                        Console.WriteLine("Enter the Id of Student to update:");
                      //  Console.WriteLine("Enter the Id of Student to update:");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Name of Student to update:");
                        string userName = Console.ReadLine();
                        if (string.IsNullOrEmpty(userName))
                        {
                            Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                            userName = Console.ReadLine();
                        }
                        Console.WriteLine("Enter the Age of Student to update:");
                        int updateAge = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Department of Student to update:");
                        string updateDepartment = Console.ReadLine();
                        // Student student = new Student(updateId,"Rammu",updateAge,up);
                        Student s2= new Student(updateId, userName, updateAge, updateDepartment);
                        s1.UpdateStudent(s2);
                        //Console.WriteLine("Student updated successfully");
                        break;

                    case 5:
                        Console.WriteLine("Enter the Id of Student to delete:");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        s1.DeleteStudent(deleteId);
                        Console.WriteLine("Student deleted successfully");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
            while (choice > 0);
           
            foreach (var item in result)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name},Age: {item.Age},{item.department}");
            }




            //Console.ReadLine();



        }
    }
}