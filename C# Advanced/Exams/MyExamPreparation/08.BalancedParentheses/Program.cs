using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> openOnes = new Stack<char>();
            bool notMatching = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    openOnes.Push(input[i]);
                }
                else
                {
                    if (openOnes.Count == 0)
                    {
                        notMatching = true;
                        break;
                    }

                    if (input[i] == '}' || input[i] == ']' || input[i] == ')')
                    {
                        char pairedOne = openOnes.Pop();

                        if (input[i] == '}' && pairedOne != '{')
                        {
                            notMatching = true;
                            break;
                        }
                        else if (input[i] == ']' && pairedOne != '[')
                        {
                            notMatching = true;
                            break;
                        }
                        else if (input[i] == ')' && pairedOne != '(')
                        {
                            notMatching = true;
                            break;
                        }
                    }
                }
            }

            if (notMatching)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
