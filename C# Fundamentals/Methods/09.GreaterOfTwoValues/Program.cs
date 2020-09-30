using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            if (dataType == "int")
            {
                GetMax(int.Parse(firstValue), int.Parse(secondValue));
            }
            else if (dataType == "char")
            {
                GetMax(char.Parse(firstValue), char.Parse(secondValue));
            }
            else if (dataType == "string")
            {
                GetMax(firstValue, secondValue);
            }
        }

        private static void GetMax(int a, int b)
        {
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }

        private static void GetMax(char a, char b)
        {
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
        private static void GetMax(string a, string b)
        {
            int compareLinguistic = String.Compare(a, b, StringComparison.InvariantCulture);

            if (compareLinguistic < 0)
            {
                Console.WriteLine(b);
            }
            else
            {
                Console.WriteLine(a);
            }
        }
    }
}
