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
            List<Student> result= s1.GetStudents(1);

            //s1.AddStudent(new Student
            //{
            //    Id = 4,
            //    Name = "John Doe",
            //    Age = 20,
            //    department = "Computer Science"
            //});
            Console.WriteLine("Enter the choice: ");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            do
            {


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Id of Student:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        //result = s1.GetStudents(id);
                        string name = Console.ReadLine();
                        int age = Convert.ToInt32(Console.ReadLine());
                        string department = Console.ReadLine();
                        s1.AddStudent(new Student
                        {
                            Id = id,
                            Name = name,
                            Age = age,
                            department = department
                        });
                        break;
                     case 2:
                        Console.WriteLine("Enter the Id of Student to fetch:");
                        int fetchId = Convert.ToInt32(Console.ReadLine());
                        s1.DeleteStudent(fetchId);
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id of Student to fetch:");
                        int fetchId1 = Convert.ToInt32(Console.ReadLine());
                        result=s1.GetStudents(fetchId1);

                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            }
            while (choice != 0);
           
            foreach (var item in result)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name},Age: {item.Age},{item.department}");
            }




            //Console.ReadLine();



        }
    }
}