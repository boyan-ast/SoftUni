using System;

namespace _07.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            bool socialScholarshipPossible = false;
            bool scholarshipPossible = false;

            double socialScholarship = 0;
            double regularScholarship = 0;

            if (grade > 4.5 && income < minSalary)
            {
                socialScholarshipPossible = true;
                socialScholarship = 0.35 * minSalary;
            }            

            if (grade >= 5.5)
            {
                scholarshipPossible = true;
                regularScholarship = grade * 25;
            }

            if (socialScholarshipPossible && scholarshipPossible)
            {
                if (socialScholarship > regularScholarship)
                {
                    scholarshipPossible = false;                    
                }
                else
                {
                    socialScholarshipPossible = false;                    
                }
            }


            if (socialScholarshipPossible)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else if (scholarshipPossible)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(regularScholarship)} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
