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
    public partial class FrmPocetniIzbornikVoditelj : Form
    {
        public FrmPocetniIzbornikVoditelj()
        {
            InitializeComponent();
        }

        private void btnUnosArtikla_Click(object sender, EventArgs e)
        {
            Hide();
            FrmUnosArtikla frmUnosArtikla = new FrmUnosArtikla();
            frmUnosArtikla.ShowDialog();

            Close();
        }

        private void btnUnosRacuna_Click(object sender, EventArgs e)
        {
            Hide();
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            frmUnosRacuna.ShowDialog();
            Close();
        }

        private void btnUnosPrimke_Click(object sender, EventArgs e)
        {
            Hide();
            FrmUnosPrimke frmUnosPrimke = new FrmUnosPrimke();
            frmUnosPrimke.ShowDialog();
            Close();
        }

        private void btnPopisRacuna_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPopisRacuna frmPopisRacuna = new FrmPopisRacuna();
            frmPopisRacuna.ShowDialog();
            Close();
        }

        private void btnPopisArtikala_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPopisArtikala frmPopisArtikala = new FrmPopisArtikala();
            frmPopisArtikala.ShowDialog();
            Close();
        }

        private void btnUnosDobavljaca_Click(object sender, EventArgs e)
        {
            Hide();
            FrmUnosDobavljaca frmUnosDobavljaca = new FrmUnosDobavljaca();
            frmUnosDobavljaca.ShowDialog();
            Close();
        }

        private void btnPopisPrimki_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPopisPrimki frmPopisPrimki = new FrmPopisPrimki();
            frmPopisPrimki.ShowDialog();
            Close();
        }

        private void btnDnevniPromet_Click(object sender, EventArgs e)
        {
            Hide();
            FrmDnevniPromet frmDnevniPromet = new FrmDnevniPromet();
            frmDnevniPromet.ShowDialog();
            Close();
        }

        private void btnRegistriraj_Click(object sender, EventArgs e)
        {
            Hide();
            FrmRegistracija frmRegistracija = new FrmRegistracija();
            frmRegistracija.ShowDialog();
            Close();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            FrmPrepoznavanjeLica.logiraniKorisnik = null;
            Hide();
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            Close();
        }

        private void FrmPocetniIzbornikVoditelj_Load(object sender, EventArgs e)
        {

        }

        //show context based help when pressing F1 key
        private void FrmPocetniIzbornikVoditelj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace);
            }
        }
    }
}
