using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNum = Console.ReadLine().TrimStart(new char[] { '0' });
            int secondNum = int.Parse(Console.ReadLine());

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder result = new StringBuilder();

            int addition = 0;

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(firstNum[i].ToString());

                int currentResult = secondNum * currentDigit + addition;

                result.Append(currentResult % 10);

                addition = currentResult / 10;
            }

            if (addition > 0)
            {
                result.Append(addition);
            }            

            Console.WriteLine(string.Join("", result.ToString().Reverse().ToArray()));
        }
    }
}
