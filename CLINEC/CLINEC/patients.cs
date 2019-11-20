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
    public partial class patients : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=clinec;Integrated Security=True");
        public patients()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_phone.Clear();
            txt_address.Clear();
            txt_type.Clear();
            txt_money_paid.Clear();
            txt_dep_id.Clear();
            txt_searche.Clear();
            txt_delet.Clear();
        }
        public void show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from patients", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into patients values('" + (txt_id.Text) + "','" + txt_name.Text + "','" + txt_phone.Text + "','" + txt_address.Text + "','"+dateTimePicker1.Text+"','" + txt_type.Text + "','" + txt_money_paid.Text + "','" + txt_dep_id.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            show();
            MessageBox.Show("Saved Data Successed");
        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from patients where id_patient='" + txt_searche.Text + "'", con);
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
            SqlCommand cmd = new SqlCommand("delete from patients where id_patient='" + txt_delet.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            show();
        }

        private void patients_Load(object sender, EventArgs e)
        {
            show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/mm/yyyy";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}
