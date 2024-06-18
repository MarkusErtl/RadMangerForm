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
    }
}
