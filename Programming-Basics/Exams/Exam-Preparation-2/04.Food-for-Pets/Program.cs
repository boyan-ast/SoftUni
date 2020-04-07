using System;

namespace _04.Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());

            double eatenFood = 0;
            double biscuits = 0d;
            double dogFood = 0;
            double catFood = 0;

            for (int i = 1; i <= days; i++)
            {
                int eatenByTheDog = int.Parse(Console.ReadLine());
                int eatenByTheCat = int.Parse(Console.ReadLine());

                double dailyFood = eatenByTheDog + eatenByTheCat;
                eatenFood += dailyFood;

                dogFood += eatenByTheDog;
                catFood += eatenByTheCat;

                if (i % 3 == 0)
                {
                    biscuits += 0.1 * dailyFood;                    
                }
            }
            
            Console.WriteLine($"Total eaten biscuits: {biscuits:f0}gr.");
            Console.WriteLine($"{(eatenFood / food * 100):f2}% of the food has been eaten.");
            Console.WriteLine($"{(dogFood / eatenFood * 100):f2}% eaten from the dog.");
            Console.WriteLine($"{(catFood / eatenFood * 100):f2}% eaten from the cat.");
        }
    }
}
