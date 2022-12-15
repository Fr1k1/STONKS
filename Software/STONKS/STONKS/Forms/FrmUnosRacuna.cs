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
using System.Windows.Forms.DataVisualization.Charting;

namespace STONKS.Forms
{
    public partial class FrmUnosRacuna : Form
    {
        public FrmUnosRacuna()
        {
            InitializeComponent();
        }

        static public List<StavkaRacuna> listaStavki = new List<StavkaRacuna>();
        static public int ukupnoUnos;

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            Hide();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void btnDodajRucno_Click(object sender, EventArgs e)
        {
           
            FrmOdaberiArtiklZaDodatiRucno frmOdaberiArtiklZaDodatiRucno = new FrmOdaberiArtiklZaDodatiRucno();
            Hide();
            frmOdaberiArtiklZaDodatiRucno.ShowDialog();
            Close();
        }

        private void btnNastavi_Click(object sender, EventArgs e)
        {
            ukupnoUnos = int.Parse(txtUkupno.Text);
            //MessageBox.Show(ukupnoUnos.ToString());

            FrmIzradaRacuna frmIzradaRacuna = new FrmIzradaRacuna();
            Hide();
            frmIzradaRacuna.ShowDialog();
            Close();
        }

        private void FrmUnosRacuna_Load(object sender, EventArgs e)
        {
            dgvArtikli.DataSource = listaStavki;
            IzracunajUkupno();
        }

        private void dgvArtikli_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            IzracunajUkupno();
        }

        private void IzracunajUkupno()
        {
            foreach (var item in listaStavki)
            {
                txtUkupno.Text = (int.Parse(txtUkupno.Text) + item.kolcina * item.Artikli.jed_cijena).ToString();
            }
        }

       
    }
}
