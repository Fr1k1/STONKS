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
    public partial class FrmUnosArtikla : Form
    {
        public FrmUnosArtikla()
        {
            InitializeComponent();
        }

        public ArtikliServices services = new ArtikliServices();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetText(TextBox textBox)
        {
            if (textBox.Text != "")
                textBox.Text = "";
        }

        private void FrmUnosArtikla_Load(object sender, EventArgs e)
        {
            cbArticleType.Size = new Size(316, 120);
            GetVrsteArtikla();
        }

        private void GetVrsteArtikla()
        {
            var vrsteArtikla = services.GetVrsteArtikla();
            cbArticleType.DataSource = vrsteArtikla;
        }

        private void btnAddArtikl_Click(object sender, EventArgs e)
        {

            var vrstaArtikla = cbArticleType.SelectedItem as VrstaArtikla;
            var artikl = new Artikl
            {

                sifra = txtCode.Text,
                naziv = txtName.Text,
                jed_cijena = Convert.ToInt32(txtUnitPrice.Text),
                
                pdv = Convert.ToInt32(txtPDV.Text),
                vrsta_artikla_id=vrstaArtikla.id,
                VrsteArtikla = vrstaArtikla,



            };

            services.DodajArtikl(artikl);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            //ako neko upise broj npr 85 dodaj ispred njega nule da duzina bude kolko treba za barkod
            //barkod ima 12 znamenki, ak neko upise 3 broja za sifru ispred se dodaje devet nula
        }

        private void txtCode_Click(object sender, EventArgs e)
        {
            SetText(txtCode);
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            SetText(txtName);

        }

        private void txtUnitPrice_Click(object sender, EventArgs e)
        {
            SetText(txtUnitPrice);

        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            SetText(txtCode);

        }

        private void txtPDV_Click(object sender, EventArgs e)
        {
            SetText(txtPDV);

        }
    }
}
