using System;

namespace _01.SquareRoot
{
    class Program
    {
        public static double Sqrt(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", "Sqrt for neagative numbers is undefined!");
            }

            return Math.Sqrt(value);
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(Sqrt(number));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: " + ex.Message);              
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
