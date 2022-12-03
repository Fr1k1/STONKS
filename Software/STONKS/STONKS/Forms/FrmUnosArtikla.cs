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
    public partial class FrmUnosArtikla : Form
    {
        public FrmUnosArtikla()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmUnosArtikla_Load(object sender, EventArgs e)
        {
            cbArticleType.Size = new Size(316, 120);
        }

        private void btnAddArtikl_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Hide();
            FrmPocetniIzbornik frmPocetniIzbornik = new FrmPocetniIzbornik();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }
    }
}
