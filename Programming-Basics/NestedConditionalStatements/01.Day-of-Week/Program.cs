using System;

namespace _01.Day_of_Week
{
    class Program
    {
        public static string[] days =
        {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
        };
        static void Main(string[] args)
        {
            int dayOfWeek = int.Parse(Console.ReadLine());

            PrintDayOfWeek(dayOfWeek);
        }
        private static void PrintDayOfWeek(int day)
        {
            switch (day)
            {
                case 1:
                    Console.WriteLine(days[0]);
                    break;
                case 2:
                    Console.WriteLine(days[1]);
                    break;
                case 3:
                    Console.WriteLine(days[2]);
                    break;
                case 4:
                    Console.WriteLine(days[3]);
                    break;
                case 5:
                    Console.WriteLine(days[4]);
                    break;
                case 6:
                    Console.WriteLine(days[5]);
                    break;
                case 7:
                    Console.WriteLine(days[6]);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
