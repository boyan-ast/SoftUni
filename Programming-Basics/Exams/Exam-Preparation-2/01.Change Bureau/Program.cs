using System;

namespace _01.Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double cnys = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());

            double bitcoinsToEur = (bitcoins * 1168) / 1.95;

            double cnysToEur = ((cnys * 0.15) * 1.76) / 1.95;

            double totalSum = bitcoinsToEur + cnysToEur;
            totalSum = totalSum - (commission / 100) * totalSum;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
