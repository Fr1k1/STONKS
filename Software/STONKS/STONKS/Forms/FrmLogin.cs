﻿using BusinessLayer.Services;
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

            Hide();

            FrmPrepoznavanjeLica frmPrepoznavanje = new FrmPrepoznavanjeLica();
            frmPrepoznavanje.ShowDialog();

            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();



            Close();

            //LoginUser(txtUsername.Text, txtPassword.Text);

            //GetAllUsers();

        }

        /* private void LoginUser(string korime, string lozinka)
         {
             using (var db = new STONKS_DB())
             {
                 var korisnik = db.Korisnici.FirstOrDefault(k => k.korime == korime && k.lozinka == lozinka);

                 if (korisnik != null)
                 {
                     MessageBox.Show("Uspjesan login");
                 }
             }
         }*/  //ovo dela ali pretvori u n layer

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void GetAllUsers()
        {
            var allusers = services.GetKorisnici();
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
