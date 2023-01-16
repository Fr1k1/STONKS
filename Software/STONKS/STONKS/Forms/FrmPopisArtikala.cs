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
            FrmPrepoznavanjeLica.CheckLogirani();
            Close();
        }

        private void SetText(TextBox textBox)
        {
            if (textBox.Text != "")
                textBox.Text = "";
        }

        private void FrmPopisArtikala_Load(object sender, EventArgs e)
        {
            DohvatiVrste();
            PrikaziArtikle();
            LoadanjeCharta();

        }

        private void LoadanjeCharta()
        {
            var vrste = services.GetVrsteArtikla();
            foreach (var vrsta in vrste)
            {
                if (services.GetArtikliPoVrsti(vrsta.naziv) > 0)
                    chartArticles.Series["Artikli po vrsti"].Points.AddXY(vrsta.naziv, services.GetArtikliPoVrsti(vrsta.naziv));
            }
        }

        private void DohvatiVrste()
        {
            var vrste = services.GetVrsteArtikla();
            cbVrsta.DataSource = vrste.ToList();
        }

        private void SortirajAbecedno()
        {
            var vrste = services.GetArtikliAbecedno();
            dgvArtikli.DataSource = vrste.ToList();
        }

        private void SortirajPoCijeni()
        {
            var vrste = services.GetArtikliPoCijeni();
            dgvArtikli.DataSource = vrste.ToList();
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

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            PrikaziArtikle();
        }

        private void txtPretraziArtikle_Click(object sender, EventArgs e)
        {
            SetText(txtPretraziArtikle);
        }

        private void cbSort_TextChanged(object sender, EventArgs e)
        {
            if (cbSort.Text == "ABECEDNO")
                SortirajAbecedno();

            if (cbSort.Text == "CIJENA")
                SortirajPoCijeni();
        }

        private void cbVrsta_TextChanged(object sender, EventArgs e)
        {
            string izraz = cbVrsta.Text;
            var artikli = services.FilterByType(izraz);
            dgvArtikli.DataSource = artikli;
        }
    }
}
