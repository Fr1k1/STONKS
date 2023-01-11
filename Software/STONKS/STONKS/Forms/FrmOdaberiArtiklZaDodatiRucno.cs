using BusinessLayer.Services;
using EntitiesLayer.Entities;
using iTextSharp.text;
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
    public partial class FrmOdaberiArtiklZaDodatiRucno : Form
    {
        private ArtikliServices artikliServices = new ArtikliServices();
        public FrmUnosPrimke UnosPrimke { get; set; }
        public FrmOdaberiArtiklZaDodatiRucno()
        {
            InitializeComponent();
        }

        private ArtikliServices servicesArtikl = new ArtikliServices();
      
        private void FrmOdaberiArtiklZaDodatiRucno_Load(object sender, EventArgs e)
        {
            PrikaziArtikle();
            UrediTablicuStavke();
        }

        private void PrikaziArtikle()
        {
            var artikli = servicesArtikl.GetArtikli();
            dgvPopisArtikala.DataSource = artikli;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Zatvori();
        }

        private void txtPretrazi_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtPretrazi.Text;
            // TODO ili dole na keyup prema grafovima
        }

        private void btnDodajArtikl_Click(object sender, EventArgs e)
        {
            DodajArtiklUListu();
            // TODO da smanji kolicinu na skladistu ili baca error ak nema dovoljno tih artikala 

            var selectedRow = dgvPopisArtikala.CurrentRow;

            if (selectedRow != null)
            {
                var selectedArtikl = selectedRow.DataBoundItem as Artikl;
                StavkaRacuna novaStavka = new StavkaRacuna
                {
                    Artikli = selectedArtikl,
                    kolcina = 1,
                    popust = 0,
                    artikl_id = selectedArtikl.id,
                };
                FrmUnosRacuna.listaStavkiURacunu.Add(novaStavka);
                Zatvori();
            }
            else
            {
                MessageBox.Show("Nije odabran artikl!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Zatvori()
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            Hide();
            frmUnosRacuna.ShowDialog();
            Close();
        }

        private void DodajArtiklUListu()
        {
            // TODO da smanji kolicinu na skladistu ili baca error ak nema dovoljno tih artikala 

            var selectedRow = dgvPopisArtikala.CurrentRow;

            if (selectedRow != null)
            {
                var selectedArtikl = selectedRow.DataBoundItem as Artikl;
                StavkaRacuna novaStavka = new StavkaRacuna
                {
                    Artikli = selectedArtikl,
                    kolcina = 1,
                    popust = 0,
                    artikl_id = selectedArtikl.id,
                    jed_cijena = selectedArtikl.jed_cijena,
                };
                if (FrmUnosRacuna.listaStavkiURacunu.Any(item => item.artikl_id == novaStavka.artikl_id))
                {
                    // vec je dodan ko stavka
                    var stavka = FrmUnosRacuna.listaStavkiURacunu.Find(item => item.artikl_id == novaStavka.artikl_id);
                    stavka.kolcina++;
                }
                else
                {
                    FrmUnosRacuna.listaStavkiURacunu.Add(novaStavka);
                }
                
                Zatvori();
            }
            else
            {
                MessageBox.Show("Nije odabran artikl!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPretrazi_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = txtPretrazi.Text;
            dgvPopisArtikala.DataSource = artikliServices.SearchArtikli(searchText);
        }

        private void UrediTablicuStavke()
        {
            dgvPopisArtikala.Columns[0].Visible = false;
            dgvPopisArtikala.Columns[1].Visible = false;
            dgvPopisArtikala.Columns[6].Visible = false;
            dgvPopisArtikala.Columns[8].Visible = false;
            dgvPopisArtikala.Columns[10].Visible = false;

            dgvPopisArtikala.Columns[2].HeaderText = "Naziv artikla";
            dgvPopisArtikala.Columns[3].HeaderText = "Saldo";
            dgvPopisArtikala.Columns[4].HeaderText = "Jedinicna cijena";
            dgvPopisArtikala.Columns[5].HeaderText = "PDV";
            dgvPopisArtikala.Columns[7].HeaderText = "Barkod";
            dgvPopisArtikala.Columns[9].HeaderText = "Vrsta artikla";
        }

        private void dgvPopisArtikala_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DodajArtiklUListu();
        }

        private void txtPretrazi_Click(object sender, EventArgs e)
        {
            txtPretrazi.Text = "";
        }
    }
}
