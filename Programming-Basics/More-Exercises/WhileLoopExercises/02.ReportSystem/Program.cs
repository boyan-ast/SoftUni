using System;

namespace _02.ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededSum = int.Parse(Console.ReadLine());

            int cashTransactions = 0;
            int cardTransactions = 0;
            int cashIncome = 0;
            int cardIncome = 0;
            int counter = 0;
            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                counter++;
                int income = int.Parse(command); 

                if (counter % 2 != 0)
                {
                    if (income > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        cashIncome += income;
                        cashTransactions++;
                        neededSum -= income;
                    }
                }
                else
                {
                    if (income < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        cardIncome += income;
                        cardTransactions++;
                        neededSum -= income;
                    }
                }

                if (neededSum <= 0)
                {
                    Console.WriteLine($"Average CS: {(cashIncome * 1.0 / cashTransactions):f2}");
                    Console.WriteLine($"Average CC: {(cardIncome * 1.0 / cardTransactions):f2}");
                    return;
                }
            }

            Console.WriteLine($"Failed to collect required money for charity.");
        }
    }
}
