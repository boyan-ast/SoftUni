using System;

namespace _04.Backin30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int timeInMinutes = hours * 60 + minutes + 30;
            int finalHour = timeInMinutes / 60;

            if (finalHour == 24)
            {
                finalHour = 0;
            }

            int finalMinutes = timeInMinutes % 60;

            Console.WriteLine($"{finalHour}:{finalMinutes:d2}");
        }
    }
}
