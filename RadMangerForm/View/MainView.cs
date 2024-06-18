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
    public partial class MainView : Form
    {

        public event EventHandler<EventArgs> SearchButtonClicked;
        public event EventHandler<EventArgs> LoadButtonClicked;

        public event EventHandler<EventArgs> EditButtonClicked; //übergabe von Parameter
        public event EventHandler<EventArgs> DeleteButtonClicked; //übergabe von Parameter

        public MainView()
        {
            InitializeComponent();
        }

        private void OnSearchBtn_Clicked(object sender, EventArgs e)
        {
            SearchButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadBtn_Clicked(object sender, EventArgs e)
        {
            LoadButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void OnEditBtn_Clicked(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
