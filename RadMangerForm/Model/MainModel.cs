﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace RadMangerForm.Model
{
    public class MainModel
    {
        // Connection string to connect to the database
        string _connectionString = "server=localhost;database=RadManager;uid=root;pwd=radmanager";


        public MainModel() //ctor is empty
        {
        }

        /// <summary>
        /// Loads all Strecken from the database
        /// </summary>
        /// <returns></returns>
        public List<Strecke> LoadButtonClicked() // Load all Strecken from DB
        {
            string query = "SELECT StreckenID, Name, Länge, Dauer, Schwierigkeitsgrad, TrinkbrunnenID, BelagID, BundeslandID FROM Strecken";

            List<Strecke> strecken = new List<Strecke>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Verbindung aufbauen     

                using (MySqlCommand command = new MySqlCommand(query, connection)) // SQL-Befehl senden
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Strecke strecke = new Strecke
                            {
                                StreckenID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Länge = reader.GetInt32(2),
                                Dauer = reader.GetTimeSpan(3),
                                Schwierigkeitsgrad = reader.GetInt32(4),
                                TrinkbrunnenID = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                                BelagID = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                BundeslandID = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7)
                            };
                            strecken.Add(strecke);
                        }
                    }
                }
            }

            return strecken;
        }
        /// <summary>
        /// Loads a Strecke by its Id
        /// </summary>
        /// <param name="streckenId"></param>
        /// <returns></returns>
        public Strecke LoadStreckeById(int? streckenId)
        {
            if(streckenId == null)
            {
                return null;
            }
            string query = "SELECT StreckenID, Name, Länge, Dauer, Schwierigkeitsgrad, TrinkbrunnenID, BelagID, BundeslandID FROM Strecken WHERE StreckenID = @StreckenID";

            Strecke strecke = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Verbindung aufbauen

                using (MySqlCommand command = new MySqlCommand(query, connection)) // SQL-Befehl senden
                {
                    command.Parameters.AddWithValue("@StreckenID", streckenId); // Parameter hinzufügen

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            strecke = new Strecke
                            {
                                StreckenID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Länge = reader.GetInt32(2),
                                Dauer = reader.GetTimeSpan(3),
                                Schwierigkeitsgrad = reader.GetInt32(4),
                                TrinkbrunnenID = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                                BelagID = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                BundeslandID = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7)
                            };
                        }
                    }
                }
            }

            return strecke;
        }
        /// <summary>
        /// Adds a new Strecke to the database
        /// </summary>
        /// <param name="neueStrecke"></param>
        public void AddStrecke(Strecke neueStrecke)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"
                 INSERT INTO Strecken (Name, Länge, Dauer, Schwierigkeitsgrad, BundeslandID, TrinkbrunnenID, BelagID)
                 VALUES (@Name, @Länge, @Dauer, @Schwierigkeitsgrad, @BundeslandID, @TrinkbrunnenID, @BelagID)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", neueStrecke.Name);
                    command.Parameters.AddWithValue("@Länge", neueStrecke.Länge);
                    command.Parameters.AddWithValue("@Dauer", neueStrecke.Dauer);
                    command.Parameters.AddWithValue("@Schwierigkeitsgrad", neueStrecke.Schwierigkeitsgrad);
                    command.Parameters.AddWithValue("@BundeslandID", neueStrecke.BundeslandID.HasValue ? (object)neueStrecke.BundeslandID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@TrinkbrunnenID", neueStrecke.TrinkbrunnenID.HasValue ? (object)neueStrecke.TrinkbrunnenID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@BelagID", neueStrecke.BelagID.HasValue ? (object)neueStrecke.BelagID.Value : DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// This method is called when the search button is clicked. It searches for a Strecke by its name
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public List<Strecke> SearchButtonClicked(string userInput)
        {
            string query = "SELECT StreckenID, Name, Länge, Dauer, Schwierigkeitsgrad, TrinkbrunnenID, BelagID, BundeslandID " +
                "FROM Strecken " +
                "WHERE Name " +
                "LIKE @Name";

            List<Strecke> strecken = new List<Strecke>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Verbindung aufbauen     

                using (MySqlCommand command = new MySqlCommand(query, connection)) // SQL-Befehl senden
                {
                    // Parameter hinzufügen, um SQL-Injection zu vermeiden
                    command.Parameters.AddWithValue("@Name", userInput + "%"); //hier das % Zeichen ist für die Suche nach dem Anfang des Namens

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Strecke strecke = new Strecke
                            {
                                StreckenID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Länge = reader.GetInt32(2),
                                Dauer = reader.GetTimeSpan(3),
                                Schwierigkeitsgrad = reader.GetInt32(4),
                                TrinkbrunnenID = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                                BelagID = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                BundeslandID = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7)
                            };
                            strecken.Add(strecke);
                        }
                    }
                }
            }

            return strecken;
        }
        /// <summary>
        /// Delets a Strecke from the database
        /// </summary>
        /// <param name="streckenId">Id from Strecke</param>
        public void DeleteStrecke(int? streckenId)
        {
            if (streckenId != null)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Überprüfen und Löschen der Einträge in der ZOT_Strecke_Trinkbrunnen Tabelle
                            string checkZOTQuery = "SELECT COUNT(*) FROM ZOT_Strecke_Trinkbrunnen WHERE StreckenID = @StreckenID";
                            int countZOT = 0;
                            using (MySqlCommand checkZOTCommand = new MySqlCommand(checkZOTQuery, connection, transaction))
                            {
                                checkZOTCommand.Parameters.AddWithValue("@StreckenID", streckenId);
                                countZOT = Convert.ToInt32(checkZOTCommand.ExecuteScalar());
                            }

                            if (countZOT > 0)
                            {
                                string deleteZOTQuery = "DELETE FROM ZOT_Strecke_Trinkbrunnen WHERE StreckenID = @StreckenID";
                                using (MySqlCommand deleteZOTCommand = new MySqlCommand(deleteZOTQuery, connection, transaction))
                                {
                                    deleteZOTCommand.Parameters.AddWithValue("@StreckenID", streckenId);
                                    deleteZOTCommand.ExecuteNonQuery();
                                }
                            }

                            // Überprüfen und Löschen der Einträge in der Belag Tabelle
                            string checkBelagQuery = "SELECT COUNT(*) FROM Belag WHERE BelagID IN (SELECT BelagID FROM Strecken WHERE StreckenID = @StreckenID)";
                            int countBelag = 0;
                            using (MySqlCommand checkBelagCommand = new MySqlCommand(checkBelagQuery, connection, transaction))
                            {
                                checkBelagCommand.Parameters.AddWithValue("@StreckenID", streckenId);
                                countBelag = Convert.ToInt32(checkBelagCommand.ExecuteScalar());
                            }

                            if (countBelag > 0)
                            {
                                string deleteBelagQuery = "DELETE FROM Belag WHERE BelagID IN (SELECT BelagID FROM Strecken WHERE StreckenID = @StreckenID)";
                                using (MySqlCommand deleteBelagCommand = new MySqlCommand(deleteBelagQuery, connection, transaction))
                                {
                                    deleteBelagCommand.Parameters.AddWithValue("@StreckenID", streckenId);
                                    deleteBelagCommand.ExecuteNonQuery();
                                }
                            }

                            // Löschen der Einträge in der Strecken Tabelle
                            string deleteStreckeQuery = "DELETE FROM Strecken WHERE StreckenID = @StreckenID";
                            using (MySqlCommand deleteStreckeCommand = new MySqlCommand(deleteStreckeQuery, connection, transaction))
                            {
                                deleteStreckeCommand.Parameters.AddWithValue("@StreckenID", streckenId);
                                deleteStreckeCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Fehler beim Löschen der Strecke: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
           
            }
        }

        //public static void LoadData()
        //{
        //    string connectionString = "server=localhost;user id=root;password=;database=radmanager";

        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        MySqlCommand command = connection.CreateCommand();

        //        // Abfrage für alle Tabellen
        //        string[] tables = { "Bundesland", "Person", "Fahrrad", "Strecken", "Belag", "Koordinaten", "Trinkbrunnen", "ZOT_Strecke_Trinkbrunnen" };

        //        foreach (string table in tables)
        //        {
        //            command.CommandText = $"SELECT * FROM {table}";
        //            using (MySqlDataReader reader = command.ExecuteReader())
        //            {
        //                Console.WriteLine($"Table: {table}");
        //                for (int i = 0; i < reader.FieldCount; i++)
        //                {
        //                    Console.Write(reader.GetName(i) + "\t");
        //                }
        //                Console.WriteLine();

        //                while (reader.Read())
        //                {
        //                    for (int i = 0; i < reader.FieldCount; i++)
        //                    {
        //                        Console.Write(reader[i] + "\t");
        //                    }
        //                    Console.WriteLine();
        //                }
        //                Console.WriteLine();
        //            }
        //        }

        //        // Verbindung schließen
        //        connection.Close();
        //    }
            
        //}

        /// <summary>
        /// This method is called when the load button is clicked. It loads all Bundesländer from the database
        /// </summary>
        /// <returns></returns>
        public List<Bundesland> GetBundesländer()
        {
            string query = "SELECT BundeslandID, Name, PersonenID, StreckenID, Hauptstadt, Einwohnerzahl, Fläche FROM Bundesland";

            List<Bundesland> bundesländer = new List<Bundesland>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Verbindung aufbauen     

                using (MySqlCommand command = new MySqlCommand(query, connection)) // SQL-Befehl senden
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bundesland bundesland = new Bundesland
                            {
                                BundeslandID = reader.GetInt32(0),
                                Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                                PersonenID = reader.GetInt32(2),
                                StreckenID = reader.GetInt32(3),
                                Hauptstadt = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Einwohnerzahl = reader.GetInt32(5),
                                Fläche = reader.GetInt32(6)
                            };
                            bundesländer.Add(bundesland);
                        }
                    }
                }
            }

            return bundesländer;
        }
    }
}
