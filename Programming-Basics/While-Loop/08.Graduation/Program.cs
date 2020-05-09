using System;

namespace _08.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int count = 1;
            double sumGrade = 0;

            while (count <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    sumGrade += grade;
                    count++;
                }
            }

            Console.WriteLine($"{name} graduated. Average grade: {(sumGrade/12):f2}");
        }
    }
}
