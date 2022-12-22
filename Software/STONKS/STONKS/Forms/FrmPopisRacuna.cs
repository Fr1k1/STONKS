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
    public partial class FrmPopisRacuna : Form
    {
        public FrmPopisRacuna()
        {
            InitializeComponent();
        }

        private RacuniServices racunServices = new RacuniServices();
        private StavkeServices stavkaServices = new StavkeServices();
        private NaciniPlacanjaServices naciniServices = new NaciniPlacanjaServices();

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void FrmPopisRacuna_Load(object sender, EventArgs e)
        {
            var naciniPlacanja = naciniServices.GetNaciniPlacanja();
            cboVrsta.DataSource = naciniPlacanja;
        }

        private void dgvRacuni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PrikaziStavke();
        }

        private void PrikaziRacune()
        {
            var racuni = racunServices.GetRacuni();
            dgvRacuni.DataSource = racuni;
            UrediTablicuRacuni();
        }

        private void PrikaziStavke()
        {
            var odabraniRed = dgvRacuni.CurrentRow.DataBoundItem as Racun;
            dgvStavke.DataSource = stavkaServices.GetStavke(odabraniRed);
            UrediTablicuStavke();
        }
        private void cboVrsta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVrsta.SelectedIndex == 0)
            {
                PrikaziRacune();
            }
            else
            {
                var odabraniNacin = cboVrsta.SelectedItem as NacinPlacanja;
                var racuni = racunServices.GetRacuniFilter(odabraniNacin.id);
                dgvRacuni.DataSource = racuni;
            }
        }

        private void UrediTablicuRacuni()
        {
            dgvRacuni.ReadOnly = true;
            dgvRacuni.Columns[7].Visible = false;
            dgvRacuni.Columns[8].Visible = false;
            dgvRacuni.Columns[10].Visible = false;
            
            dgvRacuni.Columns["id"].DisplayIndex = 0;
            dgvRacuni.Columns["vrijeme_izdavanja"].DisplayIndex = 1;
            dgvRacuni.Columns["popust"].DisplayIndex = 2;
            dgvRacuni.Columns["ukupno"].DisplayIndex = 3;
            dgvRacuni.Columns["pdv"].DisplayIndex = 4;
            dgvRacuni.Columns["cjena_bez_pdv"].DisplayIndex = 5;
            dgvRacuni.Columns["NaciniPlacanja"].DisplayIndex = 6;
            dgvRacuni.Columns["korisnik_id"].DisplayIndex = 7;

            dgvRacuni.Columns["id"].HeaderText = "ID racuna";
            dgvRacuni.Columns["vrijeme_izdavanja"].HeaderText = "Vrijeme izdavanja";
            dgvRacuni.Columns["popust"].HeaderText = "Popust [EUR]";
            dgvRacuni.Columns["ukupno"].HeaderText = "Ukupan iznos racuna [EUR]";
            dgvRacuni.Columns["cjena_bez_pdv"].HeaderText = "Iznos bez PDV-a [EUR]";
            dgvRacuni.Columns["pdv"].HeaderText = "Iznos PDV-a [EUR]";
            dgvRacuni.Columns["korisnik_id"].HeaderText = "ID zaposlenika";
            dgvRacuni.Columns["NaciniPlacanja"].HeaderText = "Nacin placanja";
            
            dgvRacuni.Columns["popust"].DefaultCellStyle.Format = "N2"; // N2 is for 2 decimals
            dgvRacuni.Columns["ukupno"].DefaultCellStyle.Format = "N2";
            dgvRacuni.Columns["cjena_bez_pdv"].DefaultCellStyle.Format = "N2";  
            dgvRacuni.Columns["pdv"].DefaultCellStyle.Format = "N2";
        }

        private void UrediTablicuStavke()
        {
            dgvStavke.Columns[7].Visible = false;
            dgvStavke.Columns[0].Visible = false;
            dgvStavke.Columns[1].Visible = false;
            dgvStavke.ReadOnly = true;

            dgvStavke.Columns["Artikli"].DisplayIndex = 0;
            dgvStavke.Columns["kolcina"].DisplayIndex = 1;
            dgvStavke.Columns["popust"].DisplayIndex = 2;

            dgvStavke.Columns["Artikli"].HeaderText = "Naziv artikla";
            dgvStavke.Columns["kolcina"].HeaderText = "Kolicina";
            dgvStavke.Columns["popust"].HeaderText = "Popust po artiklu [%]";
            dgvStavke.Columns["jed_cijena"].HeaderText = "Cijena/kom [EUR]";
            dgvStavke.Columns["ukupno"].HeaderText = "Ukupno [EUR]";
        }

        private void btnStorniraj_Click(object sender, EventArgs e)
        {
            var selectedRacun = dgvRacuni.CurrentRow.DataBoundItem as Racun;
            if(selectedRacun != null)
                CreateStorno(selectedRacun);
        }

        private void CreateStorno(Racun racun)
        {   
            //dohvatiti stavke
            var stavke = stavkaServices.GetStavke(racun);
            if (racunServices.AddInverse(racun, stavke))
            {
                MessageBox.Show("Racun je uspješno storniran","Uspijeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrikaziRacune();
            }
            else
            {
                MessageBox.Show("Došlo je do greške prilikom storniranja","Greška",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
