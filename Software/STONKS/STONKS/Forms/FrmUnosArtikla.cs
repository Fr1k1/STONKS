using BusinessLayer.Services;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace STONKS.Forms
{
    public partial class FrmUnosArtikla : Form
    {

        //Author : Martin Friščić (all code except help)

        public FrmUnosArtikla()
        {
            InitializeComponent();
        }

        public ArtikliServices services = new ArtikliServices();

        private void SetText(TextBox textBox)
        {
            if (textBox.Text != "")
                textBox.Text = "";
        }


        //on form load all article types are loaded for the dropdown
        private void FrmUnosArtikla_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + "\\UserManual.chm";
            cbArticleType.Size = new Size(316, 120);
            GetVrsteArtikla();
        }

        //gets all article types for the dropdown
        private void GetVrsteArtikla()
        {
            var vrsteArtikla = services.GetVrsteArtikla();
            cbArticleType.DataSource = vrsteArtikla;
        }

        private void btnAddArtikl_Click(object sender, EventArgs e)
        {
            //firstly it checks it TextBoxes are not empty and not equal to placeholder values

            if (txtCode.Text == "" || txtName.Text == "" || txtUnitPrice.Text == "" || txtPDV.Text == ""
                || txtCode.Text == "SIFRA/BARKOD" || txtName.Text == "NAZIV" || txtUnitPrice.Text == "JEDINICNA CIJENA" || txtPDV.Text == "PDV"
                )
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            //checks if the value is good (bigger than 0)
            if (double.Parse(txtUnitPrice.Text) < 0 || double.Parse(txtPDV.Text) < 0)
            {
                MessageBox.Show("Cijena i PDV moraju biti pozitivni");
                return;
            }

            if(!Regex.IsMatch(txtCode.Text, @"^[0-9]*$")) {
                MessageBox.Show("Barkod se sastoji samo od brojeva!");
                return;
            }

            //tries to add an article

            var vrstaArtikla = cbArticleType.SelectedItem as VrstaArtikla;
            var artikl = new Artikl
            {
                sifra = txtCode.Text,
                naziv = txtName.Text,
                jed_cijena = Convert.ToDouble(txtUnitPrice.Text),
                pdv = Convert.ToInt32(txtPDV.Text),
                vrsta_artikla_id = vrstaArtikla.id,
                VrsteArtikla = vrstaArtikla,
            };
            foreach (var a in services.GetArtikli())
            {
                //checks if barcode already exists in database because it has to be unique
                if (long.Parse(txtCode.Text) == long.Parse(a.sifra))
                {
                    MessageBox.Show("Artikl s ovim barkodom vec postoji!");
                    return;
                }
            }
            bool success = services.DodajArtikl(artikl);
            if (success)
                MessageBox.Show("Uspjesno dodan artikl");
            else
                MessageBox.Show("Greska u dodavanju");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
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

        //generates the barcode
        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions { Height = 100, Width = 300 }
            };
            pbBarcode.Image = writer.Write(txtCode.Text);
        }

        //enables printing barcode on click
        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            printDocument1.Print();
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pbBarcode.Image, 0, 0);
        }



        //show context based help when pressing F1 key
        private void FrmUnosArtikla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "unos_artikla.html");
            }
        }
    }
}
