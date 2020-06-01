using System;

namespace _01.Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double monthlyIncome = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double personalExpenses = double.Parse(Console.ReadLine());

            double unexpectedExpenses = 0.3 * monthlyIncome;
            double savedMoneyPerMonth = monthlyIncome - (unexpectedExpenses + personalExpenses);

            double savedMoney = savedMoneyPerMonth * months;
            double savedMoneyPercent = savedMoneyPerMonth / monthlyIncome * 100;

            Console.WriteLine($"She can save {savedMoneyPercent:f2}%");
            Console.WriteLine($"{savedMoney:f2}");
        }
    }
}
