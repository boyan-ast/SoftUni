using System;

namespace _05.Care_of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int purchasedFood = int.Parse(Console.ReadLine()) * 1000;

            string command = null;
            int totalFood = 0;

            while ((command = Console.ReadLine()) != "Adopted")
            {
                int dailyFood = int.Parse(command);
                totalFood += dailyFood;
            }

            if (totalFood > purchasedFood)
            {
                Console.WriteLine($"Food is not enough. You need {totalFood-purchasedFood} grams more.");
            }
            else
            {
                Console.WriteLine($"Food is enough! Leftovers: {purchasedFood-totalFood} grams.");
            }
        }
    }
}
