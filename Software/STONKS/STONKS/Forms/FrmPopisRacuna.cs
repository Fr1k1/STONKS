using BusinessLayer.Services;
using EntitiesLayer.Entities;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace STONKS.Forms
{
    public partial class FrmPopisRacuna : Form
    {
        public FrmPopisRacuna()
        {
            InitializeComponent();
        }

        private RacuniServices racunServices = new RacuniServices();
        private ArtikliServices artiklServices = new ArtikliServices();
        private StavkeServices stavkaServices = new StavkeServices();
        private NaciniPlacanjaServices naciniServices = new NaciniPlacanjaServices();

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void FrmPopisRacuna_Load(object sender, EventArgs e)
        {
            var naciniPlacanja = naciniServices.GetNaciniPlacanja();
            cboVrsta.DataSource = naciniPlacanja;
            loadanjeCharta1();
        }

        private void dgvRacuni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PrikaziStavke();
        }

        private void PrikaziRacune()
        {
            var racuni = racunServices.GetRacuni();
            dgvRacuni.DataSource = racuni;
            UrediTablicuRacuni();
        }

        private void PrikaziStavke()
        {
            var odabraniRed = dgvRacuni.CurrentRow.DataBoundItem as Racun;
            var stavke = stavkaServices.GetStavke(odabraniRed);
            dgvStavke.DataSource = stavke;
            UrediTablicuStavke();
            loadanjeCharta2(stavke);
        }
        private void cboVrsta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVrsta.SelectedIndex == 0)
            {
                PrikaziRacune();
            }
            else
            {
                var odabraniNacin = cboVrsta.SelectedItem as NacinPlacanja;
                var racuni = racunServices.GetRacuniFilter(odabraniNacin.id);
                dgvRacuni.DataSource = racuni;
            }
        }

        private void UrediTablicuRacuni()
        {
            dgvRacuni.ReadOnly = true;
            dgvRacuni.Columns[7].Visible = false;
            dgvRacuni.Columns[8].Visible = false;
            dgvRacuni.Columns[10].Visible = false;
            
            dgvRacuni.Columns["id"].DisplayIndex = 0;
            dgvRacuni.Columns["vrijeme_izdavanja"].DisplayIndex = 1;
            dgvRacuni.Columns["popust"].DisplayIndex = 2;
            dgvRacuni.Columns["ukupno"].DisplayIndex = 3;
            dgvRacuni.Columns["pdv"].DisplayIndex = 4;
            dgvRacuni.Columns["cjena_bez_pdv"].DisplayIndex = 5;
            dgvRacuni.Columns["NaciniPlacanja"].DisplayIndex = 6;
            dgvRacuni.Columns["korisnik_id"].DisplayIndex = 7;

            dgvRacuni.Columns["id"].HeaderText = "ID racuna";
            dgvRacuni.Columns["vrijeme_izdavanja"].HeaderText = "Vrijeme izdavanja";
            dgvRacuni.Columns["popust"].HeaderText = "Popust [EUR]";
            dgvRacuni.Columns["ukupno"].HeaderText = "Ukupan iznos racuna [EUR]";
            dgvRacuni.Columns["cjena_bez_pdv"].HeaderText = "Iznos bez PDV-a [EUR]";
            dgvRacuni.Columns["pdv"].HeaderText = "Iznos PDV-a [EUR]";
            dgvRacuni.Columns["korisnik_id"].HeaderText = "ID zaposlenika";
            dgvRacuni.Columns["NaciniPlacanja"].HeaderText = "Nacin placanja";
            
            dgvRacuni.Columns["popust"].DefaultCellStyle.Format = "N2"; // N2 is for 2 decimals
            dgvRacuni.Columns["ukupno"].DefaultCellStyle.Format = "N2";
            dgvRacuni.Columns["cjena_bez_pdv"].DefaultCellStyle.Format = "N2";  
            dgvRacuni.Columns["pdv"].DefaultCellStyle.Format = "N2";
        }

        private void UrediTablicuStavke()
        {
            dgvStavke.Columns[7].Visible = false;
            dgvStavke.Columns[0].Visible = false;
            dgvStavke.Columns[1].Visible = false;
            dgvStavke.ReadOnly = true;

            dgvStavke.Columns["Artikli"].DisplayIndex = 0;
            dgvStavke.Columns["kolcina"].DisplayIndex = 1;
            dgvStavke.Columns["popust"].DisplayIndex = 2;

            dgvStavke.Columns["Artikli"].HeaderText = "Naziv artikla";
            dgvStavke.Columns["kolcina"].HeaderText = "Kolicina";
            dgvStavke.Columns["popust"].HeaderText = "Popust po artiklu [%]";
        }

        private void btnStorniraj_Click(object sender, EventArgs e)
        {
            var selectedRacun = dgvRacuni.CurrentRow.DataBoundItem as Racun;
            if(selectedRacun != null)
                CreateStorno(selectedRacun);
        }

        private void CreateStorno(Racun racun)
        {   
            //dohvatiti stavke
            var stavke = stavkaServices.GetStavke(racun);
            if (racunServices.AddInverse(racun, stavke))
            {
                MessageBox.Show("Racun je uspiješno storniran","Uspijeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrikaziRacune();
            }
            else
            {
                MessageBox.Show("Došlo je do greške prilikom stroniranja","Greška",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void loadanjeCharta1()
        {
            chartRacuni.Series["Broj placanja"].Points.AddXY("Karticno", racunServices.GetRacuniByNacinPlacanja(3));
            chartRacuni.Series["Broj placanja"].Points.AddXY("Gotovina", racunServices.GetRacuniByNacinPlacanja(2));
        }

        private void loadanjeCharta2(List<StavkaRacuna> stavke)
        {
            chartStavke.Series["Broj artikala"].Points.Clear();

            List<string> listaVrstaArtikala = new List<string>();

            // sve vrste artikla u racunu
            foreach(var s in stavke)
            {
                string vrsta = (artiklServices.GetArtikl(s.artikl_id)).VrsteArtikla.naziv;
                if (!listaVrstaArtikala.Contains(vrsta))
                {
                    listaVrstaArtikala.Add(vrsta);
                }
            }

            // po svakoj vrsti artikla od postojecih u tom racunu
            foreach (var vrstaIzListe in listaVrstaArtikala)
            {
                var broj = 0;
                string vrsta = null;

                foreach (var s in stavke)
                {
                    vrsta = (artiklServices.GetArtikl(s.artikl_id)).VrsteArtikla.naziv;
                    if (vrsta == vrstaIzListe)
                    {
                        broj+=s.kolcina;
                    }
                }
                if (broj > 0)
                {
                    chartStavke.Series["Broj artikala"].Points.AddXY(vrstaIzListe, broj);
                }
            }

        }

        private void btnGenerirajPdf_Click(object sender, EventArgs e)
        {
            var selectedRacun = dgvRacuni.CurrentRow.DataBoundItem as Racun;
            if (selectedRacun != null)
                generirajPdf(selectedRacun);

            
        }

        private void generirajPdf(Racun racun)
        {
            var stavke = stavkaServices.GetStavke(racun);


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

            PdfPTable infoTablica = new PdfPTable(2) { SpacingBefore = 10, WidthPercentage = 100f };

            infoTablica.AddCell(new PdfPCell(new Paragraph("Ducan d.o.o. - Poslovnica Karlovac\nDomobranska 22, 47000 Karlovac\n\tel. 047/ 123 223\nOIB: 12345645612\nwww.ducan.hr\ninfo@ducan.com\nIBAN: HR55123456789123456789")));
            document.Add(infoTablica);


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
            foreach (var stavka in stavke)
            {
                // redni broj stavke
                stavkeTablica.AddCell(i.ToString() + ".");
                i++;

                // naziv artikla
                stavkeTablica.AddCell(stavka.Artikli.ToString());

                // cijena po kom
                stavkeTablica.AddCell(stavka.jed_cijena.ToString());

                // kom
                stavkeTablica.AddCell(stavka.kolcina.ToString());

                // popust
                stavkeTablica.AddCell(stavka.popust.ToString());

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
            slikaQR.ScaleAbsolute(120, 120);
            slikaQR.Alignment = Element.ALIGN_CENTER;
            document.Add(slikaQR);
            slikaQR.SpacingAfter = 40;

            document.Add(new Paragraph("Racun je pravovaljan bez ziga jer je izdan na racunalu.", highlightFont));

            // document.Add(new Paragraph("Zaposlenik: " + FrmFaceRecNewApproach.logiraniKorisnik.korime)); // OVO JE DOBRO
            document.Add(new Paragraph("Zaposlenik: " + "PROMIJENI U KOMENTAR IZNAD"));
            var selectedNacinPlacanja = racun.NaciniPlacanja as NacinPlacanja;
            document.Add(new Paragraph("Nacin placanja: " + selectedNacinPlacanja.naziv));
            document.Add(new Paragraph("Datum i mjesto izdavanja: " + datumIzdavanja.ToString("dd.MM.yyyy HH:mm:ss") + ", Karlovac"));

            document.Close();
            Process.Start(filePath);
        }
    }
}
