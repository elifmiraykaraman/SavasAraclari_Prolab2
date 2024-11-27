namespace SavasAraclari_Prolab2
{
    partial class Form1
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        /// <param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        /// içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbOyuncuEl = new System.Windows.Forms.ListBox();
            this.btnSecHamle = new System.Windows.Forms.Button();
            this.btnYeniHamle = new System.Windows.Forms.Button();
            this.lbSecilenOyuncuKartlari = new System.Windows.Forms.ListBox();
            this.lbSecilenBilgisayarKartlari = new System.Windows.Forms.ListBox();
            this.lblOyuncuSkor = new System.Windows.Forms.Label();
            this.lblBilgisayarSkor = new System.Windows.Forms.Label();
            this.pbSecilenOyuncuKart1 = new System.Windows.Forms.PictureBox();
            this.pbSecilenOyuncuKart2 = new System.Windows.Forms.PictureBox();
            this.pbSecilenOyuncuKart3 = new System.Windows.Forms.PictureBox();
            this.pbSecilenBilgisayarKart1 = new System.Windows.Forms.PictureBox();
            this.pbSecilenBilgisayarKart2 = new System.Windows.Forms.PictureBox();
            this.pbSecilenBilgisayarKart3 = new System.Windows.Forms.PictureBox();
            this.txtOyunSonucu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenOyuncuKart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenOyuncuKart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenOyuncuKart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenBilgisayarKart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenBilgisayarKart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenBilgisayarKart3)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOyuncuEl
            // 
            this.lbOyuncuEl.FormattingEnabled = true;
            this.lbOyuncuEl.Location = new System.Drawing.Point(20, 20);
            this.lbOyuncuEl.Name = "lbOyuncuEl";
            this.lbOyuncuEl.Size = new System.Drawing.Size(200, 150);
            this.lbOyuncuEl.TabIndex = 0;
            // 
            // btnSecHamle
            // 
            this.btnSecHamle.Location = new System.Drawing.Point(250, 20);
            this.btnSecHamle.Name = "btnSecHamle";
            this.btnSecHamle.Size = new System.Drawing.Size(150, 50);
            this.btnSecHamle.TabIndex = 1;
            this.btnSecHamle.Text = "Hamle Yap";
            this.btnSecHamle.UseVisualStyleBackColor = true;
            this.btnSecHamle.Click += new System.EventHandler(this.btnSecHamle_Click);
            // 
            // btnYeniHamle
            // 
            this.btnYeniHamle.Location = new System.Drawing.Point(250, 80);
            this.btnYeniHamle.Name = "btnYeniHamle";
            this.btnYeniHamle.Size = new System.Drawing.Size(150, 50);
            this.btnYeniHamle.TabIndex = 2;
            this.btnYeniHamle.Text = "Yeni Hamle";
            this.btnYeniHamle.UseVisualStyleBackColor = true;
            this.btnYeniHamle.Click += new System.EventHandler(this.btnYeniHamle_Click);
            // 
            // lbSecilenOyuncuKartlari
            // 
            this.lbSecilenOyuncuKartlari.FormattingEnabled = true;
            this.lbSecilenOyuncuKartlari.Location = new System.Drawing.Point(20, 200);
            this.lbSecilenOyuncuKartlari.Name = "lbSecilenOyuncuKartlari";
            this.lbSecilenOyuncuKartlari.Size = new System.Drawing.Size(200, 150);
            this.lbSecilenOyuncuKartlari.TabIndex = 3;
            // 
            // lbSecilenBilgisayarKartlari
            // 
            this.lbSecilenBilgisayarKartlari.FormattingEnabled = true;
            this.lbSecilenBilgisayarKartlari.Location = new System.Drawing.Point(400, 200);
            this.lbSecilenBilgisayarKartlari.Name = "lbSecilenBilgisayarKartlari";
            this.lbSecilenBilgisayarKartlari.Size = new System.Drawing.Size(200, 150);
            this.lbSecilenBilgisayarKartlari.TabIndex = 4;
            // 
            // lblOyuncuSkor
            // 
            this.lblOyuncuSkor.AutoSize = true;
            this.lblOyuncuSkor.Location = new System.Drawing.Point(20, 380);
            this.lblOyuncuSkor.Name = "lblOyuncuSkor";
            this.lblOyuncuSkor.Size = new System.Drawing.Size(96, 17);
            this.lblOyuncuSkor.TabIndex = 5;
            this.lblOyuncuSkor.Text = "Oyuncu Skor: ";
            // 
            // lblBilgisayarSkor
            // 
            this.lblBilgisayarSkor.AutoSize = true;
            this.lblBilgisayarSkor.Location = new System.Drawing.Point(400, 380);
            this.lblBilgisayarSkor.Name = "lblBilgisayarSkor";
            this.lblBilgisayarSkor.Size = new System.Drawing.Size(108, 17);
            this.lblBilgisayarSkor.TabIndex = 6;
            this.lblBilgisayarSkor.Text = "Bilgisayar Skor: ";
            // 
            // PictureBoxes for Oyuncu
            // 
            this.pbSecilenOyuncuKart1.Location = new System.Drawing.Point(20, 420);
            this.pbSecilenOyuncuKart1.Size = new System.Drawing.Size(100, 100);
            this.pbSecilenOyuncuKart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.pbSecilenOyuncuKart2.Location = new System.Drawing.Point(140, 420);
            this.pbSecilenOyuncuKart2.Size = new System.Drawing.Size(100, 100);
            this.pbSecilenOyuncuKart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.pbSecilenOyuncuKart3.Location = new System.Drawing.Point(260, 420);
            this.pbSecilenOyuncuKart3.Size = new System.Drawing.Size(100, 100);
            this.pbSecilenOyuncuKart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // PictureBoxes for Bilgisayar
            this.pbSecilenBilgisayarKart1.Location = new System.Drawing.Point(400, 420);
            this.pbSecilenBilgisayarKart1.Size = new System.Drawing.Size(100, 100);
            this.pbSecilenBilgisayarKart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.pbSecilenBilgisayarKart2.Location = new System.Drawing.Point(520, 420);
            this.pbSecilenBilgisayarKart2.Size = new System.Drawing.Size(100, 100);
            this.pbSecilenBilgisayarKart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.pbSecilenBilgisayarKart3.Location = new System.Drawing.Point(640, 420);
            this.pbSecilenBilgisayarKart3.Size = new System.Drawing.Size(100, 100);
            this.pbSecilenBilgisayarKart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // 
            // txtOyunSonucu
            // 
            this.txtOyunSonucu.Location = new System.Drawing.Point(20, 540);
            this.txtOyunSonucu.Multiline = true;
            this.txtOyunSonucu.Name = "txtOyunSonucu";
            this.txtOyunSonucu.ReadOnly = true;
            this.txtOyunSonucu.Size = new System.Drawing.Size(720, 50);
            this.txtOyunSonucu.TabIndex = 7;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.lbOyuncuEl);
            this.Controls.Add(this.btnSecHamle);
            this.Controls.Add(this.btnYeniHamle);
            this.Controls.Add(this.lbSecilenOyuncuKartlari);
            this.Controls.Add(this.lbSecilenBilgisayarKartlari);
            this.Controls.Add(this.lblOyuncuSkor);
            this.Controls.Add(this.lblBilgisayarSkor);
            this.Controls.Add(this.pbSecilenOyuncuKart1);
            this.Controls.Add(this.pbSecilenOyuncuKart2);
            this.Controls.Add(this.pbSecilenOyuncuKart3);
            this.Controls.Add(this.pbSecilenBilgisayarKart1);
            this.Controls.Add(this.pbSecilenBilgisayarKart2);
            this.Controls.Add(this.pbSecilenBilgisayarKart3);
            this.Controls.Add(this.txtOyunSonucu);
            this.Name = "Form1";
            this.Text = "Savaş Araçları Oyunu";
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenOyuncuKart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenOyuncuKart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenOyuncuKart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenBilgisayarKart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenBilgisayarKart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecilenBilgisayarKart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lbOyuncuEl;
        private System.Windows.Forms.Button btnSecHamle;
        private System.Windows.Forms.Button btnYeniHamle;
        private System.Windows.Forms.ListBox lbSecilenOyuncuKartlari;
        private System.Windows.Forms.ListBox lbSecilenBilgisayarKartlari;
        private System.Windows.Forms.Label lblOyuncuSkor;
        private System.Windows.Forms.Label lblBilgisayarSkor;
        private System.Windows.Forms.PictureBox pbSecilenOyuncuKart1;
        private System.Windows.Forms.PictureBox pbSecilenOyuncuKart2;
        private System.Windows.Forms.PictureBox pbSecilenOyuncuKart3;
        private System.Windows.Forms.PictureBox pbSecilenBilgisayarKart1;
        private System.Windows.Forms.PictureBox pbSecilenBilgisayarKart2;
        private System.Windows.Forms.PictureBox pbSecilenBilgisayarKart3;
        private System.Windows.Forms.TextBox txtOyunSonucu;
    }
}
