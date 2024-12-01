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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.flowLayoutPanelKartlar.BackgroundImage = global::SavasAraclari_Prolab2.Properties.Resources.ARKA_ALT_UST;
            this.flowLayoutPanelKartlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanelKartlar.Location = new System.Drawing.Point(-1, -1);
            this.flowLayoutPanelKartlar.Name = "flowLayoutPanelKartlar";
            this.flowLayoutPanelKartlar.Size = new System.Drawing.Size(801, 148);
            this.flowLayoutPanelKartlar.TabIndex = 13;
            // 
            // flowLayoutPanelBilgisayarKartlar
            // 
            this.flowLayoutPanelBilgisayarKartlar.BackgroundImage = global::SavasAraclari_Prolab2.Properties.Resources.ARKA_ALT_UST;
            this.flowLayoutPanelBilgisayarKartlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(30, 166);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(213, 63);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox2.Location = new System.Drawing.Point(30, 396);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(213, 63);
            this.richTextBox2.TabIndex = 18;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Oynamak İstediğiniz Tur Sayısını Yazınız : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 76);
            this.button1.TabIndex = 20;
            this.button1.Text = "Oynamak için Tıklayınız";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::SavasAraclari_Prolab2.Properties.Resources.ARKA_PLAN;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flowLayoutPanelBilgisayarKartlar);
            this.Controls.Add(this.flowLayoutPanelKartlar);
            this.Controls.Add(this.btnYeniHamle);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Savaş Araçları Oyunu";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYeniHamle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelKartlar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBilgisayarKartlar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
