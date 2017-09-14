using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string istifadeciAdi = textBox1.Text;
            string istifadeciParolu = textBox2.Text;

            if (istifadeciAdi == "admin" && istifadeciParolu == "admin")
            {
                Form2 tezeForm = new Form2();
                this.Hide();
                tezeForm.Show();
            }
            else
            {
                label1.Text = "Istifadeci Adi ve ya Parol Sehvdir";
            }
        }
    }
}
