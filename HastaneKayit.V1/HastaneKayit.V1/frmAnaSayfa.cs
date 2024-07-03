using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HastaneKayit.V1.Doktor;
using HastaneKayit.V1.Hasta;
using HastaneKayit.V1.NewFolder1;
using HastaneKayit.V1.Yonetici;

namespace HastaneKayit.V1
{
    public partial class frmAnaSayfa : Form

    {
        private readonly HastaneDataContext db = new HastaneDataContext();
        private string sonDuyuruIcerik = "";
        public frmAnaSayfa()
        {
            InitializeComponent();
        }



        private void Giris_Click(object sender, EventArgs e)
        {
            frmGiris hst = new frmGiris();
            hst.MdiParent = this.MdiParent;
            hst.Show();

            this.Hide();
        }






        public void GosterMesaj(string baslik, string icerik)
        {
            sonDuyuruIcerik = icerik; 
            if (Visible) 
            {
                MessageBox.Show(sonDuyuruIcerik, baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
            FetchLatestAnnouncement();
           labelControl1.Left = (this.ClientSize.Width - labelControl1.Width) / 2;
            labelControl1.Top = (this.ClientSize.Height - labelControl1.Height) / 2;
        }

       

        private void FetchLatestAnnouncement()
        {
            try
            {
                // tbl_Duyuru tablosuna erişim için LINQ sorgusu
                Table<tbl_Duyuru> duyurular = db.GetTable<tbl_Duyuru>();

                // Tarihe göre en son duyuruyu seç
                var latestAnnouncement = (from duyuru in duyurular
                                          orderby duyuru.Tarih descending
                                          select duyuru.Icerik).FirstOrDefault();

                if (latestAnnouncement != null)
                {
                    
                   
                        GosterMesaj("Son Duyuru", latestAnnouncement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duyuru getirilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
