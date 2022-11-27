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

namespace STONKS
{
    public partial class Form1 : Form
    {
        private UlogeServices services = new UlogeServices();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Testni commit");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = services.GetUloge();
            dataGridView1.Columns[2].Visible = false;
        }
    }
}
