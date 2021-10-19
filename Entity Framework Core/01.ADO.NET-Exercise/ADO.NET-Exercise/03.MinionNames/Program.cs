using Microsoft.Data.SqlClient;
using System;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            con.Open();

            using (con)
            {
                int villainId = int.Parse(Console.ReadLine());

                SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM Villains WHERE Id = @villainId", con);

                countCommand.Parameters.AddWithValue("@villainId", villainId);

                int count = (int)countCommand.ExecuteScalar();

                if (count > 0)
                {
                    SqlCommand command = new SqlCommand(@$"
                        SELECT v.Name as VillainName,
	                        m.Name as MinionName,
	                        m.Age as MinionAge
                        FROM Villains v
                        JOIN MinionsVillains mv ON mv.VillainId = v.Id
                        JOIN Minions m ON m.Id = mv.MinionId
                        WHERE v.Id = @id
                        ORDER BY MinionName", con);

                    command.Parameters.AddWithValue("@id", villainId);

                    SqlCommand villainNameCommand = new SqlCommand("SELECT Name FROM Villains WHERE id = @id", con);

                    villainNameCommand.Parameters.AddWithValue("@id", villainId);

                    string villainName = villainNameCommand.ExecuteScalar() as string;

                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        Console.WriteLine($"Villian: {villainName}");

                        if (reader.Read())
                        {
                            int index = 1;

                            PrintMinion(index, (string)reader["MinionName"], (int)reader["MinionAge"]);

                            while (reader.Read())
                            {
                                index++;
                                PrintMinion(index, (string)reader["MinionName"], (int)reader["MinionAge"]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
            }
        }

        static void PrintMinion(int index, string minionName, int minionAge)
        {
            Console.WriteLine($"{index}. {minionName} {minionAge}");
        }
    }
}
