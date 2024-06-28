using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vajra_1
{
    public partial class main_master : Form
    {
        public main_master()
        {
            InitializeComponent();
        }

        private void main_master_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

       

        public void main_master_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnback.PerformClick();
            }

            if (e.KeyCode == Keys.F4)
            {
                btnstockitem.PerformClick();
            }

            if (e.KeyCode == Keys.F5)
            {
                btnsupledg.PerformClick();
            }

            if (e.KeyCode == Keys.F6)
            {
                btncstledg.PerformClick();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnstockitem_Click(object sender, EventArgs e)
        {

        }
    }
}
