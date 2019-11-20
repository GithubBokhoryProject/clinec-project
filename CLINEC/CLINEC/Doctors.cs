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
    public partial class Doctors : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=clinec;Integrated Security=True");
        public Doctors()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_phone.Clear();
            txt_address.Clear();
            txt_dep_id.Clear();
            txt_searche.Clear();
            txt_delet.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd=new SqlCommand("insert into Doctors values('"+(txt_id.Text)+"','"+txt_name.Text+"','"+txt_phone.Text+"','"+txt_address.Text+"','"+int.Parse(txt_dep_id.Text)+"')",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            show();
            MessageBox.Show("Saved Data Successed");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctors where id_doc='" + txt_searche.Text+"'",con);
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
            SqlCommand cmd = new SqlCommand("delete from Doctors where id_doc='" + txt_delet.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            show();
        }
        public void show() {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctors", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}
