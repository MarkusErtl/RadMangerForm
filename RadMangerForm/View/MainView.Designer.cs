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
            components = new System.ComponentModel.Container();
            btn_Search = new Button();
            btn_loadData = new Button();
            btn_edit = new Button();
            btn_delete = new Button();
            btn_details = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btn_Add = new Button();
            dataGrdViewStrecken = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGrdViewStrecken).BeginInit();
            SuspendLayout();
            // 
            // btn_Search
            // 
            btn_Search.Location = new Point(458, 30);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(85, 39);
            btn_Search.TabIndex = 0;
            btn_Search.Text = "Search";
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += OnSearchBtn_Clicked;
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
            btn_edit.Location = new Point(552, 121);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(85, 40);
            btn_edit.TabIndex = 3;
            btn_edit.Text = "Edit";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += OnEditBtn_Clicked;
            // 
            // btn_delete
            // 
            btn_delete.CausesValidation = false;
            btn_delete.Location = new Point(552, 167);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(85, 40);
            btn_delete.TabIndex = 4;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_details
            // 
            btn_details.Location = new Point(458, 374);
            btn_details.Name = "btn_details";
            btn_details.Size = new Size(88, 37);
            btn_details.TabIndex = 5;
            btn_details.Text = "Details";
            btn_details.UseVisualStyleBackColor = true;
            btn_details.Click += btn_details_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(552, 75);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(85, 40);
            btn_Add.TabIndex = 6;
            btn_Add.Text = "Add";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // dataGrdViewStrecken
            // 
            dataGrdViewStrecken.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrdViewStrecken.Location = new Point(54, 75);
            dataGrdViewStrecken.Name = "dataGrdViewStrecken";
            dataGrdViewStrecken.Size = new Size(492, 284);
            dataGrdViewStrecken.TabIndex = 7;
            dataGrdViewStrecken.CellContentClick += dataGrdViewStrecken_CellContentClick;
            dataGrdViewStrecken.SelectionChanged += dataGrdViewStrecken_SelectionChanged;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 454);
            Controls.Add(dataGrdViewStrecken);
            Controls.Add(btn_Add);
            Controls.Add(btn_details);
            Controls.Add(btn_delete);
            Controls.Add(btn_edit);
            Controls.Add(btn_loadData);
            Controls.Add(btn_Search);
            Name = "MainView";
            Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)dataGrdViewStrecken).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Search;
        private Button btn_loadData;
        private Button btn_edit;
        private Button btn_delete;
        private Button btn_details;
        private ContextMenuStrip contextMenuStrip1;
        private Button btn_Add;
        private DataGridView dataGrdViewStrecken;
    }
}