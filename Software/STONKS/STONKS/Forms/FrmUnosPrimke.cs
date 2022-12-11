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
            dgvStavkePrimke.Columns["rabat"].HeaderText = "Rabat(%)";
            dgvStavkePrimke.Columns["nabavna_cijena"].HeaderText = "Nabavna cijena";
            dgvStavkePrimke.Columns["ukupna_cijena"].HeaderText = "Ukupna cijena";
            //---Format columns---
            dgvStavkePrimke.Columns["nabavna_cijena"].DefaultCellStyle.Format = "0.00##";
            dgvStavkePrimke.Columns["ukupna_cijena"].DefaultCellStyle.Format = "0.00##";
        }

        public void AddStavka(StavkaPrimke stavka)
        {
            if (!stavkePrimke.Contains(stavka))
                stavkePrimke.Add(stavka);
            else
                MessageBox.Show("Ovaj artikl ste već dodali!!!", "Greška",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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


        private void btnUnesiPrimku_Click(object sender, EventArgs e)
        {
            MessageBox.Show(stavkePrimke[0].ukupna_cijena.ToString());  //Testing
        }

        private void dgvStavkePrimke_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                int kolicina = (int)dgvStavkePrimke.Rows[e.RowIndex].Cells["kolicina"].Value;
                int rabat = (int)dgvStavkePrimke.Rows[e.RowIndex].Cells["rabat"].Value;
                double nabavna_cijena = (double)dgvStavkePrimke.Rows[e.RowIndex].Cells["nabavna_cijena"].Value;

                Console.WriteLine("kolicina:" + kolicina);
                Console.WriteLine("nc:" + nabavna_cijena);
                Console.WriteLine("rb:" + rabat);
                double uk_cijena = 0;
                uk_cijena = kolicina * (nabavna_cijena * (1 - (rabat / 100.00)));
                Console.WriteLine("uc:" + uk_cijena);
                dgvStavkePrimke.Rows[e.RowIndex].Cells["ukupna_cijena"].Value = uk_cijena;
        }

        private void dgvStavkePrimke_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvStavkePrimke.Rows.Count > 1) //beacuse of empty row from bindingList
                dgvStavkePrimke.CurrentCell = dgvStavkePrimke.Rows[e.RowIndex].Cells["kolicina"];
        }
    }
}
