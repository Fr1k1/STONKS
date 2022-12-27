using BusinessLayer.Services;
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
    public partial class FrmPopisArtikala : Form
    {

        public FrmPopisArtikala()
        {
            InitializeComponent();
        }

        private ArtikliServices services = new ArtikliServices();


        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();

            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();

            Close();
        }

        private void dgvRacuni_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmPopisArtikala_Load(object sender, EventArgs e)
        {
            DohvatiVrste();
            PrikaziArtikle();

        }

        private void DohvatiVrste()
        {
            var vrste=services.GetVrsteArtikla();
            cbVrsta.DataSource = vrste.ToList();
        }

        private void PrikaziArtikle()
        {
            var artikli = services.GetArtikli();
            dgvArtikli.DataSource = artikli;
            dgvArtikli.Columns[8].Visible = false;
            dgvArtikli.Columns[7].Visible = false;
            dgvArtikli.Columns[10].Visible = false;

        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            FrmUnosArtikla frmUnosArtikla = new FrmUnosArtikla();
            Hide();
            frmUnosArtikla.ShowDialog();
            Close();
        }

        private void txtPretraziArtikle_TextChanged(object sender, EventArgs e)
        {
            string izraz = txtPretraziArtikle.Text;
            var artikli = services.SearchArtikli(izraz);
            dgvArtikli.DataSource = artikli;
        }

       /* private void cbVrsta_TextChanged(object sender, EventArgs e)
        {
            string izraz = cbVrsta.Text;
            var artikli = services.SearchArtikli(izraz);
            dgvArtikli.DataSource = artikli;
        }*/

        private void cbVrsta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilterByType_Click(object sender, EventArgs e)
        {
            string izraz = cbVrsta.Text;
            var artikli = services.FilterByType(izraz);
            dgvArtikli.DataSource = artikli;
        }
    }
}
