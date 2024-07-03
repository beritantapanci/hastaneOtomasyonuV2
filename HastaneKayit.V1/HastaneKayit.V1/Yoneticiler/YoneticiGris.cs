﻿using HastaneKayit.V1.Doktor;
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
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace HastaneKayit.V1.Yonetici
{
    public partial class YoneticiGris : Form
    {
        HastaneDataContext db = new HastaneDataContext();
        public YoneticiGris()
        {
            InitializeComponent();
           
            this.AcceptButton = girisYap;
            textSifre.Properties.UseSystemPasswordChar = true;
        }
        
        private void girisYap_Click(object sender, EventArgs e)
        {
        var yonetici = (from d in db.tbl_Yoneticis
                          where d.TC == textTc.Text.Trim() && d.Sifre == textSifre.Text.Trim()
                          select d).FirstOrDefault(); 

            if (yonetici != null)
            {
                MessageBox.Show($"Hoş geldiniz  {yonetici.Ad} {yonetici.Soyad}");

                frmYonetici frm = new frmYonetici();
                frm.tcno = yonetici.TC;
              
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş.....");
            }
        }

        private void sifremiUnuttum_Click(object sender, EventArgs e)
        {
            frmSifremiUnuttum hst = new frmSifremiUnuttum();
           hst.MdiParent = this.MdiParent;
            hst.Show();
            this.Hide();
        }
    }
    
}
