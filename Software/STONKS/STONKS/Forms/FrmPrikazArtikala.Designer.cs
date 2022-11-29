namespace STONKS.Forms
{
    partial class FrmPrikazArtikala
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.cboNaziv = new System.Windows.Forms.ComboBox();
            this.txtPretraziArtikle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStorniraj = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.chartArticles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacuni.Location = new System.Drawing.Point(12, 106);
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.Size = new System.Drawing.Size(772, 223);
            this.dgvRacuni.TabIndex = 33;
            // 
            // cboNaziv
            // 
            this.cboNaziv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cboNaziv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNaziv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNaziv.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNaziv.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cboNaziv.FormattingEnabled = true;
            this.cboNaziv.ItemHeight = 25;
            this.cboNaziv.Location = new System.Drawing.Point(656, 69);
            this.cboNaziv.Name = "cboNaziv";
            this.cboNaziv.Size = new System.Drawing.Size(128, 31);
            this.cboNaziv.TabIndex = 32;
            this.cboNaziv.Text = " filter";
            // 
            // txtPretraziArtikle
            // 
            this.txtPretraziArtikle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.txtPretraziArtikle.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretraziArtikle.Location = new System.Drawing.Point(12, 69);
            this.txtPretraziArtikle.Multiline = true;
            this.txtPretraziArtikle.Name = "txtPretraziArtikle";
            this.txtPretraziArtikle.Size = new System.Drawing.Size(321, 31);
            this.txtPretraziArtikle.TabIndex = 31;
            this.txtPretraziArtikle.Text = " pretrazi...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(102, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 19);
            this.label2.TabIndex = 30;
            this.label2.Text = "| POPIS ARTIKALA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 29;
            this.label1.Text = "STONKS ";
            // 
            // btnStorniraj
            // 
            this.btnStorniraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnStorniraj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStorniraj.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorniraj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnStorniraj.Location = new System.Drawing.Point(597, 719);
            this.btnStorniraj.Name = "btnStorniraj";
            this.btnStorniraj.Size = new System.Drawing.Size(187, 38);
            this.btnStorniraj.TabIndex = 36;
            this.btnStorniraj.Text = "DODAJ ARTIKL";
            this.btnStorniraj.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnBack.Location = new System.Drawing.Point(12, 719);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(129, 38);
            this.btnBack.TabIndex = 34;
            this.btnBack.Text = "Povratak";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // chartArticles
            // 
            chartArea1.Name = "ChartArea1";
            this.chartArticles.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartArticles.Legends.Add(legend1);
            this.chartArticles.Location = new System.Drawing.Point(159, 371);
            this.chartArticles.Name = "chartArticles";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartArticles.Series.Add(series1);
            this.chartArticles.Size = new System.Drawing.Size(474, 300);
            this.chartArticles.TabIndex = 37;
            this.chartArticles.Text = "chart1";
            // 
            // FrmPrikazArtikala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(800, 769);
            this.Controls.Add(this.chartArticles);
            this.Controls.Add(this.btnStorniraj);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvRacuni);
            this.Controls.Add(this.cboNaziv);
            this.Controls.Add(this.txtPretraziArtikle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPrikazArtikala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prikaz artikala";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArticles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.ComboBox cboNaziv;
        private System.Windows.Forms.TextBox txtPretraziArtikle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStorniraj;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartArticles;
    }
}