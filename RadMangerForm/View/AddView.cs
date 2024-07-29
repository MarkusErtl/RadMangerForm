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
using System.Xml.Linq;

namespace RadMangerForm.View
{
    public partial class AddView : Form
    {
        public event EventHandler<EventArgs> SaveButtonClicked;

        public Strecke? selectedStrecke { get; set; }

        public bool IsEditMode => selectedStrecke != null && selectedStrecke.StreckenID.HasValue;

        private List<Bundesland> _bundesländer;

        public AddView(List<Bundesland> bundesländer)
        {
            _bundesländer = bundesländer;

            InitializeComponent();
            InitializeComboBox();

            this.Load += AddView_Load; //wird immer beim laden des Fensters ausgeführt
        }

        private void AddView_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                LoadStreckeData(selectedStrecke);
                this.Text = "Strecke Bearbeiten";
                btn_Save.Text = "Aktualisieren";
                lblTitle.Text = "Strecke Bearbeiten";   
            }
            else
            {
                this.Text = "Neue Strecke Hinzufügen";
                btn_Save.Text = "Speichern";
                lblTitle.Text = "Neue Strecke Hinzufügen";
            }
        }

        private void InitializeComboBox()
        {
            if (combBoxBundes == null)
            {
                throw new InvalidOperationException("Die ComboBox combBoxBundes ist nicht initialisiert.");
            }

            // Setze die Datenquelle der ComboBox auf die Liste der Bundesländer
            combBoxBundes.DataSource = _bundesländer;
            combBoxBundes.DisplayMember = "Name";  // Der Name des Bundeslands wird angezeigt
            combBoxBundes.ValueMember = "BundeslandID";  // Der Wert ist die BundeslandID
        }



        private void LoadStreckeData(Strecke selectedStrecke)
        {

            Strecke strecke = selectedStrecke; // Implementieren Sie diese Methode entsprechend
            if (strecke != null)
            {
                txtName.Text = strecke.Name;
                txtLänge.Text = strecke.Länge.ToString();
                txtDauer.Text = strecke.Dauer.ToString();
                txtSchwier.Text = strecke.Schwierigkeitsgrad.ToString();
                if(strecke.BundeslandID.HasValue)
                {
                    combBoxBundes.SelectedValue = strecke.BundeslandID;
                }
                
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveButtonClicked?.Invoke(this, EventArgs.Empty);
        }


        public Strecke GetStreckeDetails()
        {
            string errors = string.Empty;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errors += "Name darf nicht leer sein.\n";
            }

            if (!int.TryParse(txtLänge.Text, out int length) || length <= 0)
            {
                errors += "Länge muss eine positive Zahl sein.\n";
            }

            if (!TimeSpan.TryParse(txtDauer.Text, out TimeSpan duration) || duration == TimeSpan.Zero)
            {
                errors += "Dauer muss eine gültige Zeitspanne sein.\n";
            }

            if (!int.TryParse(txtSchwier.Text, out int difficulty) || difficulty <= 0 || difficulty > 10)
            {
                errors += "Schwierigkeitsgrad muss eine positive Zahl sein. (1-10)\n";
            }

            if (combBoxBundes.SelectedValue == null)
            {
                errors += "Bitte wählen Sie ein Bundesland aus.\n";
            }


            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new Strecke
            {
                Name = txtName.Text,
                Länge = length,
                Dauer = duration,
                Schwierigkeitsgrad = difficulty,
                BundeslandID = (int)combBoxBundes.SelectedValue,
                TrinkbrunnenID = null,
                BelagID = null

            };
        }

        private void combBoxBundes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
