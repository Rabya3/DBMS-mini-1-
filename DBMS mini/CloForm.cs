using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMS_mini
{
    public partial class CloForm : Form
    {
        public CloForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        string str = "Data Source=AIMEN-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "Insert INTO Clo(Name,DateCreated,DateUpdated) VALUES('" + textBox1.Text + "','" + dateTimePicker1.Value.Date + "','" + dateTimePicker2.Value.Date + "')";
            SqlCommand cmd3 = new SqlCommand(query, con);
            cmd3.ExecuteNonQuery();
            con.Close();
            display();
            MessageBox.Show("CLOS Added");
        }
       
        public void display()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(str))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clo", con);
                    DataTable tbl = new DataTable();
                    da.Fill(tbl);
                    dataGridView1.DataSource = tbl;

                }

            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error occurred");
            }// TODO: This line of code loads data into the 'projectBDataSet.Student' table. 
            

        }

        int Id = 0;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
  


            //Clearing the textboxes

            textBox1.Text = "";
         
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void CloForm_Load(object sender, EventArgs e)
        {
            display();// TODO: This line of code loads data into the 'projectBDataSet.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet.Clo);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try

            {
                string query = "Update Clo set Name='" + textBox1.Text + "' , DateUpdated='" + (DateTime.Now).Date + "'where ID=@id ";
                    con.Open();
                    SqlCommand cmd6 = new SqlCommand(query, con);
                    cmd6.Parameters.AddWithValue("@id", Id);
                    cmd6.ExecuteNonQuery();
                    MessageBox.Show("Updated ");
                    con.Close();
                    textBox1.Text = "";
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Windows.Forms.MessageBox.Show(sqlException.Message);
                MessageBox.Show("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Clo where Id =" + dataGridView1.Rows[Id].Cells[0].Value;

            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.Rows.RemoveAt(Id);
            MessageBox.Show("Deleted");
            display();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rubric r = new Rubric(Id);
            r.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashboardSystem s = new DashboardSystem();
            s.Show();
            this.Hide();
        }
    }
}
