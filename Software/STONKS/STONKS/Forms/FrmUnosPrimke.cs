using BusinessLayer.Services;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Hierarchy;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STONKS.Forms
{
    public partial class FrmUnosPrimke : Form
    {
        private DobavljaciServices dobavljaciServices = new DobavljaciServices();

        private BindingList<StavkaPrimke> stavkePrimke = new BindingList<StavkaPrimke>();
        public FrmUnosPrimke()
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

        private void FrmUnosPrimke_Load(object sender, EventArgs e)
        {
            LoadDobavljaciCBO();
            LoadStavkeDGV();
        }

        public void LoadStavkeDGV()
        {
            dgvStavkePrimke.DataSource = stavkePrimke;
            //---make invisible---
            dgvStavkePrimke.Columns[0].Visible = false;
            dgvStavkePrimke.Columns[1].Visible = false;
            dgvStavkePrimke.Columns[7].Visible = false;
            //---make read-Only---
            dgvStavkePrimke.Columns["ukupna_cijena"].ReadOnly = true;
            dgvStavkePrimke.Columns["Artikli"].ReadOnly = true;
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
        }

        public void AddStavka(StavkaPrimke stavka)
        {
            stavkePrimke.Add(stavka);
            
        }
        private void LoadDobavljaciCBO()
        {   
            cboDobavljac.DataSource = dobavljaciServices.GetDobavljaci();
        }
        private void btnAddStavkaPrimke_Click(object sender, EventArgs e)
        {   
            FrmOdaberiArtiklZaDodatiRucno frmDodajRucno = new FrmOdaberiArtiklZaDodatiRucno();
            frmDodajRucno.UnosPrimke = this;
            frmDodajRucno.ShowDialog();
        }
    }
}
