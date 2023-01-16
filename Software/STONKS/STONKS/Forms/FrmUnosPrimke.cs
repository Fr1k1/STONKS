using AForge.Video;
using AForge.Video.DirectShow;
using BusinessLayer.Services;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Hierarchy;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using BarcodeScanner;

namespace STONKS.Forms
{
    public partial class FrmUnosPrimke : Form
    {
        private DobavljaciServices dobavljaciServices = new DobavljaciServices();

        private PrimkaServices primkaServices = new PrimkaServices();

        private ArtikliServices artikliServices = new ArtikliServices();

        private BindingList<StavkaPrimke> stavkePrimke = new BindingList<StavkaPrimke>();
        
        public int IdPrimke { get; set; }
        private double FinalPrice  { get; set; }
        private double Discount  { get; set; }

        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice = null;

        public FrmUnosPrimke()
        {
            InitializeComponent();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            if (filterInfoCollection.Count > 0)
                UnloadCamera();
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void FrmUnosPrimke_Load(object sender, EventArgs e)
        {   
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(filterInfoCollection.Count > 0)  
            {
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.DesiredFrameRate = 1;

                videoCaptureDevice.Start();
            }
            
            txtBrojPrimke.Text = SetPrimkaId();
            LoadDobavljaciCBO();
            LoadStavkeDGV();
        }   

        private string SetPrimkaId()
        {
            IdPrimke  = primkaServices.GetIdForNewPrimka();

            if (IdPrimke < 10)
                return "Broj primke: 00" + IdPrimke;
            else if(IdPrimke < 100)
                return "Broj primke: 0" + IdPrimke;
            else
                return "Broj primke: " + IdPrimke;
        }

        public void LoadStavkeDGV() 
        {
            dgvStavkePrimke.DataSource = stavkePrimke;  
            dgvStavkePrimke.Columns[0].Visible = false;
            dgvStavkePrimke.Columns[1].Visible = false;
            dgvStavkePrimke.Columns[7].Visible = false;

            dgvStavkePrimke.Columns["ukupna_cijena"].ReadOnly = true;
            dgvStavkePrimke.Columns["Artikli"].ReadOnly = true;

            dgvStavkePrimke.Columns["Artikli"].DisplayIndex = 0;
            dgvStavkePrimke.Columns["kolicina"].DisplayIndex = 1;
            dgvStavkePrimke.Columns["rabat"].DisplayIndex = 2;
            dgvStavkePrimke.Columns["nabavna_cijena"].DisplayIndex = 3;
            dgvStavkePrimke.Columns["ukupna_cijena"].DisplayIndex = 4;

            dgvStavkePrimke.Columns["Artikli"].HeaderText = "Naziv artikla";
            dgvStavkePrimke.Columns["kolicina"].HeaderText = "Količina";
            dgvStavkePrimke.Columns["rabat"].HeaderText = "Rabat(%)";
            dgvStavkePrimke.Columns["nabavna_cijena"].HeaderText = "Nabavna cijena";
            dgvStavkePrimke.Columns["ukupna_cijena"].HeaderText = "Ukupna cijena";
           
            dgvStavkePrimke.Columns["rabat"].DefaultCellStyle.Format = "0.0\\%";
            dgvStavkePrimke.Columns["nabavna_cijena"].DefaultCellStyle.Format = "0.00## EUR";
            dgvStavkePrimke.Columns["ukupna_cijena"].DefaultCellStyle.Format = "0.00## EUR";
        }
        private void LoadDobavljaciCBO()
        {
            cboDobavljac.DataSource = dobavljaciServices.GetDobavljaci(); 
        }

        public void AddStavka(StavkaPrimke stavka,bool manual = true)  
        {
            if (!stavkePrimke.Contains(stavka))
            {   
                stavkePrimke.Add(stavka); 
                changeTabPosition();  
            }
            else if(manual)
                MessageBox.Show("Ovaj artikl ste već dodali!!!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void changeTabPosition()
        {
            int numOfRows = dgvStavkePrimke.RowCount - 1;
            dgvStavkePrimke.Rows[numOfRows].Cells["kolicina"].Selected = true;
        }

        private void InsertPrimka()
        {
            if (ValidatePrimka())
            {   
                var primka = new Primka()
                {
                    ukupno = FinalPrice,
                    datum = DateTime.Now,
                    Dobavljac_id = (cboDobavljac.SelectedItem as Dobavljac).id,
                };
                if (primkaServices.AddPrimka(primka, stavkePrimke.ToList()))
                {
                    MessageBox.Show("Primka je unesena!!!", "Uspiješan unos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (filterInfoCollection.Count > 0)
                        UnloadCamera();
                    Hide();
                    FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
                    frmPocetniIzbornik.ShowDialog();
                    Close();
                }
                else
                    MessageBox.Show("Došlo je do greške prilikom upisa u bazu,pokusajte kasnije", "Neuspiješan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Nisu uneseni svi potrebni podaci, primka nije unesena!!!", "Nesipravan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidatePrimka()
        {
            foreach (DataGridViewRow row in dgvStavkePrimke.Rows)
            {
                if (!row.IsNewRow)
                {
                    if ((int)row.Cells["kolicina"].Value == 0 || (double)row.Cells["nabavna_cijena"].Value == 0 || row.Cells["Artikli"].Value == null || (double)row.Cells["rabat"].Value < 0 || (double)row.Cells["rabat"].Value > 100) 
                        return false;
                }
            }               
            return true;
        }
        private void CalculateDiscount()
        {
            Discount = 0;
            foreach (var stavka in stavkePrimke)
            {
                Discount += stavka.kolicina * (stavka.nabavna_cijena * ((stavka.rabat / 100.00)));
            }
            txtPopust.Text = Discount.ToString() + " EUR";
        }

        private void CalculateFinalPrice()
        {
            FinalPrice = 0;
            foreach (var stavka in stavkePrimke)
            {
                FinalPrice += stavka.ukupna_cijena;
            }
            txtUkupno.Text = FinalPrice.ToString() + " EUR";
        }

        private void CalculateRowData(int rowIndex)
        {
            int kolicina = (int)dgvStavkePrimke.Rows[rowIndex].Cells["kolicina"].Value; 
            double rabat = (double)dgvStavkePrimke.Rows[rowIndex].Cells["rabat"].Value;    
            double nabavna_cijena = (double)dgvStavkePrimke.Rows[rowIndex].Cells["nabavna_cijena"].Value;  
            double uk_cijena = 0;
            uk_cijena = kolicina * (nabavna_cijena * (1 - (rabat / 100.00)));  
            dgvStavkePrimke.Rows[rowIndex].Cells["ukupna_cijena"].Value = uk_cijena;      
        }

        private void btnAddStavkaPrimke_Click(object sender, EventArgs e)
        {
            FrmOdaberiArtiklZaDodatiRucnoPrimka frmDodajRucno = new FrmOdaberiArtiklZaDodatiRucnoPrimka();
            frmDodajRucno.UnosPrimke = this;
            frmDodajRucno.ShowDialog();
            dgvStavkePrimke.Focus();
        }
        private void btnUnesiPrimku_Click(object sender, EventArgs e)
        {
            InsertPrimka();
        }
        private void dgvStavkePrimke_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateRowData(e.RowIndex);
            CalculateFinalPrice();
            CalculateDiscount();

        }
        private void dgvStavkePrimke_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateFinalPrice();
            CalculateDiscount();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs) 
        {   
            var image = (Bitmap)eventArgs.Frame.Clone();
            Task.Run(() =>
            {
                Scanner scanner = new Scanner();
                scanner.Scanned += new EventHandler<string>(CreateStavkaFromBarcode);
                Task.Run(() => scanner.Scan((Bitmap)image.Clone()));
            });
        }

        private void CreateStavkaFromBarcode(object sender, string sifra)
        {
             var artikl = artikliServices.GetArtikl(sifra);
             if (artikl != null)
                   {
                        var stavka = new StavkaPrimke()
                        {
                            artikl_id = artikl.id,
                            Artikli = artikl,
                            nabavna_cijena = 0.0,
                            rabat = 0,
                            kolicina = 1,
                            ukupna_cijena = 0.0,
                            primka_id = IdPrimke
                        };
                        Invoke((MethodInvoker)delegate { AddStavka(stavka,false); });
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
    }
}
