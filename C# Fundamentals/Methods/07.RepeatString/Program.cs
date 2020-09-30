using System;
using System.Diagnostics;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int counter = int.Parse(Console.ReadLine());

            //Stopwatch sw = new Stopwatch();

            //w.Start();

            string repeatedString = RepeatInputString(input, counter);

            //Console.WriteLine(sw.Elapsed);

            Console.WriteLine(repeatedString);
        }

        private static string RepeatInputString(string input, int counter)
        {
            StringBuilder sb = new StringBuilder(counter * input.Length);

            for (int i = 0; i < counter; i++)
            {
                sb.Append(input);
            }

            return sb.ToString();
        }
    }
}
