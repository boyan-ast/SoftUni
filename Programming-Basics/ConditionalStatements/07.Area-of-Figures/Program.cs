using System;

namespace _07.Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;

            switch (figure)
            {
                case "square":
                    double side = double.Parse(Console.ReadLine());
                    area = Math.Pow(side, 2);
                    break;
                case "rectangle":
                    double firstSide = double.Parse(Console.ReadLine());
                    double secondSide = double.Parse(Console.ReadLine());
                    area = firstSide * secondSide;
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    area = Math.PI * radius * radius;
                    break;
                case "triangle":
                    double sideA = double.Parse(Console.ReadLine());
                    double heightA = double.Parse(Console.ReadLine());
                    area = sideA * heightA * 0.5;
                    break;
                default:
                    break;
            }

            Console.WriteLine("{0:f3}", area);
        }
    }
}
