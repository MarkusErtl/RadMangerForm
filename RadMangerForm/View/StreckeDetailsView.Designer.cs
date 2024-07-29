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
            SuspendLayout();
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(24, 28);
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
            listBoxTrink.Location = new Point(235, 28);
            listBoxTrink.Name = "listBoxTrink";
            listBoxTrink.Size = new Size(787, 64);
            listBoxTrink.TabIndex = 2;
            listBoxTrink.SelectedIndexChanged += listBoxTrink_SelectedIndexChanged;
            // 
            // listBoxBelag
            // 
            listBoxBelag.FormattingEnabled = true;
            listBoxBelag.ItemHeight = 15;
            listBoxBelag.Location = new Point(235, 166);
            listBoxBelag.Name = "listBoxBelag";
            listBoxBelag.Size = new Size(787, 79);
            listBoxBelag.TabIndex = 3;
            listBoxBelag.SelectedIndexChanged += listBoxBelag_SelectedIndexChanged;
            // 
            // lbl10
            // 
            lbl10.AutoSize = true;
            lbl10.Location = new Point(235, 9);
            lbl10.Name = "lbl10";
            lbl10.Size = new Size(80, 15);
            lbl10.TabIndex = 4;
            lbl10.Text = "Trinkbrunnen:";
            // 
            // lbl11
            // 
            lbl11.AutoSize = true;
            lbl11.Location = new Point(235, 148);
            lbl11.Name = "lbl11";
            lbl11.Size = new Size(111, 15);
            lbl11.TabIndex = 5;
            lbl11.Text = "Belag: (Untergrund)";
            // 
            // StreckeDetailsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 396);
            Controls.Add(lbl11);
            Controls.Add(lbl10);
            Controls.Add(listBoxBelag);
            Controls.Add(listBoxTrink);
            Controls.Add(lb1);
            Name = "StreckeDetailsView";
            Text = "StreckeDetailsView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb1;
        private ListBox listBoxTrink;
        private ListBox listBoxBelag;
        private Label lbl10;
        private Label lbl11;
    }
}