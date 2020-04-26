using System;

namespace _01.Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalTime = firstTime + secondTime + thirdTime;
            TimeSpan time = TimeSpan.FromSeconds(totalTime);

            Console.WriteLine(time.ToString(@"m\:ss"));
        }
    }
}
