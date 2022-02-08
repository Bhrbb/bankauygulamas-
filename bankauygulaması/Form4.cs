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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P1SH4NN\SQL;Initial Catalog=BankaSimulasyon;Integrated Security=True");
        
        private void Form4_Load(object sender, EventArgs e)
        {

           
         //   baglanti.Open();
         //   SqlCommand komut = new SqlCommand("Select * from Tbl_Hareket where Id=@p4", baglanti);
         //  // komut.Parameters.AddWithValue("@p1",txtHesap.Text);
         //  // komut.Parameters.AddWithValue("@p2", txtAlıcı.Text);
         ////   komut.Parameters.AddWithValue("@p3", decimal.Parse(txtTutar.Text));
         //   komut.Parameters.AddWithValue("@p4",txtID.Text);
         //   SqlDataReader dr= komut.ExecuteReader();
         //   while (dr.Read())
         //   {
         //       txtHesap.Text = dr[1].ToString();
         //       txtAlıcı.Text = dr[2].ToString();
         //       txtTutar.Text = dr[3].ToString();
         //   }
         //   baglanti.Close();
         
        }

        private void txtHesap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
