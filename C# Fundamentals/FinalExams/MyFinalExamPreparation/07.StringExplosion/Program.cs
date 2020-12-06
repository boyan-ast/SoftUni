using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int power = 0;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == '>')
                {
                    result.Append(symbol.ToString());

                    power += int.Parse(input[i + 1].ToString());
                }
                else
                {
                    if (power == 0)
                    {
                        result.Append(symbol.ToString());
                    }
                    else
                    {
                        power--;
                    }
                }
            }

            Console.WriteLine(result);
         }
    }
}
