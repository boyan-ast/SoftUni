using System;
using System.Linq;

namespace _09.Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string command = string.Empty;

            int bestSubsequenceLength = -1;
            int bestSubsequenceIndex = -1;
            int bestSubsequenceSum = 0;

            int[] bestSequence = new int[length];

            int counter = 0;
            int bestCounter = 0;

            while ((command = Console.ReadLine()) != "Clone them!")
            {
                int[] sequence = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                counter++;

                int subsequenceMaxLength = 0;
                int subsequenceMaxIndex = -1;
                int subsequenceMaxSum = 0;
                int subsequenceLength = 0;


                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == 1)
                    {
                        subsequenceLength++;
                        subsequenceMaxSum++;   

                        if (subsequenceLength > subsequenceMaxLength)
                        {
                            subsequenceMaxIndex = i - subsequenceLength;
                            subsequenceMaxLength = subsequenceLength;
                        }
                    }
                    else
                    {
                        subsequenceLength = 0;
                    }

                }

                if (subsequenceMaxLength > bestSubsequenceLength)
                {
                    bestSubsequenceLength = subsequenceMaxLength;
                    bestSubsequenceIndex = subsequenceMaxIndex;
                    bestSubsequenceSum = subsequenceMaxSum;
                    bestSequence = sequence;
                    bestCounter = counter;
                }
                else if (subsequenceMaxLength == bestSubsequenceLength 
                    && subsequenceMaxIndex < bestSubsequenceIndex)
                {
                    bestSubsequenceIndex = subsequenceMaxIndex;
                    bestSubsequenceSum = subsequenceMaxSum;
                    bestSequence = sequence;
                    bestCounter = counter;
                }
                else if (subsequenceMaxLength == bestSubsequenceLength
                    && subsequenceMaxIndex == bestSubsequenceIndex
                    && subsequenceMaxSum > bestSubsequenceSum)
                {                    
                    bestSubsequenceSum = subsequenceMaxSum;
                    bestSequence = sequence;
                    bestCounter = counter;
                }
            }

            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSubsequenceSum}.");
            Console.WriteLine(string.Join(' ', bestSequence));
        }
    }
}
