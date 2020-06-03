using System;

namespace _05.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            int suitcases = 0;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                suitcases++;
                double volume = double.Parse(command);

                if (suitcases % 3 != 0)
                {
                    capacity -= volume;
                }
                else
                {
                    capacity -= (volume * 1.1);
                }

                if (capacity < 0)
                {
                    suitcases--;
                    Console.WriteLine("No more space!");
                    break;
                }


            }

            if (command == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {suitcases} suitcases loaded.");
        }
    }
}
