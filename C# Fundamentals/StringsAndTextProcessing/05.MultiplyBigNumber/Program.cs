using System;
using System.Text;
using System.Linq;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine().TrimStart(new char[] { '0' });
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int addition = 0;

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(numberAsString[i].ToString());
                int temp = digit * multiplier + addition;
                int resultDigit = temp % 10;
                addition = temp / 10;

                result.Append(resultDigit);

                if (i == 0 && addition > 0)
                {
                    result.Append(addition);
                }
            }

            Console.WriteLine(string.Join("", result.ToString().Reverse().ToArray()));
        }
    }
}
