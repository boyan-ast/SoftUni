using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string input = Console.ReadLine();

            switch (dataType)
            {
                case "int": PrintResult(int.Parse(input)); break;
                case "real": PrintResult(double.Parse(input)); break;
                case "string": PrintResult(input); break;
                default: break;
            }

        }

        private static void PrintResult(int number)
        {
            Console.WriteLine(number * 2);
        }
        private static void PrintResult(double number)
        {
            Console.WriteLine($"{(number*1.5):f2}");
        }
        private static void PrintResult(string text)
        {
            Console.WriteLine($"${text}$");
        }
    }
}
