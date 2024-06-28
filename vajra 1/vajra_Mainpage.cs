using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace vajra_1
{
    public partial class vajra_Mainpage : Form
    {

        
          

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Vajra1.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public vajra_Mainpage()
        {

            InitializeComponent();            
            btnHome_Click(this, null);
            //gunaLabel11.Text = "Manka Hardware";

            try
            {
                int pass = 1234;
                cmd = new SqlCommand("Select * FROM  CREATE_COMPANY  WHERE CMPPASS = @id ", con);
                cmd.Parameters.AddWithValue("id", pass);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    gunaLabel11.Text = dr["CMPNAME"].ToString();
                    lbladrl1.Text = dr["CMPADRL1"].ToString();
                    lbladrl2.Text = dr["CMPADRL2"].ToString()+", "+dr["CMPDIST"].ToString()+", "+"Maharashtra. (M) "+dr["CMPMOBILE"];
                }
               
                dr.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        Homepage hp = new Homepage();

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
           
                /*if (activeForm != null)
                    activeForm.Close();*/
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelMain.Controls.Add(childForm);
                panelMain.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            
            
        }

        private void myBtnSet(object sender, EventArgs e)
        {
            foreach(Control c in HeaderPanel.Controls)
            {
                c.BackColor = Color.FromArgb(3, 84, 73);
                c.ForeColor = Color.White;
            }

            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(22, 128, 123);
            click.ForeColor = Color.White;
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void gunaLabel11_Click(object sender, EventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vajra_Mainpage_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        /* private void btnHome_Click(object sender, EventArgs e)
         {

         }

         private void btnBillbook_Click(object sender, EventArgs e)
         {

         }

         private void btnHelp_Click(object sender, EventArgs e)
         {

         }
        */

        

        

        private void vajra_Mainpage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnHome.PerformClick();
            }

            if (e.KeyCode == Keys.F2)
            {
                btnBillbook.PerformClick();
            }

            if (e.KeyCode == Keys.F11)
            {
                btnLogout.PerformClick();
            }

            /*if (e.KeyCode == Keys.M)
            {
                hp.btnmaster.PerformClick();
            }

            if (e.KeyCode == Keys.T)
            {
                hp.btntransaction.PerformClick();
            }

            if (e.KeyCode == Keys.S)
            {
                hp.btnstock.PerformClick();
            }*/

            hp.Homepage_KeyDown(this,e);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(hp);
            myBtnSet(btnHome, null);

            

        }

        private void btnBillbook_Click(object sender, EventArgs e)
        {
            openChildForm(new vajra_BillBook());
            myBtnSet(btnBillbook, null);
            
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            openChildForm(new vajra_Helppage());
            myBtnSet(btnHelp, null);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*private void vajra_Mainpage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.H)
            {
                btnHome.PerformClick();
            }

            if (e.KeyCode == Keys.B)
            {
                btnBillbook.PerformClick();
            }

            if (e.KeyCode == Keys.F9)
            {
                btnHelp.PerformClick();
            }
        }*/
    }
}
