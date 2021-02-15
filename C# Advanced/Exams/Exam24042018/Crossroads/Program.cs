using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Queue<char>> queue = new Queue<Queue<char>>();

            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int passed = 0;

            string command = string.Empty;
            bool hasCrash = false;

            while ((command = Console.ReadLine()) != "END")
            {
                if (hasCrash)
                {
                    continue;
                }

                if (command == "green" && queue.Count > 0)
                {
                    Queue<char> currentCar = queue.Dequeue();
                    string carName = new string(currentCar.ToArray());
                    for (int i = 0; i < greenLight; i++)
                    {
                        if (currentCar.Count > 0)
                        {
                            currentCar.Dequeue();
                            if (currentCar.Count == 0)
                            {
                                passed++;

                                if (queue.Count == 0)
                                {
                                    break;
                                }
                                else if (i < greenLight - 1)
                                {
                                    currentCar = queue.Dequeue();
                                    carName = new string(currentCar.ToArray());
                                }
                            }
                        }
                    }

                    if (currentCar.Count > 0)
                    {
                        for (int i = 0; i < freeWindow; i++)
                        {
                            currentCar.Dequeue();

                            if (currentCar.Count == 0)
                            {
                                passed++;
                                break;
                            }
                        }

                        if (currentCar.Count > 0)
                        {
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{carName} was hit at {currentCar.Dequeue()}.");
                            hasCrash = true;
                        }
                    }


                }
                else
                {
                    Queue<char> car = new Queue<char>(command);
                    queue.Enqueue(car);
                }
            }

            if (!hasCrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passed} total cars passed the crossroads.");
            }
        }
    }
}
