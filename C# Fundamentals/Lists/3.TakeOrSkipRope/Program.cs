using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.TakeOrSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<char> nonNumbers = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    numbers.Add(int.Parse(input[i].ToString()));
                }
                else
                {
                    nonNumbers.Add(input[i]);
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int j = 0; j < numbers.Count; j++)
            {
                if (j  % 2 == 0)
                {
                    takeList.Add(numbers[j]);
                }
                else
                {
                    skipList.Add(numbers[j]);
                }
            }
            
            StringBuilder encryptedMessage = new StringBuilder();                    

            for (int i = 0; i < takeList.Count; i++)
            {
                int takeCount = takeList[i];
                int skipCount = skipList[i];

                int end = takeCount + skipCount;

                char[] resultMessage = nonNumbers.Take(takeCount).ToArray();

                encryptedMessage.Append(resultMessage);

                if (end >= nonNumbers.Count)
                {
                    break;
                }

                nonNumbers.RemoveRange(0, end);                
            }

            Console.WriteLine(encryptedMessage);
        }
    }
}
