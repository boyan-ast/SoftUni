using System;

namespace _10.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * length * height;

            string command = string.Empty;

            while ((command = Console.ReadLine())!= "Done")
            {
                int boxes = int.Parse(command);

                freeSpace -= boxes;
                if (freeSpace <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
                    return;
                }
            }

            Console.WriteLine($"{freeSpace} Cubic meters left.");
        }
    }
}
