using System;
using System.Data.SqlClient;

namespace WAD22_ADO_Exo2
{
    class Program
    {
            static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True"; 
        static void Main(string[] args)
        {
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
                            Console.WriteLine($"{reader["id"]}.{reader["nom"]} : {reader["description"]}");
                        }
                    }
                    
                }
            }
        }
    }
}
