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
        public ArtikliServices servicesArtikli = new ArtikliServices();
        public static double ukupniPDV = 0;

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
            IzracunajPDV();
            FrmIzradaRacuna frmIzradaRacuna = new FrmIzradaRacuna();
            Hide();
            frmIzradaRacuna.ShowDialog();
            Close();
        }

        private void FrmUnosRacuna_Load(object sender, EventArgs e)
        {
            refreshaj();
            //MessageBox.Show("lsita " +listaStavkiURacunu.Count().ToString());
            if (listaStavkiURacunu != null)
            {
                IzracunajPopust();
                IzracunajUkupno();
            }
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
        
        private void IzracunajPDV()
        {
            ukupniPDV = 0;
            double pdvzataj = 0;
            foreach (var item in listaStavkiURacunu)
            {
                double artiklPDV = servicesArtikli.GetPDV(item.artikl_id); // u postotku
                if (item.popust > 0)
                {
                    double popustDecimalni = 1 - ((double)(item.popust) / 100);
                    ukupniPDV = ukupniPDV + ((item.Artikli.jed_cijena * item.kolcina) * popustDecimalni) * artiklPDV / 100;
                    pdvzataj = ((item.Artikli.jed_cijena * item.kolcina) * popustDecimalni) * artiklPDV / 100;
                }
                else
                {
                    ukupniPDV = ukupniPDV + ((item.kolcina * (item.jed_cijena * artiklPDV/100)));
                    pdvzataj = ((item.kolcina * (item.jed_cijena * artiklPDV / 100)));
                }
                MessageBox.Show("pdv za taj --> "+item.Artikli + " "+ pdvzataj.ToString());
                //MessageBox.Show(item.Artikli.ToString() + " " + item.artikl_id.ToString());

                //MessageBox.Show(item.kolcina + " " + item.jed_cijena + " " + artiklPDV);
                //ukupniPDV = ukupniPDV + ((item.kolcina * (item.jed_cijena * artiklPDV/100))-((double)(item.popust) / 100 * (item.jed_cijena*item.kolcina)));


            }
            MessageBox.Show(ukupniPDV.ToString());
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

        private void btnIzbrisiArtikl_Click(object sender, EventArgs e)
        {
            var selectedStavka = dgvArtikli.CurrentRow.DataBoundItem as StavkaRacuna;
            listaStavkiURacunu.Remove(selectedStavka);
            refreshaj();
        }

        private void refreshaj()
        {
            dgvArtikli.DataSource = listaStavkiURacunu;
            UrediTablicuStavke();
            IzracunajPopust();
            IzracunajUkupno();
        }
    }
}
