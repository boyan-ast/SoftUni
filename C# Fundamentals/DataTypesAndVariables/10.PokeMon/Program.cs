using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            double initialPower = pokePower;

            int count = 0;

            while (pokePower >= distance)
            {
                count++;
                pokePower -= distance;

                if (pokePower == initialPower / 2 &&
                    exhaustionFactor != 0 &&
                    pokePower / exhaustionFactor != 0)
                {
                    pokePower /= exhaustionFactor;                    
                }

            }

            Console.WriteLine(pokePower);
            Console.WriteLine(count);
        }
    }
}
