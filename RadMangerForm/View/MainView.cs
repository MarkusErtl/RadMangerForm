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
            dataGrdViewStrecken.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        //public void UpdateStreckenList(List<Strecke> strecken)
        //{
        //    listBoxStrecken.Items.Clear();
        //    foreach (var strecke in strecken)
        //    {
        //        listBoxStrecken.Items.Add(strecke);
        //    }
        //}

        public void UpdateStreckenList(List<Strecke> strecken)
        {

            // Annahme: Ihre DataGridView heißt dataGridViewStrecken
            dataGrdViewStrecken.Rows.Clear();
            dataGrdViewStrecken.Columns.Clear();

            // Spalten hinzufügen
            dataGrdViewStrecken.Columns.Add("ID", "ID");
            dataGrdViewStrecken.Columns.Add("Name", "Name");
            dataGrdViewStrecken.Columns.Add("Entfernung", "Entfernung");
            dataGrdViewStrecken.Columns.Add("Schwierigkeit", "Schwierigkeit");
            

            // Daten hinzufügen
            foreach (var strecke in strecken)
            {
                dataGrdViewStrecken.Rows.Add(strecke.StreckenID,strecke.Name, strecke.Länge, strecke.Schwierigkeitsgrad);
            }
        }

        private void btn_details_Click(object sender, EventArgs e)
        {
            DetailButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Methode um die ausgewählte Strecke aus dem DataGridView zu holen
        /// </summary>
        /// <returns></returns>
        public Strecke GetSelectedStrecke() 
        {
            if (dataGrdViewStrecken.SelectedRows.Count == 0)
            {
                return null;
            }

            DataGridViewRow selectedRow = dataGrdViewStrecken.SelectedRows[0];

            string strecknID = selectedRow.Cells["ID"].Value.ToString();    
            string name = selectedRow.Cells["Name"].Value.ToString();
            string entfernung = selectedRow.Cells["Entfernung"].Value.ToString();
            int schwierigkeit = Convert.ToInt32(selectedRow.Cells["Schwierigkeit"].Value);
            //TimeSpan dauer = TimeSpan.Zero;
            //if (selectedRow.Cells["Dauer"].Value != null && TimeSpan.TryParse(selectedRow.Cells["Dauer"].Value.ToString(), out TimeSpan parsedDauer))
            //{
            //    dauer = parsedDauer;
            //}


            Strecke selectedStrecke = new Strecke
            {
                StreckenID = Convert.ToInt32(strecknID),
                Name = name,
                Länge = Convert.ToInt32(entfernung),
                Schwierigkeitsgrad = schwierigkeit,
                //Dauer = dauer
            };

            return selectedStrecke;
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

        private void dataGrdViewStrecken_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
