using STONKS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STONKS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "test" && txtPassword.Text == "test")
            {


                FrmPocetniIzbornik frmPocetniIzbornik = new FrmPocetniIzbornik();
                frmPocetniIzbornik.ShowDialog();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void SetText(TextBox textBox)
        {
            if (textBox.Text != "")
                textBox.Text = "";
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            SetText(txtUsername);
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            SetText(txtPassword);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
