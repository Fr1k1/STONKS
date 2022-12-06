using BusinessLayer.Services;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STONKS.Forms
{
    public partial class FrmRegistracija : Form
    {
        public FrmRegistracija()
        {
            InitializeComponent();
        }


        private UlogeServices ulogeServices = new UlogeServices();

        private KorisniciServices korisniciServices = new KorisniciServices();

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            Hide();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void FrmRegistracija_Load(object sender, EventArgs e)
        {
            GetUloge();
        }

        private void GetUloge()
        {
            var uloge = ulogeServices.GetUloge();
            cbRole.DataSource = uloge;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtOIB.Text.Length != 11)
            {
                MessageBox.Show("OIB ima 11 znakova!!");
                return;
            }
            RegisterUser();
        }

        private void RegisterUser()
        {
            Uloga uloga = cbRole.SelectedItem as Uloga;
            var korisnik = new Korisnik
            {
                ime = txtName.Text,
                prezime = txtSurname.Text,
                OIB = txtOIB.Text,
                korime = txtUsername.Text,
                lozinka = txtPassword.Text,
                uloga_id = uloga.id
            };



            korisniciServices.AddKorisnik(korisnik);
            MessageBox.Show("Uspjesno dodan korisnik");
        }

        private void SetText(TextBox textBox)
        {
            if (textBox.Text != "")
                textBox.Text = "";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {
            SetText(txtName);

        }

        private void txtSurname_Click(object sender, EventArgs e)
        {
            SetText(txtSurname);


        }

        private void txtOIB_Click(object sender, EventArgs e)
        {
            SetText(txtOIB);

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            SetText(txtUsername);

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            SetText(txtPassword);

        }
    }
}
