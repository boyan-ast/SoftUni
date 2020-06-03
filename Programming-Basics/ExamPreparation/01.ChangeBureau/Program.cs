using System;

namespace _01.ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            int bitcoinsToLev = bitcoins * 1168;
            double yuansToLev = yuans * 0.15 * 1.76;

            double totalMoneyLev = bitcoinsToLev + yuansToLev;

            double totalMoneyEur = totalMoneyLev / 1.95;

            totalMoneyEur -= (commission / 100) * totalMoneyEur;

            Console.WriteLine($"{totalMoneyEur:f2}");
        }
    }
}
