using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            double sumGrade = 0;
            int presentations = 0;
            string presentationName = string.Empty;

            while ((presentationName = Console.ReadLine()) != "Finish")
            {
                presentations++;
                double sumPresentationGrade = 0;

                for (int i = 0; i < judges; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumPresentationGrade += grade;
                    sumGrade += grade;
                }

                Console.WriteLine($"{presentationName} - {(sumPresentationGrade / judges):f2}.");
            }

            Console.WriteLine($"Student's final assessment is {(sumGrade / (presentations * judges)):f2}.");
        }
    }
}
