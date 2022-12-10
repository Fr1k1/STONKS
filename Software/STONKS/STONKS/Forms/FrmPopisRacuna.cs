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
            // TODO makni iz baze column nacin_placanja i onda ovde iz koda negde da ne baca error na popisu racuna

            var racuni = racunServices.GetRacuni();
            dgvRacuni.DataSource = racuni;
            dgvRacuni.Columns[11].Visible = false; // sakrivene stavke jer ce bit u drugom dgvu
        }

        private void PrikaziStavke()
        {
            var odabraniRed = dgvRacuni.CurrentRow.DataBoundItem as Racun;
            dgvStavke.DataSource = stavkaServices.GetStavke(odabraniRed);
            dgvStavke.Columns[5].Visible = false;
            dgvStavke.Columns[0].Visible = false; // ne treba nam id racuna kad ga vec imamo
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
