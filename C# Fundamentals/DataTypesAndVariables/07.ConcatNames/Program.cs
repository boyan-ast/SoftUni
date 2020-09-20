using System;
using System.Text;

namespace _07.ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            result.Append(firstName);
            result.Append(delimiter);
            result.Append(secondName);

            Console.WriteLine(result);
        }
    }
}
