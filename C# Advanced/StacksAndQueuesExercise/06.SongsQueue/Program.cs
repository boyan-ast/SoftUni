using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsQueue = new Queue<string>(Console.ReadLine().Split(", "));

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    string song = command.Substring(4);

                    if (!songsQueue.Contains(song))
                    {
                        songsQueue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
