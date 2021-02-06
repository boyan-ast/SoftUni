using System;

namespace TupleProblem
{
    public class StartUp
    {
        static void Main(string[] args)
         {
            string[] firstLineData = Console.ReadLine().Split();
            Tuple<string, string> nameAndAdress =
                new Tuple<string, string>(firstLineData[0] + " " + firstLineData[1], firstLineData[2]);

            string[] secondLineData = Console.ReadLine().Split();
            string name = secondLineData[0];
            int litersOfBeer = int.Parse(secondLineData[1]);
            Tuple<string, int> nameAndBeer = new Tuple<string, int>(name, litersOfBeer);

            string[] thirdLineData = Console.ReadLine().Split();
            int integerNum = int.Parse(thirdLineData[0]);
            double doubleNum = double.Parse(thirdLineData[1]);
            Tuple<int, double> numbers = new Tuple<int, double>(integerNum, doubleNum);
            
            Console.WriteLine($"{nameAndAdress.Item1} -> {nameAndAdress.Item2}");
            Console.WriteLine($"{nameAndBeer.Item1} -> {nameAndBeer.Item2}");
            Console.WriteLine($"{numbers.Item1} -> {numbers.Item2}");
        }
    }
}
