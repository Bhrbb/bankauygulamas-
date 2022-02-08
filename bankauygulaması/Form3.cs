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

namespace bankauygulaması
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti= new SqlConnection(@"Data Source=DESKTOP-P1SH4NN\SQL;Initial Catalog=BankaSimulasyon;Integrated Security=True");

        

        private void button2_Click(object sender, EventArgs e)
        {
            Random rastgele= new Random();
            int sayi= rastgele.Next(100000,1000000);
            mskHesapNo.Text=sayi.ToString();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kayitol = new SqlCommand("insert into Tbl_kisiler (Ad,Soyad,Telefon,Tckimlik,Hesapno,Sifre) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            kayitol.Parameters.AddWithValue("@p1", txtAd.Text);
            kayitol.Parameters.AddWithValue("@p2", txtSoyad.Text);
            kayitol.Parameters.AddWithValue("@p3", mskTelefon.Text);
            kayitol.Parameters.AddWithValue("@p4", mskTc.Text);
            kayitol.Parameters.AddWithValue("@p5", mskHesapNo.Text);
            kayitol.Parameters.AddWithValue("@p6", txtSifre.Text);
            kayitol.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Olundu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
