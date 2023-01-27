using BusinessLayer.Services;
using EntitiesLayer.Entities;
using System;
using System.Windows.Forms;

namespace STONKS.Forms
{
    public partial class FrmUnosDobavljaca : Form
    {   
        /// <summary>
        /// This form is responsible for entering new supplier/dobavljac into data base, it has validation for correct input
        /// Author: Filip Milohanović
        /// </summary>
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
        //when user click button to add supplier, input is validated and data is inserted if valid, user is always notified
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
        //inserts supplier into db if it dosent exsist already
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
        //checks if all required data is inserted and checks format of OIB
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
        //sets help file path on form load
        private void FrmUnosDobavljaca_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = System.Windows.Forms.Application.StartupPath + "\\UserManual.chm";
        }
    }
}
