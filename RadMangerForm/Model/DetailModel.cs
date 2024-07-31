using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RadMangerForm.Model
{
   

    public class DetailModel
    {
        // Connection string for the database
        string _connectionString = "server=localhost;database=RadManager;uid=root;pwd=radmanager";


        public DetailModel()
        {
                
        }

        /// <summary>
        /// This method loads the details of a Strecke from the database.
        /// </summary>
        /// <param name="streckenId"></param>
        /// <returns></returns>
        public Strecke GetStreckeDetails(int? streckenId)
        {
            Strecke strecke = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string queryStrecke = @"
                    SELECT StreckenID, Name, Länge, Dauer, Schwierigkeitsgrad, TrinkbrunnenID, BelagID, BundeslandID
                    FROM Strecken
                    WHERE StreckenID = @streckenId";

                using (MySqlCommand command = new MySqlCommand(queryStrecke, connection))
                {
                    command.Parameters.AddWithValue("@streckenId", streckenId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            strecke = new Strecke
                            {
                                StreckenID = reader.GetInt32("StreckenID"),
                                Name = reader.GetString("Name"),
                                Länge = reader.GetInt32("Länge"),
                                Dauer = reader.GetTimeSpan("Dauer"),
                                Schwierigkeitsgrad = reader.GetInt32("Schwierigkeitsgrad"),
                                TrinkbrunnenID = reader.IsDBNull("TrinkbrunnenID") ? (int?)null : reader.GetInt32("TrinkbrunnenID"),
                                BelagID = reader.IsDBNull("BelagID") ? (int?)null : reader.GetInt32("BelagID"),
                                BundeslandID = reader.IsDBNull("BundeslandID") ? (int?)null : reader.GetInt32("BundeslandID")
                            };
                        }
                    }
                }
            }

            return strecke;
        }

        /// <summary>
        /// This method gets the details of a Belag from the database.
        /// </summary>
        /// <param name="belagId"></param>
        /// <returns></returns>
        public Belag GetBelagDetails(int? belagId)
        {
            if (!belagId.HasValue)
            {
                return null; // oder eine entsprechende Standardrückgabe
            }
            else
            {
                Belag belag = null;

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string queryBelag = @"
                    SELECT BelagID, Name, Zustand
                    FROM Belag
                    WHERE BelagID = @belagId";

                    using (MySqlCommand command = new MySqlCommand(queryBelag, connection))
                    {
                        command.Parameters.AddWithValue("@belagId", belagId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                belag = new Belag
                                {
                                    BelagID = reader.GetInt32("BelagID"),
                                    Name = reader.GetString("Name"),
                                    Zustand = reader.GetString("Zustand")
                                };
                            }
                        }
                    }
                }

                return belag;
            }            
        }

        /// <summary>
        /// Gets the details of a Trinkbrunnen from the database.
        /// </summary>
        /// <param name="trinkbrunnenId"></param>
        /// <param name="streckenId"></param>
        /// <returns></returns>
        public List<Trinkbrunnen> GetTrinkbrunnenDetails(int? trinkbrunnenId, int? streckenId)
        {
            List<Trinkbrunnen> trinkbrunnenList = new List<Trinkbrunnen>();

            string queryTrinkbrunnen = @"
                SELECT 
                    t.TrinkbrunnenID, t.Name, t.Funktionsfähig, t.Bewertung, t.Zustand
                FROM Trinkbrunnen t";

            if (streckenId.HasValue)
            {
                queryTrinkbrunnen += @"
                    JOIN ZOT_Strecke_Trinkbrunnen zst ON t.TrinkbrunnenID = zst.TrinkbrunnenID
                    WHERE zst.StreckenID = @streckenId";
            }
            else if (trinkbrunnenId.HasValue)
            {
                queryTrinkbrunnen += " WHERE t.TrinkbrunnenID = @trinkbrunnenId";
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(queryTrinkbrunnen, connection))
                {
                    if (streckenId.HasValue)
                    {
                        command.Parameters.AddWithValue("@streckenId", streckenId);
                    }
                    else if (trinkbrunnenId.HasValue)
                    {
                        command.Parameters.AddWithValue("@trinkbrunnenId", trinkbrunnenId);
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Trinkbrunnen trinkbrunnen = new Trinkbrunnen
                            {
                                TrinkbrunnenID = reader.GetInt32("TrinkbrunnenID"),
                                Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : reader.GetString("Name"),
                                Funktionsfähig = reader.IsDBNull(reader.GetOrdinal("Funktionsfähig")) ? (bool?)null : reader.GetBoolean("Funktionsfähig"),
                                Bewertung = reader.IsDBNull(reader.GetOrdinal("Bewertung")) ? (int?)null : reader.GetInt32("Bewertung"),
                                Zustand = reader.IsDBNull(reader.GetOrdinal("Zustand")) ? null : reader.GetString("Zustand")
                            };

                            trinkbrunnenList.Add(trinkbrunnen);
                        }
                    }
                }
            }

            return trinkbrunnenList;
        }

        /// <summary>
        /// Gets the details of a Koordinaten from the database.With the help of the KoordinatenID
        /// </summary>
        /// <param name="koorindatenId"></param>
        /// <returns></returns>
        public Koordinaten GetKoordinaten(int koorindatenId)
        {
            Koordinaten koordinaten = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string queryKoordinaten = @"
                    SELECT KoordinatenID, Breitengrad, Längengrad
                    FROM Koordinaten
                    WHERE KoordinatenID = @koordinatenId";

                using (MySqlCommand command = new MySqlCommand(queryKoordinaten, connection))
                {
                    command.Parameters.AddWithValue("@koordinatenId", koorindatenId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            koordinaten = new Koordinaten
                            {
                                KoordinatenID = reader.GetInt32("KoordinatenID"),
                                Breitengrad = reader.GetInt32("Breitengrad"),
                                Längengrad = reader.GetInt32("Längengrad")
                            };
                        }
                    }
                }
            }

            return koordinaten;
        }

        /// <summary>
        /// This method saves the Trinkbrunnen data to the database, if the TrinkbrunnenID is "0", a new Trinkbrunnen is created, otherwise the existing Trinkbrunnen is updated.
        /// </summary>
        /// <param name="trinkbrunnen"></param>
        /// <param name="_selectedStrecke"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateTrinkbrunnen(Trinkbrunnen trinkbrunnen, Strecke _selectedStrecke)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {                        

                        if (trinkbrunnen.TrinkbrunnenID == 0)
                        {
                            // Insert new Trinkbrunnen
                            string insertTrinkbrunnenQuery = @"
                            INSERT INTO Trinkbrunnen (Name, Funktionsfähig, Bewertung, Zustand, KoordinatenID)
                            VALUES (@Name, @Funktionsfähig, @Bewertung, @Zustand, @KoordinatenID);
                            SELECT LAST_INSERT_ID();";

                            using (MySqlCommand insertTrinkbrunnenCommand = new MySqlCommand(insertTrinkbrunnenQuery, connection, transaction))
                            {
                                insertTrinkbrunnenCommand.Parameters.AddWithValue("@Name", trinkbrunnen.Name);
                                insertTrinkbrunnenCommand.Parameters.AddWithValue("@Funktionsfähig", trinkbrunnen.Funktionsfähig);
                                insertTrinkbrunnenCommand.Parameters.AddWithValue("@Bewertung", trinkbrunnen.Bewertung);
                                insertTrinkbrunnenCommand.Parameters.AddWithValue("@Zustand", trinkbrunnen.Zustand);
                                insertTrinkbrunnenCommand.Parameters.AddWithValue("@KoordinatenID", trinkbrunnen.KoordinatenID);

                                // Execute the insert command and get the new TrinkbrunnenID
                                trinkbrunnen.TrinkbrunnenID = Convert.ToInt32(insertTrinkbrunnenCommand.ExecuteScalar());
                                //trinkbrunnen.TrinkbrunnenID = _selectedStrecke.TrinkbrunnenID;
                            }

                            // Insert into ZOT_Strecke_Trinkbrunnen
                            string insertZOTStreckeTrinkbrunnenQuery = @"
                            INSERT INTO ZOT_Strecke_Trinkbrunnen (StreckenID, TrinkbrunnenID)
                            VALUES (@StreckenID, @TrinkbrunnenID);";

                            using (MySqlCommand insertZOTStreckeTrinkbrunnenCommand = new MySqlCommand(insertZOTStreckeTrinkbrunnenQuery, connection, transaction))
                            {
                                insertZOTStreckeTrinkbrunnenCommand.Parameters.AddWithValue("@StreckenID", _selectedStrecke.StreckenID);
                                insertZOTStreckeTrinkbrunnenCommand.Parameters.AddWithValue("@TrinkbrunnenID", trinkbrunnen.TrinkbrunnenID);

                                insertZOTStreckeTrinkbrunnenCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Update existing Trinkbrunnen
                            string updateTrinkbrunnenQuery = @"
                        UPDATE Trinkbrunnen
                        SET 
                          Name = @Name, 
                          Funktionsfähig = @Funktionsfähig, 
                          Bewertung = @Bewertung, 
                          Zustand = @Zustand,
                          KoordinatenID = @KoordinatenID
                        WHERE TrinkbrunnenID = @TrinkbrunnenID";

                            using (MySqlCommand updateTrinkbrunnenCommand = new MySqlCommand(updateTrinkbrunnenQuery, connection, transaction))
                            {
                                updateTrinkbrunnenCommand.Parameters.AddWithValue("@Name", trinkbrunnen.Name);
                                updateTrinkbrunnenCommand.Parameters.AddWithValue("@Funktionsfähig", trinkbrunnen.Funktionsfähig);
                                updateTrinkbrunnenCommand.Parameters.AddWithValue("@Bewertung", trinkbrunnen.Bewertung);
                                updateTrinkbrunnenCommand.Parameters.AddWithValue("@Zustand", trinkbrunnen.Zustand);
                                updateTrinkbrunnenCommand.Parameters.AddWithValue("@KoordinatenID", trinkbrunnen.KoordinatenID);
                                updateTrinkbrunnenCommand.Parameters.AddWithValue("@TrinkbrunnenID", trinkbrunnen.TrinkbrunnenID);

                                updateTrinkbrunnenCommand.ExecuteNonQuery();
                            }

                            // Optionally update ZOT_Strecke_Trinkbrunnen if needed
                            string updateZOTStreckeTrinkbrunnenQuery = @"
                            UPDATE ZOT_Strecke_Trinkbrunnen
                            SET 
                            TrinkbrunnenID = @TrinkbrunnenID
                            WHERE StreckenID = @StreckenID";

                            using (MySqlCommand updateZOTStreckeTrinkbrunnenCommand = new MySqlCommand(updateZOTStreckeTrinkbrunnenQuery, connection, transaction))
                            {
                                updateZOTStreckeTrinkbrunnenCommand.Parameters.AddWithValue("@TrinkbrunnenID", trinkbrunnen.TrinkbrunnenID);
                                updateZOTStreckeTrinkbrunnenCommand.Parameters.AddWithValue("@StreckenID", _selectedStrecke.StreckenID);

                                updateZOTStreckeTrinkbrunnenCommand.ExecuteNonQuery();
                            }
                        }

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction on error
                        transaction.Rollback();
                        throw new Exception("Error saving Trinkbrunnen: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Methode zum Löschen eines Trinkbrunnens aus der Datenbank
        /// </summary>
        /// <param name="trinkbrunnenId"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteTrinkbrunnen(int? trinkbrunnenId)
        {
            if(!trinkbrunnenId.HasValue)
            {
                MessageBox.Show("Bitte wählen Sie einen Trinkbrunnen aus.");
            }
            else
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Zuerst löschen Sie die Verweise in der ZOT_Strecke_Trinkbrunnen-Tabelle
                            string deleteZOTQuery = @"
                            DELETE FROM ZOT_Strecke_Trinkbrunnen 
                            WHERE TrinkbrunnenID = @TrinkbrunnenID";

                            using (MySqlCommand deleteZOTCommand = new MySqlCommand(deleteZOTQuery, connection, transaction))
                            {
                                deleteZOTCommand.Parameters.AddWithValue("@TrinkbrunnenID", trinkbrunnenId);
                                deleteZOTCommand.ExecuteNonQuery();
                            }

                            // Dann löschen Sie den Trinkbrunnen-Eintrag selbst
                            string deleteTrinkbrunnenQuery = @"
                            DELETE FROM Trinkbrunnen 
                            WHERE TrinkbrunnenID = @TrinkbrunnenID";

                            using (MySqlCommand deleteTrinkbrunnenCommand = new MySqlCommand(deleteTrinkbrunnenQuery, connection, transaction))
                            {
                                deleteTrinkbrunnenCommand.Parameters.AddWithValue("@TrinkbrunnenID", trinkbrunnenId);
                                deleteTrinkbrunnenCommand.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if any error occurs
                            transaction.Rollback();
                            throw new Exception("Error deleting Trinkbrunnen: " + ex.Message);
                        }
                    }
                }
            }
           
        }

        /// <summary>
        /// The method UpdateBelag updates the Belag data in the database.
        /// </summary>
        /// <param name="belag"></param>
        /// <param name="selectedStrecke"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void UpdateBelag(Belag belag, Strecke selectedStrecke)
        {
            if (belag == null)
            {
                throw new ArgumentNullException(nameof(belag));
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string updateQuery = @"
                UPDATE Belag
                SET Name = @name, Zustand = @zustand
                WHERE BelagID = @belagId";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@belagId", belag.BelagID);
                    command.Parameters.AddWithValue("@name", belag.Name);
                    command.Parameters.AddWithValue("@zustand", belag.Zustand);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new Exception("Update failed. No rows affected.");
                    }
                }
            }
        }

        /// <summary>
        /// GetBundesländerByID gets the Bundesland data from the database.Only the BundeslandID is required.
        /// </summary>
        /// <param name="streckenID"></param>
        /// <returns></returns>
        public Bundesland GetBundesländerByID(int? streckenID)
        {
            string query = @"
            SELECT 
                b.BundeslandID, 
                b.Name, 
                b.PersonenID, 
                b.StreckenID, 
                b.Hauptstadt, 
                b.Einwohnerzahl, 
                b.Fläche 
            FROM 
                Bundesland b
            JOIN 
                Strecken s ON b.BundeslandID = s.BundeslandID
            WHERE 
                s.StreckenID = @streckenID";

            Bundesland bundesland = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Verbindung aufbauen     

                using (MySqlCommand command = new MySqlCommand(query, connection)) // SQL-Befehl senden
                {
                    command.Parameters.AddWithValue("@streckenID", streckenID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bundesland = new Bundesland
                            {
                                BundeslandID = reader.GetInt32(0),
                                Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                                PersonenID = reader.GetInt32(2),
                                StreckenID = reader.GetInt32(3),
                                Hauptstadt = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Einwohnerzahl = reader.GetInt32(5),
                                Fläche = reader.GetInt32(6)
                            };
                        }
                    }
                }
            }

            return bundesland;
        }
    }
}
