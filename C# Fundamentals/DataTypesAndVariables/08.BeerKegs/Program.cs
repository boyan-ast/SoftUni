using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegs = int.Parse(Console.ReadLine());

            string biggestKegModel = string.Empty;
            double biggestKegVolume = 0;

            for (int i = 0; i < kegs; i++)
            {
                string kegModel = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.Pow(radius, 2) * height * Math.PI;

                if (volume > biggestKegVolume)
                {
                    biggestKegVolume = volume;
                    biggestKegModel = kegModel;
                }
            }

            Console.WriteLine(biggestKegModel);
        }
    }
}
