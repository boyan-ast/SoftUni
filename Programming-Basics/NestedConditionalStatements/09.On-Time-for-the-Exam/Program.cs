using System;

namespace _09.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMins = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMins = int.Parse(Console.ReadLine());

            TimeSpan examTime = new TimeSpan(examHour, examMins, 0);
            TimeSpan arrivalTime = new TimeSpan(arrivalHour, arrivalMins, 0);

            TimeSpan timeDifference = examTime - arrivalTime;

            if (timeDifference > new TimeSpan(0, 0, 0) && timeDifference <= new TimeSpan (0, 30, 0))
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{timeDifference.Minutes} minutes before the start");
            }
            else if (timeDifference == new TimeSpan(0, 0, 0))
            {
                Console.WriteLine("On time");
            }
            else if (timeDifference > new TimeSpan(0, 0, 0) && timeDifference > new TimeSpan(0, 30, 0))
            {
                Console.WriteLine("Early");
                if (timeDifference.Hours == 0)
                {
                    Console.WriteLine($"{timeDifference.Minutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{timeDifference.ToString(@"h\:mm")} hours before the start");
                }
            }
            else if (timeDifference < new TimeSpan(0, 0, 0))
            {
                Console.WriteLine("Late");
                if (timeDifference.Hours == 0)
                {
                    Console.WriteLine($"{-timeDifference.Minutes} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{timeDifference.ToString(@"h\:mm")} hours after the start");
                }
            }
        }
    }
}
