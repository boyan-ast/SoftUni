using System;

namespace _04.ExamRetention
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int seasons = int.Parse(Console.ReadLine());

            for (int i = 1; i <= seasons; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    students -= (int)Math.Floor(0.1 * students);
                }

                students -= (int)Math.Floor(0.2 * students);

                double extraStudents = 0;

                if (i % 3 != 0)
                {
                    extraStudents = Math.Ceiling(0.05 * students);
                }
                else
                {
                    extraStudents = Math.Ceiling(0.15 * students);
                }

                students += (int)extraStudents;
            }

            Console.WriteLine($"Students: {students}");
        }
    }
}
