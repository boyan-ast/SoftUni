using System;

namespace _06.TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int wins = 0;
            int loses = 0;
            double totalMoney = 0;

            for (int i = 0; i < days; i++)
            {
                string sport = string.Empty;
                int dailyWins = 0;
                int dailyLoses = 0;
                double dailyMoney = 0;

                while ((sport = Console.ReadLine()) != "Finish")
                {
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        dailyWins++;
                        dailyMoney += 20;
                    }
                    else if (result == "lose")
                    {
                        dailyLoses++;
                    }
                }

                if (dailyWins > dailyLoses)
                {
                    wins++;
                    dailyMoney *= 1.1;
                }
                else
                {
                    loses++;
                }

                totalMoney += dailyMoney;
            }

            if (wins > loses)
            {
                totalMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
            }
        }
    }
}
