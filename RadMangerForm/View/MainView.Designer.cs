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
            btn_edit = new Button();
            btn_delete = new Button();
            SuspendLayout();
            // 
            // btn_Search
            // 
            btn_Search.Location = new Point(758, 175);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(85, 39);
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
            listBox1.Size = new Size(499, 139);
            listBox1.TabIndex = 1;
            // 
            // btn_loadData
            // 
            btn_loadData.Location = new Point(54, 21);
            btn_loadData.Name = "btn_loadData";
            btn_loadData.Size = new Size(113, 48);
            btn_loadData.TabIndex = 2;
            btn_loadData.Text = "Load Data";
            btn_loadData.UseVisualStyleBackColor = true;
            btn_loadData.Click += OnLoadBtn_Clicked;
            // 
            // btn_edit
            // 
            btn_edit.Location = new Point(758, 75);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(85, 37);
            btn_edit.TabIndex = 3;
            btn_edit.Text = "Edit";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += OnEditBtn_Clicked;
            // 
            // btn_delete
            // 
            btn_delete.CausesValidation = false;
            btn_delete.Location = new Point(758, 118);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(85, 40);
            btn_delete.TabIndex = 4;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 454);
            Controls.Add(btn_delete);
            Controls.Add(btn_edit);
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
        private Button btn_edit;
        private Button btn_delete;
    }
}