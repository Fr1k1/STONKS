using FaceRecognitionDotNet;
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
    public partial class FaceRecNew : Form
    {

        string file1, file2 = "";
        public FaceRecNew()
        {
            InitializeComponent();
        }

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
                MessageBox.Show(currentDirectory);
                FaceRecognition fr;
                fr = FaceRecognition.Create(currentDirectory);


                var dlibtoComBuf = FaceRecognition.LoadImageFile(file1); 

                var enToCompare = fr.FaceEncodings(dlibtoComBuf).First();

                var dlibtoCombuf2 = FaceRecognition.LoadImageFile(file2);
                var enToCompare2 = fr.FaceEncodings(dlibtoCombuf2).First();

                MessageBox.Show("Tu dojdem");

                MessageBox.Show(FaceRecognition.CompareFace(enToCompare, enToCompare2).ToString());
            }

            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);   
                MessageBox.Show("false");
            }
        }

        private void btnPic1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Multiselect=true})
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bpic1 = new Bitmap(System.Drawing.Image.FromFile(ofd.FileName));
                    pbPic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbPic1.Image = bpic1;
                    file1 = ofd.FileName;
                }
            }
        }
    }
}
