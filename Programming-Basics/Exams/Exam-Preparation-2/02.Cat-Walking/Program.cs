using System;

namespace _02.Cat_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesWalking = int.Parse(Console.ReadLine());
            int numberOfWalkings = int.Parse(Console.ReadLine());
            int takenCalories = int.Parse(Console.ReadLine());

            int burnedCalories = (minutesWalking * numberOfWalkings) * 5;

            if (burnedCalories >= (0.5 * takenCalories))
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnedCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnedCalories}.");
            }
        }
    }
}
