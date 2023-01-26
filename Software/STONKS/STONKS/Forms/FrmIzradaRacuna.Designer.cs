namespace STONKS.Forms
{
    partial class FrmIzradaRacuna
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
            this.btnIzradiRacun = new System.Windows.Forms.Button();
            this.btnIzradiIGenerirajPdf = new System.Windows.Forms.Button();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.cboOdabirNacinaPlacanja = new System.Windows.Forms.ComboBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(116, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "| IZRADA RACUNA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "STONKS ";
            // 
            // btnIzradiRacun
            // 
            this.btnIzradiRacun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnIzradiRacun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzradiRacun.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzradiRacun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnIzradiRacun.Location = new System.Drawing.Point(25, 164);
            this.btnIzradiRacun.Name = "btnIzradiRacun";
            this.btnIzradiRacun.Size = new System.Drawing.Size(390, 57);
            this.btnIzradiRacun.TabIndex = 21;
            this.btnIzradiRacun.Text = "izradi racun";
            this.btnIzradiRacun.UseVisualStyleBackColor = false;
            this.btnIzradiRacun.Click += new System.EventHandler(this.btnIzradiRacun_Click);
            // 
            // btnIzradiIGenerirajPdf
            // 
            this.btnIzradiIGenerirajPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnIzradiIGenerirajPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzradiIGenerirajPdf.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzradiIGenerirajPdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnIzradiIGenerirajPdf.Location = new System.Drawing.Point(25, 240);
            this.btnIzradiIGenerirajPdf.Name = "btnIzradiIGenerirajPdf";
            this.btnIzradiIGenerirajPdf.Size = new System.Drawing.Size(390, 57);
            this.btnIzradiIGenerirajPdf.TabIndex = 22;
            this.btnIzradiIGenerirajPdf.Text = "izradi i generiraj pdf";
            this.btnIzradiIGenerirajPdf.UseVisualStyleBackColor = false;
            this.btnIzradiIGenerirajPdf.Click += new System.EventHandler(this.btnIzradiIGenerirajPdf_Click);
            // 
            // btnPovratak
            // 
            this.btnPovratak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnPovratak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPovratak.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPovratak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPovratak.Location = new System.Drawing.Point(140, 318);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(156, 57);
            this.btnPovratak.TabIndex = 23;
            this.btnPovratak.Text = "Povratak";
            this.btnPovratak.UseVisualStyleBackColor = false;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // cboOdabirNacinaPlacanja
            // 
            this.cboOdabirNacinaPlacanja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cboOdabirNacinaPlacanja.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOdabirNacinaPlacanja.ForeColor = System.Drawing.Color.Black;
            this.cboOdabirNacinaPlacanja.FormattingEnabled = true;
            this.cboOdabirNacinaPlacanja.ItemHeight = 21;
            this.cboOdabirNacinaPlacanja.Location = new System.Drawing.Point(25, 96);
            this.cboOdabirNacinaPlacanja.Name = "cboOdabirNacinaPlacanja";
            this.cboOdabirNacinaPlacanja.Size = new System.Drawing.Size(390, 29);
            this.cboOdabirNacinaPlacanja.TabIndex = 24;
            this.cboOdabirNacinaPlacanja.Text = "odabir nacina placanja:";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\7417\\source\\repos\\rpp22-askarica20-fmilohano20-mfriscic20\\Software\\STONK" +
    "S\\User manual.chm";
            // 
            // FrmIzradaRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(437, 396);
            this.Controls.Add(this.cboOdabirNacinaPlacanja);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.btnIzradiIGenerirajPdf);
            this.Controls.Add(this.btnIzradiRacun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmIzradaRacuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izrada racuna";
            this.Load += new System.EventHandler(this.FrmIzradaRacuna_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmIzradaRacuna_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIzradiRacun;
        private System.Windows.Forms.Button btnIzradiIGenerirajPdf;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.ComboBox cboOdabirNacinaPlacanja;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}