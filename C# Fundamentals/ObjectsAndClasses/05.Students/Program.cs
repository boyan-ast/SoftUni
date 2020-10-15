using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> allStudents = new List<Student>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] studentInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string town = studentInfo[3];

                Student student = new Student(name, lastName, age, town);

                allStudents.Add(student);
            }

            string townToFilter = Console.ReadLine();

            List<Student> filtered = Student.FilterByTown(allStudents, townToFilter);

            foreach (Student student in filtered)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

        public Student(string name, string lastName, int age, string town)
        {
            FirstName = name;
            LastName = lastName;
            Age = age;
            Hometown = town;
        }

        public static List<Student> FilterByTown(List<Student> students, string town)
        {
            List<Student> filteredStudents = students
                .Where(s => s.Hometown == town)
                .ToList();

            return filteredStudents;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }

}
