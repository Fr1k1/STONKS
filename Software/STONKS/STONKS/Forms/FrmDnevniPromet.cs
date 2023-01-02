using BusinessLayer.Services;
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
    public partial class FrmDnevniPromet : Form
    {   
        PrometServices prometServices = new PrometServices();

        private double UkupanPromet;
        private double UkupnoKartice;
        private double UkupnoGotovina;
        private double PopustKartice;
        private double PopustGotovina;
        private double Kartice;
        private double Gotovina;

        public FrmDnevniPromet()
        {
            InitializeComponent();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {   
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UkupnoGotovina = prometServices.CalculateCash(dtpDate.Value);
            UkupnoKartice = prometServices.CalculateCard(dtpDate.Value);

            PopustKartice = prometServices.CalculateCardDiscount(dtpDate.Value);
            PopustGotovina = prometServices.CalculateCashDiscount(dtpDate.Value);

            Kartice = UkupnoKartice + PopustKartice;
            Gotovina = UkupnoGotovina + PopustGotovina;
            UkupanPromet = UkupnoKartice + UkupnoGotovina;

            txtUkupnoKartice.Text = UkupnoKartice + " EUR";
            txtUkupnoGotovina.Text = UkupnoGotovina + " EUR";
            txtgotovinaPopust.Text = PopustGotovina + " EUR";
            txtPopustkartice.Text = PopustKartice + " EUR";
            txtUkupniPromet.Text = UkupanPromet + " EUR";
            txtGotovina.Text = Gotovina + " EUR";
            txtKartice.Text = Kartice + " EUR";
 
        }

    }
}
