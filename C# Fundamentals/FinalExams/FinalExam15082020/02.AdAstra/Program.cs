using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([|#])(?<item>[A-Za-z ]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<cal>(\d{1,4}|10{4}))\1";

            int totalCalories = 0;

            var matches = Regex.Matches(Console.ReadLine(), pattern);

            StringBuilder resultText = new StringBuilder();

            foreach (Match match in matches)
            {
                resultText.AppendLine($"Item: {match.Groups["item"].Value}, Best before: {match.Groups["date"].Value}, " +
                    $"Nutrition: {match.Groups["cal"].Value}");

                totalCalories += int.Parse(match.Groups["cal"].Value);
            }

            int days = totalCalories / 2000;

            resultText.Insert(0, $"You have food to last you for: {days} days!\n");

            Console.WriteLine(resultText.ToString().Trim());
        }
    }
}
