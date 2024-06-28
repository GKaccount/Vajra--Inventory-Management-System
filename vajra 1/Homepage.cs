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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        main_master mm = new main_master();
        main_trans mt = new main_trans();

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


        private void homepanel_Paint(object sender, PaintEventArgs e)
        {
            this.KeyPreview = true;
        }

        public void Homepage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btnmaster.PerformClick();
            }

            if (e.KeyCode == Keys.F7)
            {
                btntransaction.PerformClick();
            }

            if (e.KeyCode == Keys.F10)
            {
                btnstock.PerformClick();
            }

            mm.main_master_KeyDown(this, e);
            mt.main_trans_KeyDown(this, e);
        }


        private void Homepage_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void btnstock_Click(object sender, EventArgs e)
        {

        }

        private void btnmaster_Click(object sender, EventArgs e)
        {
            if (mm.IsDisposed)
                mm = new main_master();

            openChildForm(mm);
        }

        private void btntransaction_Click(object sender, EventArgs e)
        {
            if (mt.IsDisposed)
                mt = new main_trans();

            openChildForm(mt);
        }

        private void menupanel_Paint(object sender, PaintEventArgs e)
        {
            this.KeyPreview = true;
        }

        private void masterbtnpanel_Paint(object sender, PaintEventArgs e)
        {
            this.KeyPreview = true;
        }

        private void homepanel_Paint_1(object sender, PaintEventArgs e)
        {
            this.KeyPreview = true;
        }

        private void btnmaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                btnmaster.PerformClick();
            }
        }

        private void btnclose1_Click(object sender, EventArgs e)
        {

        }
    }
}
