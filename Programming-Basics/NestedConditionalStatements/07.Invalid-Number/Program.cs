using System;

namespace _07.Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            bool isValid = true;

            if ((number < 100 || number > 200) && number != 0)
            {
                isValid = false;
            }

            if (!isValid)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
