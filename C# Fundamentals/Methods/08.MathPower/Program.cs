using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = Calculate(num, power);

            Console.WriteLine(result);
        }

        private static double Calculate(double num, int power)
        {
            double result = 1;

            if (num == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 0; i < power; i++)
                {
                    result *= num;
                }
                return result;
            }

        }
    }
}
