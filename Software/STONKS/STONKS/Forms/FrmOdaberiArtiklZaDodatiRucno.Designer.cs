namespace STONKS.Forms
{
    partial class FrmOdaberiArtiklZaDodatiRucno
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPopisArtikala = new System.Windows.Forms.DataGridView();
            this.btnDodajArtikl = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.txtPretrazi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisArtikala)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(116, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "| odaberi artikl za dodati rucno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "STONKS ";
            // 
            // dgvPopisArtikala
            // 
            this.dgvPopisArtikala.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPopisArtikala.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvPopisArtikala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopisArtikala.Location = new System.Drawing.Point(68, 108);
            this.dgvPopisArtikala.MultiSelect = false;
            this.dgvPopisArtikala.Name = "dgvPopisArtikala";
            this.dgvPopisArtikala.ReadOnly = true;
            this.dgvPopisArtikala.Size = new System.Drawing.Size(772, 254);
            this.dgvPopisArtikala.TabIndex = 17;
            this.dgvPopisArtikala.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPopisArtikala_CellDoubleClick);
            // 
            // btnDodajArtikl
            // 
            this.btnDodajArtikl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnDodajArtikl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajArtikl.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajArtikl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnDodajArtikl.Location = new System.Drawing.Point(631, 379);
            this.btnDodajArtikl.Name = "btnDodajArtikl";
            this.btnDodajArtikl.Size = new System.Drawing.Size(209, 38);
            this.btnDodajArtikl.TabIndex = 21;
            this.btnDodajArtikl.Text = "dodaj artikl";
            this.btnDodajArtikl.UseVisualStyleBackColor = false;
            this.btnDodajArtikl.Click += new System.EventHandler(this.btnDodajArtikl_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnOdustani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdustani.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustani.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnOdustani.Location = new System.Drawing.Point(68, 379);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(129, 38);
            this.btnOdustani.TabIndex = 22;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = false;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // txtPretrazi
            // 
            this.txtPretrazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.txtPretrazi.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretrazi.Location = new System.Drawing.Point(68, 74);
            this.txtPretrazi.Multiline = true;
            this.txtPretrazi.Name = "txtPretrazi";
            this.txtPretrazi.Size = new System.Drawing.Size(321, 28);
            this.txtPretrazi.TabIndex = 23;
            this.txtPretrazi.Text = " pretrazi...";
            this.txtPretrazi.TextChanged += new System.EventHandler(this.txtPretrazi_TextChanged);
            // 
            // FrmOdaberiArtiklZaDodatiRucno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(894, 450);
            this.Controls.Add(this.txtPretrazi);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnDodajArtikl);
            this.Controls.Add(this.dgvPopisArtikala);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmOdaberiArtiklZaDodatiRucno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odaberi artikl za dodati rucno";
            this.Load += new System.EventHandler(this.FrmOdaberiArtiklZaDodatiRucno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisArtikala)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPopisArtikala;
        private System.Windows.Forms.Button btnDodajArtikl;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.TextBox txtPretrazi;
    }
}