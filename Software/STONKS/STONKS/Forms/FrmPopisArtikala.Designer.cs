namespace STONKS.Forms
{
    partial class FrmPopisArtikala
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
            this.dgvArtikli = new System.Windows.Forms.DataGridView();
            this.txtPretraziArtikle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddArticle = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.chartArticles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbVrsta = new System.Windows.Forms.ComboBox();
            this.btnFilterByType = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.cbSort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtikli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArtikli
            // 
            this.dgvArtikli.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvArtikli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtikli.Location = new System.Drawing.Point(157, 116);
            this.dgvArtikli.Name = "dgvArtikli";
            this.dgvArtikli.Size = new System.Drawing.Size(857, 223);
            this.dgvArtikli.TabIndex = 33;
            this.dgvArtikli.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRacuni_CellContentClick);
            // 
            // txtPretraziArtikle
            // 
            this.txtPretraziArtikle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.txtPretraziArtikle.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretraziArtikle.Location = new System.Drawing.Point(12, 69);
            this.txtPretraziArtikle.Multiline = true;
            this.txtPretraziArtikle.Name = "txtPretraziArtikle";
            this.txtPretraziArtikle.Size = new System.Drawing.Size(212, 31);
            this.txtPretraziArtikle.TabIndex = 31;
            this.txtPretraziArtikle.Text = " pretrazi...";
            this.txtPretraziArtikle.Click += new System.EventHandler(this.txtPretraziArtikle_Click);
            this.txtPretraziArtikle.TextChanged += new System.EventHandler(this.txtPretraziArtikle_TextChanged);
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
            // btnAddArticle
            // 
            this.btnAddArticle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnAddArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddArticle.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddArticle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnAddArticle.Location = new System.Drawing.Point(898, 719);
            this.btnAddArticle.Name = "btnAddArticle";
            this.btnAddArticle.Size = new System.Drawing.Size(187, 38);
            this.btnAddArticle.TabIndex = 36;
            this.btnAddArticle.Text = "DODAJ ARTIKL";
            this.btnAddArticle.UseVisualStyleBackColor = false;
            this.btnAddArticle.Click += new System.EventHandler(this.btnAddArticle_Click);
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
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // chartArticles
            // 
            chartArea3.Name = "ChartArea1";
            this.chartArticles.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartArticles.Legends.Add(legend3);
            this.chartArticles.Location = new System.Drawing.Point(305, 354);
            this.chartArticles.Name = "chartArticles";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Artikli po vrsti";
            this.chartArticles.Series.Add(series3);
            this.chartArticles.Size = new System.Drawing.Size(474, 300);
            this.chartArticles.TabIndex = 37;
            this.chartArticles.Text = "chart1";
            // 
            // cbVrsta
            // 
            this.cbVrsta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cbVrsta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbVrsta.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVrsta.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbVrsta.FormattingEnabled = true;
            this.cbVrsta.ItemHeight = 21;
            this.cbVrsta.Location = new System.Drawing.Point(492, 71);
            this.cbVrsta.Name = "cbVrsta";
            this.cbVrsta.Size = new System.Drawing.Size(198, 29);
            this.cbVrsta.TabIndex = 32;
            this.cbVrsta.Text = "filter vrste";
            this.cbVrsta.SelectedIndexChanged += new System.EventHandler(this.cbVrsta_SelectedIndexChanged);
            // 
            // btnFilterByType
            // 
            this.btnFilterByType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnFilterByType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterByType.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterByType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnFilterByType.Location = new System.Drawing.Point(725, 69);
            this.btnFilterByType.Name = "btnFilterByType";
            this.btnFilterByType.Size = new System.Drawing.Size(144, 31);
            this.btnFilterByType.TabIndex = 38;
            this.btnFilterByType.Text = "Filtriraj";
            this.btnFilterByType.UseVisualStyleBackColor = false;
            this.btnFilterByType.Click += new System.EventHandler(this.btnFilterByType_Click);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilter.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnResetFilter.Location = new System.Drawing.Point(907, 69);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(178, 31);
            this.btnResetFilter.TabIndex = 39;
            this.btnResetFilter.Text = "Ponisti filter";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // cbSort
            // 
            this.cbSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cbSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSort.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSort.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbSort.FormattingEnabled = true;
            this.cbSort.ItemHeight = 21;
            this.cbSort.Items.AddRange(new object[] {
            "CIJENA",
            "ABECEDNO"});
            this.cbSort.Location = new System.Drawing.Point(255, 69);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(198, 29);
            this.cbSort.TabIndex = 40;
            this.cbSort.Text = "Sortiranje";
            this.cbSort.SelectedIndexChanged += new System.EventHandler(this.cbSort_SelectedIndexChanged);
            this.cbSort.TextChanged += new System.EventHandler(this.cbSort_TextChanged);
            // 
            // FrmPopisArtikala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1097, 769);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.btnFilterByType);
            this.Controls.Add(this.chartArticles);
            this.Controls.Add(this.btnAddArticle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvArtikli);
            this.Controls.Add(this.cbVrsta);
            this.Controls.Add(this.txtPretraziArtikle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPopisArtikala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popis artikala";
            this.Load += new System.EventHandler(this.FrmPopisArtikala_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtikli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartArticles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArtikli;
        private System.Windows.Forms.TextBox txtPretraziArtikle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddArticle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartArticles;
        private System.Windows.Forms.ComboBox cbVrsta;
        private System.Windows.Forms.Button btnFilterByType;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.ComboBox cbSort;
    }
}