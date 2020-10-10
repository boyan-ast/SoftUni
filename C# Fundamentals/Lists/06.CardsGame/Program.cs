using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string winner = string.Empty;
            int sum = 0;

            while (true)
            {
                if (firstDeck.Count == 0)
                {
                    winner = "Second";
                    sum = secondDeck.Sum();
                    break;
                }
                else if (secondDeck.Count == 0)
                {
                    winner = "First";
                    sum = firstDeck.Sum();
                    break;
                }

                PlayTheGame(firstDeck, secondDeck);               
            }

            Console.WriteLine($"{winner} player wins! Sum: {sum}");
        }

        static void PlayTheGame(List<int> firstDeck, List<int> secondDeck)
        {
            int firstPlayerCard = firstDeck[0];
            int secondPlayerCard = secondDeck[0];

            firstDeck.RemoveAt(0);
            secondDeck.RemoveAt(0);

            if (firstPlayerCard > secondPlayerCard)
            {
                firstDeck.Add(firstPlayerCard);
                firstDeck.Add(secondPlayerCard);
            }
            else if (secondPlayerCard > firstPlayerCard)
            {
                secondDeck.Add(secondPlayerCard);
                secondDeck.Add(firstPlayerCard);
            }
        }
    }
}
