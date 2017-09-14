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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var baglanti_Cumlesi = "Data Source=CAVIDAN-PC\\SQLEXPRESS;Initial Catalog=CodeAcademy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection baglanti = new SqlConnection(baglanti_Cumlesi);
            baglanti.Open();

            var name = ad.Text;

            var emr = "insert into Sobeler(Name) values('"+name+"')";
            SqlCommand komanda = new SqlCommand(emr,baglanti);
            komanda.ExecuteNonQuery();

            var selectSql = "select * from Sobeler";
            var selectCmd = new SqlCommand(selectSql,baglanti);

            var adapter = new SqlDataAdapter(selectCmd);
            var ds = new DataSet();
            adapter.Fill(ds);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var baglanti_Cumlesi = "Data Source=CAVIDAN-PC\\SQLEXPRESS;Initial Catalog=CodeAcademy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection baglanti = new SqlConnection(baglanti_Cumlesi);
            baglanti.Open();

            

            var emr = "select * from Sobeler";
            SqlCommand komanda = new SqlCommand(emr, baglanti);
            komanda.ExecuteNonQuery();

            var selectSql = "select * from Sobeler";
            var selectCmd = new SqlCommand(selectSql, baglanti);

            var adapter = new SqlDataAdapter(selectCmd);
            var ds = new DataSet();
            adapter.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                netice.Text += ds.Tables[0].Rows[i]["id"] + "." + ds.Tables[0].Rows[i]["Name"].ToString() + "\r\n";
            }
        }
    }
}
