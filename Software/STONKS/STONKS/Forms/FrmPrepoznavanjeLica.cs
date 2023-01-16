using AForge.Video;
using AForge.Video.DirectShow;
using BusinessLayer.Services;
using DataAccessLayer;
using EntitiesLayer.Entities;
using FaceRecognitionDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STONKS.Forms
{
    public partial class FrmPrepoznavanjeLica : Form
    {
        public static Korisnik logiraniKorisnik = null;

        public static void CheckLogirani()
        {
            if (logiraniKorisnik.uloga_id == 1)
            {
                FrmPocetniIzbornikVoditelj frmPocetniIzbornikVoditelj = new FrmPocetniIzbornikVoditelj();
                frmPocetniIzbornikVoditelj.ShowDialog();
            }
            else
            {
                FrmPocetniIzbornik frmPocetniIzbornik = new FrmPocetniIzbornik();
                frmPocetniIzbornik.ShowDialog();
            }
        }

        private KorisniciServices services = new KorisniciServices();

        string file1, file2 = "";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace(@"\", @"\\");

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice = null;
        public FrmPrepoznavanjeLica()
        {
            InitializeComponent();
        }

        private void btnPic2_new_Click(object sender, EventArgs e)
        {
            Bitmap bPic2 = new Bitmap(System.Drawing.Image.FromFile(path + "\\captured_pic.jpg"));
            pbPic2_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPic2_new.Image = bPic2;

            file2 = path + "\\captured_pic.jpg";
            if (pbPic1_new.Image != null && pbPic2_new.Image != null)
            {
                btnCompare_new.Enabled = true;
            }
        }

        private void btnCompare_new_Click(object sender, EventArgs e)
        {
            try
            {
                string currentDirectory = Environment.CurrentDirectory + "\\models";
                FaceRecognition fr;
                fr = FaceRecognition.Create(currentDirectory);

                var pic1 = FaceRecognition.LoadImageFile(file1);
                var compare1 = fr.FaceEncodings(pic1).First();
                var pic2 = FaceRecognition.LoadImageFile(file2);
                var compare2 = fr.FaceEncodings(pic2).First();

                if (FaceRecognition.CompareFace(compare1, compare2))
                {
                    Korisnik korisnik = cbAllUsers.SelectedItem as Korisnik;
                    logiraniKorisnik = korisnik;
                    if (korisnik.uloga_id == 1)
                    {
                        Hide();
                        FrmPocetniIzbornikVoditelj frmPocetniIzbornikVoditelj = new FrmPocetniIzbornikVoditelj();
                        frmPocetniIzbornikVoditelj.ShowDialog();
                        Close();
                    }

                    else
                    {
                        Hide();
                        FrmPocetniIzbornik frmPocetniIzbornik = new FrmPocetniIzbornik();
                        frmPocetniIzbornik.ShowDialog();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Neuspješna prijava licem");
                    Hide();
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Ups, nesto s dretvama je poslo u krivu");
                return;
            }
        }

        private void btnUkljuciKameru_new_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameraName_new.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbCamera_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCamera_new.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btnTakePicture_new_Click(object sender, EventArgs e)
        {
            if (!(videoCaptureDevice == null))
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop();
                    videoCaptureDevice = null;
                }
            }
        }

        private string PathCombine(string path1, string path2)
        {
            if (Path.IsPathRooted(path2))
            {
                path2 = path2.TrimStart(Path.DirectorySeparatorChar);
                path2 = path2.TrimStart(Path.AltDirectorySeparatorChar);
            }
            return Path.Combine(path1 + @"\", path2);
        }


        private void btnPic1_new_Click(object sender, EventArgs e)
        {
            Korisnik kor = cbAllUsers.SelectedItem as Korisnik;
            string path = "\\" + GetPath(cbAllUsers.Text);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace(@"\", @"\\");
            try
            {
                Bitmap bPic1 = new Bitmap(System.Drawing.Image.FromFile(PathCombine(desktop + "\\", path)));


                pbPic1_new.SizeMode = PictureBoxSizeMode.StretchImage;
                pbPic1_new.Image = bPic1;

                file1 = PathCombine(desktop + "\\", path);
            }
            catch
            {
                MessageBox.Show("Slika ovog korisnika ne nalazi se na ovom računalu!");
                return;
            };
        }

        private string GetPath(string value)
        {
            using (var context = new STONKS_DB())
            {
                var query = from e in context.Korisnici
                            where e.slika.Contains(value)
                            select e.slika;
                return query.FirstOrDefault();
            }
        }

        private void btnUkljuciKameru_new_Click_1(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameraName_new.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            btnTakePicture_new.Enabled = true;
        }

        private void btnSave_new_Click_1(object sender, EventArgs e)
        {
            pbSlikaZaSpremiti_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSlikaZaSpremiti_new.Image = pbCamera_new.Image;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = path;

            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.FileName = "captured_pic";
            saveFileDialog.DefaultExt = ".jpg";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbSlikaZaSpremiti_new.Image.Save(saveFileDialog.FileName);
                btnPic2_new.Enabled = true;
            }
        }

        private void btnTakePicture_new_Click_1(object sender, EventArgs e)
        {
            if (!(videoCaptureDevice == null))
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.SignalToStop();
                    videoCaptureDevice = null;
                }
                btnSave_new.Enabled = true;
            }
        }

        private void FrmFaceRecNewApproach_Load(object sender, EventArgs e)
        {
            btnPic2_new.Enabled = false;
            btnSave_new.Enabled = false;
            btnCompare_new.Enabled = false;
            btnTakePicture_new.Enabled = false;
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in filterInfoCollection)
                cbCameraName_new.Items.Add(filterinfo.Name);
            cbCameraName_new.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();

            cbAllUsers.DataSource = services.GetKorisnici();
        }
    }
}