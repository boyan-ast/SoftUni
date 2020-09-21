using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                if (int.TryParse(input, out int result))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (double.TryParse(input, out double doubleResult))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out char charResult))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out bool boolResult))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
            }
        }
    }
}
