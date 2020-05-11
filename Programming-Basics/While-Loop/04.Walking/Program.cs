using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = 0;
            bool goalReached = true;

            while (totalSteps < 10000)
            {
                int steps = 0;
                bool walksOrNot = int.TryParse(Console.ReadLine(), out steps);
                totalSteps += steps;

                if (walksOrNot == false)
                {
                    steps = int.Parse(Console.ReadLine());
                    totalSteps += steps;

                    if (totalSteps < 10000)
                    {
                        goalReached = false;
                    }

                    break;
                }
            }


            if (goalReached)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{10000-totalSteps} more steps to reach goal.");
            }
        }
    }
}
