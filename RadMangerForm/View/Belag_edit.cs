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
    public partial class Belag_edit : Form
    {
        public event EventHandler<EventArgs> SaveButtonClickedBelag;

        public Belag_edit()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveButtonClickedBelag?.Invoke(this, EventArgs.Empty);
        }

        public Belag GetBelagDetails()
        {
            string errors = string.Empty;

            if (string.IsNullOrWhiteSpace(combo_Name.Text) )
            {
                errors += "Bitte wählen Sie eine gültige Namen aus.\n";
            }
            if (string.IsNullOrWhiteSpace(combo_Zustand.Text))
            {
                errors += "Bitte wählen Sie eine gültige Zustand aus.\n";
            }

            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Belag belag = new Belag
            {

                Name = combo_Name.Text,
                Zustand = combo_Zustand.Text
            };
                                   
            return belag;
        }
             
        private void combo_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_Zustand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
