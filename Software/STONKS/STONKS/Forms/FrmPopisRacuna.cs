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

        private void UrediTablicuRacuni()
        {
            dgvRacuni.Columns[2].Visible = false;
            dgvRacuni.Columns[7].Visible = false;
            dgvRacuni.Columns[8].Visible = false;
            dgvRacuni.Columns[11].Visible = false; // sakrivene stavke jer ce bit u drugom dgvu

            dgvRacuni.Columns["vrijeme_izdavanja"].DisplayIndex = 3;
            dgvRacuni.Columns["Korisnici"].DisplayIndex = 10;
            dgvRacuni.ReadOnly = true;

            dgvRacuni.Columns[0].HeaderText = "ID racuna";
            dgvRacuni.Columns[1].HeaderText = "Vrijeme izdavanja";
            dgvRacuni.Columns[3].HeaderText = "Cijena bez PDV-a";
            dgvRacuni.Columns[4].HeaderText = "PDV";
            dgvRacuni.Columns[5].HeaderText = "Popust[%]";
            dgvRacuni.Columns[6].HeaderText = "Ukupno";
            dgvRacuni.Columns[9].HeaderText = "Izdao racun";
            dgvRacuni.Columns[10].HeaderText = "Nacin placanja";
        }

        private void UrediTablicuStavke()
        {
            dgvStavke.Columns[5].Visible = false;
            dgvStavke.Columns[0].Visible = false; // ne treba nam id racuna kad ga vec imamo
            dgvStavke.ReadOnly = true;

            dgvStavke.Columns[1].HeaderText = "ID artikla";
            dgvStavke.Columns[2].HeaderText = "Kolicina";
            dgvStavke.Columns[3].HeaderText = "Popust";
            dgvStavke.Columns[4].HeaderText = "Naziv artikla";
        }

        private void cboVrsta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboVrsta.SelectedIndex == 0)
            {
                PrikaziRacune();
            }
            else
            {
                var odabraniNacin = cboVrsta.SelectedItem as NacinPlacanja;
                var racuni = racunServices.GetRacuniFilter(odabraniNacin.id);
                dgvRacuni.DataSource = racuni;
                dgvRacuni.Columns[11].Visible = false;
            }
        }
    }
}
