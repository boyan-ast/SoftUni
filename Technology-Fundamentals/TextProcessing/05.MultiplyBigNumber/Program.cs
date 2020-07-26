using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int addition = 0;

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(firstNumber[i].ToString()) * secondNumber + addition;

                if (digit > 9)
                {
                    addition = digit / 10;
                    digit = digit % 10;
                }
                else
                {
                    addition = 0;
                }

                result.Append(digit.ToString());
            }

            if (addition > 0)
            {
                result.Append(addition);
            }

            string resultString = result.ToString().TrimEnd('0');

            char[] charArray = resultString.ToCharArray();
            Array.Reverse(charArray);

            string reversedResult = new string(charArray);

            Console.WriteLine(reversedResult);
        }
    }
}
