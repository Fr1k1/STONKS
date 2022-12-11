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

        private PrimkaServices primkaServices = new PrimkaServices();

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
            txtBrojPrimke.Text = SetPrimkaId();
            LoadDobavljaciCBO();
            LoadStavkeDGV();
        }

        private string SetPrimkaId()
        {
            var id = primkaServices.GetIdForNewPrimka();

            if (id < 10)
                return "Broj primke: 00" + id;
            else if(id <100)
                return "Broj primke: 0" + id;
            else
                return "Broj primke: " + id;
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
            dgvStavkePrimke.Focus();
        }


        private void btnUnesiPrimku_Click(object sender, EventArgs e)
        {   
            MessageBox.Show(stavkePrimke[0].ukupna_cijena.ToString());  //Testing

            bool isValid = true;
            foreach(DataGridViewRow row in dgvStavkePrimke.Rows)
            {
                if (!isValid)
                    break;
                if(!row.IsNewRow)
                {
                    if ((int)row.Cells["kolicina"].Value == 0 || (double)row.Cells["nabavna_cijena"].Value == 0 || row.Cells["Artikli"].Value == null)
                        isValid = false;
                }
            }
            if(isValid)
                MessageBox.Show("Primka je unesena!!!", "Uspiješan unos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Nisu uneseni svi potrebni podaci, primka nije unesena!!!", "Nesipravan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvStavkePrimke_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateRowData(e.RowIndex);
            CalculateFinalPrice();
            CalculateDiscount();
                
        }

        private void CalculateDiscount()
        {
            double finalDiscount = 0;
            foreach (var stavka in stavkePrimke)
            {
                finalDiscount += stavka.kolicina * (stavka.nabavna_cijena * ((stavka.rabat / 100.00)));
            }
            txtPopust.Text = finalDiscount.ToString() + " EUR";
        }

        private void CalculateFinalPrice()
        {
            double finalPrice = 0;
            foreach(var stavka in stavkePrimke)
            {
                finalPrice += stavka.ukupna_cijena;
            }
            txtUkupno.Text = finalPrice.ToString() + " EUR";
        }

        private void CalculateRowData(int rowIndex)
        {
            int kolicina = (int)dgvStavkePrimke.Rows[rowIndex].Cells["kolicina"].Value;
            int rabat = (int)dgvStavkePrimke.Rows[rowIndex].Cells["rabat"].Value;
            double nabavna_cijena = (double)dgvStavkePrimke.Rows[rowIndex].Cells["nabavna_cijena"].Value;
            double uk_cijena = 0;
            uk_cijena = kolicina * (nabavna_cijena * (1 - (rabat / 100.00)));
            dgvStavkePrimke.Rows[rowIndex].Cells["ukupna_cijena"].Value = uk_cijena;
        }

        private void dgvStavkePrimke_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!dgvStavkePrimke.Rows[e.RowIndex].IsNewRow) //beacuse of empty row from bindingList
            {
                dgvStavkePrimke.CurrentCell = dgvStavkePrimke.Rows[e.RowIndex].Cells["kolicina"];
                dgvStavkePrimke.CurrentCell.Selected = true;
            }
        }

    }
}
