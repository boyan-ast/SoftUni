﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int[] solutions = new int[numbers.Length];
            int[] prev = new int[numbers.Length];

            int maxSolution = 0;
            int maxSolutionIndex = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                int solution = 1;
                int prevIndex = -1;
                int currentNumber = numbers[current];

                for (int solIndex = 0; solIndex < current; solIndex++)
                {
                    int prevNumber = numbers[solIndex];
                    int prevSolution = solutions[solIndex];

                    if (currentNumber > prevNumber
                        && solution < prevSolution + 1)
                    {
                        solution = prevSolution + 1;
                        prevIndex = solIndex;
                    }
                }

                solutions[current] = solution;
                prev[current] = prevIndex;

                if (solution > maxSolution)
                {
                    maxSolution = solution;
                    maxSolutionIndex = current;
                }
            }

            int index = maxSolutionIndex;
            List<int> result = new List<int>();

            while (index != -1)
            {
                int currentNumber = numbers[index];
                result.Add(currentNumber);
                index = prev[index];
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
         }
    }
}