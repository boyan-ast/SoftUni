using System;

namespace ThreeupleProblem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLineData = Console.ReadLine().Split();
            string firstName = firstLineData[0];
            string lastName = firstLineData[1];
            string address = firstLineData[2];
            string town = string.Empty;

            for (int i = 3; i < firstLineData.Length; i++)
            {
                town += firstLineData[i];
                town += " ";
            }

            town = town.Trim();

            Threeuple<string, string, string> nameAndAdress =
                new Threeuple<string, string, string>(firstName + " " + lastName, address, town);

            string[] secondLineData = Console.ReadLine().Split();
            string name = secondLineData[0];
            int litersOfBeer = int.Parse(secondLineData[1]);
            bool isDrunk = default;

            if (secondLineData[2] == "drunk")
            {
                isDrunk = true;
            }
            else if (secondLineData[2] == "not")
            {
                isDrunk = false;
            }

            Threeuple<string, int, bool> nameAndBeer = new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);

            string[] thirdLineData = Console.ReadLine().Split();
            string customerName = thirdLineData[0];
            double balance = double.Parse(thirdLineData[1]);
            string bankName = thirdLineData[2];
            Threeuple<string, double, string> cusotmerInfo = new Threeuple<string, double, string>(customerName, balance, bankName);

            Console.WriteLine($"{nameAndAdress.Item1} -> {nameAndAdress.Item2} -> {nameAndAdress.Item3}");
            Console.WriteLine($"{nameAndBeer.Item1} -> {nameAndBeer.Item2} -> {nameAndBeer.Item3}");
            Console.WriteLine($"{cusotmerInfo.Item1} -> {cusotmerInfo.Item2} -> {cusotmerInfo.Item3}");
        }
    }
}
