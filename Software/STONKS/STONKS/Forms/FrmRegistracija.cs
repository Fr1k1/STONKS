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

        //Author : Martin Friščić (all code except help)

        //variables for camera and gets the path to desktop

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

            FrmLogin frmLogin = new FrmLogin();
            Hide();

            frmLogin.ShowDialog();
            Close();
        }


        //on load some buttons are disabled for better user experience
        //roles are also loaded so user can choose what role will the new user be
        private void FrmRegistracija_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + "\\UserManual.chm";
            btnUkljuciKameru_new.Enabled = false;
            btnTakePicture_new.Enabled = false;
            btnSave_new.Enabled = false;
            btnRegister.Enabled = false;
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


        //first it validates inputs and then tries to register the user
        private void btnRegister_Click(object sender, EventArgs e)
        {

            //checks if TextBoxes are not empty or equal to placeholder values
            if (txtOIB.Text == "" || txtName.Text == "" || txtPassword.Text == "" || txtSurname.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            //OIB length has to be 11!
            if (txtOIB.Text.Length != 11)
            {
                MessageBox.Show("OIB ima 11 znakova!!");
                return;
            }

            //checks if the username is unique

            foreach (var kor in korisniciServices.GetKorisnici())
            {
                if (txtUsername.Text == kor.korime)
                {
                    MessageBox.Show("Korisnik s tim korisnickim imenom vec postoji!");
                    return;
                }

                //checks if the OIB is unique

                if (txtOIB.Text == kor.OIB)
                {
                    MessageBox.Show("Korisnik s tim OIBOM vec postoji!");
                    return;
                }
            }
            RegisterUser();
        }


        //adds the user to database, adds path to his picture
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

        //code for camera is the same as on FrmPrepoznavanjeLica and it is explained there

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
            btnSave_new.Enabled = true;
        }


        //before registratrion button is enabled, admin has to save the picture for the new user
        //picture saves in folder preloaded_faces on desktop with the name of new user 
        private void btnSave_new_Click(object sender, EventArgs e)
        {
            pbSlikaZaSpremiti_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlikaZaSpremiti_new.Image = pbCamera_new.Image;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = path + "\\" + "preloaded_faces";
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.FileName = txtUsername.Text;
            saveFileDialog.DefaultExt = ".jpg";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbSlikaZaSpremiti_new.Image.Save(saveFileDialog.FileName);
                btnRegister.Enabled = true;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" || txtUsername.Text != "KORISNICKO IME")
            {
                btnUkljuciKameru_new.Enabled = true;
            }
        }


        //show context based help when pressing F1 key
        private void FrmRegistracija_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "registracija.html");
            }
        }
    }
}
