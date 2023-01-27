using System;
using System.Collections.Generic;
using System.Drawing;
using ZXing;

namespace BarcodeScanner
{
    //Author : Filip Milohanović
    public class Scanner
    {
        public event EventHandler<String> Scanned;// event that is trrigered when scann is succesfull

        public void Scan(Image image)
        {

            BarcodeReader reader = new BarcodeReader();
            reader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.CODE_128 };
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


        }
    }
}
