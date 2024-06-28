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
    public partial class crcomp : Form
    {
        public crcomp()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Vajra1.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }
        private void crcomp_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void crcomp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if(txtcompadr.Text=="" && txtcompadr.Text=="" && txtcompadr1.Text=="" && combdist.Text=="" && txtpincode.Text=="" && txtphoneno.Text==""&& txtmobileno.Text=="" && txtloginid.Text=="" && txtpassword.Text=="")
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO CREATE_COMPANY (CMPNAME,CMPADRL1,CMPADRL2,CMPDIST,CMPPIN,CMPPHONE,CMPMOBILE,CMPLOGIN,CMPPASS) VALUES(@cname,@cad1,@cad2,@cdist,@cpin,@cpn,@cmn,@clid,@cp)", con);
                    cmd.Parameters.AddWithValue("@cname", txtcompname.Text);
                    cmd.Parameters.AddWithValue("@cad1", txtcompadr.Text);
                    cmd.Parameters.AddWithValue("@cad2", txtcompadr1.Text);
                    cmd.Parameters.AddWithValue("@cdist", combdist.Text);
                    cmd.Parameters.AddWithValue("@cpin", txtpincode.Text);
                    cmd.Parameters.AddWithValue("@cpn", txtphoneno.Text);
                    cmd.Parameters.AddWithValue("@cmn", txtmobileno.Text);
                    cmd.Parameters.AddWithValue("@clid", txtloginid.Text);
                    cmd.Parameters.AddWithValue("@cp", txtpassword.Text);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Company Created Successfully");
                    clear();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            
        }

        public void clear()
        {
            txtcompname.Clear();
            txtcompadr.Clear();
            txtcompadr1.Clear();
            combdist.Text = "";
            txtpincode.Clear();
            txtphoneno.Clear();
            txtmobileno.Clear();
            txtloginid.Clear();
            txtpassword.Clear();
        }
    }
}
