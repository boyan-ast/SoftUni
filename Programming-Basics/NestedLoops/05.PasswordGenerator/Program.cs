using System;

namespace _05.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            PasswordGenerator(firstNumber, secondNumber);
        }

        private static void PasswordGenerator(int n, int l)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    for (int k = 'a'; k < 'a' + l; k++)
                    {
                        for (int m = 'a'; m < l +'a'; m++)
                        {
                            for (int p = 1; p <= n; p++)
                            {
                                if ((p <= i) || (p <= j))
                                {
                                    continue;
                                }

                                Console.Write($"{i}{j}{(char)k}{(char)m}{p} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
