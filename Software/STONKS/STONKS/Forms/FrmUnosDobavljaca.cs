using BusinessLayer.Services;
using EntitiesLayer.Entities;
using System;
using System.Windows.Forms;

namespace STONKS.Forms
{
    public partial class FrmUnosDobavljaca : Form
    {
        private DobavljaciServices dobavljaciServices = new DobavljaciServices();
        public FrmUnosDobavljaca()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();
            Close();
        }

        private void btnAddDobavljac_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                var dobavljac = new Dobavljac(txtName.Text,txtOIB.Text,txtAdress.Text);
                dobavljaciServices.AddDobavljac(dobavljac);
                MessageBox.Show("Uspiješan unos", "Dobavljac unesen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Unesite ispravne podatke,OIB mora imati 11 znakova", "Neispravan unos", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private bool ValidateInput()
        {
            if (txtName.Text != "" && txtAdress.Text != "" &&  txtOIB.Text.Length == 11)
            {
                string oib = txtOIB.Text;
                for(int i = 0; i < oib.Length; i++)
                {
                    if (Char.IsLetter(oib[i]))
                        return false;
                }
                return true;
              
            }
            else
                return false;
        }
    }
}
