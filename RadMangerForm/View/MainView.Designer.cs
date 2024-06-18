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
            SuspendLayout();
            // 
            // btn_Search
            // 
            btn_Search.Location = new Point(607, 383);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(100, 40);
            btn_Search.TabIndex = 0;
            btn_Search.Text = "Search";
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += OnSearchBtn_Clicked;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Search);
            Name = "MainView";
            Text = "MainView";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Search;
    }
}