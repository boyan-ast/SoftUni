using System;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake stones = new Lake(numbers);
            int index = -1;

            foreach (int stone in stones)
            {
                index++;
                if (index < numbers.Length - 1)
                {
                    Console.Write(stone + ", ");
                }
                else
                {
                    Console.WriteLine(stone);
                }                
            }
        }
    }
}
