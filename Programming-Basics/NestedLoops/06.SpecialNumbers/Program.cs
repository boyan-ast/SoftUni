using System;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string stringNum = i.ToString();
                bool isSpecial = true;

                for (int j = 0; j < stringNum.Length; j++)
                {
                    int digit = int.Parse(stringNum[j].ToString());

                    if ((digit == 0) || (number % digit != 0))
                    {
                        isSpecial = false;
                        break;
                    }
                }

                if (isSpecial)
                {
                    Console.Write(stringNum + " ");
                }
            }
        }
    }
}
