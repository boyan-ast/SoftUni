using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] doughtInfo = command.Split();

                try
                {
                    Dough dough = new Dough(doughtInfo[1], doughtInfo[2], double.Parse(doughtInfo[3]));
                    Console.WriteLine($"{dough.CalculateCalories():f2}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
