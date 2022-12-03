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
    public partial class FrmDodavanjeSlike : Form
    {
        public FrmDodavanjeSlike()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Hide();
            FrmPrepoznavanjeLica frmPrepoznavanjeLica = new FrmPrepoznavanjeLica();
            frmPrepoznavanjeLica.ShowDialog();
            Close();
        }
    }
}
