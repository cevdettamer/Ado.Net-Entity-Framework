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
using System.Configuration;

namespace deneme2
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }

        public void doldur() 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["dbOkul"].ConnectionString;
            baglanti = new SqlConnection(connectionString);
            baglanti.Open();
            da = new SqlDataAdapter("Select *From ogrenci", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into ogrenci (Numara, Ad, Soyad) values (@Numara,@Ad,@Soyad)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Numara", textBox1.Text);
            komut.Parameters.AddWithValue("@Ad", textBox2.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox3.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Update ogrenci Set Numara=@Numara,Ad=@Ad,Soyad=@Soyad Where Numara=@Numara";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@Ad", textBox2.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox3.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From ogrenci Where Numara=@Numara";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Numara", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            doldur();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
