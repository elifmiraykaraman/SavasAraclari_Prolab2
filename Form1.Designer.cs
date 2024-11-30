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
            this.btnYeniHamle = new System.Windows.Forms.Button();
            this.flowLayoutPanelKartlar = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelBilgisayarKartlar = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnYeniHamle
            // 
            this.btnYeniHamle.Location = new System.Drawing.Point(323, 240);
            this.btnYeniHamle.Name = "btnYeniHamle";
            this.btnYeniHamle.Size = new System.Drawing.Size(174, 106);
            this.btnYeniHamle.TabIndex = 12;
            this.btnYeniHamle.Text = "Hamle Yap";
            this.btnYeniHamle.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelKartlar
            // 
            this.flowLayoutPanelKartlar.Location = new System.Drawing.Point(-1, -1);
            this.flowLayoutPanelKartlar.Name = "flowLayoutPanelKartlar";
            this.flowLayoutPanelKartlar.Size = new System.Drawing.Size(801, 148);
            this.flowLayoutPanelKartlar.TabIndex = 13;
            // 
            // flowLayoutPanelBilgisayarKartlar
            // 
            this.flowLayoutPanelBilgisayarKartlar.Location = new System.Drawing.Point(-1, 494);
            this.flowLayoutPanelBilgisayarKartlar.Name = "flowLayoutPanelBilgisayarKartlar";
            this.flowLayoutPanelBilgisayarKartlar.Size = new System.Drawing.Size(801, 156);
            this.flowLayoutPanelBilgisayarKartlar.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Crimson;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(625, 196);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "Hamle Sayısı : ";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SavasAraclari_Prolab2.Properties.Resources.ARKA_PLAN;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flowLayoutPanelBilgisayarKartlar);
            this.Controls.Add(this.flowLayoutPanelKartlar);
            this.Controls.Add(this.btnYeniHamle);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Savaş Araçları Oyunu";
            this.TransparencyKey = System.Drawing.SystemColors.Control;

          //  this.Load += new System.EventHandler(this.Form1_Load_1);
          //  this.tableLayoutPanel1.ResumeLayout(false);
          //  ((System.ComponentModel.ISupportInitialize)(this.pbBilgisayarKart6)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.pbBilgisayarKart5)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.pbBilgisayarKart4)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.pbBilgisayarKart3)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.pbBilgisayarKart2)).EndInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.pbBilgisayarKart1)).EndInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.pbOyuncuKart1)).EndInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.pbOyuncuKart2)).EndInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.pbOyuncuKart3)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.pbOyuncuKart4)).EndInit();
           // ((System.ComponentModel.ISupportInitialize)(this.pbOyuncuKart5)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.pbOyuncuKart6)).EndInit();
          //  this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYeniHamle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelKartlar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBilgisayarKartlar;
        private System.Windows.Forms.TextBox textBox1;
    }
}
