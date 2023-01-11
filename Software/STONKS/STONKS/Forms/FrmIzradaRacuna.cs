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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
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
/*
            PdfPTable infoTablica = new PdfPTable(2) { SpacingBefore = 10, WidthPercentage = 100f};

            infoTablica.AddCell(new PdfPCell(new Paragraph("Ducan d.o.o. - Poslovnica Karlovac\nDomobranska 22, 47000 Karlovac\n\tel. 047/ 123 223\nOIB: 12345645612\nwww.ducan.hr\ninfo@ducan.com\nIBAN: HR55123456789123456789")));
            document.Add(infoTablica);
*/

            iTextSharp.text.Image slikaLogo = iTextSharp.text.Image.GetInstance("logo.png");
            slikaLogo.ScaleAbsolute(130, 130);
            slikaLogo.Alignment = Element.ALIGN_LEFT;
            document.Add(slikaLogo);
            slikaLogo.SpacingAfter = 10;

            Paragraph title = new Paragraph("Racun", titleFont);
            document.Add(title);
            document.Add(new Paragraph("Ducan d.o.o. - Poslovnica Karlovac"));
            document.Add(new Paragraph("Domobranska 22, 47000 Karlovac"));
            document.Add(new Paragraph("tel. 047/ 123 223"));
            document.Add(new Paragraph("OIB: 12345645612"));
            document.Add(new Paragraph("www.ducan.hr"));
            document.Add(new Paragraph("info@ducan.com"));
            Paragraph last = new Paragraph("IBAN: HR55123456789123456789");

            document.Add(last);
            last.SpacingAfter = 20;

            // tablica stavki u racunu
            PdfPTable stavkeTablica = new PdfPTable(6) { SpacingBefore = 10, WidthPercentage = 100f };
            last.SpacingBefore = 20;

            PdfPCell cell = new PdfPCell(new Phrase("Artikli racuna"));
            cell.Colspan = 6;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            stavkeTablica.AddCell(cell);

            stavkeTablica.AddCell("Redni broj artikla");
            stavkeTablica.AddCell("Naziv artikla");
            stavkeTablica.AddCell("Cijena/kom");
            stavkeTablica.AddCell("Kolicina [kom]");
            stavkeTablica.AddCell("Popust [%]");
            stavkeTablica.AddCell("Ukupna cijena stavke [EUR]");

            var i = 1; 
            foreach (var stavka in FrmUnosRacuna.listaStavkiURacunu.ToList())
            {
                // redni broj stavke
                stavkeTablica.AddCell(i.ToString()+".");
                i++;

                // naziv artikla
                stavkeTablica.AddCell(stavka.Artikli.ToString());

                // cijena po kom
                stavkeTablica.AddCell(stavka.jed_cijena.ToString());

                // kom
                stavkeTablica.AddCell(stavka.kolcina.ToString());

                // popust
                stavkeTablica.AddCell(stavka.popust.ToString()); // TODO ovo se ne prikazuje, valjda se ni ne sprema idk

                // iznos
                var uk_cijena = stavka.kolcina * stavka.jed_cijena;
                if (stavka.popust > 0)
                {
                    uk_cijena = uk_cijena - uk_cijena * (stavka.popust / 100);
                }
                stavkeTablica.AddCell(uk_cijena.ToString());
            }
            
            PdfPCell cellUkupno = new PdfPCell(new Phrase("UKUPNA CIJENA RACUNA: "));
            cellUkupno.Colspan = 5;
            cellUkupno.HorizontalAlignment = 2; // 0=Left, 1=Centre, 2=Right
            stavkeTablica.AddCell(cellUkupno);

            stavkeTablica.AddCell(FrmUnosRacuna.ukupnoUnos.ToString());

            stavkeTablica.HorizontalAlignment = Element.ALIGN_CENTER;
            document.Add(stavkeTablica);

            document.Add(new Paragraph("ZKI: " + "842291704b770fad012333b24c54785b"));
            document.Add(new Paragraph("JIR: " + "fadd8b45-5789-458d-8b4c-afd0c54ad89e"));

            // slika qr koda do porezne, u x64/debug se nalazi
            iTextSharp.text.Image slikaQR = iTextSharp.text.Image.GetInstance("qr.png");
            slikaQR.ScaleAbsolute(120,120);
            slikaQR.Alignment = Element.ALIGN_CENTER;
            document.Add(slikaQR);
            slikaQR.SpacingAfter = 40;

            document.Add(new Paragraph("Racun je pravovaljan bez ziga jer je izdan na racunalu.", highlightFont));

            document.Add(new Paragraph("Zaposlenik: " + "Marko Markic")); // TODO
            var selectedNacinPlacanja = cboOdabirNacinaPlacanja.SelectedItem as NacinPlacanja;
            document.Add(new Paragraph("Nacin placanja: " + selectedNacinPlacanja.naziv));
            document.Add(new Paragraph("Datum i mjesto izdavanja: " + datumIzdavanja.ToString("dd.MM.yyyy HH:mm:ss") + ", Karlovac"));

            document.Close();
            Process.Start(filePath);
        }
    }
}
