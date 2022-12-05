using System;
using System.Data;
using System.Data.SqlClient;

namespace WAD22_ADO_Console
{
    class Program
    {
        static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True";
        static void Main(string[] args)
        {
            // Permet d'avoir la console en unicode (pour afficher les €)
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // enveloppe
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                #region Mode Connecté (J'ai possibilité de contacter mon serveur)
                #region ExcecuteScalar() => récupération d'une seule information
                //courrier à mettre dans l'enveloppe
                //using (SqlCommand command = connection.CreateCommand())
                //{
                //    //paramérer la commande SQL
                //    command.CommandText = "SELECT [nom] FROM [Type] where id = 1";

                //    //ouvrir la connexion
                //    connection.Open();
                //    Console.WriteLine(connection.State);

                //    // Exécuter la commande
                //    string ticketTypeName = (string)command.ExecuteScalar();
                //    Console.WriteLine(ticketTypeName);
                //}
                #endregion

                #region ExecuteReader() => récupération de multiple informations
                //using (SqlCommand command = connection.CreateCommand())
                //{
                //    //prépare la commande SQL
                //    command.CommandText = "SELECT * FROM [TYPE]";

                //    // Exécution de la commande
                //    connection.Open();

                //    using (SqlDataReader reader = command.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            //Console.WriteLine($"{reader[0]}.{reader[1]}:{reader[2]} €");
                //            Console.WriteLine($"{reader["id"]}. {reader["nom"]} : {reader["prix"]} €");
                //        }
                //    }
                //}
                #endregion
                #endregion
                #region Mode déconnecté (Je risque de perdre la connexion, par exemple en mobile, je charge le tout avant utilisation)
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Type]";

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable table_type = new DataTable();

                    adapter.Fill(table_type);

                    foreach (DataRow row in table_type.Rows)
                    {
                        Console.WriteLine($"{row["id"]}. {row["nom"]} : {row["prix"]}€");
                    }
                }
                #endregion
            }
        }
    }
}
