namespace RadMangerForm.View
{
    partial class Belag_edit
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
            lbl1 = new Label();
            combo_Name = new ComboBox();
            combo_Zustand = new ComboBox();
            lbl_name = new Label();
            lbl_zustand = new Label();
            btn_Save = new Button();
            SuspendLayout();
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(37, 28);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(212, 15);
            lbl1.TabIndex = 0;
            lbl1.Text = "Wählen Sie einen passenden Belag aus:";
            // 
            // combo_Name
            // 
            combo_Name.FormattingEnabled = true;
            combo_Name.Items.AddRange(new object[] { "Asphalt", "Schotter", "Kopfsteinpflaster", "Beton", "Wiese" });
            combo_Name.Location = new Point(163, 89);
            combo_Name.Name = "combo_Name";
            combo_Name.Size = new Size(180, 23);
            combo_Name.TabIndex = 1;
            combo_Name.SelectedIndexChanged += combo_Name_SelectedIndexChanged;
            // 
            // combo_Zustand
            // 
            combo_Zustand.FormattingEnabled = true;
            combo_Zustand.Items.AddRange(new object[] { "Gut", "Mittel", "Schlecht" });
            combo_Zustand.Location = new Point(163, 121);
            combo_Zustand.Name = "combo_Zustand";
            combo_Zustand.Size = new Size(180, 23);
            combo_Zustand.TabIndex = 2;
            combo_Zustand.SelectedIndexChanged += combo_Zustand_SelectedIndexChanged;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(57, 92);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(71, 15);
            lbl_name.TabIndex = 3;
            lbl_name.Text = "Untergrund:";
            // 
            // lbl_zustand
            // 
            lbl_zustand.AutoSize = true;
            lbl_zustand.Location = new Point(75, 124);
            lbl_zustand.Name = "lbl_zustand";
            lbl_zustand.Size = new Size(53, 15);
            lbl_zustand.TabIndex = 4;
            lbl_zustand.Text = "Zustand:";
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(268, 180);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 23);
            btn_Save.TabIndex = 5;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // Belag_edit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 230);
            Controls.Add(btn_Save);
            Controls.Add(lbl_zustand);
            Controls.Add(lbl_name);
            Controls.Add(combo_Zustand);
            Controls.Add(combo_Name);
            Controls.Add(lbl1);
            Name = "Belag_edit";
            Text = "Belag_edit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl1;
        private ComboBox combo_Name;
        private ComboBox combo_Zustand;
        private Label lbl_name;
        private Label lbl_zustand;
        private Button btn_Save;
    }
}