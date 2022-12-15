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
    public partial class FrmFaceRecNewApproach : Form
    {
        private KorisniciServices services = new KorisniciServices();

        string file1, file2 = "";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace(@"\", @"\\");


        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice = null;
        public FrmFaceRecNewApproach()
        {
            InitializeComponent();
        }

        private void btnPic2_new_Click(object sender, EventArgs e)
        {
            Bitmap bPic2 = new Bitmap(System.Drawing.Image.FromFile(path + "\\slikica.jpg"));
            pbPic2_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPic2_new.Image = bPic2;
            // file2 = "C:\\Users\\KORISNIK\\Desktop\\faces\\slikica.jpg";
            file2 = path + "\\slikica.jpg";
        }

        private void btnCompare_new_Click(object sender, EventArgs e)
        {
            try
            {
                string currentDirectory = Environment.CurrentDirectory + "\\models";

                FaceRecognition fr;
                fr = FaceRecognition.Create(currentDirectory);


                var dlibtoComBuf = FaceRecognition.LoadImageFile(file1);

                var enToCompare = fr.FaceEncodings(dlibtoComBuf).First();

                var dlibtoCombuf2 = FaceRecognition.LoadImageFile(file2);
                var enToCompare2 = fr.FaceEncodings(dlibtoCombuf2).First();



                MessageBox.Show(FaceRecognition.CompareFace(enToCompare, enToCompare2).ToString());
            }

            catch
            {

                MessageBox.Show("false");
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

            return Path.Combine(path1+@"\", path2);
        }

        private void btnSave_new_Click(object sender, EventArgs e)
        {
            pbSlikaZaSpremiti_new.SizeMode = PictureBoxSizeMode.StretchImage;

            pbSlikaZaSpremiti_new.Image = pbCamera_new.Image;
            pbSlikaZaSpremiti_new.Image.Save(@"martin.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.FileName = "slikica";
            saveFileDialog.DefaultExt = ".jpg";

            /*if (System.IO.File.Exists(saveFileDialog.FileName))
            {
                System.IO.File.Delete(saveFileDialog.FileName);
            mozda ima neki bolji nacin za save
                
            }*/
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                /* string putanja = "C:\\Slike\\slika.jpg";
                 if(!Directory.Exists(putanja))
                     Directory.CreateDirectory(putanja);
                 */

                pbSlikaZaSpremiti_new.Image.Save(saveFileDialog.FileName);
                //pbSlikaZaSpremiti.Image.Dispose();
            }
        }

        private void btnPic1_new_Click(object sender, EventArgs e)
        {

            Korisnik kor = cbAllUsers.SelectedItem as Korisnik;

            string path = "\\"+GetPath(cbAllUsers.Text);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).Replace(@"\", @"\\");



            //Bitmap bPic1 = new Bitmap(System.Drawing.Image.FromFile(path + "\\preloaded_faces\\" + kor.korime + ".jpg"));
            MessageBox.Show(GetPath(cbAllUsers.Text));

            MessageBox.Show("Putanja koja ne dela je"+ PathCombine(desktop, path));
            Bitmap bPic1 = new Bitmap(System.Drawing.Image.FromFile(PathCombine(desktop+"\\",path))); //slozi ovo s putanjama nezz kaje krivo
            //Bitmap bPic1 = new Bitmap(System.Drawing.Image.FromFile(desktop+path)); //slozi ovo s putanjama nezz kaje krivo
            
            pbPic1_new.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPic1_new.Image = bPic1;
            //file1 = path + "\\preloaded_faces\\"+ kor.korime + ".jpg";
           // MessageBox.Show(services.GetSlika(kor.korime));
            //file1 = services.GetSlika(kor.korime).ToString();
            //file1 = GetPath(kor.korime).ToString(); ovo dela
            file1 = PathCombine(desktop + "\\", path);

            MessageBox.Show("File 1 je"+file1);


           
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



        private void FrmFaceRecNewApproach_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in filterInfoCollection)
                cbCameraName_new.Items.Add(filterinfo.Name);
            cbCameraName_new.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();

            cbAllUsers.DataSource=services.GetKorisnici();

            
        }
    }
}
