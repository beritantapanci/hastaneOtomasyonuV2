﻿namespace HastaneKayit.V1.Yonetici
{
    partial class YoneticiGris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoneticiGris));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.sifremiUnuttum = new DevExpress.XtraEditors.SimpleButton();
            this.girisYap = new DevExpress.XtraEditors.SimpleButton();
            this.textSifre = new DevExpress.XtraEditors.TextEdit();
            this.textTc = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.pictureEdit1);
            this.dataLayoutControl1.Controls.Add(this.sifremiUnuttum);
            this.dataLayoutControl1.Controls.Add(this.girisYap);
            this.dataLayoutControl1.Controls.Add(this.textSifre);
            this.dataLayoutControl1.Controls.Add(this.textTc);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1108, 226, 812, 500);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(800, 450);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(776, 297);
            this.pictureEdit1.StyleController = this.dataLayoutControl1;
            this.pictureEdit1.TabIndex = 9;
            // 
            // sifremiUnuttum
            // 
            this.sifremiUnuttum.Appearance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifremiUnuttum.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.sifremiUnuttum.Appearance.Options.UseFont = true;
            this.sifremiUnuttum.Appearance.Options.UseForeColor = true;
            this.sifremiUnuttum.Location = new System.Drawing.Point(12, 398);
            this.sifremiUnuttum.Margin = new System.Windows.Forms.Padding(4);
            this.sifremiUnuttum.Name = "sifremiUnuttum";
            this.sifremiUnuttum.Size = new System.Drawing.Size(776, 29);
            this.sifremiUnuttum.StyleController = this.dataLayoutControl1;
            this.sifremiUnuttum.TabIndex = 8;
            this.sifremiUnuttum.Text = "Şifremi Unuttum";
            this.sifremiUnuttum.Click += new System.EventHandler(this.sifremiUnuttum_Click);
            // 
            // girisYap
            // 
            this.girisYap.Appearance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.girisYap.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.girisYap.Appearance.Options.UseFont = true;
            this.girisYap.Appearance.Options.UseForeColor = true;
            this.girisYap.Location = new System.Drawing.Point(12, 365);
            this.girisYap.Margin = new System.Windows.Forms.Padding(4);
            this.girisYap.Name = "girisYap";
            this.girisYap.Size = new System.Drawing.Size(776, 29);
            this.girisYap.StyleController = this.dataLayoutControl1;
            this.girisYap.TabIndex = 6;
            this.girisYap.Text = "Giriş Yap";
            this.girisYap.Click += new System.EventHandler(this.girisYap_Click);
            // 
            // textSifre
            // 
            this.textSifre.Location = new System.Drawing.Point(109, 339);
            this.textSifre.Margin = new System.Windows.Forms.Padding(4);
            this.textSifre.Name = "textSifre";
            this.textSifre.Size = new System.Drawing.Size(679, 22);
            this.textSifre.StyleController = this.dataLayoutControl1;
            this.textSifre.TabIndex = 5;
            // 
            // textTc
            // 
            this.textTc.Location = new System.Drawing.Point(109, 313);
            this.textTc.Margin = new System.Windows.Forms.Padding(4);
            this.textTc.Name = "textTc";
            this.textTc.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.textTc.Properties.MaskSettings.Set("mask", "d");
            this.textTc.Size = new System.Drawing.Size(679, 22);
            this.textTc.StyleController = this.dataLayoutControl1;
            this.textTc.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textTc;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 301);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 26);
            this.layoutControlItem1.Text = "  Tc. Kimliik No";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(85, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textSifre;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 327);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(780, 26);
            this.layoutControlItem2.Text = "  Şifre";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(85, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.girisYap;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 353);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(780, 33);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.sifremiUnuttum;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 386);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(780, 33);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.pictureEdit1;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(780, 301);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 419);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 11);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // YoneticiGris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "YoneticiGris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YoneticiGris";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton sifremiUnuttum;
        private DevExpress.XtraEditors.SimpleButton girisYap;
        private DevExpress.XtraEditors.TextEdit textSifre;
        private DevExpress.XtraEditors.TextEdit textTc;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}