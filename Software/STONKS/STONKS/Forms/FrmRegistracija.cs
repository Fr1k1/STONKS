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

namespace STONKS.Forms
{
    public partial class FrmRegistracija : Form
    {

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice = null;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public FrmRegistracija()
        {
            InitializeComponent();
        }


        private UlogeServices ulogeServices = new UlogeServices();

        private KorisniciServices korisniciServices = new KorisniciServices();

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            Hide();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void FrmRegistracija_Load(object sender, EventArgs e)
        {
            GetUloge();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in filterInfoCollection)
                cbCameraName_new.Items.Add(filterinfo.Name);
            cbCameraName_new.SelectedIndex = 0;
            captureDevice = new VideoCaptureDevice();
        }

        private void GetUloge()
        {
            var uloge = ulogeServices.GetUloge();
            cbRole.DataSource = uloge;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtOIB.Text.Length != 11)
            {
                MessageBox.Show("OIB ima 11 znakova!!");
                return;
            }
            RegisterUser();
        }

        private void RegisterUser()
        {
            Uloga uloga = cbRole.SelectedItem as Uloga;
            var korisnik = new Korisnik
            {
                ime = txtName.Text,
                prezime = txtSurname.Text,
                OIB = txtOIB.Text,
                korime = txtUsername.Text,
                lozinka = txtPassword.Text,
                uloga_id = uloga.id,
                slika = @"\preloaded_faces\" + txtUsername.Text + ".jpg",

            };



            korisniciServices.AddKorisnik(korisnik);
            MessageBox.Show("Uspjesno dodan korisnik");
        }

        private void SetText(TextBox textBox)
        {
            if (textBox.Text != "")
                textBox.Text = "";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {
            SetText(txtName);

        }

        private void txtSurname_Click(object sender, EventArgs e)
        {
            SetText(txtSurname);


        }

        private void txtOIB_Click(object sender, EventArgs e)
        {
            SetText(txtOIB);

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            SetText(txtUsername);

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            SetText(txtPassword);

        }

        private void btnUkljuciKameru_new_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameraName_new.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            btnTakePicture_new.Enabled = true;
        }

        private void CaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pbCamera_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCamera_new.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnTakePicture_new_Click(object sender, EventArgs e)
        {
            if (!(captureDevice == null))
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.SignalToStop();


                    captureDevice = null;



                }


            }
        }

        private void btnSave_new_Click(object sender, EventArgs e)
        {
            pbSlikaZaSpremiti_new.SizeMode = PictureBoxSizeMode.StretchImage;

            pbSlikaZaSpremiti_new.Image = pbCamera_new.Image;
            pbSlikaZaSpremiti_new.Image.Save(txtUsername.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            pbSlikaZaSpremiti_new.Image.Save(path + @"\preloaded_faces\" + txtUsername.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }
    }
}
