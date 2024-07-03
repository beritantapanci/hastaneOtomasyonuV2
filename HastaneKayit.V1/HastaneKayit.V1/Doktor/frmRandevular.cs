using DevExpress.XtraEditors;
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
    public partial class frmRandevular : Form
    {
        private readonly HastaneDataContext db = new HastaneDataContext();
        public string tcno;
        private int selectedMuayeneID;
        public frmRandevular()
        {
            InitializeComponent();
        }

        private void frmRandevular_Load(object sender, EventArgs e)
        {


            var doktor = db.tbl_Doktorlars.FirstOrDefault(d => d.DoktorTC == tcno);
            if (doktor != null)
            {
                textEdit1.Text = doktor.DoktorTC;
                LoadAppointments(doktor.DoktorTC); // Form yüklendiğinde randevuları yükle
            }
            else
            {
                MessageBox.Show("Doktor bulunamadı!");
            }

        }


        private void LoadAppointments(string doctorTC)
        {
            var doctor = db.tbl_Doktorlars.FirstOrDefault(d => d.DoktorTC == doctorTC);
            if (doctor != null)
            {
                var appointments = db.tbl_Randevulars
                                      .Where(r => r.DoktorID == doctor.DoktorID)
                                      .Select(r => new
                                      {
                                          r.RandevuID,
                                          r.RandevuTarihi,
                                          r.RandevuSaati,
                                          HastaAdi = r.tbl_Hastalar.HastaAd,
                                          HastaSoyadi = r.tbl_Hastalar.HastaSoyad,
                                          HastaID=r.tbl_Hastalar.HastaID
                                      })
                                      .ToList();

                gridControl1.DataSource = appointments;

            }
            else
            {
                XtraMessageBox.Show("Girilen TC numarasına sahip bir doktor bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
               
                if (e.RowHandle >= 0)
                {
                    int selectedRandevuID = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "RandevuID"));

                  
                    var muayene = db.tbl_MuayeneBilgileris.FirstOrDefault(m => m.RandevuID == selectedRandevuID);
                    if (muayene != null)
                    {
                        selectedMuayeneID = muayene.MuayeneID; // Seçili muayene ID'sini sakla
                        dateEdit1.EditValue = muayene.MuayeneTarihi;
                        memoEdit1.Text = muayene.Teşhis;

                        // Reçete bilgilerini yükle veya boşalt
                        var recete = db.tbl_Recetelers.FirstOrDefault(r => r.MuayeneID == selectedMuayeneID);
                        if (recete != null)
                        {
                            memoEdit2.Text = recete.IlacAdi;
                           
                        }
                        else
                        {
                            memoEdit2.Text = ""; 
                        }
                    }
                    else
                    {
                        // Yeni muayene bilgisi oluştur
                        muayene = new tbl_MuayeneBilgileri();
                        muayene.RandevuID = selectedRandevuID; // Seçili randevunun ID'sini ata
                        muayene.MuayeneTarihi = DateTime.Now; // Varsayılan olarak bugünün tarihini ata
                        muayene.HastaID = Convert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "HastaID"));
                        // Diğer muayene bilgilerini ekleme işlemlerini buraya ekleyebilirsiniz
                        // Örneğin: muayene.Teşhis = "Başlangıç Teşhisi";

                        db.tbl_MuayeneBilgileris.InsertOnSubmit(muayene);
                        db.SubmitChanges();

                        selectedMuayeneID = muayene.MuayeneID; // Yeni eklenen muayene ID'sini sakla

                        dateEdit1.EditValue = muayene.MuayeneTarihi;
                        memoEdit1.Text = muayene.Teşhis;

                        memoEdit2.Text = ""; // Yeni muayene için MemoEdit2'yi boşalt
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            if (selectedMuayeneID > 0)
            {
                var muayene = db.tbl_MuayeneBilgileris.FirstOrDefault(m => m.MuayeneID == selectedMuayeneID);
                if (muayene != null)
                {
                    muayene.Teşhis = memoEdit1.Text;

                    // Muayene bilgilerini güncellemek için db.SubmitChanges() kullanabiliriz
                    try
                    {
                        db.SubmitChanges();
                        XtraMessageBox.Show("Teşhis bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Teşhis güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Lütfen bir randevu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (selectedMuayeneID > 0)
            {
                var recete = db.tbl_Recetelers.FirstOrDefault(r => r.MuayeneID == selectedMuayeneID);
                if (recete != null)
                {
                    // Reçete zaten varsa güncelle
                    recete.IlacAdi = memoEdit2.Text; // MemoEdit2, ilaç adını içerir (varsayılan olarak eklediğiniz)
                    recete.Dozaj = "Günlük 2 defa 1 tablet"; // Örnek bir dozaj ekleyebilirsiniz, kullanıcıdan alınabilir

                    try
                    {
                        db.SubmitChanges();
                        XtraMessageBox.Show("Reçete bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Reçete güncelleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Reçete bulunamazsa yeni bir reçete oluştur
                    recete = new tbl_Receteler();
                    recete.MuayeneID = selectedMuayeneID; // İlgili muayene ID'sini ata
                    recete.IlacAdi = memoEdit2.Text; // MemoEdit2, ilaç adını içerir
                    recete.Dozaj = "Günlük 2 defa 1 tablet"; // Örnek bir dozaj ekleyebilirsiniz, kullanıcıdan alınabilir

                    db.tbl_Recetelers.InsertOnSubmit(recete);

                    try
                    {
                        db.SubmitChanges();
                        XtraMessageBox.Show("Reçete bilgisi eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Reçete ekleme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Lütfen bir randevu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

} 





