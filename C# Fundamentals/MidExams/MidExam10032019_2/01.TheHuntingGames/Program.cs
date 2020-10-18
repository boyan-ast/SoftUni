using System;

namespace _01.TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());

            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());

            double groupWater = waterPerPerson * players * days;
            double groupFood = foodPerPerson * players * days;

            bool haveEnergy = true;

            for (int day = 1; day <= days; day++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                groupEnergy -= energyLoss;

                if (groupEnergy <= 0)
                {
                    haveEnergy = false;
                    break;
                }

                if (day % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    groupWater *= 0.7;
                }

                if (day % 3 == 0)
                {
                    groupEnergy *= 1.1;
                    double eatenFood = groupFood / players;
                    groupFood -= eatenFood;
                }
            }

            if (haveEnergy)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {groupFood:f2} food and {groupWater:f2} water.");
            }
        }
    }
}
