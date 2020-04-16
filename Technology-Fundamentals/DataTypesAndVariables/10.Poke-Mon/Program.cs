using System;

namespace _10.Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int counter = 0;
            int initialPower = pokePower;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                counter++;

                if (pokePower == (initialPower * 0.5))
                {
                    if (pokePower >= exhaustionFactor && exhaustionFactor != 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(counter);
        }
    }
}
