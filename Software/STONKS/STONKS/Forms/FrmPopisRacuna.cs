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
    public partial class FrmPopisRacuna : Form
    {
        public FrmPopisRacuna()
        {
            InitializeComponent();
        }

        private RacuniServices services = new RacuniServices();

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void FrmPopisRacuna_Load(object sender, EventArgs e)
        {
            PrikaziRacune();
        }

        private void PrikaziRacune()
        {
            // TODO makni iz baze column nacin_placanja i onda ovde iz koda negde da ne baca error na popisu racuna

            var racuni = services.GetRacuni();
            dgvRacuni.DataSource = racuni;
            dgvRacuni.Columns[11].Visible = false; // sakrivene stavke jer ce bit u drugom dgvu


        }
    }
}
