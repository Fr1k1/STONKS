using AForge.Video;
using AForge.Video.DirectShow;
using BusinessLayer.Services;
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

        //Author : Martin Friščić (all code)


        //stores the logged user in static variable so it can be accessed in other files
        public static Korisnik logiraniKorisnik = null;

      
        //checks the role of the user
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

        //path to desktop for any user because desktop is used to store captured image
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace(@"\", @"\\");
         
        //for camera
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice = null;

        //if the directory preloaded_faces doesn't exist on user desktop than it creates it so pictures can be stored
        public FrmPrepoznavanjeLica()
        {
            string folderName = "preloaded_faces";
            string newFolder = Path.Combine(path, folderName);

            if(!Directory.Exists(newFolder))
            {
                Directory.CreateDirectory(newFolder);
            }
            InitializeComponent();
        }


        //makes the bitmap needed for facial recognition from file captured_pic on desktop
        private void btnPic2_new_Click(object sender, EventArgs e)
        {
            Bitmap bPic2 = new Bitmap(System.Drawing.Image.FromFile(path + "\\captured_pic.jpg"));
            pbPic2_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPic2_new.Image = bPic2;

            file2 = path + "\\captured_pic.jpg";
            //if both pictures are loaded
            if (pbPic1_new.Image != null && pbPic2_new.Image != null)
            {
                btnCompare_new.Enabled = true;
            }
        }

        private void btnCompare_new_Click(object sender, EventArgs e)
        {
            try
            {
                //first it has to load the models that are crucial for comparison and recognition
                string currentDirectory = Environment.CurrentDirectory + "\\models";
                FaceRecognition fr;
                fr = FaceRecognition.Create(currentDirectory);

                var pic1 = FaceRecognition.LoadImageFile(file1);
                var compare1 = fr.FaceEncodings(pic1).First();
                var pic2 = FaceRecognition.LoadImageFile(file2);
                var compare2 = fr.FaceEncodings(pic2).First();

                //compares pictures and if it is a success than it stores the user in variable
                //and chooses which form to load based on role

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
                    //in case that face recognition fails it opens a login form with username and pass authentification
                    MessageBox.Show("Neuspješna prijava licem");
                    Hide();
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                    Close();
                }
            }
            catch
            {
                //for any other exception throws an error and opens a login form with username and pass authentification
                MessageBox.Show("Ups, nesto s dretvama je poslo u krivu");
                Hide();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.ShowDialog();
                Close();
                return;
            }
        }


        //turns the camera on
        //capture device is equal to selected camera in dropdown
        private void btnUkljuciKameru_new_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameraName_new.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame; //subsription
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbCamera_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCamera_new.Image = (Bitmap)eventArgs.Frame.Clone();
        }


        //checks if the camera is on and if it is it stops the camera so I can get picture
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

        //loads the picture from folder preloaded_faces on desktop by using the info from database
        //I tried many attempts to do this with database primarily but it has many problems
        //with type conversion, waiting for picture to download etc.
        private void btnPic1_new_Click(object sender, EventArgs e)
        {
            Korisnik kor = cbAllUsers.SelectedItem as Korisnik;
            string path = "\\" + services.GetPicturePath(cbAllUsers.Text);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace(@"\", @"\\");
            try
            {
                Bitmap bPic1 = new Bitmap(System.Drawing.Image.FromFile(PathCombine(desktop + "\\", path)));

                //stretches the image and it makes picture dataSource bPic1 (bitmap from picture)
                pbPic1_new.SizeMode = PictureBoxSizeMode.StretchImage;
                pbPic1_new.Image = bPic1;

                file1 = PathCombine(desktop + "\\", path);
            }
            catch
            {
                //if the picture isn't present on the PC, than write a message
                MessageBox.Show("Slika ovog korisnika ne nalazi se na ovom računalu!");
                FrmLogin frmLogin = new FrmLogin();
                Hide();
                frmLogin.ShowDialog();
                Close();
                //return;
            };
        }

       /* private string GetPath(string value)
        {
            using (var context = new STONKS_DB())
            {
                var query = from e in context.Korisnici
                            where e.slika.Contains(value)
                            select e.slika;
                return query.FirstOrDefault();
            }
        }*/



        private void btnUkljuciKameru_new_Click_1(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameraName_new.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            btnTakePicture_new.Enabled = true;
        }


        //saves the image captured_pic with saveDialog
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


        //takes the picture
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



        //show context based help when pressing F1 key
        private void FrmPrepoznavanjeLica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "prijava_pomocu_lica.html");
            }
        }

        //on load some buttons are disabled for better User interface so users should know what to do

        private void FrmFaceRecNewApproach_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "\\UserManual.chm";
            btnPic2_new.Enabled = false;
            btnSave_new.Enabled = false;
            btnCompare_new.Enabled = false;
            btnTakePicture_new.Enabled = false;
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in filterInfoCollection)
                cbCameraName_new.Items.Add(filterinfo.Name);
            cbCameraName_new.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
            //fills the combo box with usernames of users
            cbAllUsers.DataSource = services.GetKorisnici();
        }
    }
}