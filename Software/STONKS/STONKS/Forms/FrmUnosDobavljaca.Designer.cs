namespace STONKS.Forms
{
    partial class FrmUnosDobavljaca
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddDobavljac = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtOIB = new System.Windows.Forms.TextBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(107, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "| UNOS DOBAVLJACA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "STONKS ";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Azonix", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnBack.Location = new System.Drawing.Point(200, 326);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(185, 38);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "POVRATAK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddDobavljac
            // 
            this.btnAddDobavljac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.btnAddDobavljac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDobavljac.Font = new System.Drawing.Font("Azonix", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddDobavljac.Location = new System.Drawing.Point(427, 326);
            this.btnAddDobavljac.Name = "btnAddDobavljac";
            this.btnAddDobavljac.Size = new System.Drawing.Size(185, 38);
            this.btnAddDobavljac.TabIndex = 22;
            this.btnAddDobavljac.Text = "DODAJ DOBAVLJACA";
            this.btnAddDobavljac.UseVisualStyleBackColor = false;
            this.btnAddDobavljac.Click += new System.EventHandler(this.btnAddDobavljac_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtName.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(200, 95);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(412, 31);
            this.txtName.TabIndex = 21;
            this.txtName.Text = "Naziv";
            // 
            // txtOIB
            // 
            this.txtOIB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtOIB.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOIB.Location = new System.Drawing.Point(200, 183);
            this.txtOIB.Multiline = true;
            this.txtOIB.Name = "txtOIB";
            this.txtOIB.Size = new System.Drawing.Size(412, 31);
            this.txtOIB.TabIndex = 24;
            this.txtOIB.Text = "OIB";
            // 
            // txtAdress
            // 
            this.txtAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtAdress.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdress.Location = new System.Drawing.Point(200, 263);
            this.txtAdress.Multiline = true;
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(412, 31);
            this.txtAdress.TabIndex = 25;
            this.txtAdress.Text = "Adresa";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\7417\\source\\repos\\rpp22-askarica20-fmilohano20-mfriscic20\\Software\\STONK" +
    "S\\User manual.chm";
            // 
            // FrmUnosDobavljaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.txtOIB);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddDobavljac);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmUnosDobavljaca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unos Dobavljaca";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUnosDobavljaca_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddDobavljac;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtOIB;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}