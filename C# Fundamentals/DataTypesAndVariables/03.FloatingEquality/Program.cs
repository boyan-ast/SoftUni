using System;

namespace _03.FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double eps = 0.000001;

            double diff = Math.Abs(firstNum - secondNum);

            if (diff < eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
