namespace STONKS.Forms
{
    partial class FrmUnosPrimke
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
            this.cboDobavljac = new System.Windows.Forms.ComboBox();
            this.dgvStavkePrimke = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddStavkaPrimke = new System.Windows.Forms.Button();
            this.btnUnesiPrimku = new System.Windows.Forms.Button();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.txtPopust = new System.Windows.Forms.TextBox();
            this.txtBrojPrimke = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavkePrimke)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDobavljac
            // 
            this.cboDobavljac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.cboDobavljac.Font = new System.Drawing.Font("Azonix", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cboDobavljac.FormattingEnabled = true;
            this.cboDobavljac.ItemHeight = 16;
            this.cboDobavljac.Location = new System.Drawing.Point(479, 40);
            this.cboDobavljac.Name = "cboDobavljac";
            this.cboDobavljac.Size = new System.Drawing.Size(309, 24);
            this.cboDobavljac.TabIndex = 19;
            this.cboDobavljac.Text = "Dobavljac";
            // 
            // dgvStavkePrimke
            // 
            this.dgvStavkePrimke.AllowUserToAddRows = false;
            this.dgvStavkePrimke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStavkePrimke.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dgvStavkePrimke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavkePrimke.Location = new System.Drawing.Point(12, 70);
            this.dgvStavkePrimke.MultiSelect = false;
            this.dgvStavkePrimke.Name = "dgvStavkePrimke";
            this.dgvStavkePrimke.Size = new System.Drawing.Size(776, 306);
            this.dgvStavkePrimke.TabIndex = 1;
            this.dgvStavkePrimke.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStavkePrimke_CellEndEdit);
            this.dgvStavkePrimke.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvStavkePrimke_RowsRemoved);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(101, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "| UNOS PRIMKE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "STONKS ";
            // 
            // btnAddStavkaPrimke
            // 
            this.btnAddStavkaPrimke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.btnAddStavkaPrimke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStavkaPrimke.Font = new System.Drawing.Font("Azonix", 12F);
            this.btnAddStavkaPrimke.Location = new System.Drawing.Point(16, 391);
            this.btnAddStavkaPrimke.Name = "btnAddStavkaPrimke";
            this.btnAddStavkaPrimke.Size = new System.Drawing.Size(151, 39);
            this.btnAddStavkaPrimke.TabIndex = 23;
            this.btnAddStavkaPrimke.Text = "DODAJ RUCNO";
            this.btnAddStavkaPrimke.UseVisualStyleBackColor = false;
            this.btnAddStavkaPrimke.Click += new System.EventHandler(this.btnAddStavkaPrimke_Click);
            // 
            // btnUnesiPrimku
            // 
            this.btnUnesiPrimku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnUnesiPrimku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnesiPrimku.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnesiPrimku.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnUnesiPrimku.Location = new System.Drawing.Point(580, 451);
            this.btnUnesiPrimku.Name = "btnUnesiPrimku";
            this.btnUnesiPrimku.Size = new System.Drawing.Size(208, 38);
            this.btnUnesiPrimku.TabIndex = 25;
            this.btnUnesiPrimku.Text = "UNESI PRIMKU";
            this.btnUnesiPrimku.UseVisualStyleBackColor = false;
            this.btnUnesiPrimku.Click += new System.EventHandler(this.btnUnesiPrimku_Click);
            // 
            // btnPovratak
            // 
            this.btnPovratak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnPovratak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPovratak.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPovratak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPovratak.Location = new System.Drawing.Point(16, 451);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(191, 38);
            this.btnPovratak.TabIndex = 24;
            this.btnPovratak.Text = "POVRATAK";
            this.btnPovratak.UseVisualStyleBackColor = false;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // txtUkupno
            // 
            this.txtUkupno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.txtUkupno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUkupno.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUkupno.ForeColor = System.Drawing.Color.White;
            this.txtUkupno.Location = new System.Drawing.Point(130, 29);
            this.txtUkupno.Multiline = true;
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.ReadOnly = true;
            this.txtUkupno.Size = new System.Drawing.Size(176, 19);
            this.txtUkupno.TabIndex = 28;
            this.txtUkupno.Text = "0 EUR";
            // 
            // txtPopust
            // 
            this.txtPopust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.txtPopust.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPopust.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPopust.ForeColor = System.Drawing.Color.White;
            this.txtPopust.Location = new System.Drawing.Point(130, 4);
            this.txtPopust.Multiline = true;
            this.txtPopust.Name = "txtPopust";
            this.txtPopust.ReadOnly = true;
            this.txtPopust.Size = new System.Drawing.Size(176, 19);
            this.txtPopust.TabIndex = 29;
            this.txtPopust.Text = "0 EUR";
            // 
            // txtBrojPrimke
            // 
            this.txtBrojPrimke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.txtBrojPrimke.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBrojPrimke.Font = new System.Drawing.Font("Azonix", 15F);
            this.txtBrojPrimke.ForeColor = System.Drawing.Color.White;
            this.txtBrojPrimke.Location = new System.Drawing.Point(12, 40);
            this.txtBrojPrimke.Multiline = true;
            this.txtBrojPrimke.Name = "txtBrojPrimke";
            this.txtBrojPrimke.ReadOnly = true;
            this.txtBrojPrimke.Size = new System.Drawing.Size(236, 24);
            this.txtBrojPrimke.TabIndex = 30;
            this.txtBrojPrimke.Text = "Broj primke : 000";
            this.txtBrojPrimke.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label5.Location = new System.Drawing.Point(17, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "ukupno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label4.Location = new System.Drawing.Point(17, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "popust:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPopust);
            this.panel1.Controls.Add(this.txtUkupno);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(479, 382);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 61);
            this.panel1.TabIndex = 31;
            // 
            // FrmUnosPrimke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBrojPrimke);
            this.Controls.Add(this.btnUnesiPrimku);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.btnAddStavkaPrimke);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStavkePrimke);
            this.Controls.Add(this.cboDobavljac);
            this.Name = "FrmUnosPrimke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos primke";
            this.Load += new System.EventHandler(this.FrmUnosPrimke_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavkePrimke)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboDobavljac;
        private System.Windows.Forms.DataGridView dgvStavkePrimke;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddStavkaPrimke;
        private System.Windows.Forms.Button btnUnesiPrimku;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.TextBox txtPopust;
        private System.Windows.Forms.TextBox txtBrojPrimke;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}