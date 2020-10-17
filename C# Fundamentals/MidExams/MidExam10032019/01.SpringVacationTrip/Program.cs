using System;

namespace _01.SpringVacationTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelPerKm = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());
            double roomPricePerPerson = double.Parse(Console.ReadLine());

            double foodExpenses = foodPerPerson * people * days;
            double hotelExpenses = roomPricePerPerson * people * days;

            if (people > 10)
            {
                hotelExpenses *= 0.75;
            }

            bool enoughMoney = true;

            double currentExpenses = foodExpenses + hotelExpenses;

            for (int day = 1; day <= days; day++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());

                double moneyForFuel = travelledDistance * fuelPerKm;

                currentExpenses += moneyForFuel;

                if (day % 3 == 0 || day % 5 == 0)
                {
                    currentExpenses *= 1.4;
                }

                if (day % 7 == 0)
                {
                    double receivedMoney = currentExpenses / people;
                    currentExpenses -= receivedMoney;
                }

                if (currentExpenses > budget)
                {
                    enoughMoney = false;
                    break;
                }
            }

            if (enoughMoney)
            {
                Console.WriteLine($"You have reached the destination. You have {(budget - currentExpenses):f2}$ budget left.");
            }
            else
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {(currentExpenses - budget):f2}$ more.");
            }
        }
    }
}
