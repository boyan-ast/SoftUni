using System;
using System.Text;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] commandArgs = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];

                if (action == "Add Stop")
                {
                    int index = int.Parse(commandArgs[1]);

                    if (index >= 0 && index < stops.Length)
                    {
                        string newStop = commandArgs[2];
                        stops = stops.Insert(index, newStop);
                    }
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    if (startIndex >= 0 && startIndex < stops.Length &&
                        endIndex >= startIndex && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, (endIndex - startIndex + 1));
                    }
                }
                else if (action == "Switch")
                {
                    string oldStop = commandArgs[1];
                    string newStop = commandArgs[2];

                    if (stops.Contains(oldStop))
                    {
                        stops = stops.Replace(oldStop, newStop);
                    }
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
