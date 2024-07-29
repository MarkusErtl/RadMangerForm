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
using RadMangerForm.Presenter;
using Org.BouncyCastle.Utilities;

namespace RadMangerForm.View
{
    public partial class MainView : Form
    {

        public event EventHandler<EventArgs> SearchButtonClicked;
        public event EventHandler<EventArgs> LoadButtonClicked;

        public event EventHandler<EventArgs> EditButtonClicked; //übergabe von Parameter
        public event EventHandler<EventArgs> DeleteButtonClicked; //übergabe von Parameter

        public event EventHandler<EventArgs> DetailButtonClicked; //übergabe von Parameter

        public event EventHandler<EventArgs> AddButtonClicked;

        public Strecke selectedStrecken;


        public MainView()
        {
            InitializeComponent();
        }

        private void OnEditBtn_Clicked(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void OnSearchBtn_Clicked(object sender, EventArgs e)
        {
            SearchButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadBtn_Clicked(object sender, EventArgs e)
        {
            LoadButtonClicked?.Invoke(this, EventArgs.Empty);
        }



        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateStreckenList(List<Strecke> strecken)
        {
            listBoxStrecken.Items.Clear();
            foreach (var strecke in strecken)
            {
                listBoxStrecken.Items.Add(strecke);
            }
        }

        //public void UpdateStreckenList(List<Strecke> strecken)
        //{
        //    // Annahme: Ihre DataGridView heißt dataGridViewStrecken
        //    dataGridViewStrecken.Rows.Clear();
        //    dataGridViewStrecken.Columns.Clear();

        //    // Spalten hinzufügen
        //    dataGridViewStrecken.Columns.Add("Name", "Name");
        //    dataGridViewStrecken.Columns.Add("Entfernung", "Entfernung");
        //    dataGridViewStrecken.Columns.Add("Schwierigkeit", "Schwierigkeit");

        //    // Daten hinzufügen
        //    foreach (var strecke in strecken)
        //    {
        //        dataGridViewStrecken.Rows.Add(strecke.Name, strecke.Entfernung, strecke.Schwierigkeit);
        //    }
        //}

        private void btn_details_Click(object sender, EventArgs e)
        {
            DetailButtonClicked?.Invoke(this, EventArgs.Empty);
        }


        public Strecke GetSelectedStrecke()
        {
            return listBoxStrecken.SelectedItem as Strecke;
        }

        public void ShowStreckeDetails(Strecke strecke)
        {
            string details = $@"
            Name: {strecke.Name}
            Länge: {strecke.Länge} km
            Dauer: {strecke.Dauer}
            Schwierigkeitsgrad: {strecke.Schwierigkeitsgrad}
            Belag: {strecke.Belag.Name} ({strecke.Belag.Zustand})
            Trinkbrunnen: {strecke.Trinkbrunnen.Name} (Funktionsfähig: {strecke.Trinkbrunnen.Funktionsfähig}, Bewertung: {strecke.Trinkbrunnen.Bewertung}, Zustand: {strecke.Trinkbrunnen.Zustand})
            Koordinaten: {strecke.Trinkbrunnen.Koordinaten.Breitengrad}, {strecke.Trinkbrunnen.Koordinaten.Längengrad}";

            MessageBox.Show(details, "Streckendetails");
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void dataGrdViewStrecken_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
