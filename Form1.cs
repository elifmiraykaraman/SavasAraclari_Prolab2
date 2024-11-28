using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SavasAraclari_Prolab2
{
    public partial class Form1 : Form
    {
        private GameManager oyunYonetimi;
        

        public Form1()
        {
            InitializeComponent();
            GameManager Oyunyonetimi = new GameManager();  
            GuncelleUI();
            
        }

        private void GuncelleUI()
        {
            // Oyuncunun elindeki kartları güncelle
            lbOyuncuEl.Items.Clear();
            foreach (var kart in oyunYonetimi.Oyuncu.KartListesi)
            {
                lbOyuncuEl.Items.Add(kart.ToString());
            }

            // Skorları güncelle
            lblOyuncuSkor.Text = $"Oyuncu Skor: {oyunYonetimi.Oyuncu.Skor}";
            lblBilgisayarSkor.Text = $"Bilgisayar Skor: {oyunYonetimi.Bilgisayar.Skor}";

            // PictureBox'ları temizle
            pbSecilenOyuncuKart1.Image = null;
            pbSecilenOyuncuKart2.Image = null;
            pbSecilenOyuncuKart3.Image = null;
            pbSecilenBilgisayarKart1.Image = null;
            pbSecilenBilgisayarKart2.Image = null;
            pbSecilenBilgisayarKart3.Image = null;
        }

        private void btnSecHamle_Click(object sender, EventArgs e)
        {
            // Oyuncu kart seçimi kontrolü
            if (lbOyuncuEl.SelectedItems.Count != 3)
            {
                MessageBox.Show("Lütfen 3 kart seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen kartları al
            List<SavasAraclari> oyuncuKartlari = new List<SavasAraclari>();
            foreach (var item in lbOyuncuEl.SelectedItems)
            {
                var kart = oyunYonetimi.Oyuncu.KartListesi.FirstOrDefault(k => k.ToString() == item.ToString());
                if (kart != null)
                {
                    oyuncuKartlari.Add(kart);
                }
            }

            // Bilgisayar kart seçimi
            List<SavasAraclari> bilgisayarKartlari = oyunYonetimi.Bilgisayar.KartSec();

            // Hamleyi gerçekleştir
            oyunYonetimi.YeniHamle(oyuncuKartlari, bilgisayarKartlari);

            // UI'yı güncelle
            GuncelleUI();

            // Oyun bitti mi kontrol et
            if (oyunYonetimi.OyunBitti)
            {
                MessageBox.Show(oyunYonetimi.OyunSonucu, "Oyun Sonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
