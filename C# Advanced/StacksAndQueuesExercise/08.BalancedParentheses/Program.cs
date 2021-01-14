using System;
using System.Collections.Generic;
using System.Text;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 == 1 ||
                (!input.Contains("(") && !input.Contains("{") && !input.Contains("["))
                )
            {
                Console.WriteLine("NO");
                return;
            }

            List<string> parts = new List<string>();
            StringBuilder substring = new StringBuilder();
            bool isClosing = false;

            for (int i = 0; i < input.Length - 1; i++)
            {
                substring.Append(input[i].ToString());

                if (input[i] == ')' || input[i] == ']' || input[i] == '}')
                {
                    isClosing = true;
                }

                if (((input[i + 1] == '(' || input[i + 1] == '[' || input[i + 1] == '{') && isClosing == true))
                {
                    parts.Add(substring.ToString());
                    substring = new StringBuilder();
                    isClosing = false;
                }
            }

            substring.Append(input[input.Length - 1]);
            parts.Add(substring.ToString());

            bool areBalanced = true;

            foreach (string part in parts)
            {
                areBalanced = CheckTheParanthesis(part);

                if (!areBalanced)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");

        }

        private static bool CheckTheParanthesis(string input)
        {
            if (input.Length % 2 == 1)
            {
                return false;
            }

            Stack<char> firstPart = new Stack<char>();

            for (int i = 0; i < input.Length/2; i++)
            {
                firstPart.Push(input[i]);
            }

            Queue<char> secondPart = new Queue<char>();

            for (int i = input.Length/2; i < input.Length; i++)
            {
                secondPart.Enqueue(input[i]);
            }

            bool isValid = true;

            while (firstPart.Count > 0 && secondPart.Count > 0)
            {
                char first = firstPart.Pop();
                char second = secondPart.Dequeue();

                isValid = ValidateParantheses(first, second);

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateParantheses(char first, char second)
        {
            bool isValid = true;

            switch (first)
            {
                case ' ':
                    if (second != ' ')
                    {
                        isValid = false;
                    }
                    break;
                case '{':
                    if (second != '}')
                    {
                        isValid = false;
                    }
                    break;
                case '(':
                    if (second != ')')
                    {
                        isValid = false;
                    }
                    break;
                case '[':
                    if (second != ']')
                    {
                        isValid = false;
                    }
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }
    }
}
