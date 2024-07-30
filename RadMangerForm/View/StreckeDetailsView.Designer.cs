namespace RadMangerForm.View
{
    partial class StreckeDetailsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            lb1 = new Label();
            listBoxTrink = new ListBox();
            listBoxBelag = new ListBox();
            lbl10 = new Label();
            lbl11 = new Label();
            btn_add = new Button();
            btn_edit = new Button();
            btn_delete = new Button();
            btn_belagEdit = new Button();
            btn_closeView = new Button();
            dataGridViewBundes = new DataGridView();
            label1 = new Label();
            lb2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBundes).BeginInit();
            SuspendLayout();
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(211, 9);
            lb1.Name = "lb1";
            lb1.Size = new Size(41, 15);
            lb1.TabIndex = 1;
            lb1.Text = "Label1";
            lb1.Click += lb1_Click;
            // 
            // listBoxTrink
            // 
            listBoxTrink.FormattingEnabled = true;
            listBoxTrink.ItemHeight = 15;
            listBoxTrink.Location = new Point(15, 132);
            listBoxTrink.Name = "listBoxTrink";
            listBoxTrink.Size = new Size(767, 64);
            listBoxTrink.TabIndex = 2;
            listBoxTrink.SelectedIndexChanged += listBoxTrink_SelectedIndexChanged;
            // 
            // listBoxBelag
            // 
            listBoxBelag.FormattingEnabled = true;
            listBoxBelag.ItemHeight = 15;
            listBoxBelag.Location = new Point(15, 270);
            listBoxBelag.Name = "listBoxBelag";
            listBoxBelag.Size = new Size(767, 34);
            listBoxBelag.TabIndex = 3;
            listBoxBelag.SelectedIndexChanged += listBoxBelag_SelectedIndexChanged;
            // 
            // lbl10
            // 
            lbl10.AutoSize = true;
            lbl10.Location = new Point(15, 113);
            lbl10.Name = "lbl10";
            lbl10.Size = new Size(80, 15);
            lbl10.TabIndex = 4;
            lbl10.Text = "Trinkbrunnen:";
            // 
            // lbl11
            // 
            lbl11.AutoSize = true;
            lbl11.Location = new Point(15, 252);
            lbl11.Name = "lbl11";
            lbl11.Size = new Size(111, 15);
            lbl11.TabIndex = 5;
            lbl11.Text = "Belag: (Untergrund)";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(15, 202);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(75, 23);
            btn_add.TabIndex = 6;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_edit
            // 
            btn_edit.Location = new Point(96, 202);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(75, 23);
            btn_edit.TabIndex = 7;
            btn_edit.Text = "Edit";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(177, 202);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(75, 23);
            btn_delete.TabIndex = 8;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_belagEdit
            // 
            btn_belagEdit.Location = new Point(15, 310);
            btn_belagEdit.Name = "btn_belagEdit";
            btn_belagEdit.Size = new Size(75, 23);
            btn_belagEdit.TabIndex = 9;
            btn_belagEdit.Text = "Edit";
            btn_belagEdit.UseVisualStyleBackColor = true;
            btn_belagEdit.Click += btn_belagEdit_Click;
            // 
            // btn_closeView
            // 
            btn_closeView.Location = new Point(707, 527);
            btn_closeView.Name = "btn_closeView";
            btn_closeView.Size = new Size(75, 23);
            btn_closeView.TabIndex = 10;
            btn_closeView.Text = "OK";
            btn_closeView.UseVisualStyleBackColor = true;
            btn_closeView.Click += btn_closeView_Click;
            // 
            // dataGridViewBundes
            // 
            dataGridViewBundes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBundes.Location = new Point(15, 370);
            dataGridViewBundes.Name = "dataGridViewBundes";
            dataGridViewBundes.Size = new Size(767, 76);
            dataGridViewBundes.TabIndex = 11;
            dataGridViewBundes.CellContentClick += dataGridViewBundes_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 352);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 12;
            label1.Text = "Bundeslad + Info";
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Location = new Point(15, 9);
            lb2.Name = "lb2";
            lb2.Size = new Size(38, 15);
            lb2.TabIndex = 13;
            lb2.Text = "label2";
            lb2.Click += lb2_Click;
            // 
            // StreckeDetailsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 562);
            Controls.Add(lb2);
            Controls.Add(label1);
            Controls.Add(dataGridViewBundes);
            Controls.Add(btn_closeView);
            Controls.Add(btn_belagEdit);
            Controls.Add(btn_delete);
            Controls.Add(btn_edit);
            Controls.Add(btn_add);
            Controls.Add(lbl11);
            Controls.Add(lbl10);
            Controls.Add(listBoxBelag);
            Controls.Add(listBoxTrink);
            Controls.Add(lb1);
            Name = "StreckeDetailsView";
            Text = "StreckeDetailsView";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBundes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb1;
        private ListBox listBoxTrink;
        private ListBox listBoxBelag;
        private Label lbl10;
        private Label lbl11;
        private Button btn_add;
        private Button btn_edit;
        private Button btn_delete;
        private Button btn_belagEdit;
        private Button btn_closeView;
        private DataGridView dataGridViewBundes;
        private Label label1;
        private Label lb2;
    }
}