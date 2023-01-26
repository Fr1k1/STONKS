using BusinessLayer.Services;
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

        public static Korisnik logirani;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private KorisniciServices services = new KorisniciServices();

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtUsername.Text == "Korisnicko ime" || txtPassword.Text == "" || txtPassword.Text == "Lozinka")
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
            try
            {
                var korisnik = services.GetLoggedKorisnik(txtUsername.Text, txtPassword.Text);
                FrmPrepoznavanjeLica.logiraniKorisnik = korisnik;
                LoginUser(txtUsername.Text, txtPassword.Text);
            }

            catch (Exception exc)
            {
                MessageBox.Show("Krivi korisnički podaci!");
            }
        }

        private string GetUloga(string korime, string lozinka)
        {
            var uloga = services.GetUloga(korime, lozinka);
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
                    FrmPocetniIzbornikVoditelj frm = new FrmPocetniIzbornikVoditelj();
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
            }
            else MessageBox.Show("Krivi korisnicki podaci");
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegistracija frmRegistracija = new FrmRegistracija();
            Hide();
            frmRegistracija.ShowDialog();
            Close();
        }



        //show context based help when pressing F1 key
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "prijava.html");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + "\\UserManual.chm";
        }
    }
}
