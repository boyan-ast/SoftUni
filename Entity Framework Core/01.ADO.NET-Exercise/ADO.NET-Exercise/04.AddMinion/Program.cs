using Microsoft.Data.SqlClient;
using System;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection(Configuration.ConnectionString);

            string[] minionInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] villainInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string villainName = villainInfo[1];

            int townId = FindTownId(minionTown, dbConnection);

            if (townId == -1)
            {
                AddTownToTownsTable(minionTown, dbConnection);
                townId = FindTownId(minionTown, dbConnection);
            }

            int villainId = FindVillainId(villainName, dbConnection);

            if (villainId == -1)
            {
                AddVillainToVillainsTable(villainName, dbConnection);
                villainId = FindVillainId(villainName, dbConnection);
            }

            AddMinionToMinionTable(minionName, minionAge, townId, dbConnection);

            int minionId = FindMinionId(minionName, minionAge, dbConnection);

            AssignMinionToVillain(villainId, minionId, dbConnection);

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

        }

        private static void AssignMinionToVillain(int villainId, int minionId, SqlConnection dbConnection)
        {
            OpenSqlConnection(dbConnection);

            using (dbConnection)
            {
                SqlCommand assignMinionToVillainCommand = new SqlCommand(Queries.AssingMinionToVillain, dbConnection);
                assignMinionToVillainCommand.Parameters.AddWithValue("@minionId", minionId);
                assignMinionToVillainCommand.Parameters.AddWithValue("@villainId", villainId);

                int rowsAffected = assignMinionToVillainCommand.ExecuteNonQuery();

                if (rowsAffected != 1)
                {
                    Console.WriteLine("Minion not assigned to villain! Try again later!");
                    Environment.Exit(1);
                }
            }
        }

        private static int FindMinionId(string minionName, int minionAge, SqlConnection dbConnection)
        {
            int minionId = -1;

            OpenSqlConnection(dbConnection);

            using (dbConnection)
            {
                SqlCommand findMinionIdCommand = new SqlCommand(Queries.FindMinionIdByName, dbConnection);
                findMinionIdCommand.Parameters.AddWithValue("@Name", minionName);
                findMinionIdCommand.Parameters.AddWithValue("@Age", minionAge);

                minionId = (int)findMinionIdCommand.ExecuteScalar();
            }

            return minionId;
        }

        private static void AddMinionToMinionTable(string minionName, int minionAge, int townId, SqlConnection dbConnection)
        {
            OpenSqlConnection(dbConnection);

            using (dbConnection)
            {
                SqlCommand addMinionCommand = new SqlCommand(Queries.AddMinion, dbConnection);
                addMinionCommand.Parameters.AddWithValue("@name", minionName);
                addMinionCommand.Parameters.AddWithValue("@age", minionAge);
                addMinionCommand.Parameters.AddWithValue("@townId", townId);

                int rowsAffected = addMinionCommand.ExecuteNonQuery();

                if (rowsAffected != 1)
                {
                    Console.WriteLine("Minion not added! Try again later!");
                    Environment.Exit(1);
                }
            }
        }

        private static void AddVillainToVillainsTable(string name, SqlConnection dbConnection)
        {
            OpenSqlConnection(dbConnection);

            using (dbConnection)
            {
                SqlCommand addVillainCommand = new SqlCommand(Queries.AddVillain, dbConnection);
                addVillainCommand.Parameters.AddWithValue("@villainName", name);

                int rowsAffected = addVillainCommand.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    Console.WriteLine($"Villain {name} was added to the database.");
                }
                else
                {
                    Console.WriteLine("Villain not added! Try again later!");
                    Environment.Exit(1);
                }
            }
        }

        private static int FindVillainId(string villainName, SqlConnection dbConnection)
        {
            int villainId = -1;

            OpenSqlConnection(dbConnection);

            using (dbConnection)
            {
                SqlCommand findVillainIdCommand = new SqlCommand(Queries.FindVillainIdByName, dbConnection);

                findVillainIdCommand.Parameters.AddWithValue("@Name", villainName);

                object villainIdObject = findVillainIdCommand.ExecuteScalar();

                if (villainIdObject != null)
                {
                    villainId = (int)villainIdObject;
                }                
            }

            return villainId;
        }

        private static void AddTownToTownsTable(string townName, SqlConnection dbConnection)
        {
            OpenSqlConnection(dbConnection);

            using (dbConnection)
            {
                SqlCommand addTownCommand = new SqlCommand(Queries.AddTown, dbConnection);
                addTownCommand.Parameters.AddWithValue("@townName", townName);

                int rowsAffected = addTownCommand.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    Console.WriteLine($"Town {townName} was added to the database.");
                }
                else
                {
                    Console.WriteLine("Town not added! Try again later!");
                    Environment.Exit(1);
                }
            }

        }

        private static int FindTownId(string townName, SqlConnection dbConnection)
        {
            int townId = -1;

            OpenSqlConnection(dbConnection);

            using (dbConnection)
            {
                SqlCommand findTownIdCommand = new SqlCommand(Queries.FindTownIdByName, dbConnection);
                findTownIdCommand.Parameters.AddWithValue("@townName", townName);

                object townIdObject = findTownIdCommand.ExecuteScalar();

                if (townIdObject != null)
                {
                    townId = (int)townIdObject;
                }
            }

            return townId;
        }

        private static void OpenSqlConnection(SqlConnection dbConnection)
        {
            dbConnection.ConnectionString = Configuration.ConnectionString;
            dbConnection.Open();
        }

    }
}
