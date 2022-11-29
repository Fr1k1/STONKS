namespace STONKS.Forms
{
    partial class FrmPrepoznavanjeLica
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
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecognizedUser = new System.Windows.Forms.TextBox();
            this.txtLogedUser = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.btnBack.Location = new System.Drawing.Point(12, 372);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(136, 38);
            this.btnBack.TabIndex = 30;
            this.btnBack.Text = "POVRATAK";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // pbCamera
            // 
            this.pbCamera.Location = new System.Drawing.Point(423, 21);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(353, 229);
            this.pbCamera.TabIndex = 31;
            this.pbCamera.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(57)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "STONKS ";
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.btnAddPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPicture.Font = new System.Drawing.Font("Azonix", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPicture.Location = new System.Drawing.Point(647, 372);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(129, 38);
            this.btnAddPicture.TabIndex = 38;
            this.btnAddPicture.Text = "DODAVANJE FOTOGRAFIJE";
            this.btnAddPicture.UseVisualStyleBackColor = false;
            // 
            // btnRecognize
            // 
            this.btnRecognize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.btnRecognize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecognize.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecognize.Location = new System.Drawing.Point(423, 372);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(207, 38);
            this.btnRecognize.TabIndex = 34;
            this.btnRecognize.Text = "PREPOZNAJ LICE";
            this.btnRecognize.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Azonix", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label3.Location = new System.Drawing.Point(519, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "OSOBA NA OVOJ SLICI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(99, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "| DODAVANJE FOTOGRAFIJE";
            // 
            // txtRecognizedUser
            // 
            this.txtRecognizedUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtRecognizedUser.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecognizedUser.Location = new System.Drawing.Point(505, 306);
            this.txtRecognizedUser.Multiline = true;
            this.txtRecognizedUser.Name = "txtRecognizedUser";
            this.txtRecognizedUser.Size = new System.Drawing.Size(203, 29);
            this.txtRecognizedUser.TabIndex = 39;
            this.txtRecognizedUser.Text = "Korisnicko ime";
            // 
            // txtLogedUser
            // 
            this.txtLogedUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.txtLogedUser.Font = new System.Drawing.Font("Azonix", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogedUser.Location = new System.Drawing.Point(125, 149);
            this.txtLogedUser.Multiline = true;
            this.txtLogedUser.Name = "txtLogedUser";
            this.txtLogedUser.Size = new System.Drawing.Size(203, 29);
            this.txtLogedUser.TabIndex = 40;
            this.txtLogedUser.Text = "Korisnicko ime";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Azonix", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(161, 212);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(129, 38);
            this.btnConfirm.TabIndex = 41;
            this.btnConfirm.Text = "POTVRDI";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // FrmPrepoznavanjeLica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtLogedUser);
            this.Controls.Add(this.txtRecognizedUser);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCamera);
            this.Controls.Add(this.btnBack);
            this.Name = "FrmPrepoznavanjeLica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prepoznavanje lica";
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox pbCamera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecognizedUser;
        private System.Windows.Forms.TextBox txtLogedUser;
        private System.Windows.Forms.Button btnConfirm;
    }
}