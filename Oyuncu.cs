using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavasAraclari_Prolab2
{
    public abstract class Oyuncu
    {
        public int OyuncuID { get; private set; }
        public string OyuncuAdi { get; private set; }
        public int Skor { get; set; }
        public List<SavasAraclari> KartListesi { get; private set; }
        public bool KilitliKartlarAcildi { get; set; } = false; // Kilitli kartların açılıp açılmadığını takip eder

        public int ToplamSeviyePuani
        {
            get
            {
                // Elindeki kartların toplam seviye puanını hesaplar
                return KartListesi.Sum(k => k.SeviyePuani);
            }
        }

        // Parametresiz Constructor
        protected Oyuncu()
        {
            OyuncuID = 0;
            OyuncuAdi = "Bilgisayar"; // default olarak bilgisayar
            Skor = 0;
            KartListesi = new List<SavasAraclari>();
        }

        // Parametreli Constructor
        protected Oyuncu(int oyuncuID, string oyuncuAdi, int skor)
        {
            OyuncuID = oyuncuID;
            OyuncuAdi = oyuncuAdi;
            Skor = skor;
            KartListesi = new List<SavasAraclari>();
        }

        // Skor gösterme fonksiyonu
        public void SkorGoster()
        {
            MessageBox.Show($"{OyuncuAdi} Skoru: {Skor}");
        }

        // Kart seçme fonksiyonu (Soyut, her oyuncu için farklı uygulanacak)
        public List<SavasAraclari> KartSec()
        {
            // Kart listesinden rastgele 3 kart seç
            return KartListesi
                .OrderBy(x => Guid.NewGuid()) // Rastgele sıralama
                .Take(3)                      // İlk 3 kartı al
                .ToList();
        }
    }
}
