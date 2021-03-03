using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());

            IDrawable circle = new Circle(radius);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            IDrawable rectangle = new Rectangle(width, height);

            List<IDrawable> drawableObjects = new List<IDrawable>()
            {
                circle,
                rectangle
            };

            foreach (IDrawable drawable in drawableObjects)
            {
                drawable.Draw();
            }
        }
    }
}
