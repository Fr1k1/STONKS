using BusinessLayer.Services;
using EntitiesLayer.Entities;
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
    public partial class FrmOdaberiArtiklZaDodatiRucno : Form
    {
        public FrmOdaberiArtiklZaDodatiRucno()
        {
            InitializeComponent();
        }

        private ArtikliServices servicesArtikl = new ArtikliServices();
      
        private void FrmOdaberiArtiklZaDodatiRucno_Load(object sender, EventArgs e)
        {
            PrikaziArtikle();
        }

        private void PrikaziArtikle()
        {
            var artikli = servicesArtikl.GetArtikli();
            dgvPopisArtikala.DataSource = artikli;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Zatvori();
        }

        private void txtPretrazi_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtPretrazi.Text;
            // Martin TODO
        }

        private void btnDodajArtikl_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvPopisArtikala.CurrentRow;
            
            if (selectedRow != null)
            {
                var selectedArtikl = selectedRow.DataBoundItem as Artikl;
                MessageBox.Show("odabran je " + selectedArtikl.naziv);
                // dodaj taj artikl u listu stavaka u racunu  

                // zatvori formu
                Zatvori();
            }
            else
            { // TODO 
                MessageBox.Show("Nije odabran artikl!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Zatvori()
        {
            FrmUnosRacuna frmUnosRacuna = new FrmUnosRacuna();
            Hide();
            frmUnosRacuna.ShowDialog();
            Close();
        }

    }
}
