using System;

namespace _01.EasterCozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());

            double eggsPrice = 0.75 * flourPrice;
            double milkPrice = (1.25 * flourPrice) / 4;

            double cozonacPrice = flourPrice + eggsPrice + milkPrice;

            int eggs = 0;
            int cozonacs = 0;

            while ((budget- cozonacPrice) > 0)
            {
                budget -= cozonacPrice;
                cozonacs++;
                eggs += 3;

                if (cozonacs % 3 == 0)
                {
                    int lostEggs = cozonacs - 2;
                    eggs -= lostEggs;
                }
            }

            Console.WriteLine($"You made {cozonacs} cozonacs! Now you have {eggs} eggs and {budget:f2}BGN left.");
        }
    }
}
