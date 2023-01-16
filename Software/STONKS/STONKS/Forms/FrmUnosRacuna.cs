using AForge.Video;
using AForge.Video.DirectShow;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace STONKS.Forms
{
    public partial class FrmUnosRacuna : Form
    {
        static public BindingList<StavkaRacuna> listaStavkiURacunu = new BindingList<StavkaRacuna>();
        static public double ukupnoUnos { get; set; }
        static public double ukupanPopust { get; set; }
        public ArtikliServices servicesArtikli = new ArtikliServices();
        public RacuniServices racuniServices = new RacuniServices();
        public PrometServices prometServices = new PrometServices();
        static public double ukupniPDV { get; set; }
      
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice = null;

        public FrmUnosRacuna()
        {
            InitializeComponent();
        }
        
    private void btnOdustani_Click(object sender, EventArgs e)
        {
            Zatvori();
        }

        private void btnDodajRucno_Click(object sender, EventArgs e)
        {
            UnloadCamera();
            FrmOdaberiArtiklZaDodatiRucno frmOdaberiArtiklZaDodatiRucno = new FrmOdaberiArtiklZaDodatiRucno();
            Hide();
            frmOdaberiArtiklZaDodatiRucno.ShowDialog();
            Close();
        }

        private void btnNastavi_Click(object sender, EventArgs e)
        {
            if (ProvjeriPodatke() == true)
            {
                UnloadCamera();
                IzracunajPDV();
                FrmIzradaRacuna frmIzradaRacuna = new FrmIzradaRacuna();
                Hide();
                frmIzradaRacuna.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Provjeri ispravnost podataka", "Nedopusten unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void FrmUnosRacuna_Load(object sender, EventArgs e)
        {
            if(prometServices.isZDone(DateTime.Now) == false)
            {
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.DesiredFrameRate = 1;

                videoCaptureDevice.Start();

                UrediTablicuStavke();

                if (listaStavkiURacunu != null)
                {
                    IzracunajPopust();
                    IzracunajUkupno();
                }
            }
            else
            {
                MessageBox.Show("Blagajna je zatvorena. \nNije vise moguce unijeti novi racun za danasnji dan.","Zatvoreno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Zatvori();
            }
        }

        private void dgvArtikli_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            IzracunajUkupnoPoStavci(e.RowIndex);
            IzracunajPopust();
            IzracunajUkupno();  
        }

        private void IzracunajUkupnoPoStavci(int rowIndex)
        {
            int kol = (int)dgvArtikli.Rows[rowIndex].Cells["kolcina"].Value;
            double jed_cijena = (double)dgvArtikli.Rows[rowIndex].Cells["jed_cijena"].Value;
            double popust = (double)dgvArtikli.Rows[rowIndex].Cells["popust"].Value;

            double uk_cijena = 0;
            uk_cijena = (kol * jed_cijena);

            if(popust > 0)
            {
               uk_cijena = uk_cijena - uk_cijena * (popust / 100);
            }

            dgvArtikli.Rows[rowIndex].Cells["ukupno"].Value = uk_cijena;
        }

        private void IzracunajUkupno()
        {
            ukupnoUnos = 0;
            foreach (var item in listaStavkiURacunu)
            {
                double popustDecimalni = ((double)(item.popust) / 100);
                ukupnoUnos = ukupnoUnos + (item.kolcina * item.Artikli.jed_cijena);
            }
            ukupnoUnos = ukupnoUnos - Double.Parse(txtPopust.Text);
            txtUkupno.Text = ukupnoUnos.ToString();
        }
        
        private void IzracunajPDV()
        {
            ukupniPDV = 0;
            double pdvzataj = 0;
            foreach (var item in listaStavkiURacunu)
            {
                double artiklPDV = servicesArtikli.GetPDV(item.artikl_id);
                if (item.popust > 0)
                {
                    double popustDecimalni = 1 - ((double)(item.popust) / 100);
                    ukupniPDV = ukupniPDV + ((item.Artikli.jed_cijena * item.kolcina) * popustDecimalni) * artiklPDV / 100;
                    pdvzataj = ((item.Artikli.jed_cijena * item.kolcina) * popustDecimalni) * artiklPDV / 100;
                }
                else
                {
                    ukupniPDV = ukupniPDV + ((item.kolcina * (item.jed_cijena * artiklPDV/100)));
                    pdvzataj = ((item.kolcina * (item.jed_cijena * artiklPDV / 100)));
                }
            }
        }

        private void IzracunajPopust()
        {
            ukupanPopust = 0;
            foreach (var item in listaStavkiURacunu)
            {
                double popustDecimalni = ((double)(item.popust) / 100);
                ukupanPopust += ((item.Artikli.jed_cijena * item.kolcina) * popustDecimalni);
            } 
            txtPopust.Text = ukupanPopust.ToString();
        }
        private void UrediTablicuStavke()
        {
            dgvArtikli.DataSource = listaStavkiURacunu;

            dgvArtikli.Columns[0].Visible = false;
            dgvArtikli.Columns[1].Visible = false;
            dgvArtikli.Columns[7].Visible = false;

            dgvArtikli.Columns["kolcina"].HeaderText = "Kolicina [kom]";
            dgvArtikli.Columns["Popust"].HeaderText = "Popust [%]";
            dgvArtikli.Columns["Artikli"].HeaderText = "Naziv artikla";
            dgvArtikli.Columns["jed_cijena"].HeaderText = "Cijena/kom";
            dgvArtikli.Columns["Ukupno"].HeaderText = "Ukupno";

            dgvArtikli.Columns["jed_cijena"].ReadOnly = true;
            dgvArtikli.Columns["Ukupno"].ReadOnly = true;
            dgvArtikli.Columns[6].ReadOnly = true;

            dgvArtikli.Columns["Artikli"].DisplayIndex = 0;
            dgvArtikli.Columns["kolcina"].DisplayIndex = 1;
            dgvArtikli.Columns["Popust"].DisplayIndex = 2;
        }

        private void btnIzbrisiArtikl_Click(object sender, EventArgs e)
        {
            var selectedStavka = dgvArtikli.CurrentRow.DataBoundItem as StavkaRacuna;
            listaStavkiURacunu.Remove(selectedStavka);
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var image = (Bitmap)eventArgs.Frame.Clone();

            Task.Run(() =>
            {
                BarcodeScanner scanner = new BarcodeScanner();
                scanner.Scanned += new EventHandler<string>(CreateStavkaFromBarcode);
                Task.Run(() => scanner.Scan((Bitmap)image.Clone()));
            });
        }

        private void CreateStavkaFromBarcode(object sender, string sifra)
        {
            var artikl = servicesArtikli.GetArtikl(sifra);
            if (artikl != null)
            {
                StavkaRacuna novaStavka = new StavkaRacuna()
                {
                    Artikli = artikl,
                    kolcina = 1,
                    popust = 0,
                    artikl_id = artikl.id,
                    ukupno = artikl.jed_cijena,
                    jed_cijena=artikl.jed_cijena,
                };
                
                Invoke((MethodInvoker)delegate { AddStavka(novaStavka); });
                
            }
        }

        public void AddStavka(StavkaRacuna stavka)
        {
            if (!listaStavkiURacunu.Any(s=> stavka.artikl_id == s.artikl_id )) 
            {
                listaStavkiURacunu.Add(stavka);
            }
        }

        private void UnloadCamera()
        {
            Console.WriteLine("close");
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice = null;
            }
        }

        private void Zatvori()
        {
            UnloadCamera();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            Hide();
            FrmPrepoznavanjeLica.CheckLogirani();
            Close();
        }

        private bool ProvjeriPodatke()
        {
            foreach (DataGridViewRow row in dgvArtikli.Rows)
            {
                if (!row.IsNewRow)
                {
                    if ((int)row.Cells["kolcina"].Value < 0 || (double)row.Cells["popust"].Value < 0 || row.Cells["Artikli"].Value == null)
                        return false;
                }
            }
            return true;
        }
    }
}
