using DevExpress.Data.Browsing;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace HastaneKayit.V1.Hasta
{
    public partial class RandevuAl : Form
    {
        private readonly HastaneDataContext dataContext = new HastaneDataContext();
        public string tcno;
        public RandevuAl()
        {
            InitializeComponent();
            DoktorlariComboBoxDoldur();
            BolumleriComboBoxDoldur();
            AcceptButton = simpleButton2;
            dateEdit1.Properties.MinValue = DateTime.Today;
            InitializeTimeEdit();

        }
        private void InitializeTimeEdit()
        {
            timeEdit1.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.SingleClick;
            timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            timeEdit1.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;

            // Zaman formatını ve görüntü formatını ayarla
            timeEdit1.Properties.Mask.EditMask = "HH:mm";
            timeEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            timeEdit1.Properties.DisplayFormat.FormatString = "HH:mm";
            timeEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            timeEdit1.Properties.EditFormat.FormatString = "HH:mm";
            timeEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            // Saat aralığını ve seçeneklerini belirle
            TimeSpan baslangicSaat = new TimeSpan(8, 0, 0); // Başlangıç saati 08:00
            TimeSpan bitisSaat = new TimeSpan(18, 0, 0); // Bitiş saati 18:00
            TimeSpan aralik = new TimeSpan(0, 15, 0); // 15 dakika aralıklarla

            List<string> saatListesi = new List<string>();
            TimeSpan zaman = baslangicSaat;
            while (zaman <= bitisSaat)
            {
                saatListesi.Add(zaman.ToString(@"hh\:mm"));
                zaman = zaman.Add(aralik);
            }

            // TimeEdit kontrolünün saat seçeneklerini güncelle
            //timeEdit1.Properties.Items.Clear(); // Önce mevcut öğeleri temizle
            //timeEdit1.Properties.Items.AddRange(saatListesi.ToArray());
        }
        private void DoktorlariComboBoxDoldur()
        {
            try
            {
                var doktorlar = from doktor in dataContext.tbl_Doktorlars
                                select doktor.DoktorAd;

                comboBoxEdit2.Properties.Items.AddRange(doktorlar.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktorlar yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void BolumleriComboBoxDoldur()
        {
            try
            {
                var bolumler = from bolum in dataContext.tbl_Bolums
                               select bolum.BolumAdi;

                comboBoxEdit1.Properties.Items.AddRange(bolumler.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bölümler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private bool RandevuVarMi(int doktorID, DateTime randevuTarihi, TimeSpan randevuSaati)
        {
            var ayniGunRandevular = from randevu in dataContext.tbl_Randevulars
                                    where randevu.DoktorID == doktorID &&
                                          randevu.RandevuTarihi == randevuTarihi
                                    select randevu;

            foreach (var randevu in ayniGunRandevular)
            {
                // Aynı doktorun aynı gün içinde farklı saatlerde randevusu varsa
                // Bu durumda aynı gün içinde başka bir randevu olduğu anlamına gelir.
                if (randevu.RandevuSaati == randevuSaati)
                {
                    return true;
                }
            }

            // Aynı doktorun aynı gün ve aynı saatte randevusu yoksa false döndür
            return false;
        }

        private bool SaatAraligiGecerliMi(TimeSpan randevuSaati)
        {
            return randevuSaati >= TimeSpan.FromHours(8) && randevuSaati <= TimeSpan.FromHours(18);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (kontrol.Validate())
            {
                string hastaTc = textEdit1.Text;
                string doktorAdi = comboBoxEdit2.SelectedItem?.ToString();
                string bolumAdi = comboBoxEdit1.SelectedItem?.ToString();
                DateTime randevuTarihi = dateEdit1.DateTime.Date;
                TimeSpan randevuSaati = timeEdit1.Time.TimeOfDay;
                try
                {
                    // Seçilen tarihin bugünden önce olup olmadığını kontrol et
                    if (randevuTarihi < DateTime.Today)
                    {
                        MessageBox.Show("Geçmiş tarihler için randevu oluşturulamaz.");
                        return;
                    }

                    // Randevu saati geçerli mi kontrolü
                    if (!SaatAraligiGecerliMi(randevuSaati))
                    {
                        MessageBox.Show("Randevu saati 08:00 ile 18:00 arasında olmalıdır.");
                        return; }

                        int doktorID = (from doktor in dataContext.tbl_Doktorlars
                                        where doktor.DoktorAd == doktorAdi
                                        select doktor.DoktorID).FirstOrDefault();

                        int hastaID = (from hasta in dataContext.tbl_Hastalars
                                       where hasta.HastaTC == hastaTc
                                       select hasta.HastaID).FirstOrDefault();

                        if (doktorID == 0 || hastaID == 0)
                        {
                            MessageBox.Show("Geçerli bir doktor ve hasta seçmelisiniz.");
                            return;
                        }

                        if (RandevuVarMi(doktorID, randevuTarihi, randevuSaati))
                        {
                            MessageBox.Show("Bu saatte zaten bir randevu mevcut. Lütfen başka bir saat seçin.");
                            return;
                        }

                        var yeniRandevu = new tbl_Randevular
                        {
                            RandevuSaati = randevuSaati,
                            RandevuTarihi = randevuTarihi,
                            DoktorID = doktorID,
                            HastaID = hastaID
                        };

                        dataContext.tbl_Randevulars.InsertOnSubmit(yeniRandevu);
                        dataContext.SubmitChanges();

                        //RandevuBilgisiEpostaGonder(hastaTc, doktorAdi, randevuTarihi, randevuSaati);

                        MessageBox.Show("Randevu başarıyla oluşturuldu! Randevu bilgileriniz mail adresinize gönderilmiştir.");

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Randevu oluşturulurken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void RandevuAl_Load(object sender, EventArgs e)
        {

            var hasta = dataContext.tbl_Hastalars.FirstOrDefault(h => h.HastaTC == tcno);
            if (hasta != null)
            {
                
               textEdit1.Text = hasta.HastaTC;
            }
            else
            {
                MessageBox.Show("Yonetici bulunamadı!");
            }


           


        }

        private void timeEdit1_EditValueChanged(object sender, EventArgs e)
        {
            // TimeEdit değiştiğinde yapılacak işlemler buraya eklenir
            DateTime randevuTarihi = dateEdit1.DateTime.Date;

            // timeEdit1.EditValue'yi TimeSpan olarak almak yerine doğru şekilde işleyin
            TimeSpan randevuSaati = timeEdit1.Time.TimeOfDay;

            int doktorID = 0;
            string doktorAdi = comboBoxEdit2.SelectedItem?.ToString();
            if (doktorAdi != null)
            {
                doktorID = (from doktor in dataContext.tbl_Doktorlars
                            where doktor.DoktorAd == doktorAdi
                            select doktor.DoktorID).FirstOrDefault();
            }

            if (doktorID == 0)
            {
                MessageBox.Show("Geçerli bir doktor seçmelisiniz.");
                return;
            }

            // Seçilen saat dolu mu kontrol et
            if (RandevuVarMi(doktorID, randevuTarihi, randevuSaati))
            {
                // Doluysa seçimi iptal et ve mesaj göster
                MessageBox.Show("Seçilen saatte zaten bir randevu mevcut. Lütfen başka bir saat seçin.");
                timeEdit1.EditValue = null; // Seçimi temizle
            }
            else
            {
                // Boşsa işlem yapabilirsiniz
            }
        }
    }
    //private void RandevuBilgisiEpostaGonder(string hastaTc, string doktorAdi, DateTime randevuTarihi, TimeSpan randevuSaati)
    //{
    //    try
    //    {
    //        var hasta = (from h in dataContext.tbl_Hastalars
    //                     where h.HastaTC == hastaTc
    //                     select h).FirstOrDefault();

    //        if (hasta != null)
    //        {
    //            MailMessage mail = new MailMessage();
    //            SmtpClient smtpSunucusu = new SmtpClient("smtp.gmail.com");

    //            mail.From = new MailAddress("sizin_email@gmail.com");
    //            mail.To.Add(hasta.HastaMail);
    //            mail.Subject = "Randevu Bilgileriniz";
    //            mail.Body = $"Merhaba {hasta.HastaAd},\n\nRandevunuz başarıyla oluşturulmuştur. İşte detaylar:\n\nDoktor: {doktorAdi}\nRandevu Tarihi: {randevuTarihi.ToShortDateString()}\nRandevu Saati: {randevuSaati.ToString(@"hh\:mm")}\n\nSağlıklı günler dileriz.";

    //            smtpSunucusu.Port = 587;
    //            smtpSunucusu.Credentials = new System.Net.NetworkCredential("sizin_email@gmail.com", "sizin_sifreniz");
    //            smtpSunucusu.EnableSsl = true;

    //            smtpSunucusu.Send(mail);
    //        }
    //        else
    //        {
    //            MessageBox.Show("Hasta bulunamadı!");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Email gönderilirken bir hata oluştu: " + ex.Message);
    //    }
    //}
   
    

   
}
    

