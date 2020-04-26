using System;

namespace _04.Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputDim = Console.ReadLine();
            string outputDim = Console.ReadLine();

            double resultInMeters = 0;

            if (inputDim == "m")
            {
                resultInMeters = number;
            }
            else if (inputDim == "cm")
            {
                resultInMeters = number / 100;
            }
            else if (inputDim == "mm")
            {
                resultInMeters = number / 1000;
            }

            double result = 0;

            if (outputDim == "m")
            {
                result = resultInMeters;
            }
            else if (outputDim == "cm")
            {
                result = resultInMeters * 100;
            }
            else if (outputDim == "mm")
            {
                result = resultInMeters * 1000;
            }

            Console.WriteLine($"{result:f3}");
        }
    }
}
