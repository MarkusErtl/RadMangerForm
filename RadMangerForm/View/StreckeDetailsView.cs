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
        public StreckeDetailsView(Strecke strecke)
        {
            InitializeComponent();
            DisplayStreckeDetails(strecke);
        }


        public void DisplayStreckeDetails(Strecke strecke)
        {
            lb1.Text = $@" 
            Name:               {strecke.Name}
            Länge:              {strecke.Länge} km
            Dauer:              {strecke.Dauer}
            Schwierigkeitsgrad: {strecke.Schwierigkeitsgrad}";     
        }

        public void DisplayTrinkbrunnenDetails(IEnumerable<Trinkbrunnen> trinkbrunnen)
        {

            listBoxTrink.Items.Clear();
            foreach (var brunnen in trinkbrunnen)
            {
                listBoxTrink.Items.Add($@"
                Name:{(brunnen.Name ?? "Unbekannt")}
                Funktionsfähig:{(brunnen.Funktionsfähig.HasValue ? brunnen.Funktionsfähig.Value.ToString() : "Unbekannt")}
                Bewertung:{(brunnen.Bewertung.HasValue ? brunnen.Bewertung.Value.ToString() : "Unbekannt")}
                Zustand:{(brunnen.Zustand ?? "Unbekannt")}");
                listBoxTrink.Items.Add(" ");
            }
        }
        public void DisplayBelagDetails(Belag belag)
        {
            listBoxBelag.Items.Clear();

            string belagName = belag.Name ?? "Unbekannt";
            string zustand = belag.Zustand ?? "Unbekannt";

            listBoxBelag.Items.Add($@"
             Belag Name:         {belagName}
             Zustand:            {zustand}");
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

        void IDetailView.ShowDialog()
        {
            base.ShowDialog();
        }
    }
}
