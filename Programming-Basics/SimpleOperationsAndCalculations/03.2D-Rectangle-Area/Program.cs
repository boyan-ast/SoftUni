using System;
using System.Transactions;

namespace _03._2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double length = Math.Abs(x2 - x1);
            double width = Math.Abs(y2 - y1);

            double area = length * width;
            double perimeter = (length + width) * 2;

            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{perimeter:f2}");
        }
    }
}
