using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Shape rectangle = new Rectangle(4, 10);

            shapes.Add(rectangle);

            Shape circle = new Circle(10);

            shapes.Add(circle);

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Draw());
                Console.WriteLine($"{shape.CalculateArea():f2}");
                Console.WriteLine($"{shape.CalculatePerimeter():f2}");
            }
        }
    }
}
