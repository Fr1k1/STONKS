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

        static public List<StavkaRacuna> listaStavkiURacunu = new List<StavkaRacuna>();
        static public double ukupnoUnos;
        static public double ukupanPopust;

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            listaStavkiURacunu.Clear(); 
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
            FrmIzradaRacuna frmIzradaRacuna = new FrmIzradaRacuna();
            Hide();
            frmIzradaRacuna.ShowDialog();
            Close();
        }

        private void FrmUnosRacuna_Load(object sender, EventArgs e)
        {
            dgvArtikli.DataSource = listaStavkiURacunu;
            UrediTablicuStavke();
            IzracunajPopust();
            IzracunajUkupno();
        }

        private void dgvArtikli_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            IzracunajUkupnoPoStavci(e.RowIndex);
            IzracunajPopust();
            IzracunajUkupno();
        }

        private void IzracunajUkupnoPoStavci(int rowIndex)
        {
            // racuna se novi stupac ukupno kad god se promijeni kolicina
            int kol = (int)dgvArtikli.Rows[rowIndex].Cells["kolcina"].Value;
            double jed_cijena = (double)dgvArtikli.Rows[rowIndex].Cells["jed_cijena"].Value;
            double popust = (double)dgvArtikli.Rows[rowIndex].Cells["popust"].Value;

            double uk_cijena = 0;
            uk_cijena = (kol * jed_cijena);

            if(popust> 0)
            {
               uk_cijena = uk_cijena - uk_cijena * (popust / 100);
            }

            dgvArtikli.Rows[rowIndex].Cells["ukupno"].Value = uk_cijena;
        }

        private void IzracunajUkupno()
        {
            ukupnoUnos = 0;
            foreach (var item in listaStavkiURacunu)
            {
                double popustDecimalni = ((double)(item.popust) / 100);
                ukupnoUnos = ukupnoUnos + (item.kolcina * item.Artikli.jed_cijena);
            }
            ukupnoUnos = ukupnoUnos - Double.Parse(txtPopust.Text);
            txtUkupno.Text = ukupnoUnos.ToString();
        }

        private void IzracunajPopust() // unosi se u postotku
        {
            ukupanPopust = 0;
            foreach (var item in listaStavkiURacunu)
            {
                double popustDecimalni = ((double)(item.popust) / 100);
                ukupanPopust += ((item.Artikli.jed_cijena * item.kolcina) * popustDecimalni);
            } 
            txtPopust.Text = ukupanPopust.ToString();
        }
        private void UrediTablicuStavke()
        {
            dgvArtikli.Columns[0].Visible = false;
            dgvArtikli.Columns[1].Visible = false;
            dgvArtikli.Columns[7].Visible = false;

            dgvArtikli.Columns["kolcina"].HeaderText = "Kolicina [kom]";
            dgvArtikli.Columns["Popust"].HeaderText = "Popust [%]";
            dgvArtikli.Columns["Artikli"].HeaderText = "Naziv artikla";
            dgvArtikli.Columns["jed_cijena"].HeaderText = "Cijena/kom";
            dgvArtikli.Columns["Ukupno"].HeaderText = "Ukupno";

            dgvArtikli.Columns["jed_cijena"].ReadOnly = true;
            dgvArtikli.Columns["Ukupno"].ReadOnly = true;
            dgvArtikli.Columns[6].ReadOnly = true;

            dgvArtikli.Columns["Artikli"].DisplayIndex = 0;
            dgvArtikli.Columns["kolcina"].DisplayIndex = 1;
            dgvArtikli.Columns["Popust"].DisplayIndex = 2;
        }
    }
}
