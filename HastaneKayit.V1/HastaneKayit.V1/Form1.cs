using HastaneKayit.V1.Doktor;
using HastaneKayit.V1.Hasta;
using HastaneKayit.V1.Yonetici;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
            fr1 = new frmAnaSayfa();
            fr1.MdiParent = this; // MDI parent olarak Form1'i belirleyin
            fr1.WindowState = FormWindowState.Maximized; // Formu maksimize edin
            fr1.Show();
        }
        frmAnaSayfa fr1;
        frmDoktorGris fr2;
        frmHastaGris fr3;
        YoneticiGris fr4;
        frmDoktorKayit fr5;
        frmHastaKayit fr6;
        frmSifremiUnuttum fr7;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new frmDoktorGris();
                fr2.MdiParent = this; // MDI parent olarak Form1'i belirleyin
                fr2.Show();
            }
            else
            {
                fr2.Activate(); // Form zaten açıksa ön plana getirin
            }
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new frmAnaSayfa();
                fr1.MdiParent = this; // MDI parent olarak Form1'i belirleyin
                fr1.Show();
            }
            else
            {
                fr1.Activate(); // Form zaten açıksa ön plana getirin
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; 
            this.StartPosition = FormStartPosition.CenterParent;

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new frmHastaGris();
                fr3.MdiParent = this; 
                fr3.Show();
            }
            else
            {
                fr3.Activate(); 
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new YoneticiGris();
                fr4.MdiParent = this;
                fr4.Show();
            }
            else
            {
                fr4.Activate();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new frmDoktorKayit();
                fr5.MdiParent = this;
                fr5.Show();
            }
            else
            {
                fr5.Activate();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new frmHastaKayit();
                fr6.MdiParent = this;
                fr6.Show();
            }
            else
            {
                fr6.Activate();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new frmSifremiUnuttum();
                fr7.MdiParent = this;
                fr7.Show();
            }
            else
            {
                fr7.Activate();
            }
        }
    }
}
