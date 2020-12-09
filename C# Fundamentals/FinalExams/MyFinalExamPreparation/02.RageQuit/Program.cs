using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            StringBuilder rageMessage = new StringBuilder();

            int startSymbol = 0;
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (char.IsDigit(symbol))
                {
                    int repeatCount = 0;
                    string repeatString = input.Substring(startSymbol, count);

                    if (i < input.Length - 1 && char.IsDigit(input[i + 1]))
                    {
                        repeatCount = int.Parse(symbol.ToString() + input[i + 1].ToString());
                        startSymbol = i + 2;
                    }
                    else
                    {
                        repeatCount = int.Parse(symbol.ToString());
                        startSymbol = i + 1;
                    }

                    for (int j = 0; j < repeatCount; j++)
                    {
                        rageMessage.Append(repeatString);
                    }

                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            Console.WriteLine($"Unique symbols used: {rageMessage.ToString().Distinct().Count()}");
            Console.WriteLine($"{rageMessage}");

        }
    }
}
