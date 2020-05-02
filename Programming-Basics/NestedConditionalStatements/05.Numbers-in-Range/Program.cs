using System;

namespace _05.Numbers_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isValid = ConditionsChecker(number);

            if (isValid)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static bool ConditionsChecker(int num)
        {
            if ((num >= -100 && num <= 100) && num != 0)
            {
                return true;
            }

            return false;
        }
    }
}
