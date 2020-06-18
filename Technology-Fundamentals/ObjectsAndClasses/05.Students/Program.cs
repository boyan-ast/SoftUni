using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            List<Student> allStudents = new List<Student>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string town = input[3];

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Hometown = town
                };

                allStudents.Add(student);
            }

            string filterTown = Console.ReadLine();
            List<Student> filteredStudents = allStudents.Where(x => x.Hometown == filterTown).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Hometown { get; set; }

            public Student()
            {

            }
            public Student(string firstName, string lastName, int age, string hometown)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                Hometown = hometown;
            }

            public override string ToString()
            {
                return $"{FirstName} {LastName} is {Age} years old.";
            }
        }
    }
}
