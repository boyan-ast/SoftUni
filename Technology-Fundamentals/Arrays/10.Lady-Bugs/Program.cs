using System;
using System.Linq;

namespace _10.Lady_Bugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] initialIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[size];

            for (int i = 0; i < initialIndexes.Length; i++)
            {
                if (initialIndexes[i] >= 0 && initialIndexes[i] < size)
                {
                    field[initialIndexes[i]] = 1;
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split();
                int startIndex = int.Parse(tokens[0]);
                int flyLength = int.Parse(tokens[2]);
                string direction = tokens[1];


                if ((startIndex < 0 || startIndex >= size) || 
                    flyLength == 0 || 
                    field[startIndex] == 0)
                {
                    continue;
                }

                int endIndex = 0;

                if (direction == "right")
                {
                    endIndex = startIndex + flyLength;
                }
                else if (direction == "left")
                {
                    endIndex = startIndex - flyLength;
                }

                if (endIndex < 0 || endIndex >= size)
                {
                    field[startIndex] = 0;
                    continue;
                }

                if (field[endIndex] == 0)
                {
                    field[startIndex] = 0;
                    field[endIndex] = 1;                    
                }
                else
                {
                    while (true)
                    {
                        if (direction == "right")
                        {
                            endIndex = endIndex + flyLength;
                        }
                        else if (direction == "left")
                        {
                            endIndex = endIndex - flyLength;
                        }

                        if (endIndex < 0 || endIndex >= size)
                        {                            
                            break;
                        }

                        if (field[endIndex] == 0)
                        {
                            field[endIndex] = 1;
                            break;
                        }
                    }

                    field[startIndex] = 0;
                }

            }

            Console.WriteLine(string.Join(' ', field));

        }
    }
}
