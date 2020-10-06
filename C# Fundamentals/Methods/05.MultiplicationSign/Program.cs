using System;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNum = Console.ReadLine();
            string secondNum = Console.ReadLine();
            string thirdNum = Console.ReadLine();

            FindResultSign(firstNum, secondNum, thirdNum);
        }

        private static void FindResultSign(string a, string b, string c)
        {           

            if (a == "0" || b == "0" || c == "0")
            {
                Console.WriteLine("zero");
            }
            else
            {
                int minuses = 0;

                string[] nums = new string[] { a, b, c };

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i][0] == '-')
                    {
                        minuses++;
                    }
                }

                if (minuses == 1 || minuses == 3)
                {
                    Console.WriteLine("negative");
                }
                else
                {
                    Console.WriteLine("positive");
                }
            }
        }
    }
}
