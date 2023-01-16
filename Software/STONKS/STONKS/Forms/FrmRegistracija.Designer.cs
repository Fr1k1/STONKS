namespace STONKS.Forms
{
    partial class FrmRegistracija
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtOIB = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTakePicture_new = new System.Windows.Forms.Button();
            this.btnSave_new = new System.Windows.Forms.Button();
            this.btnUkljuciKameru_new = new System.Windows.Forms.Button();
            this.pbSlikaZaSpremiti_new = new System.Windows.Forms.PictureBox();
            this.pbCamera_new = new System.Windows.Forms.PictureBox();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.cbCameraName_new = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaZaSpremiti_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera_new)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnBack.Location = new System.Drawing.Point(12, 490);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(158, 38);
            this.btnBack.TabIndex = 30;
            this.btnBack.Text = "POVRATAK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnRegister.Location = new System.Drawing.Point(191, 490);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(166, 38);
            this.btnRegister.TabIndex = 29;
            this.btnRegister.Text = "REGISTRIRAJ SE";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtPassword.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(12, 356);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(345, 31);
            this.txtPassword.TabIndex = 27;
            this.txtPassword.Text = "LOZINKA";
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtUsername.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(12, 283);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(345, 31);
            this.txtUsername.TabIndex = 26;
            this.txtUsername.Text = "KORISNICKO IME";
            this.txtUsername.Click += new System.EventHandler(this.txtUsername_Click);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtOIB
            // 
            this.txtOIB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtOIB.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOIB.Location = new System.Drawing.Point(12, 210);
            this.txtOIB.Multiline = true;
            this.txtOIB.Name = "txtOIB";
            this.txtOIB.Size = new System.Drawing.Size(345, 31);
            this.txtOIB.TabIndex = 25;
            this.txtOIB.Text = "OIB";
            this.txtOIB.Click += new System.EventHandler(this.txtOIB_Click);
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtSurname.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(12, 137);
            this.txtSurname.Multiline = true;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(345, 31);
            this.txtSurname.TabIndex = 24;
            this.txtSurname.Text = "PREZIME";
            this.txtSurname.Click += new System.EventHandler(this.txtSurname_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtName.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(12, 64);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(345, 31);
            this.txtName.TabIndex = 23;
            this.txtName.Text = "IME";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(97, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "| REGISTRACIJA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "STONKS ";
            // 
            // btnTakePicture_new
            // 
            this.btnTakePicture_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnTakePicture_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakePicture_new.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakePicture_new.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnTakePicture_new.Location = new System.Drawing.Point(868, 297);
            this.btnTakePicture_new.Name = "btnTakePicture_new";
            this.btnTakePicture_new.Size = new System.Drawing.Size(167, 68);
            this.btnTakePicture_new.TabIndex = 69;
            this.btnTakePicture_new.Text = "POSLIKAJ";
            this.btnTakePicture_new.UseVisualStyleBackColor = false;
            this.btnTakePicture_new.Click += new System.EventHandler(this.btnTakePicture_new_Click);
            // 
            // btnSave_new
            // 
            this.btnSave_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnSave_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave_new.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave_new.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnSave_new.Location = new System.Drawing.Point(681, 297);
            this.btnSave_new.Name = "btnSave_new";
            this.btnSave_new.Size = new System.Drawing.Size(167, 68);
            this.btnSave_new.TabIndex = 68;
            this.btnSave_new.Text = "SPREMI";
            this.btnSave_new.UseVisualStyleBackColor = false;
            this.btnSave_new.Click += new System.EventHandler(this.btnSave_new_Click);
            // 
            // btnUkljuciKameru_new
            // 
            this.btnUkljuciKameru_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.btnUkljuciKameru_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUkljuciKameru_new.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUkljuciKameru_new.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnUkljuciKameru_new.Location = new System.Drawing.Point(501, 297);
            this.btnUkljuciKameru_new.Name = "btnUkljuciKameru_new";
            this.btnUkljuciKameru_new.Size = new System.Drawing.Size(167, 68);
            this.btnUkljuciKameru_new.TabIndex = 67;
            this.btnUkljuciKameru_new.Text = "UKLJUCI KAMERU";
            this.btnUkljuciKameru_new.UseVisualStyleBackColor = false;
            this.btnUkljuciKameru_new.Click += new System.EventHandler(this.btnUkljuciKameru_new_Click);
            // 
            // pbSlikaZaSpremiti_new
            // 
            this.pbSlikaZaSpremiti_new.Location = new System.Drawing.Point(888, 35);
            this.pbSlikaZaSpremiti_new.Name = "pbSlikaZaSpremiti_new";
            this.pbSlikaZaSpremiti_new.Size = new System.Drawing.Size(224, 206);
            this.pbSlikaZaSpremiti_new.TabIndex = 65;
            this.pbSlikaZaSpremiti_new.TabStop = false;
            // 
            // pbCamera_new
            // 
            this.pbCamera_new.Location = new System.Drawing.Point(501, 35);
            this.pbCamera_new.Name = "pbCamera_new";
            this.pbCamera_new.Size = new System.Drawing.Size(279, 206);
            this.pbCamera_new.TabIndex = 63;
            this.pbCamera_new.TabStop = false;
            // 
            // cbRole
            // 
            this.cbRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRole.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRole.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.ItemHeight = 21;
            this.cbRole.Location = new System.Drawing.Point(12, 416);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(198, 29);
            this.cbRole.TabIndex = 70;
            this.cbRole.Text = "ULOGA";
            // 
            // cbCameraName_new
            // 
            this.cbCameraName_new.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.cbCameraName_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCameraName_new.Font = new System.Drawing.Font("Azonix", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCameraName_new.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbCameraName_new.FormattingEnabled = true;
            this.cbCameraName_new.ItemHeight = 13;
            this.cbCameraName_new.Location = new System.Drawing.Point(501, 416);
            this.cbCameraName_new.Name = "cbCameraName_new";
            this.cbCameraName_new.Size = new System.Drawing.Size(112, 21);
            this.cbCameraName_new.TabIndex = 71;
            // 
            // FrmRegistracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1145, 569);
            this.Controls.Add(this.cbCameraName_new);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.btnTakePicture_new);
            this.Controls.Add(this.btnSave_new);
            this.Controls.Add(this.btnUkljuciKameru_new);
            this.Controls.Add(this.pbSlikaZaSpremiti_new);
            this.Controls.Add(this.pbCamera_new);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtOIB);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegistracija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registracija";
            this.Load += new System.EventHandler(this.FrmRegistracija_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaZaSpremiti_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera_new)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtOIB;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTakePicture_new;
        private System.Windows.Forms.Button btnSave_new;
        private System.Windows.Forms.Button btnUkljuciKameru_new;
        private System.Windows.Forms.PictureBox pbSlikaZaSpremiti_new;
        private System.Windows.Forms.PictureBox pbCamera_new;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.ComboBox cbCameraName_new;
    }
}