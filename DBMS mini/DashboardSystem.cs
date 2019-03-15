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
    public partial class DashboardSystem : Form
    {
        public DashboardSystem()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=AIMEN-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentPortal s = new StudentPortal();
            s.Show();
            this.Hide();
        }

        private void DashboardSystem_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloForm s = new CloForm();
            s.Show();
            this.Hide();
        }
        int Id = 0;
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Rubric s = new Rubric(Id);
            s.Show();
            this.Hide();
        }
    }
}
