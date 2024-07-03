using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneKayit.V1.Doktor
{
    public partial class frmDoktorGris : Form
    {
        HastaneDataContext db = new HastaneDataContext();

        public frmDoktorGris()
        {
            InitializeComponent();
            this.AcceptButton = girisYap;
            textSifre.Properties.UseSystemPasswordChar = true;
        }

       
       
       

        private void girisYap_Click(object sender, EventArgs e)
        {

            if (kontrol.Validate())
            {
                var doktor = (from d in db.tbl_Doktorlars
                              where d.DoktorTC == textTc.Text.Trim() && d.DoktorSifre == textSifre.Text.Trim()
                              select d).FirstOrDefault(); // TC ve şifre ile doktoru sorgula

                if (doktor != null)
                {
                    MessageBox.Show($"Hoş geldiniz Dr. {doktor.DoktorAd} {doktor.DoktorSoyad}");

                    frmDoktorProfil frm = new frmDoktorProfil();
                    frm.tcno = doktor.DoktorTC;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                   this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş.....");
                }
            }
        }

        private void kayitOl_Click(object sender, EventArgs e)
        {
            frmDoktorKayit dr = new frmDoktorKayit();
            dr.MdiParent = this.MdiParent;
            dr.Show();
            this.Hide();
        }

        private void sifremiUnuttum_Click(object sender, EventArgs e)
        {
            frmSifremiUnuttum hst = new frmSifremiUnuttum();
           hst.MdiParent = this.MdiParent;
            hst.Show();
            this.Hide();
        }

        private void frmDoktorGris_Load(object sender, EventArgs e)
        {

        }
    }
}
