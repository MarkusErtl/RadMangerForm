using RadMangerForm.View;
using MySql.Data.MySqlClient;

namespace RadMangerForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainView());

            // MySql connection

            MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=;database=radmanager");

            connection.Open();

            MySqlCommand command = connection.CreateCommand();


        }

       
    }
}