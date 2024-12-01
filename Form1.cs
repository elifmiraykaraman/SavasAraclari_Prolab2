using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SavasAraclari_Prolab2
{
    public partial class Form1 : Form
    {

        private List<SavasAraclari> eldekiKartlar = new List<SavasAraclari>();
        private List<SavasAraclari> kullanilmisKartlar = new List<SavasAraclari>();
        private List<SavasAraclari> secilebilirKartlar = new List<SavasAraclari>();
        private List<SavasAraclari> secilenKartlar = new List<SavasAraclari>();
        private List<SavasAraclari> bilgisayarKartlari = new List<SavasAraclari>();
        private List<SavasAraclari> bilgisayarKullanilmisKartlar = new List<SavasAraclari>();
        private List<SavasAraclari> bilgisayarSecilebilirKartlar = new List<SavasAraclari>();
        private List<SavasAraclari> bilgisayarSecilenKartlar = new List<SavasAraclari>();

        private Random rnd = new Random();

        public int oyuncuPuan = 0 ;
        public int bilgisayarPuan = 0 ;
        public int hamleSayisi = 0;
        public int istenenHamleSayisi = 0; 
        public Form1()
        {
            InitializeComponent();
            
            // Form yüklendiğinde çalışacak olay işleyiciyi bağla
            this.Load += Form1_Load;

            // Başlangıçta kartları oluşturun ve arayüze ekleyin
            KartlariOlusturVeEkle();
            
            BilgisayarKartlariOlusturVeEkle();

            // "Yeni Hamle" butonunun tıklama olayını ekleyin
            btnYeniHamle.Click += btnYeniHamle_Click;

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = true;
            textBox2.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            label1.Visible = false;
            textBox2.Visible = false;
            flowLayoutPanelKartlar.Visible = true;
            flowLayoutPanelBilgisayarKartlar.Visible = true;
            richTextBox1.Visible = true;
            richTextBox2.Visible = true;
            btnYeniHamle.Visible = true;
            textBox1.Visible = true;
            istenenHamleSayisi = int.Parse(textBox2.Text); 
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Form arka planını ayarla
            this.BackgroundImage = Properties.Resources.ARKA_PLAN; // Arka plan görseli
            this.BackgroundImageLayout = ImageLayout.Stretch;
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text = "\n" + "Oyuncu Puanı : " + oyuncuPuan.ToString();
            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.Text = "\n" + "Bilgisayar Puanı : " + bilgisayarPuan.ToString();
            textBox1.Text = "Hamle Sayısı: 0";
            label1.BackColor = Color.Transparent;
        }

        private void BilgisayarKartlariOlusturVeEkle()
        {
            // Bilgisayarın kartlarını oluşturun
            for (int i = 0; i < 6; i++)
            {
                bilgisayarKartlari.Add(RastgeleKartOlustur(false));
            }
            foreach (var kart in bilgisayarKartlari)
            {
                PictureBox pictureBoxKart1 = new PictureBox();
                pictureBoxKart1.Image = ResimGetir(kart);
                pictureBoxKart1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxKart1.Size = new Size(100, 150);
                pictureBoxKart1.Tag = kart;

                // Yeni PictureBox (üstteki resim için)
                PictureBox ustResim = new PictureBox();
                ustResim.Image = Properties.Resources.gizli; // Üst resim
                ustResim.SizeMode = PictureBoxSizeMode.StretchImage;
                ustResim.Size = pictureBoxKart1.Size; // Üst resim ana kart boyutunda
                ustResim.Location = new Point(0, 0); // Üst resmi tam olarak oturt
                ustResim.BackColor = Color.Transparent;

                // Üst resmi ana PictureBox'ın üzerine ekle
                pictureBoxKart1.Controls.Add(ustResim);


                flowLayoutPanelBilgisayarKartlar.Controls.Add(pictureBoxKart1);
            }

            // İlk tur için kartları güncelle ve göster
            BilgisayarKartlariGuncelleVeGoster();
        }
        private void KartlariOlusturVeEkle()
        {
            // Başlangıçta eldeki kartları oluşturun ve arayüze ekleyin
            for (int i = 0; i < 6; i++)
            {
                eldekiKartlar.Add(RastgeleKartOlustur(false));
            }

            // Kartları arayüze ekleyin
            foreach (var kart in eldekiKartlar)
            {
                PictureBox pictureBoxKart = new PictureBox();
                pictureBoxKart.Image = ResimGetir(kart);
                pictureBoxKart.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxKart.Size = new Size(100, 150);
                pictureBoxKart.Tag = kart;
                pictureBoxKart.Click += PictureBox_Click;

                flowLayoutPanelKartlar.Controls.Add(pictureBoxKart);
            }

            // İlk tur için kartları güncelle ve göster
            KartlariGuncelleVeGoster();
        }

        private void btnYeniHamle_Click(object sender, EventArgs e)
        {

            

            while (secilebilirKartlar.Count < 1 || bilgisayarSecilebilirKartlar.Count < 1) {
                
                // 1. Seçilen kartları işle
                HamleYap();

                // 2. Kullanılmış kartları kontrol et
                KullanilmisKartlariKontrolEt();

                // 3. Seçilebilir kartları güncelle ve ekranda göster
                KartlariGuncelleVeGoster();

                // 3.1 Bilgisayarın kartlarını güncelle ve ekranda göster
                BilgisayarKartlariGuncelleVeGoster();

                // 4. Yeni bir kart ver
                YeniKartVer();

                // 4.1 Bilgisayara yeni bir kart ver
                BilgisayaraYeniKartVer();

                // 5. Seçimleri ve arayüzü temizle
                SecimleriTemizle();
                
            }

            // 1. Seçilen kartları işle
            HamleYap();

            // 2. Kullanılmış kartları kontrol et
            KullanilmisKartlariKontrolEt();

            // 3. Seçilebilir kartları güncelle ve ekranda göster
            KartlariGuncelleVeGoster();

            // 3.1 Bilgisayarın kartlarını güncelle ve ekranda göster
            BilgisayarKartlariGuncelleVeGoster();

            // 4. Yeni bir kart ver
            YeniKartVer();

            // 4.1 Bilgisayara yeni bir kart ver
            BilgisayaraYeniKartVer();

            // 5. Seçimleri ve arayüzü temizle
            SecimleriTemizle();

            hamleSayisi++;

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Text = "\n" + "Oyuncu Puanı : " + oyuncuPuan.ToString();
            richTextBox2.SelectAll();
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.Text = "\n" + "Bilgisayar Puanı : " + bilgisayarPuan.ToString();

            textBox1.Text = "Hamle Sayısı: " + hamleSayisi.ToString();

            OyunBittiMi();
        }

        private void HamleYap()
        {
            if (secilenKartlar.Count != 3)
            {
                MessageBox.Show("Lütfen 3 kart seçiniz.");
                return;
            }

            var bilgisayarSecilenKartlar= BilgisayarKartSec();


            if (bilgisayarSecilenKartlar.Count != 3)
            {
                MessageBox.Show("Bilgisayar yeterli karta sahip değil.");
                return;
            }

            // Saldırı hesaplamaları
            SaldiriHesapla(secilenKartlar, bilgisayarSecilenKartlar);

            // Kullanılmış kartları güncelle
            kullanilmisKartlar.AddRange(secilenKartlar);
            bilgisayarKullanilmisKartlar.AddRange(bilgisayarSecilenKartlar);

            // Seçilen kartları temizle
            secilenKartlar.Clear();
            bilgisayarSecilenKartlar.Clear();
        }

        private void BilgisayaraYeniKartVer()
        {
            // Yeni kart oluştur
            SavasAraclari yeniKart = RastgeleKartOlustur(bilgisayarKartlari.Count >= 20);

            // Kartı bilgisayarın kartlarına ekle
            bilgisayarKartlari.Add(yeniKart);

            // Kartları panale ekleyin
            foreach (var kart in bilgisayarSecilebilirKartlar)
            {
                PictureBox pictureBoxKart1 = new PictureBox();
                pictureBoxKart1.Image = ResimGetir(kart);
                pictureBoxKart1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxKart1.Size = new Size(100, 150);
                pictureBoxKart1.Tag = kart;

                // Yeni PictureBox (üstteki resim için)
                PictureBox ustResim = new PictureBox();
                ustResim.Image = Properties.Resources.gizli; // Üst resim
                ustResim.SizeMode = PictureBoxSizeMode.StretchImage;
                ustResim.Size = pictureBoxKart1.Size; // Üst resim ana kart boyutunda
                ustResim.Location = new Point(0, 0); // Üst resmi tam olarak oturt
                ustResim.BackColor = Color.Transparent;

                // Üst resmi ana PictureBox'ın üzerine ekle
                pictureBoxKart1.Controls.Add(ustResim);

                

                flowLayoutPanelBilgisayarKartlar.Controls.Add(pictureBoxKart1);
            }
        }

        private void KullanilmisKartlariKontrolEt()
        {
            if (eldekiKartlar.All(k => kullanilmisKartlar.Contains(k)))
            {
                // Tüm kartlar kullanıldı, kullanılmış kartları sıfırla
                kullanilmisKartlar.Clear();
                MessageBox.Show("Tüm kartlar kullanıldı, kartlar tekrar seçilebilir.");
            }
            if (bilgisayarKartlari.All(k => bilgisayarKullanilmisKartlar.Contains(k)))
            {
                // Bilgisayarın tüm kartları kullanıldı, kullanılmış kartları sıfırla
                bilgisayarKullanilmisKartlar.Clear();
            }
        }

        private void KartlariGuncelleVeGoster()
        {
            // Paneldeki tüm kontrolleri temizleyin
            flowLayoutPanelKartlar.Controls.Clear();
            // Seçilebilir kartları güncelle
            secilebilirKartlar = eldekiKartlar.Except(kullanilmisKartlar).ToList();

            foreach (var kart in secilebilirKartlar)
            {
                PictureBox pictureBoxKart = new PictureBox();
                pictureBoxKart.Image = ResimGetir(kart);
                pictureBoxKart.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxKart.Size = new Size(100, 150);
                pictureBoxKart.Tag = kart;
                pictureBoxKart.Click += PictureBox_Click;

                // Kart seçilebilir
                pictureBoxKart.Enabled = true;
                pictureBoxKart.BackColor = Color.Transparent;


                flowLayoutPanelKartlar.Controls.Add(pictureBoxKart);
            }
            
        }

        private void BilgisayarKartlariGuncelleVeGoster()
        {
            // Paneldeki tüm kontrolleri temizleyin
            flowLayoutPanelBilgisayarKartlar.Controls.Clear();
            // Bilgisayarın seçilebilir kartlarını güncelle
            bilgisayarSecilebilirKartlar = bilgisayarKartlari.Except(bilgisayarKullanilmisKartlar).ToList();

            
            // Kartları panale ekleyin
            foreach (var kart in bilgisayarSecilebilirKartlar)
            {
                PictureBox pictureBoxKart1 = new PictureBox();
                pictureBoxKart1.Image = ResimGetir(kart);
                pictureBoxKart1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxKart1.Size = new Size(100, 150);
                pictureBoxKart1.Tag = kart;

                // Yeni PictureBox (üstteki resim için)
                PictureBox ustResim = new PictureBox();
                ustResim.Image = Properties.Resources.gizli; // Üst resim
                ustResim.SizeMode = PictureBoxSizeMode.StretchImage;
                ustResim.Size = pictureBoxKart1.Size; // Üst resim ana kart boyutunda
                ustResim.Location = new Point(0, 0); // Üst resmi tam olarak oturt
                ustResim.BackColor = Color.Transparent;

                // Üst resmi ana PictureBox'ın üzerine ekle
                pictureBoxKart1.Controls.Add(ustResim);

                // Kart seçilebilir
                pictureBoxKart1.Enabled = true;
                pictureBoxKart1.BackColor = Color.Transparent;
                
                flowLayoutPanelBilgisayarKartlar.Controls.Add(pictureBoxKart1);
            }
            
        }

        private void YeniKartVer()
        {
            // Yeni kart oluştur
            SavasAraclari yeniKart = RastgeleKartOlustur(eldekiKartlar.Count >= 20);

            // Kartı eldeki kartlara ekle
            eldekiKartlar.Add(yeniKart);

            // Kartın görselini ve kontrolünü oluştur
            PictureBox pictureBoxYeniKart = new PictureBox();
            pictureBoxYeniKart.Image = ResimGetir(yeniKart);
            pictureBoxYeniKart.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxYeniKart.Size = new Size(100, 150);
            pictureBoxYeniKart.Tag = yeniKart;
            pictureBoxYeniKart.Click += PictureBox_Click;

            // Kartı arayüze ekleyin
            flowLayoutPanelKartlar.Controls.Add(pictureBoxYeniKart);
        }

        private void SecimleriTemizle()
        {
            // Seçilen kartları temizle
            secilenKartlar.Clear();
            bilgisayarSecilenKartlar.Clear();

            // Tüm PictureBox'ların arka plan rengini sıfırlayın
            foreach (Control control in flowLayoutPanelKartlar.Controls)
            {
                if (control is PictureBox)
                {
                    control.BackColor = Color.Transparent;
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (secilenKartlar.Count >= 3)
            {
                MessageBox.Show("En fazla 3 kart seçebilirsiniz.");
                return;
            }

            PictureBox pictureBox = sender as PictureBox;
            SavasAraclari kart = pictureBox.Tag as SavasAraclari;

            if (kart != null)
            {
                if (kullanilmisKartlar.Contains(kart))
                {
                    MessageBox.Show("Bu kart daha önce kullanıldı.");
                    return;
                }

                if (secilenKartlar.Contains(kart))
                {
                    
                    secilenKartlar.Remove(kart);
                    pictureBox.BackColor = Color.Transparent;
                }
                else
                {
                   
                    secilenKartlar.Add(kart);
                    pictureBox.BackColor = Color.LightBlue;
                }
            }
        }


        private List<SavasAraclari> BilgisayarKartSec()
        {
            
            bilgisayarSecilebilirKartlar = bilgisayarKartlari.Except(bilgisayarKullanilmisKartlar).ToList();

            

            while (bilgisayarSecilenKartlar.Count < 3 && bilgisayarSecilebilirKartlar.Count > 0)
            {
                int index = rnd.Next(bilgisayarSecilebilirKartlar.Count);
                var secilenKart = bilgisayarSecilebilirKartlar[index];
                bilgisayarSecilenKartlar.Add(secilenKart);
                bilgisayarSecilebilirKartlar.RemoveAt(index);
            }

            return bilgisayarSecilenKartlar;
        }

        private void SaldiriHesapla(List<SavasAraclari> oyuncuKartlari, List<SavasAraclari> bilgisayarKartlari)
        {
            int karsilastirmaSayisi = Math.Min(oyuncuKartlari.Count, bilgisayarKartlari.Count);
            for (int i = 0; i < karsilastirmaSayisi; i++)
            {
                var oyuncuKart = oyuncuKartlari[i];
                var bilgisayarKart = bilgisayarKartlari[i];

                int oyuncuHasar = oyuncuKart.Vurus;
                int bilgisayarHasar = bilgisayarKart.Vurus;

               
                oyuncuHasar = SinifAvantajiHesapla(oyuncuKart, bilgisayarKart, oyuncuHasar);
                bilgisayarHasar = SinifAvantajiHesapla(bilgisayarKart, oyuncuKart, bilgisayarHasar);

                
                oyuncuKart.DurumGuncelle(oyuncuKart,bilgisayarKart,bilgisayarHasar);
                bilgisayarKart.DurumGuncelle(bilgisayarKart, oyuncuKart, oyuncuHasar);

                
                if (oyuncuKart.Dayaniklilik <= 0)
                {
                    bilgisayarPuan = bilgisayarPuan + 10;
                    eldekiKartlar.Remove(oyuncuKart);
                    flowLayoutPanelKartlar.Controls.RemoveByKey(oyuncuKart.KartAdi);
                    
                }

                if (bilgisayarKart.Dayaniklilik <= 0)
                {
                    oyuncuPuan = oyuncuPuan + 10;
                    bilgisayarKartlari.Remove(bilgisayarKart);
                    flowLayoutPanelBilgisayarKartlar.Controls.RemoveByKey(bilgisayarKart.KartAdi);
                     
                }
            }
        }

        private int SinifAvantajiHesapla(SavasAraclari saldiranKart, SavasAraclari savunanKart, int hasar)
        {
            if (saldiranKart.KartAdi.Contains("Obus") && savunanKart.Sinif == "Deniz") 
            {   
                hasar = hasar + 5;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("KFS") &&  savunanKart.Sinif == "Deniz")
            {
                hasar = hasar + 10;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("KFS") && savunanKart.Sinif == "Hava")
            {
                hasar = hasar + 20;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("Ucak") && savunanKart.Sinif == "Kara")
            {
                hasar = hasar + 10;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("Siha") && savunanKart.Sinif == "Kara")
            {
                hasar = hasar + 10;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("Siha") && savunanKart.Sinif == "Deniz")
            {
                hasar = hasar + 10;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("Firkateyn") && savunanKart.Sinif == "Hava")
            { 
                hasar = hasar + 5;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("Sida") && savunanKart.Sinif == "Kara")
            {
                hasar = hasar + 10;
                return hasar;
            }
            if (saldiranKart.KartAdi.Contains("Sida") && savunanKart.Sinif == "Hava")
            {
                hasar = hasar + 10;
                return hasar;
            }
            return hasar;
        }

        private SavasAraclari RastgeleKartOlustur(bool kilitliKartlarAcik)
        {
            int kartTipi = rnd.Next(1, kilitliKartlarAcik ? 7 : 4);

            switch (kartTipi)
            {
                case 1: return new Ucak();
                case 2: return new Obus();
                case 3: return new Firkateyn();
                case 4: return new Siha();
                case 5: return new KFS();
                case 6: return new Sida();
                default: return new Ucak();
            }
        }

        private Image ResimGetir(SavasAraclari kart)
        {
           
                if (kart is Ucak)
                    return Properties.Resources.Ucak;
                else if (kart is Obus)
                    return Properties.Resources.Obus;
                else if (kart is Firkateyn)
                    return Properties.Resources.Firkateyn;
                else if (kart is Siha)
                    return Properties.Resources.Siha;
                else if (kart is KFS)
                    return Properties.Resources.KFS;
                else if (kart is Sida)
                    return Properties.Resources.Sida;
                else
                    return null;
            
            
        }

        private void OyunBittiMi()
        {   
            if(hamleSayisi == istenenHamleSayisi)
            {
                KimKazandi(eldekiKartlar,bilgisayarKartlari);
                DialogResult result = MessageBox.Show("Oyun sona erdi.Tekrardan başlamak istermisiniz?", "Oyun Sonu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Oyun yeniden başlatılıyor...");
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }

        }

        private void KimKazandi(List<SavasAraclari> oyuncu_kartlari,List<SavasAraclari> bilgisayar_kartlari)
        {
            int oyuncu_toplam_dayaniklilik = 0;
            int bilgisayar_toplam_dayaniklilik = 0;

            for (int i = 0; i<oyuncu_kartlari.Count; i++) {
                oyuncu_toplam_dayaniklilik += oyuncu_kartlari[i].Dayaniklilik;
                
            }
            for (int i = 0; i < bilgisayar_kartlari.Count; i++)
            {
                bilgisayar_toplam_dayaniklilik += bilgisayar_kartlari[i].Dayaniklilik;

            }

            if (oyuncu_toplam_dayaniklilik > bilgisayar_toplam_dayaniklilik)
            {
                MessageBox.Show("Tebrikler Kazandınız!!!");
            }
            if(bilgisayar_toplam_dayaniklilik > oyuncu_toplam_dayaniklilik)
            {
                MessageBox.Show("Malesef kaybettiniz.Bilgisayar Kazandı!!!");
            }

        }
    }
}
