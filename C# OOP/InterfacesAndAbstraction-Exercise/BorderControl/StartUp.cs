using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs.Length == 3)
                {
                    string name = commandArgs[0];
                    int age = int.Parse(commandArgs[1]);
                    string id = commandArgs[2];
                    Citizen citizen = new Citizen(name, age, id);
                    identifiables.Add(citizen);
                }
                else if (commandArgs.Length == 2)
                {
                    string model = commandArgs[0];
                    string id = commandArgs[1];
                    Robot robot = new Robot(model, id);
                    identifiables.Add(robot);
                }
            }

            string fakeId = Console.ReadLine();

            string[] fakeIds = identifiables
                .Where(x => x.Id.EndsWith(fakeId))
                .Select(x => x.Id)
                .ToArray();

            foreach (string id in fakeIds)
            {
                Console.WriteLine(id);
            }
        }
    }
}
