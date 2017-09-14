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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            var baglantiCumlesi = "Data Source=CAVIDAN-PC\\SQLEXPRESS;Initial Catalog=CodeAcademy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection bagla = new SqlConnection(baglantiCumlesi);
            bagla.Open();

            var sqlEmr = "select * from Sobeler";
            SqlCommand kamanda = new SqlCommand(sqlEmr, bagla);
            kamanda.ExecuteNonQuery();

            var adapter = new SqlDataAdapter(kamanda);
            var ds = new DataSet();
            adapter.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i]["Name"]);
            }


            var sqlEmrD = "select * from Hekimler";
            SqlCommand kamandaD = new SqlCommand(sqlEmrD, bagla);
            kamandaD.ExecuteNonQuery();

            var adapterD = new SqlDataAdapter(kamandaD);
            var dsD = new DataSet();
            adapterD.Fill(dsD);

            for (int i = 0; i < dsD.Tables[0].Rows.Count; i++)
            {
                comboBox5.Items.Add(dsD.Tables[0].Rows[i]["Name"].ToString() + " " + dsD.Tables[0].Rows[i]["SurName"].ToString());
            }

            var sqlEmrF = "select * from Tarix";
            SqlCommand kamandaF = new SqlCommand(sqlEmrF, bagla);
            kamandaD.ExecuteNonQuery();

            var adapterF = new SqlDataAdapter(kamandaF);
            var dsF = new DataSet();
            adapterF.Fill(dsF);

            for (int i = 0; i < dsF.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(dsF.Tables[0].Rows[i]["Tarix"].ToString());
            }

            var sqlEmrG = "select * from Novbe";
            SqlCommand kamandaG = new SqlCommand(sqlEmrG, bagla);
            kamandaG.ExecuteNonQuery();

            var adapterG = new SqlDataAdapter(kamandaG);
            var dsG = new DataSet();
            adapterG.Fill(dsG);

            for (int i = 0; i < dsG.Tables[0].Rows.Count; i++)
            { 
                comboBox2.Items.Add(dsG.Tables[0].Rows[i]["Name"].ToString() + ") " + dsG.Tables[0].Rows[i]["Start_Time"].ToString() + " " + dsG.Tables[0].Rows[i]["End_Time"].ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var baglanti_Cumlesi = "Data Source=CAVIDAN-PC\\SQLEXPRESS;Initial Catalog=CodeAcademy;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection baglayici = new SqlConnection(baglanti_Cumlesi);
            baglayici.Open();

            var sobe_txt = comboBox1.SelectedItem;
            var hekim_txt = comboBox5.SelectedItem;
            //var tarix_txt =comboBox4.Items;
            //var Novbe_txt =Convert.ToDateTime(comboBox2.Items);
            var ad_txt = textBox1.Text;
            var soyad_txt = textBox5.Text;
            var yash_txt = textBox4.Text;
            var tel_txt = textBox3.Text;

            var emr_Cumlesi = "insert into Qeydiyata_Al(Name,SurName,Age,Phone,Sobe,Hekim) values('" + ad_txt + "','" + soyad_txt + "','" + yash_txt + "','" + tel_txt + "','" + sobe_txt + "','" + hekim_txt + "')";
            SqlCommand kamanda = new SqlCommand(emr_Cumlesi,baglayici);
            kamanda.ExecuteNonQuery();
           
            baglayici.Close();
            baglayici.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 tezeForm4 = new Form4();
            this.Hide();
            tezeForm4.Show();
        }
    }
}
