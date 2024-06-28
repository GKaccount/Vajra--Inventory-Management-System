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
    public partial class main_trans : Form
    {
        public main_trans()
        {
            InitializeComponent();
        }

        salesentry se = new salesentry();

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            /*if (activeForm != null)
                activeForm.Close();*/
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            homepanel.Controls.Add(childForm);
            homepanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void main_trans_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F8)
            {

                btnsalesentry.PerformClick();

            }

            if (e.KeyCode == Keys.Escape)
            {
                
                btnclose1.PerformClick();
                
            }
            se.salesentry_KeyDown(this, e);
        }

        private void main_trans_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void btnsalesentry_Click(object sender, EventArgs e)
        {
            if (se.IsDisposed)
                se = new salesentry();
            openChildForm(se);

        }

        private void btnclose1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
} 
