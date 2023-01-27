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
    public partial class FrmOdaberiArtiklZaDodatiRucnoPrimka : Form
    {
        /// <summary>
        /// This form is tasked with showing user list of artikls/products that can be added to primka
        /// User can select product and that data will be transfer to FrmUnosPrimke
        /// Author : Filip Milohanović
        /// 
        /// </summary>
        private ArtikliServices artikliServices = new ArtikliServices();
        public FrmUnosPrimke UnosPrimke { get; set; }
        public FrmOdaberiArtiklZaDodatiRucnoPrimka()
        {
            InitializeComponent();
        }
        //loads data into data grid view and sets help file path
        private void FrmOdaberiArtiklZaDodatiRucnoPrimka_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + "\\UserManual.chm";
            LoadArtikliDGV();
        }
        //sets data sourse for data grid view and disables colums that are not needed
        private void LoadArtikliDGV()
        {
            dgvPopisArtikala.DataSource = artikliServices.GetArtikli();
            dgvPopisArtikala.Columns[0].Visible = false;
            dgvPopisArtikala.Columns[6].Visible = false;
            dgvPopisArtikala.Columns[7].Visible = false;
            dgvPopisArtikala.Columns[8].Visible = false;
            dgvPopisArtikala.Columns[10].Visible = false;
        }
        //method that creates Stavka primke based on selected artikl and adds it to form UnosPrimke by calling its method
        private void InsertStavka()
        {
            var stavka = new StavkaPrimke()
            {
                artikl_id = (dgvPopisArtikala.CurrentRow.DataBoundItem as Artikl).id,
                Artikli = (dgvPopisArtikala.CurrentRow.DataBoundItem as Artikl),
                nabavna_cijena = 0.0,
                rabat = 0,
                kolicina = 1,
                ukupna_cijena = 0.0,
                primka_id = UnosPrimke.IdPrimke
            };
            UnosPrimke.AddStavka(stavka);
        }
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
        //when clicking the button stavka is added and form is closed
        private void btnDodajArtikl_Click(object sender, EventArgs e)
        {
            InsertStavka();
            Close();
        }
        //searches list of artikls when user types something into search box
        private void txtPretrazi_TextChanged(object sender, EventArgs e)
        {
            dgvPopisArtikala.DataSource = artikliServices.SearchArtikli(txtPretrazi.Text);
        }
        //also adds stavka into frmUnosPrimke when double clicking on product in dgv(better user experience)
        private void dgvPopisArtikala_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            InsertStavka();
            Close();
        }

        //show context based help when pressing F1 key
        private void FrmOdaberiArtiklZaDodatiRucnoPrimka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "UnosStavkePrimke.htm");
            }
        }

    }
}
