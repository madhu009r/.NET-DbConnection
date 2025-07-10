using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string department { get; set; }
    

        public Student()
        {
           
        }
        public Student( int Id, string Name,int Age, string department)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.department = department;

        }
    } 
}
