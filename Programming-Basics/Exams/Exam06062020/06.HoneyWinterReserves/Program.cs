using System;

namespace _06.HoneyWinterReserves
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededHoney = double.Parse(Console.ReadLine());
            string beeName = String.Empty;
            bool isSuccessful = false;

            while ((beeName = Console.ReadLine()) != "Winter has come")
            {
                double honeyPerBee = 0;                

                for (int i = 0; i < 6; i++)
                {
                    double honeyPerMonth = double.Parse(Console.ReadLine());
                    honeyPerBee += honeyPerMonth;
                }

                if (honeyPerBee < 0)
                {
                    Console.WriteLine($"{beeName} was banished for gluttony");
                }

                neededHoney -= honeyPerBee;

                if (neededHoney <= 0)
                {
                    isSuccessful = true;
                    break;
                }
            }

            if (isSuccessful)
            {
                Console.WriteLine($"Well done! Honey surplus {Math.Abs(neededHoney):f2}.");
            }
            else
            {
                Console.WriteLine($"Hard Winter! Honey needed {neededHoney:f2}.");
            }
        }
    }
}
