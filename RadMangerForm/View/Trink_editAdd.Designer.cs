namespace RadMangerForm.View
{
    partial class Trink_editAdd
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
            lbl_title = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txt_Name = new TextBox();
            combo_funktionsfähig = new ComboBox();
            combo_bewertung = new ComboBox();
            combo_zustand = new ComboBox();
            btn_save = new Button();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(36, 27);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(98, 15);
            lbl_title.TabIndex = 0;
            lbl_title.Text = "Belag auswählen:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 63);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 94);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 2;
            label2.Text = "Funktionsfähig:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 127);
            label3.Name = "label3";
            label3.Size = new Size(178, 15);
            label3.TabIndex = 3;
            label3.Text = "Bewertung (Trinkwasserqualität):";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 163);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 4;
            label4.Text = "Zustand:";
            // 
            // txt_Name
            // 
            txt_Name.Location = new Point(233, 55);
            txt_Name.Name = "txt_Name";
            txt_Name.Size = new Size(251, 23);
            txt_Name.TabIndex = 6;
            // 
            // combo_funktionsfähig
            // 
            combo_funktionsfähig.FormattingEnabled = true;
            combo_funktionsfähig.Items.AddRange(new object[] { "Ja", "Nein" });
            combo_funktionsfähig.Location = new Point(233, 91);
            combo_funktionsfähig.Name = "combo_funktionsfähig";
            combo_funktionsfähig.Size = new Size(251, 23);
            combo_funktionsfähig.TabIndex = 7;
            // 
            // combo_bewertung
            // 
            combo_bewertung.FormattingEnabled = true;
            combo_bewertung.Items.AddRange(new object[] { "Ausgezeichnet", "Gut", "Akzeptabel", "Mangehlhaft", "Nicht_trinkbar" });
            combo_bewertung.Location = new Point(233, 124);
            combo_bewertung.Name = "combo_bewertung";
            combo_bewertung.Size = new Size(251, 23);
            combo_bewertung.TabIndex = 8;
            // 
            // combo_zustand
            // 
            combo_zustand.FormattingEnabled = true;
            combo_zustand.Items.AddRange(new object[] { "Sehr gut", "Gut (kleine Mängel)", "Akzeptabel (einige Mängel)", "Schlecht (deutliche Schäden)", "Sehr schlecht (starke Schäden)" });
            combo_zustand.Location = new Point(233, 160);
            combo_zustand.Name = "combo_zustand";
            combo_zustand.Size = new Size(251, 23);
            combo_zustand.TabIndex = 9;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(409, 212);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(75, 23);
            btn_save.TabIndex = 11;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // Trink_editAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 255);
            Controls.Add(btn_save);
            Controls.Add(combo_zustand);
            Controls.Add(combo_bewertung);
            Controls.Add(combo_funktionsfähig);
            Controls.Add(txt_Name);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbl_title);
            Name = "Trink_editAdd";
            Text = "Trink_editAdd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_title;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_Name;
        private ComboBox combo_funktionsfähig;
        private ComboBox combo_bewertung;
        private ComboBox combo_zustand;
        private Button btn_save;
    }
}