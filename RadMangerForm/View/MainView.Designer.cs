namespace RadMangerForm.View
{
    using System.Diagnostics;
    using System.Windows.Forms;
    public partial class MainView 
    {

        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Search = new Button();
            listBox1 = new ListBox();
            btn_loadData = new Button();
            SuspendLayout();
            // 
            // btn_Search
            // 
            btn_Search.Location = new Point(637, 242);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(106, 47);
            btn_Search.TabIndex = 0;
            btn_Search.Text = "Search";
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += OnSearchBtn_Clicked;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(54, 86);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(387, 64);
            listBox1.TabIndex = 1;
            // 
            // btn_loadData
            // 
            btn_loadData.Location = new Point(54, 12);
            btn_loadData.Name = "btn_loadData";
            btn_loadData.Size = new Size(125, 46);
            btn_loadData.TabIndex = 2;
            btn_loadData.Text = "Load Data";
            btn_loadData.UseVisualStyleBackColor = true;
            btn_loadData.Click += OnLoadBtn_Clicked;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_loadData);
            Controls.Add(listBox1);
            Controls.Add(btn_Search);
            Name = "MainView";
            Text = "MainView";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Search;
        private ListBox listBox1;
        private Button btn_loadData;
    }
}