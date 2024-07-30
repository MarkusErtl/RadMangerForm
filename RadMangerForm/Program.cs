using RadMangerForm.View;
using MySql.Data.MySqlClient;
using RadMangerForm.Model;
using RadMangerForm.Presenter;

namespace RadMangerForm
{
   static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            // MySql connection
            MySqlConnection connection = new MySqlConnection("server=localhost;database=RadManager;uid=root;pwd=radmanager");

            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            // --- Default Data -----------
           //InsertData(command);
            // --------------------------
            connection.Close();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainModel mainModel = new MainModel();
            MainView mainView = new MainView();
            MainPresenter mainPresenter = new MainPresenter(mainView, mainModel);


            Application.Run(mainView);  

        }


        public static void InsertData(MySqlCommand command)
        {   
                // Daten löschen
                command.CommandText = @"
                    DELETE FROM ZOT_Strecke_Trinkbrunnen;
                    DELETE FROM Trinkbrunnen;
                    DELETE FROM Koordinaten;
                    DELETE FROM Belag;
                    DELETE FROM Strecken;
                    DELETE FROM Fahrrad;
                    DELETE FROM Person;
                    DELETE FROM Bundesland;
                ";
                command.ExecuteNonQuery();

                // Daten einfügen
                command.CommandText = @"
                    INSERT INTO Bundesland (BundeslandID, Name, PersonenID, StreckenID, Hauptstadt, Einwohnerzahl, Fläche) VALUES
                    (1, 'Bayern', 1, 1, 'München', 13076721, 70550),
                    (2, 'Berlin', 2, 2, 'Berlin', 3644826, 891),
                    (3, 'Nordrhein-Westfalen', 3, 3, 'Düsseldorf', 17947221, 34085);

                    INSERT INTO Person (PersonID, Vorname, Nachname, GebDatum, FahrradID, Addresse, E_mail) VALUES
                    (1, 'Max', 'Mustermann', '1980-05-15', 1, 'Musterstraße 1, München', 'max@muster.de'),
                    (2, 'Erika', 'Mustermann', '1985-08-25', 2, 'Beispielweg 23, Berlin', 'erika@muster.de'),
                    (3, 'John', 'Doe', '1990-02-10', 3, 'Hauptstraße 12, Düsseldorf', 'john@doe.com');

                    INSERT INTO Fahrrad (FahrradID, Fahrradname, Hersteller, Modeljahr, Preis) VALUES
                    (1, 'Mountainbike', 'Cube', '2022', 1200.50),
                    (2, 'Rennrad', 'Giant', '2021', 1500.75),
                    (3, 'Trekkingrad', 'Trek', '2023', 900.00);

                    INSERT INTO Strecken (StreckenID, Name, Länge, Dauer, Schwierigkeitsgrad, TrinkbrunnenID, BelagID, BundeslandID) VALUES
                    (1, 'Alpenroute -', 120, '05:30:00', 5, 1, 1, 1),
                    (2, 'City Tour  -', 20, '01:00:00', 2, 2, 2, 2),
                    (3, 'Rheinradweg -', 150, '07:45:00', 3, 3, 3,3);

                    INSERT INTO Belag (BelagID, Name, Zustand) VALUES
                    (1, 'Asphalt', 'Gut'),
                    (2, 'Schotter', 'Mittel'),
                    (3, 'Kopfsteinpflaster', 'Schlecht');
                   

                    INSERT INTO Koordinaten (KoordinatenID, Breitengrad, Längengrad) VALUES
                    (1, 0, 0),
                    (2, 52, 13),
                    (3, 50, 8),
                    (4, 55, 9);

                    INSERT INTO Trinkbrunnen (TrinkbrunnenID, Name, Funktionsfähig, Bewertung, Zustand, KoordinatenID) VALUES
                    (1, 'Brunnen am Marktplatz', 1, 5, 'Sehr gut', 1),
                    (2, 'Brunnen am Marktplatz2', 2, 4, 'Sehr gut', 1),
                    (3, 'Brunnen im Park', 1, 4, 'Gut', 2),
                    (4, 'Brunnen am Rhein', 0, 2, 'Schlecht', 3);

                    INSERT INTO ZOT_Strecke_Trinkbrunnen (StreckenID, TrinkbrunnenID) VALUES
                    (1, 1),
                    (2, 2),
                    (3, 3);
                ";
                command.ExecuteNonQuery();
            
        }


    }
}