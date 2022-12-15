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
using System.Security.Cryptography;
using EntitiesLayer.Entities;


namespace STONKS.Forms
{
    public partial class FaceRecNew : Form
    {

        string file1, file2 = "";
        string path=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public FaceRecNew()
        {
            InitializeComponent();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice = null;


        private void btnPic2_Click(object sender, EventArgs e)
        {
            /*using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bPic2 = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
                    pbPic2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbPic2.Image = bPic2;
                    file2 = "slikica.jpg";

                }
            }*/

            Bitmap bPic2 = new Bitmap(System.Drawing.Image.FromFile(path + "\\slikica.jpg"));
            pbPic2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPic2.Image = bPic2;
           // file2 = "C:\\Users\\KORISNIK\\Desktop\\faces\\slikica.jpg";
            file2 = path+"\\slikica.jpg";
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
            pbSlikaZaSpremiti.Image.Save(@"martin.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.FileName = "slikica";
            saveFileDialog.DefaultExt = ".jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                /* string putanja = "C:\\Slike\\slika.jpg";
                 if(!Directory.Exists(putanja))
                     Directory.CreateDirectory(putanja);
                 */
                pbSlikaZaSpremiti.Image.Save(saveFileDialog.FileName);
            }
        }

        private void pbSlikaZaSpremiti_Click(object sender, EventArgs e)
        {

        }

        private void pbPic2_Click(object sender, EventArgs e)
        {

        }

        private void btnPic1_Click(object sender, EventArgs e)
        {

            using(WebClient client=new WebClient())
            {
                //client.DownloadFile(new Uri("https://lh3.googleusercontent.com/pUfFGXRLeKcvdtxAgj0GoRRLjg57t_Zf7Y8Z7cf9ySdmLGoM5z8OKzaLF-yxGxDrMt3tQ5Gf9bSzbPnhIwqbNoGpXMrAcUGAxaqMAByorXKoE5-ARoEEiHyoYBLREIhRt-3daT8o_kk6x1wQ3DN3NjVYoX2mG9gPBcL_QA4WOdE0ewNtt44rHEAxzCt6JD9O6z5s_EPhhFzawENSlHFrJFAenRg8yiki6SmB_c3gynafDbe5WV81SHfTK_BZTKjHGXMHjCgAKjyM-CTQdpjvz02azLo_J3PZIBe1Q1xV5xsAfOrGHzhYzfoOi0tabMu9f2lRDtz4sdwn3WLoKcHP0tGzeK0fiIUKVK4VGEhCSVDlyCOHuGIHXzyWrtR4133PqNeMSWURS33RvUCqKCcWhd773voIi2rNiLGylk5ZeXAhziWg_n_YtP-bzdDhPSm9kZvn16EW8sFLIXT3WsC_g3O_7WcKKgpqdabIlrPL6LVpPfgfyt9Q1rs6W-rWIty6i3RuohsgPjSF17CKjKsH9tk-GF4i0sigClnCG4QaYNYIKadIv4sRqODHLrHmJbw5Hhg6PFMBXWlVBDVlwOvG3pMyxMQ1MT5q4lHg3C_B-Xsq89wWx9qpyaLFN0MweT-M-gpucmTp7Q-D0IZ66FxEe5pjTQJ8QVORbNLhsrxCmBVhWxg952wIWmOLc85Noj5n6KtRlehGTvHQZKGpkVqdb8EgOKcbuaSJn3afpUzNtmWPNY4DOi4Kwgx2W63myAvQPnvLuZkK2sFpvKOm-8wJqIY-u46LJUTwvnabct9u2oZDElgRz8wKmt6_8VYWV-DP2gfYLDB1WkIMQ6Hb4c2py0D-qBSEYRTVcSMaoWSCriU5YlKVerTSBgOKTJfGs2w68D065-AlxeksSDeARqc5gWoISPFLl41ZvWmXEo2JZ_r2T2TfZP98ge9tt1P0ZVheLrJMBh5T7m-jzJ2oYiVgAEJcBRjEW-eGfFlf-5NXp-qtSgnEkrrjzXyMODk11x_4_jEcnQC94dbIHalLbUAfdUtnfGA0eg=w386-h357-no?authuser=0"), @"C:\Users\KORISNIK\Desktop\skinuta.jpg");
            }

            Bitmap bPic1 = new Bitmap(System.Drawing.Image.FromFile(path+ "\\preloaded_faces\\slikica.jpg"));
            pbPic1.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPic1.Image = bPic1;
            file1 = path + "\\preloaded_faces\\slikica.jpg";


            /* using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true })
             {
                 if (ofd.ShowDialog() == DialogResult.OK)
                 {
                     Bitmap bpic1 = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
                     pbPic1.SizeMode = PictureBoxSizeMode.StretchImage;
                     pbPic1.Image = bpic1;
                     file1 = ofd.FileName;
                 }
             }*/

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
