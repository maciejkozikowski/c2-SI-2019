namespace WindowsFormsApp1
{
    partial class Form1
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
            this.button1Wybierz = new System.Windows.Forms.Button();
            this.labelSciezka = new System.Windows.Forms.Label();
            this.openFileDialogSciezka = new System.Windows.Forms.OpenFileDialog();
            this.buttonGenerujSeqCov = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1Wybierz
            // 
            this.button1Wybierz.Location = new System.Drawing.Point(519, 13);
            this.button1Wybierz.Name = "button1Wybierz";
            this.button1Wybierz.Size = new System.Drawing.Size(75, 23);
            this.button1Wybierz.TabIndex = 0;
            this.button1Wybierz.Text = "Wybierz";
            this.button1Wybierz.UseVisualStyleBackColor = true;
            this.button1Wybierz.Click += new System.EventHandler(this.button1Wybierz_Click);
            // 
            // labelSciezka
            // 
            this.labelSciezka.AutoSize = true;
            this.labelSciezka.Location = new System.Drawing.Point(13, 13);
            this.labelSciezka.Name = "labelSciezka";
            this.labelSciezka.Size = new System.Drawing.Size(0, 13);
            this.labelSciezka.TabIndex = 1;
            // 
            // openFileDialogSciezka
            // 
            this.openFileDialogSciezka.FileName = "openFileDialog1";
            // 
            // buttonGenerujSeqCov
            // 
            this.buttonGenerujSeqCov.Location = new System.Drawing.Point(519, 42);
            this.buttonGenerujSeqCov.Name = "buttonGenerujSeqCov";
            this.buttonGenerujSeqCov.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerujSeqCov.TabIndex = 2;
            this.buttonGenerujSeqCov.Text = "Generuj";
            this.buttonGenerujSeqCov.UseVisualStyleBackColor = true;
            this.buttonGenerujSeqCov.Click += new System.EventHandler(this.buttonGeneruj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pokrywanie sekwencyjne";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGenerujSeqCov);
            this.Controls.Add(this.labelSciezka);
            this.Controls.Add(this.button1Wybierz);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1Wybierz;
        private System.Windows.Forms.Label labelSciezka;
        private System.Windows.Forms.OpenFileDialog openFileDialogSciezka;
        private System.Windows.Forms.Button buttonGenerujSeqCov;
        private System.Windows.Forms.Label label1;
    }
}

