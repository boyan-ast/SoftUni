using System;

namespace _07.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            if (secondNum == 0 && (operation == '/'|| operation == '%'))
            {
                Console.WriteLine($"Cannot divide {firstNum} by zero");
                return;
            }

            double result = 0;

            switch (operation)
            {
                case '+': result = firstNum + secondNum; break;
                case '-': result = firstNum - secondNum; break;
                case '*': result = firstNum * secondNum; break;
                case '/': result = (double)firstNum / secondNum; break;
                case '%': result = firstNum % secondNum; break;
                default: break;
            }

            string evenOrOdd = EvenOrOddChecker(result);

            if (operation != '/' && operation != '%')
            {
                Console.WriteLine($"{firstNum} {operation} {secondNum} = {result} - {evenOrOdd}");
            }
            else if (operation == '/')
            {
                Console.WriteLine($"{firstNum} {operation} {secondNum} = {result:f2}");
            }
            else
            {
                Console.WriteLine($"{firstNum} {operation} {secondNum} = {result}");
            }

        }

        private static string EvenOrOddChecker(double result)
        {
            if (result % 2 == 0)
            {
                return "even";
            }

            return "odd";
        }
    }
}
