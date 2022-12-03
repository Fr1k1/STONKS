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
    public partial class FrmPrepoznavanjeLica : Form
    {
        public FrmPrepoznavanjeLica()
        {
            InitializeComponent();
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            FrmDodavanjeSlike frmDodavanjeSlike=new FrmDodavanjeSlike();
            Hide();
            frmDodavanjeSlike.ShowDialog();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();

            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Hide();

            FrmPocetniIzbornikVoditelj frmPocetniIzbornik = new FrmPocetniIzbornikVoditelj();
            frmPocetniIzbornik.ShowDialog();

            Close();
        }
    }
}
