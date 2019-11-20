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

namespace CLINEC
{
    public partial class Departments : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=clinec;Integrated Security=True");
        public Departments()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_salary.Clear();
            txt_searche.Clear();
            txt_delete.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("insert into Department values('" + (txt_id.Text) + "','" + txt_name.Text + "','" + txt_salary.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            show();
            MessageBox.Show("Saved Data Successed");
        }
        public void show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from Department ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Department where id_dep='" + txt_searche.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Department where id_dep='" + txt_delete.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            show();
        
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}
