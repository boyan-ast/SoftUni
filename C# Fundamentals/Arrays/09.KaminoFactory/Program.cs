using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());

            int bestSequenceCounter = -1;
            int bestSequenceIndex = -1;
            int bestSequenceSum = 0;
            int[] bestSequence = new int[sequenceLength];
            int bestSequenceNumber = 0;
            int sequenceNumber = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Clone them!")
            {
                int[] sequence = command.Split("!",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sequenceNumber++;

                int bestSubsequenceIndex = -1;
                int sequenceSum = 0;

                int bestSubsequenceCounter = 0;
                int subsequenceCounter = 0;

                for (int i = 0; i < sequenceLength; i++)
                {
                    if (sequence[i] == 1)
                    {
                        subsequenceCounter++;
                        sequenceSum++;

                        if (subsequenceCounter > bestSubsequenceCounter)
                        {
                            bestSubsequenceCounter = subsequenceCounter;
                            bestSubsequenceIndex = i - subsequenceCounter + 1;
                        }
                    }
                    else
                    {
                        subsequenceCounter = 0;
                    }
                }

                if (bestSubsequenceCounter > bestSequenceCounter)
                {
                    bestSequenceCounter = bestSubsequenceCounter;
                    bestSequenceIndex = bestSubsequenceIndex;
                    bestSequenceSum = sequenceSum;
                    bestSequence = sequence;
                    bestSequenceNumber = sequenceNumber;
                }
                else if (bestSubsequenceCounter == bestSequenceCounter && bestSubsequenceIndex < bestSequenceIndex)
                {
                    bestSequenceIndex = bestSubsequenceIndex;
                    bestSequenceSum = sequenceSum;
                    bestSequence = sequence;
                    bestSequenceNumber = sequenceNumber;
                }
                else if (bestSubsequenceCounter == bestSequenceCounter && bestSubsequenceIndex == bestSequenceIndex && bestSequenceSum < sequenceSum)
                {
                    bestSequenceSum = sequenceSum;
                    bestSequence = sequence;
                    bestSequenceNumber = sequenceNumber;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSequenceNumber} with sum: {bestSequenceSum}.");
            Console.WriteLine(String.Join(" ", bestSequence));

        }
    }
}
