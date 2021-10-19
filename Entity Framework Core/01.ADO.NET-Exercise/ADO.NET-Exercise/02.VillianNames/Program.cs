using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _02.VillianNames
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true");
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand command = new SqlCommand(@"select 
	                                                    v.Name,
	                                                    COUNT(mv.MinionId) as MinionsCount
                                                    from Villains v
                                                    left join MinionsVillains mv on v.Id = mv.VillainId
                                                    group by v.Name
                                                    -- having COUNT(mv.MinionId) > 3
                                                    order by COUNT(mv.MinionId) desc", dbConnection);

                SqlDataReader dataReader = command.ExecuteReader();

                using (dataReader)
                {
                    StringBuilder result = new StringBuilder();

                    while (dataReader.Read())
                    {
                        result.AppendLine($"{(string)dataReader["Name"]} - {(int)dataReader["MinionsCount"]}");
                    }

                    
                    Console.WriteLine(result.ToString().Trim());
                }

            }
        }
    }
}
