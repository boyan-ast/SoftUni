using System;

namespace _08.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {            
            int kegsNumber = int.Parse(Console.ReadLine());
            string biggestKegModel = String.Empty;
            double biggestKegVolume = 0;

            for (int i = 0; i < kegsNumber; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > biggestKegVolume)
                {
                    biggestKegVolume = volume;
                    biggestKegModel = model;
                }
            }

            Console.WriteLine(biggestKegModel);
        }
    }
}
