using System;
using System.Data.SqlClient;
using WAD22_ADO_Exo2.Models;

namespace WAD22_ADO_Exo2
{
    class Program
    {
        static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True"; 
        static void Main(string[] args)
        {
            Spectacle sp1 = new Spectacle();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [spectacle]";

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine($"{reader["id"]}.{reader["nom"]} : {reader["description"]}");
                            sp1.id = (int)reader["id"];
                            sp1.nom = (string)reader["nom"];
                            sp1.description = (string)reader["description"];
                        }
                    }
                }
            }

            Console.WriteLine($"{sp1.id}. {sp1.nom} : {sp1.description}");
        }
    }
}
