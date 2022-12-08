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
    public partial class FrmIzradaRacuna : Form
    {
        public FrmIzradaRacuna()
        {
            InitializeComponent();
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            Hide();
            frmUnosRacuna.ShowDialog();
            Close();
        }

        private void FrmIzradaRacuna_Load(object sender, EventArgs e)
        {
            var allNaciniPlacanja = new NaciniPlacanjaServices().GetNaciniPlacanja();
            cboOdabirNacinaPlacanja.DataSource = allNaciniPlacanja;
        }
    }
}
