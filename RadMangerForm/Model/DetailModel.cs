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
        string _connectionString = "server=localhost;database=RadManager;uid=root;pwd=radmanager";


        public DetailModel()
        {
                
        }


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

        public List<Trinkbrunnen> GetTrinkbrunnenDetails(int? trinkbrunnenId)
        {
            if (!trinkbrunnenId.HasValue) // Überprüfung, ob der Wert null ist
            {
                return null;
            }
            else
            {
                string queryTrinkbrunnen = @"
                SELECT 
                    t.TrinkbrunnenID, t.Name, t.Funktionsfähig, t.Bewertung, t.Zustand
                FROM Trinkbrunnen t
                WHERE t.TrinkbrunnenID = @trinkbrunnenId";

                List<Trinkbrunnen> trinkbrunnenList = new List<Trinkbrunnen>();

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(queryTrinkbrunnen, connection))
                    {
                        command.Parameters.AddWithValue("@trinkbrunnenId", trinkbrunnenId);

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
        }

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


    }
}
