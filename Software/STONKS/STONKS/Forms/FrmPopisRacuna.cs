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
    //Author : Ana Škarica 
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
            FrmPrepoznavanjeLica.CheckLogirani();
            Close();
        }

        private void FrmPopisRacuna_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + "\\UserManual.chm";
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
            
            dgvRacuni.Columns["popust"].DefaultCellStyle.Format = "N2";
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
            dgvStavke.Columns["kolcina"].HeaderText = "Kolicina [kom]";
            dgvStavke.Columns["ukupno"].HeaderText = "Ukupna cijena [EUR]";
            dgvStavke.Columns["jed_cijena"].HeaderText = "Cijena/kom [EUR]";
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
            var stavke = stavkaServices.GetStavke(racun);
            racun.korisnik_id = FrmPrepoznavanjeLica.logiraniKorisnik.id;
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

            foreach(var s in stavke)
            {
                string vrsta = (artiklServices.GetArtikl(s.artikl_id)).VrsteArtikla.naziv;
                if (!listaVrstaArtikala.Contains(vrsta))
                {
                    listaVrstaArtikala.Add(vrsta);
                }
            }

            foreach (var vrstaIzListe in listaVrstaArtikala)
            {
                var broj = 0;
                string vrsta = null;

                foreach (var s in stavke)
                {
                    vrsta = (artiklServices.GetArtikl(s.artikl_id)).VrsteArtikla.naziv;
                    if (vrsta == vrstaIzListe)
                    {
                        broj += s.kolcina;
                    }
                }
                if (broj > 0)
                {
                    chartStavke.Series["Broj artikala"].Points.AddXY(vrstaIzListe, broj);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvRacuni.DataSource = racunServices.GetRacuniByDate(dateTimePicker1.Value);
        }

        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            PrikaziRacune();
        }


        //show context based help when pressing F1 key
        private void FrmPopisRacuna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "popisracuna.html");
            }
        }
    }
}
