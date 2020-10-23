using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            if (lectures == 0 || students == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            double maxBonus = double.MinValue;
            int maxBonusAttendances = int.MinValue;

            for (int i = 0; i < students; i++)
            {
                int attendances = int.Parse(Console.ReadLine());

                double bonus = attendances * 1.0 / lectures * (5 + initialBonus);

                if (bonus > maxBonus)
                {
                    maxBonus = bonus;
                    maxBonusAttendances = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxBonusAttendances} lectures.");
        }
    }
}
