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
        /// <summary>
        /// This form is tasked with showin user statistics of daily trafic,
        /// closing shop for the day and making reports in pdf.
        /// Author : Filip Milohanović
        /// 
        /// </summary>
        PrometServices prometServices = new PrometServices();

        private double UkupanPromet;
        private double UkupnoKartice;
        private double UkupnoGotovina;
        private double PopustKartice;
        private double PopustGotovina;
        private double Kartice;
        private double Gotovina;
        private double Porez;
        private Dictionary<Korisnik, double> trafficPerEmploye;

        public FrmDnevniPromet()
        {
            InitializeComponent();    
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {   
            Hide();
            FrmPrepoznavanjeLica.CheckLogirani();
            Close();
        }

        //gets trafic data for selected day
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetPromet();
        }
        // gets trafic data from service and assignes it to labels, some data is calculated based on other data
        private void GetPromet()
        {   
            CheckIfTraficReportHasBeenSubmited();
            UkupnoGotovina = prometServices.CalculateCash(dtpDate.Value);
            UkupnoKartice = prometServices.CalculateCard(dtpDate.Value);
            PopustKartice = prometServices.CalculateCardDiscount(dtpDate.Value);
            PopustGotovina = prometServices.CalculateCashDiscount(dtpDate.Value);
            trafficPerEmploye = prometServices.GetTraficByEmployees(dtpDate.Value);
            Porez = prometServices.CalculateTax(dtpDate.Value);
            Kartice = UkupnoKartice + PopustKartice;
            Gotovina = UkupnoGotovina + PopustGotovina;
            UkupanPromet = UkupnoKartice + UkupnoGotovina;
            lblUkupnoKartice.Text = UkupnoKartice + " EUR";
            lblUkupnoGotovina.Text = UkupnoGotovina + " EUR";
            lblgotovinaPopust.Text = PopustGotovina + " EUR";
            lblPopustkartice.Text = PopustKartice + " EUR";
            lblUkupniPromet.Text = UkupanPromet + " EUR";
            lblGotovina.Text = Gotovina + " EUR";
            lblKartice.Text = Kartice + " EUR";
        }

        // checks if cash register is closed for the day and enables or disables buttons
        private void CheckIfTraficReportHasBeenSubmited()
        {   
            var promet = prometServices.isZDone(dtpDate.Value);
            Console.WriteLine(promet);
            if(DateTime.Now.Date != dtpDate.Value.Date)
            {
                btnIzradaZ.Enabled = false;
                if(promet)
                    btnIspisZ.Enabled = true;
                else
                    btnIspisZ.Enabled = false;
            }
            else if (promet)
            {
                btnIspisZ.Enabled = true;
            }
            else
            {
                btnIzradaZ.Enabled = true;
                btnIspisZ.Enabled = false;
            }
        }
        //generate promet X
        private void btnIspisPrometX_Click(object sender, EventArgs ev)
        {
            genreateTraficReport();
        }

        //method that generates pdf for reports and writes it on desktop, nothing smart
       private void genreateTraficReport(bool isFinalReport = false)
       {
            DateTime datumIzdavanja = DateTime.Now;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Izvestaj_" + datumIzdavanja.ToString("dd.MM.yyyy_HH_mm_ss") + ".pdf";
            Document document = new Document(PageSize.A6);
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();
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

            PdfPTable cashTable = new PdfPTable(2) { SpacingBefore = 10, WidthPercentage = 100f };
            cashTable.AddCell("Gotovina");
            cashTable.AddCell(Gotovina + " EUR");
            cashTable.AddCell("Popust");
            cashTable.AddCell(PopustGotovina + " EUR");
            cashTable.AddCell(new Paragraph("Ukupno gotovina", highlightFont));
            cashTable.AddCell(new Paragraph(UkupnoGotovina + " EUR", highlightFont));

            document.Add(cashTable);

            PdfPTable cardTable = new PdfPTable(2) { SpacingBefore = 10, WidthPercentage = 100f };
            cardTable.AddCell("Kartice");
            cardTable.AddCell(Kartice + " EUR");
            cardTable.AddCell("Popust");
            cardTable.AddCell(PopustKartice + " EUR");
            cardTable.AddCell(new Paragraph("Ukupno kartice", highlightFont));
            cardTable.AddCell(new Paragraph(UkupnoKartice + " EUR", highlightFont));

            document.Add(cardTable);
            document.Add(new Paragraph("PROMET: " + UkupanPromet + " EUR", totalFont));
            document.Add(new Paragraph("PDV: " + Porez + " EUR", highlightFont));
            
            if (isFinalReport && trafficPerEmploye != null)
            {
                document.Add(new Paragraph("Promet po zaposlenicima"));
                foreach (var entry in trafficPerEmploye)
                {
                    document.Add(new Paragraph(entry.Key.ime + " " + entry.Key.prezime + ": " + entry.Value + " EUR"));
                }
            }

            document.Add(new Paragraph("Izdao:" + FrmPrepoznavanjeLica.logiraniKorisnik.ime + " " + FrmPrepoznavanjeLica.logiraniKorisnik.prezime));
            document.Close();
            Process.Start(filePath);
        }

        // method that closes cash register for the day, after this is done, no other bills can be issued
        private void btnIzradaIspisZ_Click(object sender, EventArgs e)
        {
            if (prometServices.CreateZ(FrmPrepoznavanjeLica.logiraniKorisnik))
            {
                MessageBox.Show("Promez Z izrađen", "Uspijeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CheckIfTraficReportHasBeenSubmited();
                btnIzradaZ.Enabled = false;
            }
            else
                MessageBox.Show("Došlo je do greške", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //sets help file path and date time picker to today
        private void FrmDnevniPromet_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "\\UserManual.chm";
            dtpDate.Value = DateTime.Now;
        }
        // generate promet z/ final day report
        private void btnIspisZ_Click(object sender, EventArgs e)
        {
            genreateTraficReport(true);
        }

        //shows context based help when pressing F1 key
        private void FrmDnevniPromet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "dnevniPromet.htm");
            }
        }
        
    }
}
