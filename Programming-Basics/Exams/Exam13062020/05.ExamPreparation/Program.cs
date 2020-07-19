using System;

namespace _05.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int problems = int.Parse(Console.ReadLine());
            int trainerEnergy = int.Parse(Console.ReadLine());

            int problemsSolved = 0;
            int questions = 0;
            bool trainerWins = false;

            while (trainerEnergy >= 0)
            {
                problemsSolved += problems;

                trainerEnergy += problems * 2;
                students -= problems;

                questions += students * 2;

                trainerEnergy -= students * 2 * 3;

                if (students < 10)
                {
                    trainerWins = true;
                    break;
                }

                int newStudents = students / 10;
                students += newStudents;
            }

            if (trainerWins)
            {
                Console.WriteLine("The students are too few!");
                Console.WriteLine($"Problems solved: {problemsSolved}");
            }
            else
            {
                Console.WriteLine("The trainer is too tired!");
                Console.WriteLine($"Questions asked: {questions}");
            }
        }
    }
}
