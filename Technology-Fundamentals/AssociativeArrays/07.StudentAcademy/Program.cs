using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            int numberOfGrades = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfGrades; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades.Add(student, new List<double>());
                }

                studentsGrades[student].Add(grade);
            }

            Dictionary<string, List<double>> filteredStudents = studentsGrades
                .Where(x => (x.Value.Sum() / x.Value.Count) >= 4.50)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var kvp in filteredStudents.OrderByDescending(x => x.Value.Sum() / x.Value.Count))
            {
                double averageGrade = kvp.Value.Sum() / kvp.Value.Count;
                Console.WriteLine($"{kvp.Key} -> {averageGrade:f2}");
            }

        }
    }
}
