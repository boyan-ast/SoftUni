using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = string.Empty;

            while ((number = Console.ReadLine())!="END")
            {                
                bool isPalindrome = PalindromeChecker(number);

                Console.WriteLine(isPalindrome.ToString().ToLower());
            }
        }

        private static bool PalindromeChecker(string num)
        {
            for (int i = 0; i < num.Length / 2; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
