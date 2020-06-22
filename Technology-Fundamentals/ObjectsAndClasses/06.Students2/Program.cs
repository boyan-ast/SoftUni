using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Students2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] studentData = command.Split();
                string firstName = studentData[0];
                string lastName = studentData[1];
                int age = int.Parse(studentData[2]);
                string town = studentData[3];

                Student student = new Student(firstName, lastName, age, town);
                bool exists = false;


                foreach (Student person in students)
                {
                    if (student.FirstName == person.FirstName && student.LastName == person.LastName)
                    {
                        person.Age = student.Age;
                        person.Hometown = student.Hometown;
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    students.Add(student);
                }
            }

            string filterCity = Console.ReadLine();

            List<Student> filteredStudents = students.Where(x => x.Hometown == filterCity).ToList();

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
