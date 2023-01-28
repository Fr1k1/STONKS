namespace STONKS.Forms
{
    partial class FrmPopisRacuna
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVrsta = new System.Windows.Forms.ComboBox();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.btnStorniraj = new System.Windows.Forms.Button();
            this.chartRacuni = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStavke = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrikaziSve = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(156, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "| popis racuna";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "STONKS ";
            // 
            // cboVrsta
            // 
            this.cboVrsta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVrsta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cboVrsta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVrsta.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVrsta.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cboVrsta.FormattingEnabled = true;
            this.cboVrsta.ItemHeight = 21;
            this.cboVrsta.Location = new System.Drawing.Point(1069, 90);
            this.cboVrsta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboVrsta.Name = "cboVrsta";
            this.cboVrsta.Size = new System.Drawing.Size(212, 29);
            this.cboVrsta.TabIndex = 25;
            this.cboVrsta.Text = " filter";
            this.cboVrsta.SelectedIndexChanged += new System.EventHandler(this.cboVrsta_SelectedIndexChanged);
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRacuni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRacuni.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacuni.Location = new System.Drawing.Point(36, 137);
            this.dgvRacuni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.Size = new System.Drawing.Size(1247, 274);
            this.dgvRacuni.TabIndex = 26;
            this.dgvRacuni.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRacuni_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label3.Location = new System.Drawing.Point(31, 439);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "stavke racuna";
            // 
            // dgvStavke
            // 
            this.dgvStavke.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStavke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStavke.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavke.Location = new System.Drawing.Point(36, 466);
            this.dgvStavke.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.Size = new System.Drawing.Size(1247, 274);
            this.dgvStavke.TabIndex = 28;
            // 
            // btnPovratak
            // 
            this.btnPovratak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnPovratak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPovratak.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPovratak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPovratak.Location = new System.Drawing.Point(36, 1083);
            this.btnPovratak.Margin = new System.Windows.Forms.Padding(4, 4, 4, 30);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(172, 47);
            this.btnPovratak.TabIndex = 29;
            this.btnPovratak.Text = "Povratak";
            this.btnPovratak.UseVisualStyleBackColor = false;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // btnStorniraj
            // 
            this.btnStorniraj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStorniraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnStorniraj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStorniraj.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorniraj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnStorniraj.Location = new System.Drawing.Point(1027, 1083);
            this.btnStorniraj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 30);
            this.btnStorniraj.Name = "btnStorniraj";
            this.btnStorniraj.Size = new System.Drawing.Size(249, 47);
            this.btnStorniraj.TabIndex = 31;
            this.btnStorniraj.Text = "storaniraj";
            this.btnStorniraj.UseVisualStyleBackColor = false;
            this.btnStorniraj.Click += new System.EventHandler(this.btnStorniraj_Click);
            // 
            // chartRacuni
            // 
            chartArea9.Name = "ChartArea1";
            this.chartRacuni.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chartRacuni.Legends.Add(legend9);
            this.chartRacuni.Location = new System.Drawing.Point(68, 759);
            this.chartRacuni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartRacuni.Name = "chartRacuni";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series9.Legend = "Legend1";
            series9.Name = "Broj placanja";
            this.chartRacuni.Series.Add(series9);
            this.chartRacuni.Size = new System.Drawing.Size(584, 300);
            this.chartRacuni.TabIndex = 38;
            this.chartRacuni.Text = "chartRacuni";
            // 
            // chartStavke
            // 
            this.chartStavke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            chartArea10.Name = "ChartArea1";
            this.chartStavke.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chartStavke.Legends.Add(legend10);
            this.chartStavke.Location = new System.Drawing.Point(679, 759);
            this.chartStavke.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartStavke.Name = "chartStavke";
            this.chartStavke.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Broj artikala";
            this.chartStavke.Series.Add(series10);
            this.chartStavke.Size = new System.Drawing.Size(565, 300);
            this.chartStavke.TabIndex = 39;
            this.chartStavke.Text = "chart1";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(436, 94);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 40;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label4.Location = new System.Drawing.Point(31, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "odaberi datum izdavanja:";
            // 
            // btnPrikaziSve
            // 
            this.btnPrikaziSve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnPrikaziSve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikaziSve.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrikaziSve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPrikaziSve.Location = new System.Drawing.Point(645, 89);
            this.btnPrikaziSve.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrikaziSve.Name = "btnPrikaziSve";
            this.btnPrikaziSve.Size = new System.Drawing.Size(205, 36);
            this.btnPrikaziSve.TabIndex = 42;
            this.btnPrikaziSve.Text = "prikazi sve";
            this.btnPrikaziSve.UseVisualStyleBackColor = false;
            this.btnPrikaziSve.Click += new System.EventHandler(this.btnPrikaziSve_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\7417\\source\\repos\\rpp22-askarica20-fmilohano20-mfriscic20\\Software\\STONK" +
    "S\\User manual.chm";
            // 
            // FrmPopisRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1311, 1197);
            this.Controls.Add(this.btnPrikaziSve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.chartStavke);
            this.Controls.Add(this.chartRacuni);
            this.Controls.Add(this.btnStorniraj);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.dgvStavke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvRacuni);
            this.Controls.Add(this.cboVrsta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPopisRacuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popis racuna";
            this.Load += new System.EventHandler(this.FrmPopisRacuna_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPopisRacuna_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVrsta;
        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvStavke;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.Button btnStorniraj;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRacuni;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStavke;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrikaziSve;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}