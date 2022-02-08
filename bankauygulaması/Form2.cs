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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string hesap;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P1SH4NN\SQL;Initial Catalog=BankaSimulasyon;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            lblHesap.Text = hesap;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kisiler where HesapNo=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",hesap);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[1] + "" + dr[2];
                LblTc.Text = dr[4].ToString();
                LblTel.Text = dr[3].ToString();



            }
            baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm = new Form3();
         
            frm.Show();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        { 

            // Gönderilen Hesabın Para artışı
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update tbl_Hesap set bakiye=bakiye+@p1 where hesapno=@p2 ", baglanti);
            komut.Parameters.AddWithValue("@p1", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p2",mskHesap.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
           // MessageBox.Show("İşlem Gerçekleşti.");
            //Gönderen Hesap PAra azalışı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Update tbl_Hesap set bakiye=bakiye-@k1 where hesapno=@k2 ", baglanti);
            komut2.Parameters.AddWithValue("@k1", decimal.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@k2", hesap);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Gerçekleşti.");
            // hareket tablosu 
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into tbl_hareket (Gonderen,Alıcı,Tutar) values (@p1,@p2,@p3)", baglanti);
            komut3.Parameters.AddWithValue("@p1", hesap);
            komut3.Parameters.AddWithValue("@p2", mskHesap.Text);
            komut3.Parameters.AddWithValue("@p3", decimal.Parse(txtTutar.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();

        }
    }
}
