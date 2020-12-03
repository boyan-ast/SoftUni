using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>();

            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string pieceName = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                pieces.Add(pieceName, new[] { composer, key });
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandArgs = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string pieceName = commandArgs[1];

                switch (action)
                {
                    case "Add":
                        string composer = commandArgs[2];
                        string key = commandArgs[3];

                        if (pieces.ContainsKey(pieceName))
                        {
                            Console.WriteLine($"{pieceName} is already in the collection!");
                        }
                        else
                        {
                            pieces.Add(pieceName, new[] { composer, key });
                            Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                        }
                        break;
                    case "Remove":
                        if (pieces.ContainsKey(pieceName))
                        {
                            pieces.Remove(pieceName);
                            Console.WriteLine($"Successfully removed {pieceName}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = commandArgs[2];

                        if (pieces.ContainsKey(pieceName))
                        {
                            pieces[pieceName][1] = newKey;
                            Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var kvp in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value[0]}, Key: {kvp.Value[1]}");
            }
        }
    }
}
