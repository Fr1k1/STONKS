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
        private ArtikliServices artikliServices = new ArtikliServices();
        public FrmUnosPrimke UnosPrimke { get; set; }
        public FrmOdaberiArtiklZaDodatiRucnoPrimka()
        {
            InitializeComponent();
        }

        private void FrmOdaberiArtiklZaDodatiRucnoPrimka_Load(object sender, EventArgs e)
        {
            LoadArtikliDGV();
        }

        private void LoadArtikliDGV()
        {
            dgvPopisArtikala.DataSource = artikliServices.GetArtikli();
            dgvPopisArtikala.Columns[0].Visible = false;
            dgvPopisArtikala.Columns[6].Visible = false;
            dgvPopisArtikala.Columns[7].Visible = false;
            dgvPopisArtikala.Columns[8].Visible = false;
            dgvPopisArtikala.Columns[10].Visible = false;
        }

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

        private void btnDodajArtikl_Click(object sender, EventArgs e)
        {
            InsertStavka();
            Close();
        }
        private void txtPretrazi_TextChanged(object sender, EventArgs e)
        {
            dgvPopisArtikala.DataSource = artikliServices.SearchArtikli(txtPretrazi.Text);
        }

        private void dgvPopisArtikala_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            InsertStavka();
            Close();
        }
    }
}
