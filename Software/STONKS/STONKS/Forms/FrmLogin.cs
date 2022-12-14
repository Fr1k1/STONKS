using BusinessLayer.Services;
using DataAccessLayer;
using EntitiesLayer.Entities;
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

        private KorisniciServices services = new KorisniciServices();

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            LoginUser(txtUsername.Text, txtPassword.Text);

        }

        private string GetUloga(string korime, string lozinka)
        {
            var uloga = services.GetUloga(korime, lozinka);
            //MessageBox.Show("Uloga je" + uloga.ToString());
            return uloga[0];
        }

        public static Korisnik korisnik;

        private void LoginUser(string korime, string lozinka)
        {
            var korisnik = services.GetKorisnik(korime, lozinka);
            if (korisnik)
            {

                if (GetUloga(txtUsername.Text, txtPassword.Text) == "voditelj")
                {
                    Hide();


                    FaceRecNew frm = new FaceRecNew();
                    frm.ShowDialog();

                    Close();

                }

                else
                {
                    Hide();
                    FrmPocetniIzbornik frmPocetniIzbornik = new FrmPocetniIzbornik();
                    frmPocetniIzbornik.ShowDialog();
                    Close();

                }
                //FrmPrepoznavanjeLica frmPrepoznavanje = new FrmPrepoznavanjeLica();
                //frmPrepoznavanje.ShowDialog();

            }

            else MessageBox.Show("Krivi korisnicki podaci");

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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegistracija frmRegistracija = new FrmRegistracija();
            Hide();
            frmRegistracija.ShowDialog();
            Close();
        }
    }
}
