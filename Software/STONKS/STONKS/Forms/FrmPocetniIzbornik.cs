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
    public partial class FrmPocetniIzbornik : Form
    {
        public FrmPocetniIzbornik()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnUnosArtikla_Click(object sender, EventArgs e)
        {
            FrmUnosArtikla frmUnosArtikla = new FrmUnosArtikla();
            frmUnosArtikla.ShowDialog();
        }

        private void btnUnosRacuna_Click(object sender, EventArgs e)
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            frmUnosRacuna.ShowDialog();
        }

        private void btnUnosPrimke_Click(object sender, EventArgs e)
        {
            FrmUnosPrimke frmUnosPrimke = new FrmUnosPrimke();
            frmUnosPrimke.ShowDialog();
        }

        private void btnUnosDobavljaca_Click(object sender, EventArgs e)
        {
            FrmUnosDobavljaca frmUnosDobavljaca = new FrmUnosDobavljaca();
            frmUnosDobavljaca.ShowDialog();
        }

        private void btnPopisRacuna_Click(object sender, EventArgs e)
        {
            FrmPopisRacuna frmPopisRacuna = new FrmPopisRacuna();
            frmPopisRacuna.ShowDialog();
        }

        private void btnPopisArtikala_Click(object sender, EventArgs e)
        {
            FrmPrikazArtikala frmPrikazArtikala=new FrmPrikazArtikala();
            frmPrikazArtikala.ShowDialog();
        }

        private void btnPopisPrimki_Click(object sender, EventArgs e)
        {
            FrmPopisPrimki frmPopisPrimki = new FrmPopisPrimki();
            frmPopisPrimki.ShowDialog();
        }

        private void btnDnevniPromet_Click(object sender, EventArgs e)
        {
            FrmDnevniPromet frmDnevniPromet = new FrmDnevniPromet();
            frmDnevniPromet.ShowDialog();
        }
    }
}
