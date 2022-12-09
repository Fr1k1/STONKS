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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPretraziRacun = new System.Windows.Forms.TextBox();
            this.cboVrsta = new System.Windows.Forms.ComboBox();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.btnGenerirajPdf = new System.Windows.Forms.Button();
            this.btnStorniraj = new System.Windows.Forms.Button();
            this.chartRacuni = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRacuni)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(117, 19);
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
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "STONKS ";
            // 
            // txtPretraziRacun
            // 
            this.txtPretraziRacun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.txtPretraziRacun.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretraziRacun.Location = new System.Drawing.Point(27, 74);
            this.txtPretraziRacun.Multiline = true;
            this.txtPretraziRacun.Name = "txtPretraziRacun";
            this.txtPretraziRacun.Size = new System.Drawing.Size(321, 31);
            this.txtPretraziRacun.TabIndex = 24;
            this.txtPretraziRacun.Text = " pretrazi...";
            // 
            // cboVrsta
            // 
            this.cboVrsta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cboVrsta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVrsta.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVrsta.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cboVrsta.FormattingEnabled = true;
            this.cboVrsta.ItemHeight = 21;
            this.cboVrsta.Location = new System.Drawing.Point(834, 73);
            this.cboVrsta.Name = "cboVrsta";
            this.cboVrsta.Size = new System.Drawing.Size(128, 29);
            this.cboVrsta.TabIndex = 25;
            this.cboVrsta.Text = " filter";
            this.cboVrsta.SelectedIndexChanged += new System.EventHandler(this.cboVrsta_SelectedIndexChanged);
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRacuni.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacuni.Location = new System.Drawing.Point(27, 111);
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.Size = new System.Drawing.Size(935, 223);
            this.dgvRacuni.TabIndex = 26;
            this.dgvRacuni.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRacuni_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label3.Location = new System.Drawing.Point(23, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "stavke racuna";
            // 
            // dgvStavke
            // 
            this.dgvStavke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStavke.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavke.Location = new System.Drawing.Point(27, 379);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.Size = new System.Drawing.Size(935, 223);
            this.dgvStavke.TabIndex = 28;
            // 
            // btnPovratak
            // 
            this.btnPovratak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnPovratak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPovratak.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPovratak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPovratak.Location = new System.Drawing.Point(27, 880);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(129, 38);
            this.btnPovratak.TabIndex = 29;
            this.btnPovratak.Text = "Povratak";
            this.btnPovratak.UseVisualStyleBackColor = false;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // btnGenerirajPdf
            // 
            this.btnGenerirajPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnGenerirajPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerirajPdf.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerirajPdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnGenerirajPdf.Location = new System.Drawing.Point(546, 880);
            this.btnGenerirajPdf.Name = "btnGenerirajPdf";
            this.btnGenerirajPdf.Size = new System.Drawing.Size(209, 38);
            this.btnGenerirajPdf.TabIndex = 30;
            this.btnGenerirajPdf.Text = "generiraj pdf";
            this.btnGenerirajPdf.UseVisualStyleBackColor = false;
            // 
            // btnStorniraj
            // 
            this.btnStorniraj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnStorniraj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStorniraj.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorniraj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnStorniraj.Location = new System.Drawing.Point(770, 880);
            this.btnStorniraj.Name = "btnStorniraj";
            this.btnStorniraj.Size = new System.Drawing.Size(187, 38);
            this.btnStorniraj.TabIndex = 31;
            this.btnStorniraj.Text = "storaniraj";
            this.btnStorniraj.UseVisualStyleBackColor = false;
            // 
            // chartRacuni
            // 
            chartArea3.Name = "ChartArea1";
            this.chartRacuni.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartRacuni.Legends.Add(legend3);
            this.chartRacuni.Location = new System.Drawing.Point(286, 619);
            this.chartRacuni.Name = "chartRacuni";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartRacuni.Series.Add(series3);
            this.chartRacuni.Size = new System.Drawing.Size(438, 244);
            this.chartRacuni.TabIndex = 38;
            this.chartRacuni.Text = "chart1";
            // 
            // FrmPopisRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(983, 948);
            this.Controls.Add(this.chartRacuni);
            this.Controls.Add(this.btnStorniraj);
            this.Controls.Add(this.btnGenerirajPdf);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.dgvStavke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvRacuni);
            this.Controls.Add(this.cboVrsta);
            this.Controls.Add(this.txtPretraziRacun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPopisRacuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popis racuna";
            this.Load += new System.EventHandler(this.FrmPopisRacuna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRacuni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPretraziRacun;
        private System.Windows.Forms.ComboBox cboVrsta;
        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvStavke;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.Button btnGenerirajPdf;
        private System.Windows.Forms.Button btnStorniraj;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRacuni;
    }
}