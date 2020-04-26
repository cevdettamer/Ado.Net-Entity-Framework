using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbOkulEntities db;
        void doldur()  
        {
            db = new dbOkulEntities();
            dataGridView1.DataSource = db.ogrencis.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogrenci yeniogrenci = new ogrenci();
            yeniogrenci.Numara = Convert.ToInt32(textBox1.Text);
            yeniogrenci.Ad = textBox2.Text;
            yeniogrenci.Soyad = textBox3.Text;
            db.ogrencis.Add(yeniogrenci);
            db.SaveChanges();
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int guncelle = Convert.ToInt32(textBox1.Text);
            var guncellenecekogrenci = db.ogrencis.Where(w => w.Numara == guncelle).FirstOrDefault();
            guncellenecekogrenci.Ad = textBox2.Text;
            guncellenecekogrenci.Soyad = textBox3.Text;
            db.SaveChanges();
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int silinecek = Convert.ToInt32(textBox1.Text);
            var silinecekkisi = db.ogrencis.Where(w => w.Numara == silinecek).FirstOrDefault();
            db.ogrencis.Remove(silinecekkisi);
            db.SaveChanges();
            doldur();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }
    }
}
