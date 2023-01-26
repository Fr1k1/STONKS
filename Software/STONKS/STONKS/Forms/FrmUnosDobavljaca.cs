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
                InsertDobavljac();
            } 
            else
            {
                MessageBox.Show("Unesite ispravne podatke,OIB mora imati 11 znakova!!!", "Neispravan unos", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void InsertDobavljac()
        {
            if(dobavljaciServices.AlreadyExists(txtOIB.Text,txtName.Text))
                MessageBox.Show("Dobavljac sa tim podacima već postoji!!!", "Neuspiješan unos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var dobavljac = new Dobavljac(txtName.Text, txtOIB.Text, txtAdress.Text);
                dobavljaciServices.AddDobavljac(dobavljac);
                MessageBox.Show("Dobavljac unesen!!!", "Uspiješan unos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        //show context based help when pressing F1 key
        private void FrmUnosDobavljaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, HelpNavigator.Topic, "unosDobavljaca.htm");
            }
        }
    }
}
