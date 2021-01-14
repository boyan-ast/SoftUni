using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<Queue<char>> cars = new Queue<Queue<char>>();
            int count = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green" && cars.Count > 0)
                {
                    Queue<char> currentCar = cars.Dequeue();
                    string carName = new string(currentCar.ToArray());

                    for (int i = 0; i < greenLight; i++)
                    {
                        currentCar.Dequeue();

                        if (currentCar.Count == 0)
                        {
                            count++;

                            if (cars.Count > 0 && i != greenLight - 1)
                            {
                                currentCar = cars.Dequeue();
                                carName = new string(currentCar.ToArray());
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (currentCar.Count > 0)
                    {
                        for (int j = 0; j < freeWindow; j++)
                        {
                            currentCar.Dequeue();

                            if (currentCar.Count == 0)
                            {
                                count++;
                                break;
                            }
                        }

                        if (currentCar.Count > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carName} was hit at {currentCar.Dequeue()}.");
                            return;
                        }
                    }
                }
                else if(command != "green")
                {
                    Queue<char> carNameAsQueue = new Queue<char>(command);
                    cars.Enqueue(carNameAsQueue);
                }            


            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}
