namespace Had
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Rychlost = new System.Windows.Forms.TrackBar();
            this.lblRychlost = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSkore = new System.Windows.Forms.Label();
            this.Skore = new System.Windows.Forms.Label();
            this.tlacitkoStart = new System.Windows.Forms.Button();
            this.tlacitkoStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Rychlost)).BeginInit();
            this.SuspendLayout();
            // 
            // Rychlost
            // 
            this.Rychlost.Location = new System.Drawing.Point(12, 69);
            this.Rychlost.Maximum = 100;
            this.Rychlost.Name = "Rychlost";
            this.Rychlost.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Rychlost.Size = new System.Drawing.Size(45, 377);
            this.Rychlost.TabIndex = 0;
            this.Rychlost.Value = 50;
            this.Rychlost.Scroll += new System.EventHandler(this.Rychlost_Scroll);
            // 
            // lblRychlost
            // 
            this.lblRychlost.AutoSize = true;
            this.lblRychlost.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblRychlost.Location = new System.Drawing.Point(6, 9);
            this.lblRychlost.Name = "lblRychlost";
            this.lblRychlost.Size = new System.Drawing.Size(95, 33);
            this.lblRychlost.TabIndex = 1;
            this.lblRychlost.Text = "Rychlost";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(60, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 450);
            this.panel1.TabIndex = 2;
            // 
            // lblSkore
            // 
            this.lblSkore.AutoSize = true;
            this.lblSkore.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSkore.Location = new System.Drawing.Point(648, 184);
            this.lblSkore.Name = "lblSkore";
            this.lblSkore.Size = new System.Drawing.Size(75, 33);
            this.lblSkore.TabIndex = 3;
            this.lblSkore.Text = "Skore:";
            // 
            // Skore
            // 
            this.Skore.AutoSize = true;
            this.Skore.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Skore.Location = new System.Drawing.Point(653, 230);
            this.Skore.Name = "Skore";
            this.Skore.Size = new System.Drawing.Size(70, 84);
            this.Skore.TabIndex = 4;
            this.Skore.Text = "0";
            // 
            // tlacitkoStart
            // 
            this.tlacitkoStart.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tlacitkoStart.Location = new System.Drawing.Point(636, 27);
            this.tlacitkoStart.Name = "tlacitkoStart";
            this.tlacitkoStart.Size = new System.Drawing.Size(152, 52);
            this.tlacitkoStart.TabIndex = 5;
            this.tlacitkoStart.Text = "Start";
            this.tlacitkoStart.UseVisualStyleBackColor = true;
            this.tlacitkoStart.Click += new System.EventHandler(this.tlacitkoStart_Click);
            // 
            // tlacitkoStop
            // 
            this.tlacitkoStop.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tlacitkoStop.Location = new System.Drawing.Point(636, 85);
            this.tlacitkoStop.Name = "tlacitkoStop";
            this.tlacitkoStop.Size = new System.Drawing.Size(152, 52);
            this.tlacitkoStop.TabIndex = 6;
            this.tlacitkoStop.Text = "Stop";
            this.tlacitkoStop.UseVisualStyleBackColor = true;
            this.tlacitkoStop.Click += new System.EventHandler(this.tlacitkoStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.tlacitkoStop);
            this.Controls.Add(this.tlacitkoStart);
            this.Controls.Add(this.Skore);
            this.Controls.Add(this.lblSkore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRychlost);
            this.Controls.Add(this.Rychlost);
            this.Name = "Form1";
            this.Text = "Had";
            ((System.ComponentModel.ISupportInitialize)(this.Rychlost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar Rychlost;
        private System.Windows.Forms.Label lblRychlost;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSkore;
        private System.Windows.Forms.Label Skore;
        private System.Windows.Forms.Button tlacitkoStart;
        private System.Windows.Forms.Button tlacitkoStop;
        private System.Windows.Forms.Timer timer1;
    }
}

