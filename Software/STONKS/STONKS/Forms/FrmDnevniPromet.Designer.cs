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
            this.txtUkupniPromet = new System.Windows.Forms.TextBox();
            this.txtUkupnoKartice = new System.Windows.Forms.TextBox();
            this.txtUkupnoGotovina = new System.Windows.Forms.TextBox();
            this.txtPopustkartice = new System.Windows.Forms.TextBox();
            this.txtKartice = new System.Windows.Forms.TextBox();
            this.txtgotovinaPopust = new System.Windows.Forms.TextBox();
            this.txtGotovina = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIspisPrometX = new System.Windows.Forms.Button();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.btnIzradaIspisZ = new System.Windows.Forms.Button();
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
            this.label3.Location = new System.Drawing.Point(15, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "popust:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.txtUkupniPromet);
            this.panel1.Controls.Add(this.txtUkupnoKartice);
            this.panel1.Controls.Add(this.txtUkupnoGotovina);
            this.panel1.Controls.Add(this.txtPopustkartice);
            this.panel1.Controls.Add(this.txtKartice);
            this.panel1.Controls.Add(this.txtgotovinaPopust);
            this.panel1.Controls.Add(this.txtGotovina);
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
            // txtUkupniPromet
            // 
            this.txtUkupniPromet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUkupniPromet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUkupniPromet.Font = new System.Drawing.Font("Azonix", 28F);
            this.txtUkupniPromet.ForeColor = System.Drawing.Color.White;
            this.txtUkupniPromet.Location = new System.Drawing.Point(386, 167);
            this.txtUkupniPromet.Multiline = true;
            this.txtUkupniPromet.Name = "txtUkupniPromet";
            this.txtUkupniPromet.ReadOnly = true;
            this.txtUkupniPromet.Size = new System.Drawing.Size(155, 39);
            this.txtUkupniPromet.TabIndex = 35;
            this.txtUkupniPromet.Text = "0 EUR";
            this.txtUkupniPromet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUkupnoKartice
            // 
            this.txtUkupnoKartice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUkupnoKartice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUkupnoKartice.Font = new System.Drawing.Font("Azonix", 18F);
            this.txtUkupnoKartice.ForeColor = System.Drawing.Color.White;
            this.txtUkupnoKartice.Location = new System.Drawing.Point(803, 92);
            this.txtUkupnoKartice.Multiline = true;
            this.txtUkupnoKartice.Name = "txtUkupnoKartice";
            this.txtUkupnoKartice.ReadOnly = true;
            this.txtUkupnoKartice.Size = new System.Drawing.Size(99, 29);
            this.txtUkupnoKartice.TabIndex = 34;
            this.txtUkupnoKartice.Text = "0 EUR";
            this.txtUkupnoKartice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUkupnoGotovina
            // 
            this.txtUkupnoGotovina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUkupnoGotovina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUkupnoGotovina.Font = new System.Drawing.Font("Azonix", 18F);
            this.txtUkupnoGotovina.ForeColor = System.Drawing.Color.White;
            this.txtUkupnoGotovina.Location = new System.Drawing.Point(290, 92);
            this.txtUkupnoGotovina.Multiline = true;
            this.txtUkupnoGotovina.Name = "txtUkupnoGotovina";
            this.txtUkupnoGotovina.ReadOnly = true;
            this.txtUkupnoGotovina.Size = new System.Drawing.Size(99, 29);
            this.txtUkupnoGotovina.TabIndex = 33;
            this.txtUkupnoGotovina.Text = "0 EUR";
            this.txtUkupnoGotovina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPopustkartice
            // 
            this.txtPopustkartice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtPopustkartice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPopustkartice.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPopustkartice.ForeColor = System.Drawing.Color.White;
            this.txtPopustkartice.Location = new System.Drawing.Point(646, 57);
            this.txtPopustkartice.Multiline = true;
            this.txtPopustkartice.Name = "txtPopustkartice";
            this.txtPopustkartice.ReadOnly = true;
            this.txtPopustkartice.Size = new System.Drawing.Size(81, 19);
            this.txtPopustkartice.TabIndex = 32;
            this.txtPopustkartice.Text = "0 EUR";
            this.txtPopustkartice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKartice
            // 
            this.txtKartice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtKartice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKartice.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKartice.ForeColor = System.Drawing.Color.White;
            this.txtKartice.Location = new System.Drawing.Point(653, 15);
            this.txtKartice.Multiline = true;
            this.txtKartice.Name = "txtKartice";
            this.txtKartice.ReadOnly = true;
            this.txtKartice.Size = new System.Drawing.Size(81, 19);
            this.txtKartice.TabIndex = 31;
            this.txtKartice.Text = "0 EUR";
            this.txtKartice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtgotovinaPopust
            // 
            this.txtgotovinaPopust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtgotovinaPopust.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtgotovinaPopust.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgotovinaPopust.ForeColor = System.Drawing.Color.White;
            this.txtgotovinaPopust.Location = new System.Drawing.Point(123, 45);
            this.txtgotovinaPopust.Multiline = true;
            this.txtgotovinaPopust.Name = "txtgotovinaPopust";
            this.txtgotovinaPopust.ReadOnly = true;
            this.txtgotovinaPopust.Size = new System.Drawing.Size(81, 19);
            this.txtgotovinaPopust.TabIndex = 30;
            this.txtgotovinaPopust.Text = "0 EUR";
            this.txtgotovinaPopust.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGotovina
            // 
            this.txtGotovina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtGotovina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGotovina.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGotovina.ForeColor = System.Drawing.Color.White;
            this.txtGotovina.Location = new System.Drawing.Point(137, 16);
            this.txtGotovina.Multiline = true;
            this.txtGotovina.Name = "txtGotovina";
            this.txtGotovina.ReadOnly = true;
            this.txtGotovina.Size = new System.Drawing.Size(81, 19);
            this.txtGotovina.TabIndex = 29;
            this.txtGotovina.Text = "0 EUR";
            this.txtGotovina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.label6.Location = new System.Drawing.Point(15, 92);
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
        private System.Windows.Forms.TextBox txtUkupniPromet;
        private System.Windows.Forms.TextBox txtUkupnoKartice;
        private System.Windows.Forms.TextBox txtUkupnoGotovina;
        private System.Windows.Forms.TextBox txtPopustkartice;
        private System.Windows.Forms.TextBox txtKartice;
        private System.Windows.Forms.TextBox txtgotovinaPopust;
        private System.Windows.Forms.TextBox txtGotovina;
        private System.Windows.Forms.Button btnIspisPrometX;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.Button btnIzradaIspisZ;
    }
}