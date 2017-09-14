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

namespace WindowsFormsApp17
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var baglantiCumlesi = "Data Source=CAVIDAN-PC\\SQLEXPRESS;Initial Catalog=CodeAcademy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection bagla = new SqlConnection(baglantiCumlesi);
            bagla.Open();

            var sqlEmr = "select * from Sobeler";
            SqlCommand kamanda = new SqlCommand(sqlEmr,bagla);
            kamanda.ExecuteNonQuery();

            var adapter = new SqlDataAdapter(kamanda);
            var ds = new DataSet();
            adapter.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                textBox1.Text += ds.Tables[0].Rows[i]["id"].ToString() + "." + ds.Tables[0].Rows[i]["Name"].ToString() + "\r\n";
            }
            bagla.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var baglantiCumlesi = "Data Source=CAVIDAN-PC\\SQLEXPRESS;Initial Catalog=CodeAcademy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection bagla = new SqlConnection(baglantiCumlesi);
            bagla.Open();

            var sqlEmr = "select * from Hekimler";
            SqlCommand kamanda = new SqlCommand(sqlEmr, bagla);
            kamanda.ExecuteNonQuery();

            var adapter = new SqlDataAdapter(kamanda);
            var ds = new DataSet();
            adapter.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                textBox2.Text += ds.Tables[0].Rows[i]["id"].ToString() + "." + ds.Tables[0].Rows[i]["Name"].ToString() + " " + ds.Tables[0].Rows[i]["SurName"].ToString() + " " + ds.Tables[0].Rows[i]["Email"].ToString() +  "\r\n";
            }
            bagla.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 tezeForm3 = new Form3();
            this.Hide();
            tezeForm3.Show();
        }
    }
}
