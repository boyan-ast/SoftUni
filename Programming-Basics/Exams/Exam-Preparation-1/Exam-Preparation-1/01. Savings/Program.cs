using System;

namespace _01._Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double expenses = double.Parse(Console.ReadLine());

            double unexpectedExpenses = 0.3 * income;

            double savingsPerMonth = income - expenses - unexpectedExpenses;
            double savingsPerMontPercent = savingsPerMonth / income * 100;

            double totalSavings = savingsPerMonth * months;

            Console.WriteLine($"She can save {savingsPerMontPercent:f2}%");
            Console.WriteLine($"{totalSavings:f2}");
        }
    }
}
