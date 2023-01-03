using BusinessLayer.Services;
using EntitiesLayer.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace STONKS.Forms
{
    public partial class FrmDnevniPromet : Form
    {   
        PrometServices prometServices = new PrometServices();

        private double UkupanPromet;
        private double UkupnoKartice;
        private double UkupnoGotovina;
        private double PopustKartice;
        private double PopustGotovina;
        private double Kartice;
        private double Gotovina;
        private Dictionary<Korisnik, double> trafficPerEmploye;

        public FrmDnevniPromet()
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {   
            //get trafic data from prometServices
            UkupnoGotovina = prometServices.CalculateCash(dtpDate.Value);
            UkupnoKartice = prometServices.CalculateCard(dtpDate.Value);
            PopustKartice = prometServices.CalculateCardDiscount(dtpDate.Value);
            PopustGotovina = prometServices.CalculateCashDiscount(dtpDate.Value);
            trafficPerEmploye = prometServices.GetTraficByEmployees(dtpDate.Value);
            // calculate missing data from avelible ones
            Kartice = UkupnoKartice + PopustKartice;
            Gotovina = UkupnoGotovina + PopustGotovina;
            UkupanPromet = UkupnoKartice + UkupnoGotovina;
            // set value of ui elements
            lblUkupnoKartice.Text = UkupnoKartice + " EUR";
            lblUkupnoGotovina.Text = UkupnoGotovina + " EUR";
            lblgotovinaPopust.Text = PopustGotovina + " EUR";
            lblPopustkartice.Text = PopustKartice + " EUR";
            lblUkupniPromet.Text = UkupanPromet + " EUR";
            lblGotovina.Text = Gotovina + " EUR";
            lblKartice.Text = Kartice + " EUR";

        }

        private void btnIspisPrometX_Click(object sender, EventArgs ev)
        {
            genreateTraficReport();
        }

       private void genreateTraficReport(bool isFinalReport = false)
       {
            DateTime datumIzdavanja = DateTime.Now;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Izvestaj_" + datumIzdavanja.ToString("dd.MM.yyyy_HH_mm_ss") + ".pdf";
            Document document = new Document(PageSize.A6);

            // Podešavamo fajl za pisanje
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Dodajemo datum izdavanja na vrhu dokumenta
            Font titleFont = FontFactory.GetFont("Arial", 20);
            Font totalFont = FontFactory.GetFont("Arial", 16);
            Font highlightFont = FontFactory.GetFont("Arial", 12);
            titleFont.SetStyle("bold");
            totalFont.SetStyle("bold");
            highlightFont.SetStyle("bold");
            Paragraph title;
            if (isFinalReport)
                 title = new Paragraph("Promet Z", titleFont);
            else
                title = new Paragraph("Promet X", titleFont);
            document.Add(title);
            document.Add(new Paragraph("Datum izdavanja: " + datumIzdavanja.ToString("dd.MM.yyyy HH:mm:ss")));

            // Kreiramo tabelu za gotovinu
            PdfPTable cashTable = new PdfPTable(2) { SpacingBefore = 10, WidthPercentage = 100f };
            cashTable.AddCell("Gotovina");
            cashTable.AddCell(Gotovina + " EUR");
            cashTable.AddCell("Popust");
            cashTable.AddCell(PopustGotovina + " EUR");
            cashTable.AddCell(new Paragraph("Ukupno gotovina", highlightFont));
            cashTable.AddCell(new Paragraph(UkupnoGotovina + " EUR", highlightFont));


            // Dodajemo tabelu u dokument
            document.Add(cashTable);

            // Kreiramo tabelu za kartice
            PdfPTable cardTable = new PdfPTable(2) { SpacingBefore = 10, WidthPercentage = 100f };
            cardTable.AddCell("Kartice");
            cardTable.AddCell(Kartice + " EUR");
            cardTable.AddCell("Popust");
            cardTable.AddCell(PopustKartice + " EUR");
            cardTable.AddCell(new Paragraph("Ukupno kartice", highlightFont));
            cardTable.AddCell(new Paragraph(UkupnoKartice + " EUR", highlightFont));

            // Dodajemo tabelu u dokument
            document.Add(cardTable);
            document.Add(new Paragraph("PROMET: " + UkupanPromet + " EUR", totalFont));
            //ispis prometa po zaposelnicima
            if(isFinalReport && trafficPerEmploye != null)
            {
                document.Add(new Paragraph("Promet po zaposlenicima"));
                foreach (var entry in trafficPerEmploye)
                {
                    document.Add(new Paragraph(entry.Key.ime + " " + entry.Key.prezime + ": " + entry.Value + " EUR"));
                }
            }

            // Dodajemo ime osobe koja je izdala dokument na dnu stranice
            document.Add(new Paragraph("Izdao: John Smith"));

            // Zatvaramo dokument
            document.Close();
            //otvaranje pdf 
            Process.Start(filePath);
        }

        private void btnIzradaIspisZ_Click(object sender, EventArgs e)
        {
            genreateTraficReport(true);
        }
    }
}
