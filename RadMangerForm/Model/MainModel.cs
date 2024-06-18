using MySql.Data.MySqlClient;
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
        // Löschen über Liste von IDs der jeweiligen Tabelle(Name von Tabelle auch als Event)
        public MainModel()
        {
                
        }


        public void SearchButtonClicked()
        {
            // Do something
        }

        public void DeleteDBElements(string tableName, List<int> ids)
        {
            string connectionString = "server=localhost;database=swe4ilv;uid=root;pwd=password1";
            string idsString = string.Join(",", ids);                                               // merge all List IDs

            string query = $"DELETE FROM {tableName} WHERE Id IN ({idsString})";
            using (SqlConnection connection = new SqlConnection(connectionString))     
            {
                connection.Open();                                                                  // Verbindung aufbauen     

                using (SqlCommand command = new SqlCommand(query, connection))                      // Send SQL Command
                {
                    int rowsAffected = command.ExecuteNonQuery();                                   // Executes and returns how many rows are effected
                    Console.WriteLine($"{rowsAffected} rows were deleted.");
                }
            }
        }
    }
}
