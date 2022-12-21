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
            MessageBox.Show("UKUPNO UNOS " + ukupnoUnos.ToString());

            FrmIzradaRacuna frmIzradaRacuna = new FrmIzradaRacuna();
            Hide();
            frmIzradaRacuna.ShowDialog();
            Close();
        }

        private void FrmUnosRacuna_Load(object sender, EventArgs e)
        {
            dgvArtikli.DataSource = listaStavkiURacunu;
            IzracunajUkupno();
            UrediTablicuStavke();
        }

        private void dgvArtikli_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            IzracunajPopust();
            IzracunajUkupno();
        }

        private void IzracunajUkupno()
        {
            foreach (var item in listaStavkiURacunu)
            {
                ukupnoUnos = (item.kolcina * item.Artikli.jed_cijena) 
                    //- (((double)(item.popust) / 100) * item.Artikli.jed_cijena)  // OVO NE DELA DOBRO
                    ;
            }
            txtUkupno.Text = ukupnoUnos.ToString();
        }

        private void IzracunajPopust() // unosi se u postotku, NE DELA
        {
            foreach (var item in listaStavkiURacunu)
            {
                MessageBox.Show(item.popust.ToString() + " "+ ((double)(item.popust ) / 100).ToString());
                ukupanPopust = ((double)(item.popust) / 100) * item.Artikli.jed_cijena;
            } 
            txtPopust.Text = ukupanPopust.ToString();
        }
        private void UrediTablicuStavke()
        {
            dgvArtikli.Columns[0].Visible = false;
            dgvArtikli.Columns[1].Visible = false;
            dgvArtikli.Columns[5].Visible = false;

            dgvArtikli.Columns[2].HeaderText = "Kolicina";
            dgvArtikli.Columns[3].HeaderText = "Popust";
            dgvArtikli.Columns[4].HeaderText = "Naziv artikla";

            dgvArtikli.Columns[4].ReadOnly = true;

            dgvArtikli.Columns["Artikli"].DisplayIndex = 0;
            dgvArtikli.Columns["kolcina"].DisplayIndex = 1;
            dgvArtikli.Columns["Popust"].DisplayIndex = 2;
        }
    }
}
