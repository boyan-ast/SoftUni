using System;

namespace _01.ExamSubmissions
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int problems = int.Parse(Console.ReadLine());

            double submissions = students * Math.Ceiling(problems * 2.8);
            int extraSubmissions = students * (problems / 3);

            submissions += extraSubmissions;

            double memoryNeeded = 5 * Math.Ceiling(submissions / 10);

            Console.WriteLine($"{memoryNeeded} KB needed");
            Console.WriteLine($"{submissions} submissions");
        }
    }
}
