using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int volume = 0;

            for (int i = 0; i < n; i++)
            {
                int pouredWater = int.Parse(Console.ReadLine());

                if (255 - volume < pouredWater)
                {
                    Console.WriteLine($"Insufficient capacity!");
                    continue;
                }

                volume += pouredWater;
            }

            Console.WriteLine(volume);
        }
    }
}
