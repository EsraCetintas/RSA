using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsimetrikSifreleme_RSA
{
    public partial class Form1 : Form
    {
        public static string metin;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "DEŞİFRELİ METİN";
            richTextBox2.Clear();
            Desifreleme desifreleme = new Desifreleme();
            desifreleme.LBul();
            richTextBox2.Text =Desifreleme.DesifreliMetin; 
            desifreleme.MetinDesifrele();
            richTextBox2.Text = Desifreleme.DesifreliMetin;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            metin = richTextBox1.Text;
            AnahtarOlusturma anahtar = new AnahtarOlusturma();
            anahtar.pUret();
            anahtar.qUret();
            anahtar.nBulma();
            anahtar.Totient();
            anahtar.eBulma();
            anahtar.dBulma();
            Sifreleme sifreleme = new Sifreleme();
            sifreleme.LBul();
            sifreleme.MetinSifrele();
            richTextBox2.Text = Sifreleme.SifreliMetin;
        }
    }
}
