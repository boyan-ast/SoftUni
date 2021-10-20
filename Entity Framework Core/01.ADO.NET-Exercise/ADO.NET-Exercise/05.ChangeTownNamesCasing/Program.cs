using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");

            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand updateTownNames = new SqlCommand(Queries.UpdateTownsToUppercase, dbConnection);
                updateTownNames.Parameters.AddWithValue("@countryName", country);

                int rowsAffected = updateTownNames.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                List<string> updatedTowns = new List<string>();

                SqlCommand selectUpdatedTowns = new SqlCommand(Queries.FindTownByCountry, dbConnection);
                selectUpdatedTowns.Parameters.AddWithValue("@countryName", country);

                SqlDataReader reader = selectUpdatedTowns.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            updatedTowns.Add((string)reader["Name"]);
                        }

                        Console.WriteLine($"{rowsAffected} town names were affected.");
                        Console.Write('[');
                        Console.Write(string.Join(", ", updatedTowns));
                        Console.WriteLine(']');
                    }
                    else
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                }
            }
        }
    }
}
