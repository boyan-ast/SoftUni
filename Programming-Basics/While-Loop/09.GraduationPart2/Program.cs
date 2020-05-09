using System;

namespace _09.GraduationPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int count = 1;
            int failedCounter = 0;
            double sumGrade = 0;

            while (count <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    sumGrade += grade;
                    count++;
                }
                else
                {
                    failedCounter++;

                    if (failedCounter == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {count} grade");
                        return;
                    }
                }
            }

            Console.WriteLine($"{name} graduated. Average grade: {(sumGrade / 12):f2}");
        }
    }
}


