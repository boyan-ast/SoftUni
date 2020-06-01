using System;

namespace _01.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            int counter = 0;

            while ((input = Console.ReadLine()) != "Stop")
            {
                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}
