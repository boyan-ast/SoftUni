using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Topping test = new Topping("Meat", 500);

                Console.WriteLine(test.Weight * test.CaloriesPerGram);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
