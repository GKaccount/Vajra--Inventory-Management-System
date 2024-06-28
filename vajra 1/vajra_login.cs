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
    public partial class vajra_login : Form
    {
        public vajra_login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Vajra1.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        private void main_create_company_Click(object sender, EventArgs e)
        {
            crcomp c = new crcomp();
            c.Show();
        }

        private void vajra_login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void vajra_login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                main_create_company.PerformClick();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void main_login_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM CREATE_COMPANY WHERE CMPLOGIN=@user AND CMPPASS=@pass", con);
                cmd.Parameters.AddWithValue("@user", txtloginid.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                    
                    vajra_Mainpage mp = new vajra_Mainpage();
                    mp.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Login Id or Password");
                }

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();

            }
        }
    }
}
