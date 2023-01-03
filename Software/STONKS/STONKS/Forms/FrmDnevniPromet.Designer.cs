namespace STONKS.Forms
{
    partial class FrmDnevniPromet
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbPopust = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIspisPrometX = new System.Windows.Forms.Button();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.btnIzradaIspisZ = new System.Windows.Forms.Button();
            this.lblUkupniPromet = new System.Windows.Forms.Label();
            this.lblUkupnoKartice = new System.Windows.Forms.Label();
            this.lblUkupnoGotovina = new System.Windows.Forms.Label();
            this.lblgotovinaPopust = new System.Windows.Forms.Label();
            this.lblPopustkartice = new System.Windows.Forms.Label();
            this.lblKartice = new System.Windows.Forms.Label();
            this.lblGotovina = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(106, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 19);
            this.label2.TabIndex = 37;
            this.label2.Text = "| dnevni promet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 36;
            this.label1.Text = "STONKS ";
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.dtpDate.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpDate.Location = new System.Drawing.Point(16, 58);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(204, 21);
            this.dtpDate.TabIndex = 38;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lbPopust
            // 
            this.lbPopust.AutoSize = true;
            this.lbPopust.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPopust.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.lbPopust.Location = new System.Drawing.Point(15, 16);
            this.lbPopust.Name = "lbPopust";
            this.lbPopust.Size = new System.Drawing.Size(116, 19);
            this.lbPopust.TabIndex = 22;
            this.lbPopust.Text = "Gotovina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label3.Location = new System.Drawing.Point(18, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "popust:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblGotovina);
            this.panel1.Controls.Add(this.lblKartice);
            this.panel1.Controls.Add(this.lblPopustkartice);
            this.panel1.Controls.Add(this.lblgotovinaPopust);
            this.panel1.Controls.Add(this.lblUkupnoGotovina);
            this.panel1.Controls.Add(this.lblUkupnoKartice);
            this.panel1.Controls.Add(this.lblUkupniPromet);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbPopust);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(16, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 257);
            this.panel1.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Azonix", 28F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label8.Location = new System.Drawing.Point(15, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(377, 38);
            this.label8.TabIndex = 28;
            this.label8.Text = "Ukupni promet:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Azonix", 18F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label7.Location = new System.Drawing.Point(543, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "Ukupno Kartice:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Azonix", 18F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label6.Location = new System.Drawing.Point(18, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 24);
            this.label6.TabIndex = 26;
            this.label6.Text = "Ukupno Gotovina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label4.Location = new System.Drawing.Point(543, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "kartice:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label5.Location = new System.Drawing.Point(543, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "popust:";
            // 
            // btnIspisPrometX
            // 
            this.btnIspisPrometX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnIspisPrometX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIspisPrometX.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIspisPrometX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnIspisPrometX.Location = new System.Drawing.Point(563, 358);
            this.btnIspisPrometX.Name = "btnIspisPrometX";
            this.btnIspisPrometX.Size = new System.Drawing.Size(208, 38);
            this.btnIspisPrometX.TabIndex = 42;
            this.btnIspisPrometX.Text = "ispis Promet X";
            this.btnIspisPrometX.UseVisualStyleBackColor = false;
            this.btnIspisPrometX.Click += new System.EventHandler(this.btnIspisPrometX_Click);
            // 
            // btnPovratak
            // 
            this.btnPovratak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnPovratak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPovratak.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPovratak.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnPovratak.Location = new System.Drawing.Point(16, 358);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(191, 38);
            this.btnPovratak.TabIndex = 41;
            this.btnPovratak.Text = "POVRATAK";
            this.btnPovratak.UseVisualStyleBackColor = false;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // btnIzradaIspisZ
            // 
            this.btnIzradaIspisZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnIzradaIspisZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzradaIspisZ.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzradaIspisZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnIzradaIspisZ.Location = new System.Drawing.Point(792, 358);
            this.btnIzradaIspisZ.Name = "btnIzradaIspisZ";
            this.btnIzradaIspisZ.Size = new System.Drawing.Size(294, 38);
            this.btnIzradaIspisZ.TabIndex = 43;
            this.btnIzradaIspisZ.Text = "izrada i ispis Promet z";
            this.btnIzradaIspisZ.UseVisualStyleBackColor = false;
            this.btnIzradaIspisZ.Click += new System.EventHandler(this.btnIzradaIspisZ_Click);
            // 
            // lblUkupniPromet
            // 
            this.lblUkupniPromet.AutoSize = true;
            this.lblUkupniPromet.Font = new System.Drawing.Font("Azonix", 28F);
            this.lblUkupniPromet.ForeColor = System.Drawing.Color.White;
            this.lblUkupniPromet.Location = new System.Drawing.Point(398, 167);
            this.lblUkupniPromet.Name = "lblUkupniPromet";
            this.lblUkupniPromet.Size = new System.Drawing.Size(153, 38);
            this.lblUkupniPromet.TabIndex = 37;
            this.lblUkupniPromet.Text = "0 EUR";
            // 
            // lblUkupnoKartice
            // 
            this.lblUkupnoKartice.AutoSize = true;
            this.lblUkupnoKartice.Font = new System.Drawing.Font("Azonix", 18F);
            this.lblUkupnoKartice.ForeColor = System.Drawing.Color.White;
            this.lblUkupnoKartice.Location = new System.Drawing.Point(803, 92);
            this.lblUkupnoKartice.Name = "lblUkupnoKartice";
            this.lblUkupnoKartice.Size = new System.Drawing.Size(96, 24);
            this.lblUkupnoKartice.TabIndex = 38;
            this.lblUkupnoKartice.Text = "0 EUR";
            // 
            // lblUkupnoGotovina
            // 
            this.lblUkupnoGotovina.AutoSize = true;
            this.lblUkupnoGotovina.Font = new System.Drawing.Font("Azonix", 18F);
            this.lblUkupnoGotovina.ForeColor = System.Drawing.Color.White;
            this.lblUkupnoGotovina.Location = new System.Drawing.Point(293, 92);
            this.lblUkupnoGotovina.Name = "lblUkupnoGotovina";
            this.lblUkupnoGotovina.Size = new System.Drawing.Size(96, 24);
            this.lblUkupnoGotovina.TabIndex = 39;
            this.lblUkupnoGotovina.Text = "0 EUR";
            // 
            // lblgotovinaPopust
            // 
            this.lblgotovinaPopust.AutoSize = true;
            this.lblgotovinaPopust.Font = new System.Drawing.Font("Azonix", 15.75F);
            this.lblgotovinaPopust.ForeColor = System.Drawing.Color.White;
            this.lblgotovinaPopust.Location = new System.Drawing.Point(121, 57);
            this.lblgotovinaPopust.Name = "lblgotovinaPopust";
            this.lblgotovinaPopust.Size = new System.Drawing.Size(85, 21);
            this.lblgotovinaPopust.TabIndex = 40;
            this.lblgotovinaPopust.Text = "0 EUR";
            // 
            // lblPopustkartice
            // 
            this.lblPopustkartice.AutoSize = true;
            this.lblPopustkartice.Font = new System.Drawing.Font("Azonix", 15.75F);
            this.lblPopustkartice.ForeColor = System.Drawing.Color.White;
            this.lblPopustkartice.Location = new System.Drawing.Point(646, 57);
            this.lblPopustkartice.Name = "lblPopustkartice";
            this.lblPopustkartice.Size = new System.Drawing.Size(85, 21);
            this.lblPopustkartice.TabIndex = 41;
            this.lblPopustkartice.Text = "0 EUR";
            // 
            // lblKartice
            // 
            this.lblKartice.AutoSize = true;
            this.lblKartice.Font = new System.Drawing.Font("Azonix", 15.75F);
            this.lblKartice.ForeColor = System.Drawing.Color.White;
            this.lblKartice.Location = new System.Drawing.Point(653, 16);
            this.lblKartice.Name = "lblKartice";
            this.lblKartice.Size = new System.Drawing.Size(85, 21);
            this.lblKartice.TabIndex = 42;
            this.lblKartice.Text = "0 EUR";
            // 
            // lblGotovina
            // 
            this.lblGotovina.AutoSize = true;
            this.lblGotovina.Font = new System.Drawing.Font("Azonix", 15.75F);
            this.lblGotovina.ForeColor = System.Drawing.Color.White;
            this.lblGotovina.Location = new System.Drawing.Point(137, 15);
            this.lblGotovina.Name = "lblGotovina";
            this.lblGotovina.Size = new System.Drawing.Size(85, 21);
            this.lblGotovina.TabIndex = 43;
            this.lblGotovina.Text = "0 EUR";
            // 
            // FrmDnevniPromet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1098, 419);
            this.Controls.Add(this.btnIzradaIspisZ);
            this.Controls.Add(this.btnIspisPrometX);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDnevniPromet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dnevni promet";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lbPopust;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnIspisPrometX;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.Button btnIzradaIspisZ;
        private System.Windows.Forms.Label lblUkupniPromet;
        private System.Windows.Forms.Label lblGotovina;
        private System.Windows.Forms.Label lblKartice;
        private System.Windows.Forms.Label lblPopustkartice;
        private System.Windows.Forms.Label lblgotovinaPopust;
        private System.Windows.Forms.Label lblUkupnoGotovina;
        private System.Windows.Forms.Label lblUkupnoKartice;
    }
}