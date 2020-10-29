using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> allStudents = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                Student student = allStudents.FirstOrDefault(x => x.Name == name);

                if (student == null)
                {
                    student = new Student(name);
                    allStudents.Add(student);
                }

                student.AddGrade(grade);
            }

            List<Student> filteredStudents = new List<Student>();

            foreach (Student student in allStudents)
            {
                if (student.AverageGrade() >= 4.50)
                {
                    filteredStudents.Add(student);
                }
            }

            filteredStudents = filteredStudents.OrderByDescending(x => x.AverageGrade()).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        private double averageGrade;

        public Student(string name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            Grades.Add(grade);
        }

        public double AverageGrade()
        {
            averageGrade = Grades.Average();
            return averageGrade;
        }

        public override string ToString()
        {
            return $"{Name} -> {averageGrade:f2}";             
        }
    }
}
