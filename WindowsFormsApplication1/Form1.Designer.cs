namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lstNetworks = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.posizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstNetworks
            // 
            this.lstNetworks.Location = new System.Drawing.Point(12, 62);
            this.lstNetworks.Name = "lstNetworks";
            this.lstNetworks.Size = new System.Drawing.Size(664, 97);
            this.lstNetworks.TabIndex = 1;
            this.lstNetworks.UseCompatibleStateImageBehavior = false;
            this.lstNetworks.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DIMMI DOVE SEI:";
            // 
            // posizione
            // 
            this.posizione.Location = new System.Drawing.Point(127, 19);
            this.posizione.Name = "posizione";
            this.posizione.Size = new System.Drawing.Size(100, 20);
            this.posizione.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "PER SALVARE LE INFO DEVI FARE REFRESH";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.posizione);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstNetworks);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "lstNetworks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lstNetworks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox posizione;
        private System.Windows.Forms.Label label2;
    }
}

