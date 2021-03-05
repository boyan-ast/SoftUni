using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                string type = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(commandArgs[4]);

                    soldiersById.Add(id, new Private(id, firstName, lastName, salary));
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(commandArgs[4]);

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < commandArgs.Length; i++)
                    {
                        string privateId = commandArgs[i];

                        if (!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        lieutenantGeneral.AddPrivate((IPrivate)soldiersById[privateId]);
                    }

                    soldiersById[id] = lieutenantGeneral;

                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(commandArgs[4]);

                    bool isCorpsValid = Enum.TryParse(commandArgs[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }


                    Commando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commandArgs.Length; i+=2)
                    {
                        string codeName = commandArgs[i];
                        string state = commandArgs[i + 1];

                        bool isMissionStateValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;

                        }

                        Mission mission = new Mission(codeName, missionState);

                        commando.AddMission(mission);

                    }

                    soldiersById[id] = commando;

                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(commandArgs[4]);

                    bool isCorpsValid = Enum.TryParse(commandArgs[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commandArgs.Length; i += 2)
                    {
                        string part = commandArgs[i];
                        int hoursWorked = int.Parse(commandArgs[i + 1]);

                        Repair repair = new Repair(part, hoursWorked);

                        engineer.AddRepair(repair);
                    }

                    soldiersById[id] = engineer;
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(commandArgs[4]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }
            }

            foreach (var soldier in soldiersById)
            {

            }
        }
    }
}
