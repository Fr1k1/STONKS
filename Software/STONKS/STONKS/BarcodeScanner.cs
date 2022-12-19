using STONKS.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace STONKS
{
    public class BarcodeScanner
    {
        public event EventHandler<String> Scanned;



        public void Scan(Image image)
        {

            BarcodeReader reader = new BarcodeReader();
            reader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.EAN_13 };
            reader.Options.TryHarder = true;

            // read the barcode from the camera


            Result result = reader.Decode((Bitmap)image);

            if (result != null)
            {
                // convert the barcode data to a number
                //long barcodeNumber = Convert.ToInt64(result.Text);

                // display the number in the text box
                Scanned?.Invoke(this, result.Text);
            }
            else
            {
                // display an error message if the barcode could not be read
                MessageBox.Show("Unable to read barcode.");
            }

        }
    }
}