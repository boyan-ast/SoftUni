using System;

namespace _05.Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallLength = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double wardrobeSide = double.Parse(Console.ReadLine());

            double totalArea = (hallLength * 100) * (hallWidth * 100);
            double wardrobeArea = (wardrobeSide * 100) * (wardrobeSide * 100);
            double benchArea = totalArea / 10;

            double freeArea = totalArea - wardrobeArea - benchArea;

            int dancers = (int)Math.Floor(freeArea / (7000 + 40));

            Console.WriteLine(dancers);
        }
    }
}
