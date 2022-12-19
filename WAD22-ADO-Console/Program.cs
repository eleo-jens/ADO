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
                #region Mode déconnecté (Je risque de perdre la connexion, par exemple en mobile, je charge le tout avant utilisation)
                //using (SqlCommand command = connection.CreateCommand())
                //{
                //    command.CommandText = "SELECT * FROM [Type]";

                //    SqlDataAdapter adapter = new SqlDataAdapter(command);

                //    DataTable table_type = new DataTable();

                //    adapter.Fill(table_type);

                //    foreach (DataRow row in table_type.Rows)
                //    {
                //        Console.WriteLine($"{row["id"]}. {row["nom"]} : {row["prix"]}€");
                //    }
                //}
                #endregion

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

                #region Ordres DML (toujours en Mode Connecté)
                    #region INSERT avec ExecuteNonQuery() : récupération nb de lignes affectées
                    //using (SqlCommand command = connection.CreateCommand())
                    //{
                    //     @ permet le retour à la ligne
                    //    command.CommandText = @"INSERT INTO [Representation] 
                    //                                ([dateRepresentation], [heureRepresentation], [idSpectacle]) 
                    //                            VALUES ('2022-12-20', '8:45', 1), 
                    //                                   ('2022-12-20', '10:45', 1)";
                    //    connection.Open();
                    //    int nbLignes = command.ExecuteNonQuery();
                    //    Console.WriteLine($"Il y a {nbLignes} nouvelle(s) représentation(s) de l'inauguration.");
                    //}
                    #endregion

                    #region UPDATE avec ExecuteScalar() : récupération d'info par l'OUTPUT
                    //using (SqlCommand command = connection.CreateCommand())
                    //{
                    //    // @ permet le retour à la ligne
                    //    command.CommandText = @"UPDATE [Representation] 
                    //                            SET [heureRepresentation] = '12:15'
                    //                            OUTPUT [deleted].[id]
                    //                            WHERE [idSpectacle] = 1
                    //                                AND [heureRepresentation] = '8:45'";
                    //    connection.Open();
                    //int? id = (int?)command.ExecuteScalar();
                    //if (id is null) Console.WriteLine("Aucune mise à jour");
                    //    Console.WriteLine($"La réprésentation numéro {id} a été reporté à 12h15.");
                    //}
                    #endregion

                    #region DELETE avec ExecuteReader() : récupération d'info par l'OUTPUT
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        // @ permet le retour à la ligne
                        command.CommandText = @"DELETE FROM [Representation] 
                                                    OUTPUT [deleted].[id],
                                                           [deleted].[dateRepresentation],
                                                           [deleted].[heureRepresentation]";
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine($"Les représentations supprimées sont: ");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["id"]}: {reader["dateRepresentation"]} - {reader["heureRepresentation"]}");
                            }
                        }

                    }
                    #endregion
                #endregion

            }
        }
    }
}
