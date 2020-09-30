using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string action = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            int result = Calculate(firstNum, secondNum, action);

            Console.WriteLine("{0}", result);
        }

        private static int Calculate(int a, int b, string action)
        {
            int result = 0;

            switch (action)
            {
                case "/": result = a / b; break;
                case "*": result = a * b; break;
                case "+": result = a + b; break;
                case "-": result = a - b; break;
                default: break;
            }

            return result;
        }
    }
}
