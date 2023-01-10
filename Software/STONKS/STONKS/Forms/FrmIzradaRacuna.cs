using BusinessLayer.Services;
using EntitiesLayer.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace STONKS.Forms
{
    public partial class FrmIzradaRacuna : Form
    {
        public FrmIzradaRacuna()
        {
            InitializeComponent();
        }

        public RacuniServices servicesRacuni = new RacuniServices();
        public StavkeServices servicesStavke = new StavkeServices();

        private void FrmIzradaRacuna_Load(object sender, EventArgs e)
        {
            var allNaciniPlacanja = new NaciniPlacanjaServices().GetNaciniPlacanja();

            List<NacinPlacanja> novaListaNacinaPlacanja = allNaciniPlacanja;
            novaListaNacinaPlacanja.RemoveAt(0); // removed "All" from default NaciniPlacanja list
            cboOdabirNacinaPlacanja.DataSource = novaListaNacinaPlacanja;
        }

        private void btnIzradiRacun_Click(object sender, EventArgs e)
        {
            insertajRacun();
            povratakNaMeni();
        }

        private void btnIzradiIGenerirajPdf_Click(object sender, EventArgs e)
        {
           // insertajRacun();
            generirajPdf();
           // povratakNaMeni();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            Hide();
            frmUnosRacuna.ShowDialog();
            Close();
        }

        private void povratakNaMeni() 
        {
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            Hide();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void insertajRacun()
        {
            var selectedNacinPlacanja = cboOdabirNacinaPlacanja.SelectedItem as NacinPlacanja;
            var racunNovi = new Racun
            {
                nacin_placanja_id = selectedNacinPlacanja.id,
                korisnik_id = 1, // TODO logged user
                vrijeme_izdavanja = DateTime.Now,
                ukupno = FrmUnosRacuna.ukupnoUnos,
                popust = FrmUnosRacuna.ukupanPopust, 
                pdv = FrmUnosRacuna.ukupnoUnos - (FrmUnosRacuna.ukupnoUnos * 0.75), // TODO nez kaj s ovim
                cjena_bez_pdv = FrmUnosRacuna.ukupnoUnos - (FrmUnosRacuna.ukupnoUnos * 0.25), // TODO nez kaj s ovim
            };
            if (servicesRacuni.AddRacun(racunNovi, FrmUnosRacuna.listaStavkiURacunu.ToList()))
            {
                MessageBox.Show("Unesen racun!");
                Close();
            }
            else
            {
                MessageBox.Show("Neuspjesno unosenje racuna!");
            }
        }

        private void generirajPdf()
        {
           
            DateTime datumIzdavanja = DateTime.Now;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Racun_" + datumIzdavanja.ToString("dd.MM.yyyy_HH_mm_ss") + ".pdf";
            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            Font titleFont = FontFactory.GetFont("Arial", 20);
            Font totalFont = FontFactory.GetFont("Arial", 16);
            Font highlightFont = FontFactory.GetFont("Arial", 12);
            titleFont.SetStyle("bold");
            totalFont.SetStyle("bold");
            highlightFont.SetStyle("bold");

            Paragraph title = new Paragraph("Racun", titleFont);
            document.Add(title);
            document.Add(new Paragraph("Datum izdavanja: " + datumIzdavanja.ToString("dd.MM.yyyy HH:mm:ss")));

            // tablica stavki u racunu
            PdfPTable stavkeTablica = new PdfPTable(4) { SpacingBefore = 10, WidthPercentage = 100f };
            MessageBox.Show("duljina "+FrmUnosRacuna.listaStavkiURacunu.Count().ToString());
            foreach (var stavka in FrmUnosRacuna.listaStavkiURacunu.ToList())
            {/*
                MessageBox.Show("1 " + stavka.Artikli.ToString());
                MessageBox.Show("2 " + stavka.jed_cijena.ToString());
                MessageBox.Show("3 " + stavka.kolcina.ToString());
                MessageBox.Show("4 " + (stavka.kolcina * stavka.jed_cijena).ToString());*/

                // naziv artikla
                stavkeTablica.AddCell(stavka.Artikli.ToString());

                // cijena po kom
                stavkeTablica.AddCell(stavka.jed_cijena.ToString());

                // kom
                stavkeTablica.AddCell(stavka.kolcina.ToString());

                //iznos
                stavkeTablica.AddCell((stavka.kolcina*stavka.jed_cijena).ToString());
            }
            document.Add(stavkeTablica);

            document.Add(new Paragraph("Marko Markic")); // TODO
            document.Close();
            Process.Start(filePath);
        }
    }
}
