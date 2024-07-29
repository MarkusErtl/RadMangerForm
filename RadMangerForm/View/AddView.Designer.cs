namespace RadMangerForm.View
{
    partial class AddView
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
            lblTitle = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            txtDauer = new TextBox();
            txtLänge = new TextBox();
            txtSchwier = new TextBox();
            textBox1 = new TextBox();
            btn_Save = new Button();
            lbl100 = new Label();
            combBoxBundes = new ComboBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(42, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(111, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Strecke hinzufügen:";
            lblTitle.Click += lblTitle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 67);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 125);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Länge (km):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(140, 96);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 3;
            label4.Text = "Dauer:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 154);
            label5.Name = "label5";
            label5.Size = new Size(143, 15);
            label5.TabIndex = 4;
            label5.Text = "Schwierigkeitsgrad (1-10):";
            // 
            // txtName
            // 
            txtName.Location = new Point(212, 64);
            txtName.Name = "txtName";
            txtName.Size = new Size(160, 23);
            txtName.TabIndex = 5;
            // 
            // txtDauer
            // 
            txtDauer.Location = new Point(212, 93);
            txtDauer.Name = "txtDauer";
            txtDauer.Size = new Size(160, 23);
            txtDauer.TabIndex = 6;
            // 
            // txtLänge
            // 
            txtLänge.Location = new Point(212, 122);
            txtLänge.Name = "txtLänge";
            txtLänge.Size = new Size(160, 23);
            txtLänge.TabIndex = 7;
            // 
            // txtSchwier
            // 
            txtSchwier.Location = new Point(212, 151);
            txtSchwier.Name = "txtSchwier";
            txtSchwier.Size = new Size(160, 23);
            txtSchwier.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(378, 93);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(226, 23);
            textBox1.TabIndex = 9;
            textBox1.Text = "(z.B., 02:30 für 2 Stunden und 30 Minuten)";
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(486, 224);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(118, 31);
            btn_Save.TabIndex = 10;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // lbl100
            // 
            lbl100.AutoSize = true;
            lbl100.Location = new Point(109, 186);
            lbl100.Name = "lbl100";
            lbl100.Size = new Size(72, 15);
            lbl100.TabIndex = 11;
            lbl100.Text = "Bundesland:";
            // 
            // combBoxBundes
            // 
            combBoxBundes.FormattingEnabled = true;
            combBoxBundes.Location = new Point(212, 183);
            combBoxBundes.Name = "combBoxBundes";
            combBoxBundes.Size = new Size(160, 23);
            combBoxBundes.TabIndex = 12;
            combBoxBundes.SelectedIndexChanged += combBoxBundes_SelectedIndexChanged;
            // 
            // AddView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 281);
            Controls.Add(combBoxBundes);
            Controls.Add(lbl100);
            Controls.Add(btn_Save);
            Controls.Add(textBox1);
            Controls.Add(txtSchwier);
            Controls.Add(txtLänge);
            Controls.Add(txtDauer);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Name = "AddView";
            Text = "AddView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtName;
        private TextBox txtDauer;
        private TextBox txtLänge;
        private TextBox txtSchwier;
        private TextBox textBox1;
        private Button btn_Save;
        private Label lbl100;
        private ComboBox combBoxBundes;
    }
}