using System;

namespace _06.Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int wins = 0;
            int losses = 0;

            double totalSum = 0;

            for (int i = 0; i < days; i++)
            {
                string command = null;

                int currentWins = 0;
                int currentLosses = 0;
                double dailySum = 0;

                while ((command = Console.ReadLine()) != "Finish")
                {
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        dailySum += 20;
                        currentWins++;
                    }
                    else if (result == "lose")
                    {
                        currentLosses++;
                    }
                }

                if (currentWins > currentLosses)
                {
                    wins++;
                    dailySum *= 1.1;
                }
                else
                {
                    losses++;
                }

                totalSum += dailySum;
            }

            if (wins > losses)
            {
                totalSum *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalSum:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalSum:f2}");
            }
        }
    }
}
