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
    public partial class FrmPopisPrimki : Form
    {
        private PrimkaServices primkaServices = new PrimkaServices();
        public FrmPopisPrimki()
        {
            InitializeComponent();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void FrmPopisPrimki_Load(object sender, EventArgs e)
        {
            LoadDGVs();
        }

        private void LoadDGVs()
        {
            dgvPrimke.DataSource = primkaServices.GetPrimke();
            //---make invisible---
            dgvPrimke.Columns[0].Visible = false;
            dgvPrimke.Columns[3].Visible = false;
            dgvPrimke.Columns[5].Visible = false;
            //---Reorder columns---
            dgvPrimke.Columns["datum"].DisplayIndex = 0;
            dgvPrimke.Columns["Dobavljaci"].DisplayIndex = 1;
            dgvPrimke.Columns["ukupno"].DisplayIndex = 2;
            //---Rename columns---
            dgvPrimke.Columns["datum"].HeaderText = "Datum unosa";
            dgvPrimke.Columns["Dobavljaci"].HeaderText = "Dobavljac";
            dgvPrimke.Columns["ukupno"].HeaderText = "Ukupan iznos";
            //---Format columns---
            dgvPrimke.Columns["ukupno"].DefaultCellStyle.Format = "0.00## EUR";

            
        }

        private void dgvPrimke_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine((dgvPrimke.CurrentRow.DataBoundItem as Primka).ukupno.ToString());
            dgvStavkePrimke.DataSource = primkaServices.GetStavkeFromPrimka(dgvPrimke.CurrentRow.DataBoundItem as Primka);
            //---make invisible---
            dgvStavkePrimke.Columns[0].Visible = false;
            dgvStavkePrimke.Columns[1].Visible = false;
            dgvStavkePrimke.Columns[7].Visible = false;

            //---Reorder columns---
            dgvStavkePrimke.Columns["Artikli"].DisplayIndex = 0;
            dgvStavkePrimke.Columns["kolicina"].DisplayIndex = 1;
            dgvStavkePrimke.Columns["rabat"].DisplayIndex = 2;
            dgvStavkePrimke.Columns["nabavna_cijena"].DisplayIndex = 3;
            dgvStavkePrimke.Columns["ukupna_cijena"].DisplayIndex = 4;
            //---Rename columns---
            dgvStavkePrimke.Columns["Artikli"].HeaderText = "Naziv artikla";
            dgvStavkePrimke.Columns["kolicina"].HeaderText = "Količina";
            dgvStavkePrimke.Columns["rabat"].HeaderText = "Rabat";
            dgvStavkePrimke.Columns["nabavna_cijena"].HeaderText = "Nabavna cijena";
            dgvStavkePrimke.Columns["ukupna_cijena"].HeaderText = "Ukupna cijena";
            //---Format columns---
            dgvStavkePrimke.Columns["rabat"].DefaultCellStyle.Format = "0\\%";
            dgvStavkePrimke.Columns["nabavna_cijena"].DefaultCellStyle.Format = "0.00## EUR";
            dgvStavkePrimke.Columns["ukupna_cijena"].DefaultCellStyle.Format = "0.00## EUR";
        }
    }
}
