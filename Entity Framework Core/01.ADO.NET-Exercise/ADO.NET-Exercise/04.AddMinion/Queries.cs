using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddMinion
{
    public static class Queries
    {
        public const string FindTownIdByName = @"SELECT Id FROM Towns WHERE Name = @townName";

        public const string AddTown = @"INSERT INTO Towns (Name) VALUES (@townName)";

        public const string FindVillainIdByName = @"SELECT Id FROM Villains WHERE Name = @Name";

        public const string AddVillain = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string AddMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public const string FindMinionIdByName = @"SELECT Id FROM Minions WHERE Name = @Name AND Age = @Age";

        public const string AssingMinionToVillain = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
    }
}
