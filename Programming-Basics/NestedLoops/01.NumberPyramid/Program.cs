using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            int number = 0;

            for (int i = 1; i <= numbers; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    number++;
                    Console.Write(number + " ");                    

                    if (number == numbers)
                    {
                        return;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
