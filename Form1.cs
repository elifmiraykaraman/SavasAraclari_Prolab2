using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SavasAraclari_Prolab2
{
    public partial class Form1 : Form
    {
        private OyunYonetimi oyunYonetimi; // Oyun yönetimi nesnesi
        private List<Kart> secilenKartlar = new List<Kart>(); // Oyuncunun seçtiği kartlar
        private PictureBox[] pbOyuncuKartlar; // Oyuncu kartlarını temsil eden PictureBox'lar

        public Form1()
        {
            InitializeComponent();

            // Oyun yönetimini başlat
            oyunYonetimi = new OyunYonetimi();

            // Alt satırdaki PictureBox'ları bir diziye al
            pbOyuncuKartlar = new PictureBox[]
            {
                pbOyuncuKart1, pbOyuncuKart2, pbOyuncuKart3,
                pbOyuncuKart4, pbOyuncuKart5, pbOyuncuKart6
            };

            // Oyuncu kartlarına tıklama olaylarını bağla
            foreach (var pb in pbOyuncuKartlar)
            {
                pb.Click += OyuncuKart_Click;
            }

            // UI'yi güncelle
            GuncelleUI();
        }

        private void GuncelleUI()
        {
            // Oyuncunun elindeki kartları güncelle
            var oyuncuKartlari = oyunYonetimi.Oyuncu.KartListesi;

            for (int i = 0; i < pbOyuncuKartlar.Length; i++)
            {
                if (i < oyuncuKartlari.Count)
                {
                    pbOyuncuKartlar[i].Image = oyuncuKartlari[i].Image; // Kart görselini ayarla
                    pbOyuncuKartlar[i].Enabled = true; // Tıklanabilir yap
                    pbOyuncuKartlar[i].Tag = oyuncuKartlari[i]; // Kartı Tag ile ilişkilendir
                }
                else
                {
                    pbOyuncuKartlar[i].Image = null; // Görseli temizle
                    pbOyuncuKartlar[i].Enabled = false; // Tıklanamaz yap
                    pbOyuncuKartlar[i].Tag = null; // İlişkiyi kaldır
                }
            }

            // Seçilen kartları sıfırla
            secilenKartlar.Clear();

            // Seçim görsellerini sıfırla
            foreach (var pb in pbOyuncuKartlar)
            {
                pb.BorderStyle = BorderStyle.None;
            }
        }

        private void OyuncuKart_Click(object sender, EventArgs e)
        {
            // Tıklanan PictureBox'ı al
            PictureBox pb = sender as PictureBox;

            if (pb != null && pb.Tag is Kart kart)
            {
                if (secilenKartlar.Contains(kart))
                {
                    // Kart zaten seçiliyse, seçimi kaldır
                    secilenKartlar.Remove(kart);
                    pb.BorderStyle = BorderStyle.None;
                }
                else
                {
                    if (secilenKartlar.Count < 3)
                    {
                        // Yeni kartı seç
                        secilenKartlar.Add(kart);
                        pb.BorderStyle = BorderStyle.FixedSingle;
                    }
                    else
                    {
                        MessageBox.Show("En fazla 3 kart seçebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSecHamle_Click(object sender, EventArgs e)
        {
            // Oyuncu kart seçimi kontrolü
            if (secilenKartlar.Count != 3)
            {
                MessageBox.Show("Lütfen 3 kart seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bilgisayar kart seçimi
            List<Kart> bilgisayarKartlari = oyunYonetimi.Bilgisayar.KartSec();

            // Hamleyi gerçekleştir
            oyunYonetimi.YeniHamle(secilenKartlar, bilgisayarKartlari);

            // UI'yı güncelle
            GuncelleUI();

            // Oyun bitti mi kontrol et
            if (oyunYonetimi.OyunBitti)
            {
                // Skorları MessageBox ile göster
                string sonucMesaji = $"Oyun Bitti!\n\n" +
                                     $"Oyuncu Skor: {oyunYonetimi.Oyuncu.Skor}\n" +
                                     $"Bilgisayar Skor: {oyunYonetimi.Bilgisayar.Skor}\n\n" +
                                     $"Sonuç: {oyunYonetimi.OyunSonucu}";

                MessageBox.Show(sonucMesaji, "Oyun Sonu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Oyun yeniden başlatılır
                YeniOyun();
            }
        }

        private void YeniOyun()
        {
            // Yeni bir oyun başlat
            oyunYonetimi = new OyunYonetimi();
            GuncelleUI();
        }

        private void btnYenidenBaslat_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan onay al
            var result = MessageBox.Show("Oyunu yeniden başlatmak istediğinize emin misiniz?", "Yeniden Başlat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                YeniOyun();
            }
        }
    }
}
