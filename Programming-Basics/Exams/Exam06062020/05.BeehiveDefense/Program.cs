using System;

namespace _05.BeehiveDefense
{
    class Program
    {
        static void Main(string[] args)
        {
            int bees = int.Parse(Console.ReadLine());
            int bearHealth = int.Parse(Console.ReadLine());
            int bearPower = int.Parse(Console.ReadLine());
            bool bearWon = true;

            while (bees >= 100)
            {
                bees -= bearPower;
                bearHealth -= (bees * 5);

                if (bearHealth <= 0)
                {
                    bearWon = false;
                    break;
                }
            }

            if (bees < 0)
            {
                bees = 0;
            }

            if (bearWon)
            {
                Console.WriteLine($"The bear stole the honey! Bees left {bees}.");
            }
            else
            {
                Console.WriteLine($"Beehive won! Bees left {bees}.");
            }
        }
    }
}
