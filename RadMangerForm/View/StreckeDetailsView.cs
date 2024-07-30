using Org.BouncyCastle.Asn1.X509;
using RadMangerForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadMangerForm.View
{

    public partial class StreckeDetailsView : Form, IDetailView
    {
        public event EventHandler<EventArgs> AddButtonClicked;
        public event EventHandler<EventArgs> EditButtonClicked;
        public event EventHandler<EventArgs> DeleteButtonClicked;
        public event EventHandler<EventArgs> BelagEditButtonClicked;

        public event EventHandler<EventArgs> CloseButtonClicked;

        private Dictionary<string, Trinkbrunnen> trinkbrunnenMap = new Dictionary<string, Trinkbrunnen>();
        private Dictionary<string, Belag> belagMap = new Dictionary<string, Belag>();

        public StreckeDetailsView(Strecke strecke)
        {
            InitializeComponent();
            DisplayStreckeDetails(strecke);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public Trinkbrunnen GetSelectedTrinkbrunnen()
        {
            if (listBoxTrink.SelectedItem != null)
            {
                string selectedText = listBoxTrink.SelectedItem.ToString().Trim();
                if (trinkbrunnenMap.ContainsKey(selectedText))
                {
                    return trinkbrunnenMap[selectedText];
                }
            }
            return null;
        }
        public void DisplayTrinkbrunnenDetails(IEnumerable<Trinkbrunnen> trinkbrunnen)
        {
            listBoxTrink.Items.Clear();
            trinkbrunnenMap.Clear();

            foreach (var brunnen in trinkbrunnen)
            {
                var displayText = $@"
                Name:{(brunnen.Name ?? "Unbekannt")}
                Funktionsfähig:{(brunnen.Funktionsfähig.HasValue ? brunnen.Funktionsfähig.Value.ToString() : "Unbekannt")}
                Bewertung:{(brunnen.Bewertung.HasValue ? brunnen.Bewertung.Value.ToString() : "Unbekannt")}
                Zustand:{(brunnen.Zustand ?? "Unbekannt")}";

                // Removing leading spaces and new lines for better readability
                displayText = displayText.Trim();

                listBoxTrink.Items.Add(displayText);
                //listBoxTrink.Items.Add(" ");

                trinkbrunnenMap[displayText] = brunnen;
            }
        }


        public void DisplayStreckeDetails(Strecke strecke)
        {
            lb1.Font = new Font("Arial", 12, FontStyle.Bold);
            lb2.Font = new Font("Arial", 12, FontStyle.Bold);

            lb1.Text = $@" 
             {strecke.Name}
             {strecke.Länge} km
             {strecke.Dauer}
             {strecke.Schwierigkeitsgrad}";

            lb2.Text = $@"
            Name:
            Länge:
            Dauer:
            Schwierigkeitsgrad:";


        }

        public void DisplayBundesländer(Bundesland bundesland)

        {
            // Annahme: Ihre DataGridView heißt dataGrdViewBundesländer
            dataGridViewBundes.Rows.Clear();
            dataGridViewBundes.Columns.Clear();

            // Spalten hinzufügen
            dataGridViewBundes.Columns.Add("BundeslandID", "Bundesland ID");
            dataGridViewBundes.Columns.Add("Name", "Name");
            dataGridViewBundes.Columns.Add("PersonenID", "Personen ID");
            dataGridViewBundes.Columns.Add("StreckenID", "Strecken ID");
            dataGridViewBundes.Columns.Add("Hauptstadt", "Hauptstadt");
            dataGridViewBundes.Columns.Add("Einwohnerzahl", "Einwohnerzahl");
            dataGridViewBundes.Columns.Add("Flaeche", "Fläche");

            // Daten hinzufügen

            dataGridViewBundes.Rows.Add(
                bundesland.BundeslandID,
                bundesland.Name,
                bundesland.PersonenID,
                bundesland.StreckenID,
                bundesland.Hauptstadt,
                bundesland.Einwohnerzahl,
                bundesland.Fläche
                );

        }



        public void DisplayBelagDetails(Belag belag)
        {
            listBoxBelag.Items.Clear();
            belagMap.Clear();


            var displayText = $@"
                Belag Name: {(belag.Name ?? "Unbekannt")}
                Zustand: {(belag.Zustand ?? "Unbekannt")}";

            // Entfernen von führenden Leerzeichen und Zeilenumbrüchen für bessere Lesbarkeit
            displayText = displayText.Trim();

            listBoxBelag.Items.Add(displayText);
            listBoxBelag.Items.Add(" ");

            belagMap[displayText] = belag;
        }

        private void btn_belagEdit_Click(object sender, EventArgs e)
        {
            BelagEditButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void lb1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxTrink_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxBelag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_closeView_Click(object sender, EventArgs e)
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridViewBundes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lb2_Click(object sender, EventArgs e)
        {

        }

        void IDetailView.ShowDialog()
        {
            if (this.Visible)
            {
                base.Update();
            }
            else
            {

                base.ShowDialog();
            }
        }
    }
}
