using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace vajra_1
{
    public partial class salesentry : Form
    {
        public salesentry()
        {
            InitializeComponent();
            dgvsalesLoadData();
            dgvsearchitemLoadData();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Vajra1.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public void dgvsalesLoadData()
        {
            dgvsales.DataSource = null;
            
            dgvsales.AutoGenerateColumns = false;
            
            dgvsales.ColumnCount = 5;

            int i = 0;

            dgvsales.Rows.Clear();             

            cmd = new SqlCommand("SELECT * FROM SALESENTRY", con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dgvsales.Rows.Add(i, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void dgvsearchitemLoadData()
        {
            /*string sq = "SELECT DESCRIPTION, ITEMTYPE FROM STOCKITEM";
            con.Open();
            SqlCommand scm = new SqlCommand(sq, con);
            SqlDataAdapter sdr = new SqlDataAdapter(scm);
           
            sdr.Fill(dt);
            dgvsearchitem.DataSource = dt;
            con.Close();*/
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM STOCKITEM", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                dgvsearchitem.AutoGenerateColumns = false;
                dgvsearchitem.ColumnCount = 2;
                dgvsearchitem.Columns[0].HeaderText = "Description";
                dgvsearchitem.Columns[0].DataPropertyName = "DESCRIPTION";
                dgvsearchitem.Columns[1].HeaderText = "Item Type";
                dgvsearchitem.Columns[1].DataPropertyName = "ITEMTYPE";
                dgvsearchitem.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            /*while (dr.Read())
            {
                i++;
                dgvsearchitem.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();*/


        }


        private void dgvsales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvsearchitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvsearchitem.Rows[e.RowIndex];

                // txtDescription.Text = row.Cells["Description"].Value.ToString();
                //txtItemType.Text = row.Cells["Item Type"].Value.ToString();

                txtDescription.Text = dgvsearchitem.SelectedRows[0].Cells[0].Value.ToString();
                txtItemType.Text = dgvsearchitem.SelectedRows[0].Cells[1].Value.ToString();
            }*/
        }

        /*private void dgvsearchitem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvsearchitem.Rows[e.RowIndex];

                // txtDescription.Text = row.Cells["Description"].Value.ToString();
                //txtItemType.Text = row.Cells["Item Type"].Value.ToString();

                txtDescription.Text = dgvsearchitem.SelectedRows[0].Cells[0].Value.ToString();
                txtItemType.Text = dgvsearchitem.SelectedRows[0].Cells[1].Value.ToString();
            }
        }*/

        public void salesentry_KeyDown(object sender, KeyEventArgs e)
        {



            if (e.KeyCode == Keys.Escape)
            {

                this.Dispose();
            }

        }

        private void salesentry_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void dgvsearchitem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                DataGridViewRow row = this.dgvsearchitem.Rows[e.RowIndex];

                txtDescription.Text = dgvsearchitem.SelectedRows[0].Cells[0].Value.ToString();
                
                
              
                    cmd = new SqlCommand("Select * FROM  STOCKITEM  WHERE DESCRIPTION = @desc ", con);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtrate.Text = (dr["MRP"].ToString());


                    }

                    dr.Close();
                    con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtdesc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM STOCKITEM WHERE DESCRIPTION LIKE '" + txtdesc.Text + "%'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                dgvsearchitem.AutoGenerateColumns = false;
                dgvsearchitem.Columns[0].HeaderText = "Description";
                dgvsearchitem.Columns[0].DataPropertyName = "DESCRIPTION";
                dgvsearchitem.Columns[1].HeaderText = "Item Type";
                dgvsearchitem.Columns[1].DataPropertyName = "ITEMTYPE";
                dgvsearchitem.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnanewcst_Click(object sender, EventArgs e)
        {

        }

        private void btnaddrow_Click(object sender, EventArgs e)
        {

            
            try
            {

                int amt = int.Parse(txtrate.Text) * int.Parse(txtqty.Text);

                cmd = new SqlCommand("INSERT INTO SALESENTRY (DESCRIPTION, QTY, RATE, AMOUNT) VALUES(@desc,@qty,@rate,@amount)", con);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@qty", txtqty.Text);
                cmd.Parameters.AddWithValue("@rate", txtrate.Text);
                cmd.Parameters.AddWithValue("@amount", amt);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
                con.Close();
                dgvsalesLoadData();
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvsales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvsales.Rows[e.RowIndex];

                /*txtDescription.Text = row.Cells["Description"].Value.ToString();
                txtItemType.Text = row.Cells["Item Type"].Value.ToString();
                txtqty.Text = row.Cells["Qty."].Value.ToString();*/

                txtDescription.Text = dgvsales.SelectedRows[0].Cells[1].Value.ToString();
                txtqty.Text = dgvsales.SelectedRows[0].Cells[2].Value.ToString();
                txtrate.Text = dgvsales.SelectedRows[0].Cells[3].Value.ToString();

            }
        }

        public void clearData()
        {
            txtDescription.Clear();
            txtqty.Clear();
            txtrate.Clear();
        }

        private void btndeleterow_Click(object sender, EventArgs e)
        {


            try
            {

                int amt = int.Parse(txtrate.Text) * int.Parse(txtqty.Text);
                con.Open();
                cmd = new SqlCommand("DELETE FROM SALESENTRY WHERE DESCRIPTION = @desc and QTY = @qty and RATE = @rate and AMOUNT = @amount" , con);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@qty", txtqty.Text);
                cmd.Parameters.AddWithValue("@rate", txtrate.Text);
                cmd.Parameters.AddWithValue("@amount", amt);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                cmd.ExecuteNonQuery();
                con.Close();
                dgvsalesLoadData();
                clearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdaterow_Click(object sender, EventArgs e)
        {
            try
            {

                int amt = int.Parse(txtrate.Text) * int.Parse(txtqty.Text);
                con.Open();
                cmd = new SqlCommand("UPDATE SALESENTRY SET DESCRIPTION = @desc, QTY = @qty, RATE = @rate, AMOUNT = @amount WHERE DESCRIPTION = @desc", con);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@qty", txtqty.Text);
                cmd.Parameters.AddWithValue("@rate", txtrate.Text);
                cmd.Parameters.AddWithValue("@amount", amt);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                cmd.ExecuteNonQuery();
                con.Close();
                dgvsalesLoadData();
                clearData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
