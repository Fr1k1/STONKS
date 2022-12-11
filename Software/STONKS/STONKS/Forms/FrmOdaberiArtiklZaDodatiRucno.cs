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
    public partial class FrmOdaberiArtiklZaDodatiRucno : Form
    {
        private ArtikliServices artikliServices = new ArtikliServices();
        public FrmUnosPrimke UnosPrimke { get; set; }
        public FrmOdaberiArtiklZaDodatiRucno()
        {
            InitializeComponent();
        }

        private void FrmOdaberiArtiklZaDodatiRucno_Load(object sender, EventArgs e)
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

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDodajArtikl_Click(object sender, EventArgs e)
        {   
            
            var stavka = new StavkaPrimke()
            {
                artikl_id = int.Parse((dgvPopisArtikala.CurrentRow.DataBoundItem as Artikl).sifra),
                Artikli = (dgvPopisArtikala.CurrentRow.DataBoundItem as Artikl)

            };
            UnosPrimke.AddStavka(stavka);
            Close();
        }

        private void txtPretrazi_TextChanged(object sender, EventArgs e)
        {
            dgvPopisArtikala.DataSource = artikliServices.SearchArtikli(txtPretrazi.Text);
        }
    }
}
