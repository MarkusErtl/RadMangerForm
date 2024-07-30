using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RadMangerForm.Model;

namespace RadMangerForm.View
{
    public partial class Trink_editAdd : Form
    {
        public Strecke _selectedStrecke { get; set; }
        public Trinkbrunnen _trinkbrunnen { get; set; }


       public event EventHandler<EventArgs> SaveButtonClicked;

        public bool IsEditMode => _trinkbrunnen != null && _trinkbrunnen.TrinkbrunnenID.HasValue;

        public Trink_editAdd()
        {
            InitializeComponent();


            this.Load += Trink_editAdd_Load;
        }

        private void Trink_editAdd_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                LoadTrinkbrunnenData(_trinkbrunnen);
                this.Text = "Trinkbrunnen Bearbeiten";
                btn_save.Text = "Aktualisieren";
               lbl_title.Text = "Trinkbrunnen Bearbeiten";
            }
            else
            {
                this.Text = "Neuen Trinkbrunnen Hinzufügen";
                btn_save.Text = "Speichern";
                lbl_title.Text = "Neuen Trinkbrunnen Hinzufügen";
            }
        }

        private void LoadTrinkbrunnenData(Trinkbrunnen trinkbrunnen)
        {
            if (trinkbrunnen != null)
            {
                txt_Name.Text = trinkbrunnen.Name;

                if(trinkbrunnen.Funktionsfähig == true)
                {
                    combo_funktionsfähig.Text = "Ja";
                }
                else
                {
                    combo_funktionsfähig.Text = "Nein";
                }

                combo_bewertung.Text = trinkbrunnen.Bewertung.ToString();
                combo_zustand.Text = trinkbrunnen.Zustand;
               
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveButtonClicked?.Invoke(this, EventArgs.Empty);          
        }

        enum Bewertung
        {
            Ausgezeichnet,
            Gut,
            Akzeptabel,
            Mangehlhaft,
            Nicht_trinkbar            
        }

        /// <summary>
        /// Method to get the details of the Trinkbrunnen
        /// </summary>
        /// <returns></returns>
        public Trinkbrunnen GetTrinkbrunnenDetails()
        {
            string errors = string.Empty;

            if (string.IsNullOrWhiteSpace(txt_Name.Text))
            {
                errors += "Name darf nicht leer sein.\n";
            }

            bool funktionsfähig = combo_funktionsfähig.Text == "Ja";

            if (string.IsNullOrWhiteSpace(combo_bewertung.Text) || !Enum.TryParse<Bewertung>(combo_bewertung.Text.Replace(" ", "_"), out Bewertung bewertung))
            {
                errors += "Bitte wählen Sie eine gültige Bewertung aus.\n";
            }

            if (string.IsNullOrWhiteSpace(combo_zustand.Text))
            {
                errors += "Zustand darf nicht leer sein.\n";
            }
                      

            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int trinkbrunnenID = _trinkbrunnen?.TrinkbrunnenID ?? 0;
            int koordinatenID = _trinkbrunnen?.KoordinatenID ?? 1;

            Trinkbrunnen trinkbrunnen = new Trinkbrunnen
            {
                Name = txt_Name.Text,
                Funktionsfähig = funktionsfähig,
                Bewertung = (int)Enum.Parse(typeof(Bewertung), combo_bewertung.Text.Replace(" ", "_")),
                Zustand = combo_zustand.Text,
                KoordinatenID = koordinatenID,
                TrinkbrunnenID = trinkbrunnenID
            };

            return trinkbrunnen;
        }

    }
}
