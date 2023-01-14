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
    public partial class FrmDnevniPromet : Form
    {
        public FrmDnevniPromet()
        {
            InitializeComponent();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Hide();

            //if (FrmFaceRecNewApproach.logiraniKorisnik.uloga_id == 1)
            //{
            //    FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            //    frmPocetniIzbornik.ShowDialog();
            //}

            //else
            //{
            //    FrmPocetniIzbornik frmPocetniIzbornik = new FrmPocetniIzbornik();
            //    frmPocetniIzbornik.ShowDialog();
            //}

            FrmFaceRecNewApproach.CheckLogirani(FrmFaceRecNewApproach.logiraniKorisnik.uloga_id);


            Close();
        }
    }
}
