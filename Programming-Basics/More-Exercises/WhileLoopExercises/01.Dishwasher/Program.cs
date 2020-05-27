using System;

namespace _01.Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottlesOfDetergent = int.Parse(Console.ReadLine());
            int totalVolume = bottlesOfDetergent * 750;

            int dishes = 0;
            int pots = 0;
            int counter = 0;

            bool enoughDetergent = true;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                counter++;

                if (counter % 3 != 0)
                {
                    dishes += int.Parse(command);
                    totalVolume -= int.Parse(command) * 5;
                }
                else
                {
                    pots += int.Parse(command);
                    totalVolume -= int.Parse(command) * 15;
                }

                if (totalVolume < 0)
                {
                    enoughDetergent = false;
                    break;
                }                 
            }

            if (enoughDetergent)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
                Console.WriteLine($"Leftover detergent {totalVolume} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(totalVolume)} ml. more necessary!");
            }
        }
    }
}
