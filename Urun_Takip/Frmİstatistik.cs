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

namespace Urun_Takip
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-83L42UFV\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Kategori Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from TblKategori", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while(dr.Read())
            {
                LblToplamKategori.Text = dr[0].ToString();
            }
            baglanti.Close();

            //Toplam Ürün Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from TblUrunler", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblToplamUrun.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //En Yüksek Stoklu Ürün
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select * from TblUrunler where stok = (select MAX(stok) from TblUrunler)", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblEnYuksekStok.Text = dr5["UrunAd"].ToString();
            }
            baglanti.Close();

            //En Düşük Stoklu Ürün
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select * from TblUrunler where stok = (select min(stok) from TblUrunler)", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblEnDusukStokUrun.Text = dr6["UrunAd"].ToString();
            }
            baglanti.Close();

            //Toplam Beyaz Eşya Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from TblUrunler where Kategori= (select ID from TblKategori where Ad='Beyaz Eşya')", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBeyazEsya.Text = dr3[0].ToString();
            }
            baglanti.Close();

            // Toplam Küçük Ev Aletleri
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(*) from TblUrunler where Kategori= (select ID from TblKategori where Ad='Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblKucukEvAletleri.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam Laptop Kar Oranı
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select stok*(SatisFiyat-AlisFiyat) from TblUrunler where UrunAd='Laptop'", baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblLaptopKarOrani.Text = dr7[0].ToString() + " ₺";
            }
            baglanti.Close();

            //Beyaz Eşya Toplam Kar Oranı
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select Sum  (Stok*(SatisFiyat-AlisFiyat)) as 'Toplam Stokla Çarpılan Sonuç' from TblUrunler where Kategori = (select ID from TblKategori where Ad = 'Beyaz Eşya')", baglanti);
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblBeyazEsyaToplamKar.Text = dr8[0].ToString() + " ₺";
            }
            baglanti.Close();

            
        }

    }
}
