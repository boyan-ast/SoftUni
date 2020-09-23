using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = new string[] { "Invalid day!", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int number = int.Parse(Console.ReadLine());

            if (number < 1 || number > 7)
            {
                number = 0;
            }

            Console.WriteLine(days[number]);
        }
    }
}
