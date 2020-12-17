using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                stack.Push(expression[i].ToString());
            }

            while (stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int secondNum = int.Parse(stack.Pop());

                int result = CalculateResult(firstNum, secondNum, sign);

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }

        private static int CalculateResult(int firstNum, int secondNum, string sign)
        {
            if (sign == "+")
            {
                return firstNum + secondNum;
            }
            else if (sign == "-")
            {
                return firstNum - secondNum;
            }

            throw new ArgumentException();
        }
    }
}
