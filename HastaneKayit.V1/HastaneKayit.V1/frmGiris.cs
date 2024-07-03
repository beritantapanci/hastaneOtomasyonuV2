using HastaneKayit.V1.Doktor;
using HastaneKayit.V1.Hasta;
using HastaneKayit.V1.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneKayit.V1
{
    public partial class frmGiris : Form
    {
        private HastaneDataContext db = new HastaneDataContext();
        public frmGiris()
        {
            InitializeComponent();
            this.AcceptButton = girisYap;
            textSifre.Properties.UseSystemPasswordChar = true;
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private void girisYap_Click(object sender, EventArgs e)
        {
            if (kontrol.Validate())
            {
                string tc = textTc.Text.Trim();
                string sifre = textSifre.Text.Trim();

                if (string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(sifre))
                {
                    MessageBox.Show("Lütfen TC ve şifre alanlarını doldurun.");
                    return;
                }

                // Yönetici girişi
                var yonetici = db.tbl_Yoneticis.FirstOrDefault(d => d.TC == tc && d.Sifre == sifre);
                if (yonetici != null)
                {
                    MessageBox.Show($"Hoş geldiniz {yonetici.Ad} {yonetici.Soyad}");
                    frmYonetici frm = new frmYonetici();
                    frm.tcno = yonetici.TC;
                 
                    frm.Show();
                    this.Hide();
                    return;
                }

                // Hasta girişi
                var hasta = db.tbl_Hastalars.FirstOrDefault(d => d.HastaTC == tc && d.HastaSifre == sifre);
                if (hasta != null)
                {
                    MessageBox.Show($"Hoş geldiniz {hasta.HastaAd} {hasta.HastaSoyad}");
                    frmHastaProfil frm = new frmHastaProfil();
                    frm.tcno = hasta.HastaTC;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    this.Hide();
                    return;
                }

                // Doktor girişi
                var doktor = db.tbl_Doktorlars.FirstOrDefault(d => d.DoktorTC == tc && d.DoktorSifre == sifre);
                if (doktor != null)
                {
                    MessageBox.Show($"Hoş geldiniz  {doktor.DoktorAd} {doktor.DoktorSoyad}");
                    frmDoktorProfil frm = new frmDoktorProfil();
                    frm.tcno = doktor.DoktorTC;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    this.Hide();
                    return;
                }

                // Hiçbir kullanıcı bulunamazsa
                MessageBox.Show("Hatalı Giriş.....");
            } }

        private void kayitOl_Click(object sender, EventArgs e)
        {
            frmDoktorKayit frm = new frmDoktorKayit();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Hide();
        }

        private void sifremiUnuttum_Click(object sender, EventArgs e)
        {
            frmHastaKayit frm = new frmHastaKayit();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Hide();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmSifremiUnuttum frm = new frmSifremiUnuttum();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Hide();
        }
    }
}

