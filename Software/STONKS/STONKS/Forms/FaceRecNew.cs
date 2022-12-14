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
using System.Drawing.Imaging;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using AForge.Video;
using AForge.Video.DirectShow;


namespace STONKS.Forms
{
    public partial class FaceRecNew : Form
    {

        string file1, file2 = "";
        public FaceRecNew()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice = null;


        private void btnPic2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bPic2 = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
                    pbPic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbPic2.Image = bPic2;
                    file2 = ofd.FileName;

                }
            }
        }

        private void pbPic1_Click(object sender, EventArgs e)
        {

        }

        private void btnCompare_Click(object sender, EventArgs e)
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

        private void FaceRecNew_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterinfo in filterInfoCollection)
                cbCameraName.Items.Add(filterinfo.Name);
            cbCameraName.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void btnUkljuciKameru_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameraName.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pbCamera.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void pbCamera_Click(object sender, EventArgs e)
        {

        }

        private void btnTakePicture_Click(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            pbSlikaZaSpremiti.SizeMode = PictureBoxSizeMode.StretchImage;

            pbSlikaZaSpremiti.Image = pbCamera.Image;
            //pbSlikaZaSpremiti.Image.Save(@"martin.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.FileName = "slikica";
            saveFileDialog.DefaultExt = ".jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbSlikaZaSpremiti.Image.Save(saveFileDialog.FileName);
            }
        }

        private void pbSlikaZaSpremiti_Click(object sender, EventArgs e)
        {

        }

        private void btnPic1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bpic1 = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
                    pbPic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbPic1.Image = bpic1;
                    file1 = ofd.FileName;
                }
            }

            /* using (var client = new WebClient())
             {
                 var imageBytes = client.DownloadData("https://img.freepik.com/free-photo/top-view-beautiful-roses-bouquet-with-pink-ribbon_23-2148822309.jpg?w=2000");
                 using (var stream = new MemoryStream(imageBytes))
                 {

                     using (var bitmap = new Bitmap(stream))
                     {

                         pbPic1.Image=bitmap;    
                     }
                 }
             }*/

            // pbPic1.Load("https://lh3.googleusercontent.com/LbTINGjYfcfXbkCEfDb1jf1yo3EfWiOPOuxzrL9tpdTzSerbKgEVthqJ8dewjvaZl77B68qy2KGST2yHkjaXyDNUZ8L7NO-yA1rkiXT8VGX1DtbgOIaiBFhX-9B1H2kAcmIeRrw__SCMWvvMKYYDn9WErZGkz1dCz8Nx0eRYnIK5vr4AIJqgj7XCRt2-dDC08QzckjNi2Emf4gxKszkp0LvVKGaJrF08tRIrVHji13FwGdt9fwhWYIdpBh1H_GtqoQGmtvXKxT4d6s-M8yR-FFa4jualyau5Rb64w0n9RkrP5jkKaZhxiWPduTN3HXccspe_qYlO3Q4MPcdOyz7f8o_HVcwjXCmXj-rJTvL77bULE8NUiLIBE3EIHpl8EJQTXzbNhZJHpE9qYbM0fcXs7MAO6oq8B1GGi9FsZ_suvxnej3oDP9mtEvF67x0UYvhmBmX2vQMy4k3EOsYF49z1I7rYZE4W-BXNbGajYpADqCq8niSJEVAoggp4J6ASBRdekQ0O0J8osu3LK69bCXzUsjSoZ6FdqOrzTl00KYi1sJnKnS-eReNokWasC_wLIKj60pn1U_PjPvsyYYIzO4h2XAilg_l_zohVrdGgrD0bJrXsv76WZ_4G6uvxsDOspGxpr5dC-b8QiU0ywd0O_z2pjvBfMuolk5mBdb2tsVZiLP-L76pWeqRnF7-HMNjK4RVFFzeBBog1Iqb38MdzSk_1lxeaClpBFkUdcswAt6BjKG8uEDpBqAjaoUP4X_7RZGSrKhBlnCGaXAD40JKIujc9Y-0-Y6c34zoK8IIotOPOsNFu6RQzzZEa8bW2lk-6ss0496HEaoX2JeuLih-QukKP8lpiRejPy_Sg_Y7zxP_No4FYGPdoutaSmUn9uszee8PzORrjGYWV7xFQSu4PPYg0nLeE8wVQUoHih4YbNbR94NBdXbl5wIMvi1KKLkefZzGbQ1VRdqq5FSAEserbjp-gfjPIIis0Un53qzNSVxYWOS3GKazrnvKOfTEv23Wi6qqAyBJq5hmIcv8PlEmMgVVYl6ETdWTf=w238-h220-no?authuser=3"); 
            //ova metoda ucitava sliku s linka
            //prijavljeniKorisnik.slika
        }


    }
}
