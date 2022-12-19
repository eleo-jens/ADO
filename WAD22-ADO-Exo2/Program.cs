using System;
using System.Data.SqlClient;
using WAD22_ADO_Exo2.Models;

namespace WAD22_ADO_Exo2
{
    class Program
    {
        #region Exercice 2 Mode connecté
        //static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True"; 
        //static void Main(string[] args)
        //{
        //    Spectacle sp1 = new Spectacle();
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand command = connection.CreateCommand())
        //        {
        //            command.CommandText = "SELECT * FROM [spectacle]";

        //            connection.Open();

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    //Console.WriteLine($"{reader["id"]}.{reader["nom"]} : {reader["description"]}");
        //                    sp1.id = (int)reader["id"];
        //                    sp1.nom = (string)reader["nom"];
        //                    sp1.description = (string)reader["description"];
        //                }
        //            }
        //        }
        //    }

        //    Console.WriteLine($"{sp1.id}. {sp1.nom} : {sp1.description}");
        //}
        #endregion

        #region Exercice 3 DML

        static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True";

        static void Main(string[] args)
        {
            Spectacle sp = new Spectacle();
            sp.nom = "Roméo et Juliette";
            sp.description = "Pièce de William Shakespeare";

            Representation RJ1 = new Representation();
            Representation RJ2 = new Representation();
            RJ1.dateRepresentation = new DateTime(2022,12,24);
            RJ1.heureRepresentation = new DateTime(1, 1, 1, 18, 0, 0);
            RJ2.dateRepresentation = new DateTime(2022,12,31);
            RJ2.heureRepresentation = new DateTime(1,1,1, 16,0,0);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //@ permet le retour à la ligne
                    command.CommandText = @"INSERT INTO [Representation] 
                                            ([dateRepresentation], [heureRepresentation], [idSpectacle]) 
                                        VALUES ('2022-12-20', '8:45', 1), 
                                               ('2022-12-20', '10:45', 1)";
                    connection.Open();
                    int nbLignes = command.ExecuteNonQuery();
                    Console.WriteLine($"Il y a {nbLignes} nouvelle(s) représentation(s) de l'inauguration.");
                    connection.Close();
                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @$"INSERT INTO [spectacle] 
                                            ([nom], [description])
                                            OUTPUT [inserted].[id]
                                            VALUES ('{sp.nom}', '{sp.description}')";
                    connection.Open();
                    sp.id = (int)command.ExecuteScalar();

                    RJ1.idSpectacle = sp.id;
                    RJ2.idSpectacle = sp.id;
                    connection.Close();
                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    //Console.WriteLine(RJ1.dateRepresentation.Date.ToString("yyyy-MM-dd"));
                    //Console.WriteLine(RJ1.heureRepresentation.TimeOfDay);
                    command.CommandText = @$"INSERT INTO [Representation] 
                                            ([idSpectacle], [dateRepresentation], [heureRepresentation])
                                            OUTPUT [inserted].[id]
                                            VALUES ({RJ1.idSpectacle}, '{RJ1.dateRepresentation.Date.ToString("yyyy-MM-dd")}',        '{RJ1.heureRepresentation.TimeOfDay}'),
                                                    ({RJ2.idSpectacle}, '{RJ2.dateRepresentation.Date.ToString("yyyy-MM-dd")}',        '{RJ2.heureRepresentation.TimeOfDay}')";
                    connection.Open();
                    int nbLignes = command.ExecuteNonQuery();
                    Console.WriteLine($"Le nombre de lignes affectées : {nbLignes}");
                    connection.Close();
                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE [spectacle]
                                            SET [description] = 'Réception d''inauguration seulement sur invitation'
                                            OUTPUT [inserted].[id]
                                            WHERE [nom] = 'Inauguration'";

                    connection.Open();

                    int id = (int)command.ExecuteScalar();
                    Console.WriteLine($"Le spectacle {id} a été modifié.");
                    connection.Close();
                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE [Representation]
                                            OUTPUT [deleted].[id], [deleted].[heureRepresentation], [deleted].[dateRepresentation], [deleted].[idSpectacle]
                                            WHERE [idSpectacle] = 1";

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Suppression de la répresentation du spectacle {reader["idSpectacle"]} du {reader["dateRepresentation"]} à {reader["heureRepresentation"]}");
                        }
                    }
                }
            }
        }

        #endregion
    }
}
