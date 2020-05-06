using System;

namespace _06.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < tabs; i++)
            {
                string website = Console.ReadLine();
                int fine = CalculateFine(website);

                salary -= fine;

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }

            Console.WriteLine(salary);
        }

        private static int CalculateFine(string site)
        {
            int fineToPay = 0;

            switch (site)
            {
                case "Facebook": fineToPay = 150; break;
                case "Instagram": fineToPay = 100; break;
                case "Reddit": fineToPay = 50; break;
                default: fineToPay = 0; break;
            }

            return fineToPay;
        }
    }
}
