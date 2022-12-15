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

        private BindingList<StavkaPrimke> stavkePrimke = new BindingList<StavkaPrimke>();   // local list of stavkePrimka, will be pushed into db latter
        
        public int IdPrimke { get; set; }
        private double FinalPrice  { get; set; }
        private double Discount  { get; set; }
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
            IdPrimke  = primkaServices.GetIdForNewPrimka();

            //convert id into a number with 3 digits (add leading zeros)
            if (IdPrimke < 10)
                return "Broj primke: 00" + IdPrimke;
            else if(IdPrimke < 100)
                return "Broj primke: 0" + IdPrimke;
            else
                return "Broj primke: " + IdPrimke;
        }

        public void LoadStavkeDGV()     //adds data source and changes look of dgv 
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

        public void AddStavka(StavkaPrimke stavka)  // function that can be called from another form
        {
            if (!stavkePrimke.Contains(stavka))     // check if artikl is alredy in dgv
            {
                stavkePrimke.Add(stavka);   //if it isnt add it
                changeTabPosition();    //change selected cell to a cell in new row
            }
            else
                MessageBox.Show("Ovaj artikl ste već dodali!!!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void LoadDobavljaciCBO()
        {   
            cboDobavljac.DataSource = dobavljaciServices.GetDobavljaci();   //load cbo for suppliers
        }
        private void btnAddStavkaPrimke_Click(object sender, EventArgs e)
        {
            FrmOdaberiArtiklZaDodatiRucno frmDodajRucno = new FrmOdaberiArtiklZaDodatiRucno();
            frmDodajRucno.UnosPrimke = this;
            frmDodajRucno.ShowDialog();
            dgvStavkePrimke.Focus();
        }

        private void changeTabPosition()
        {
            int numOfRows = dgvStavkePrimke.RowCount - 1; // get nuber of row in dgv
            dgvStavkePrimke.Rows[numOfRows - 1].Cells["kolicina"].Selected = true; // select cell in row-1 and collumn kolicina
        }

        private void btnUnesiPrimku_Click(object sender, EventArgs e)
        {
            if(ValidatePrimka())
            {
                var primka = new Primka()
                {
                    //id = IdPrimke,
                    ukupno = FinalPrice,
                    datum = DateTime.Now,
                    Dobavljac_id = (cboDobavljac.SelectedItem as Dobavljac).id,
                    //Dobavljaci = cboDobavljac.SelectedItem as Dobavljac
                };
                if(primkaServices.AddPrimka(primka, stavkePrimke.ToList()))
                    MessageBox.Show("Primka je unesena!!!", "Uspiješan unos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Došlo je do greške prilikom upisa u bazu,pokusajte kasnije", "Neuspiješan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Nisu uneseni svi potrebni podaci, primka nije unesena!!!", "Nesipravan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidatePrimka()
        {
            foreach (DataGridViewRow row in dgvStavkePrimke.Rows)
            {
                if (!row.IsNewRow)
                {
                    if ((int)row.Cells["kolicina"].Value == 0 || (double)row.Cells["nabavna_cijena"].Value == 0 || row.Cells["Artikli"].Value == null) //cehck if all inputs are filled and valid
                        return false;
                }
            }               
            return true;
        }

        private void dgvStavkePrimke_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateRowData(e.RowIndex);
            CalculateFinalPrice();
            CalculateDiscount();
                
        }

        private void CalculateDiscount()
        {
            Discount = 0;
            foreach (var stavka in stavkePrimke)
            {
                Discount += stavka.kolicina * (stavka.nabavna_cijena * ((stavka.rabat / 100.00)));
            }
            txtPopust.Text = Discount.ToString() + " EUR";
        }

        private void CalculateFinalPrice()
        {
            FinalPrice = 0;
            foreach (var stavka in stavkePrimke)
            {
                FinalPrice += stavka.ukupna_cijena;
            }
            txtUkupno.Text = FinalPrice.ToString() + " EUR";
        }

        private void CalculateRowData(int rowIndex)
        {
            int kolicina = (int)dgvStavkePrimke.Rows[rowIndex].Cells["kolicina"].Value;     //read kolicina from selected row
            int rabat = (int)dgvStavkePrimke.Rows[rowIndex].Cells["rabat"].Value;        //read rabat from selected row
            double nabavna_cijena = (double)dgvStavkePrimke.Rows[rowIndex].Cells["nabavna_cijena"].Value;       //read nabavna_cijena from selected row
            double uk_cijena = 0;
            uk_cijena = kolicina * (nabavna_cijena * (1 - (rabat / 100.00)));       //calculate row final price
            dgvStavkePrimke.Rows[rowIndex].Cells["ukupna_cijena"].Value = uk_cijena;         //set  row final price    
        }

        private void dgvStavkePrimke_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateFinalPrice();
            CalculateDiscount();
        }
    }
}
