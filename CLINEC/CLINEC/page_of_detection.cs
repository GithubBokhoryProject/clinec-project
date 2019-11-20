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
    public partial class page_of_detection : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=clinec;Integrated Security=True");
        public page_of_detection()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_amountofcure.Clear();
            txt_analyzes.Clear();
            txt_cure.Clear();
            txt_delete.Clear();
            txt_detection.Clear();
            txt_disease.Clear();
            txt_doctor_id.Clear();
            txt_id_page.Clear();
            txt_patient_id.Clear();
            txt_searche.Clear();
            show();
        }
        public void show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from page_of_Detection", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into page_of_Detection values('" + (txt_id_page.Text) + "','" + txt_disease.Text + "','" + txt_analyzes.Text + "','" + txt_detection.Text + "','" + (txt_cure.Text) + "','"+txt_amountofcure.Text+"','"+txt_doctor_id.Text+"','"+txt_patient_id.Text+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            show();
            MessageBox.Show("Saved Data Successed");
        }

        private void page_of_detection_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from page_of_Detection where id_page='" + txt_searche.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from page_of_Detection where id_page='" + txt_delete.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            show();
        }
    }
}
