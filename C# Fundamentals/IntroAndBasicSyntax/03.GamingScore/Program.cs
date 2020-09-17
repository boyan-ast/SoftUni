using System;

namespace _03.GamingScore
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double spentmoney = 0;
            string gameName = string.Empty;

            while ((gameName = Console.ReadLine()) != "Game Time")
            {
                double price = PriceCalculator(gameName);

                if (price == 0)
                {
                    Console.WriteLine("Not Found");
                    continue;
                }
                else
                {
                    if (price > budget)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else if (price == budget)
                    {
                        budget = 0;
                        Console.WriteLine($"Bought {gameName}");
                        Console.WriteLine("Out of money");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {gameName}");
                        budget -= price;
                        spentmoney += price;
                    }
                }

                
            }
                Console.WriteLine($"Total spent: ${spentmoney:f2}. Remaining: ${budget:f2}");
        }

        private static double PriceCalculator(string name)
        {
            double price = 0;

            if (name == "OutFall 4" || name == "RoverWatch Origins Edition")
            {
                price = 39.99;
            }
            else if (name == "CS: OG")
            {
                price = 15.99;
            }
            else if (name == "Zplinter Zell")
            {
                price = 19.99;
            }
            else if (name == "Honored 2")
            {
                price = 59.99;
            }
            else if (name == "RoverWatch")
            {
                price = 29.99;
            }

            return price;
        }
    }
}
