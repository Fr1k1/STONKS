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
           txtUkupniPromet.Text = prometServices.CalculateTotal(dtpDate.Value).ToString() + " EUR";
        }

        


    }
}
