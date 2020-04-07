using System;

namespace _05.Suitcases_load
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());

            int counter = 0;
            string command = null;

            while ((command = Console.ReadLine()) != "End")
            {
                counter++;

                double suitcaseVolume = double.Parse(command);

                if (counter % 3 == 0)
                {
                    suitcaseVolume *= 1.1;
                }

                capacity -= suitcaseVolume;

                if (capacity <= 0)
                {
                    counter--;
                    Console.WriteLine("No more space!");
                    break;
                }
            }

            if (command == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {counter} suitcases loaded.");

        }
    }
}
