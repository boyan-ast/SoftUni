using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            int counter = 1;

            while (counter <= numberOfStudents)
            {
                string[] inputInfo = Console.ReadLine().Split();
                Student student = new Student(inputInfo[0], inputInfo[1], double.Parse(inputInfo[2]));
                students.Add(student);

                counter++;
            }

            foreach (var student in students.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine(student);
            }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public Student()
            {
                    
            }
            public Student(string firstName, string lastName, double grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:f2}";
            }
        }
    }    
}
