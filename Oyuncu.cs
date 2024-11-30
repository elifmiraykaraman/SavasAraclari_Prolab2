using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class Oyuncu
    {
        public int OyuncuID { get; set; }
        public string OyuncuAdi { get; set; }
        public int Skor { get; set; }
        public List<SavasAraclari> ElKartlari { get; set; }
        public List<SavasAraclari> KullanilmisKartlar { get; set; }

        public Oyuncu(int oyuncuID, string oyuncuAdi)
        {
            OyuncuID = oyuncuID;
            OyuncuAdi = oyuncuAdi;
            Skor = 0;
            ElKartlari = new List<SavasAraclari>();
            KullanilmisKartlar = new List<SavasAraclari>();
        }

        public void KullanilmisKartlariKontrolEt()
        {
            if (ElKartlari.All(k => KullanilmisKartlar.Contains(k)))
            {
                KullanilmisKartlar.Clear();
                Console.WriteLine($"{OyuncuAdi}: Tüm kartlar kullanıldı, kartlar tekrar seçilebilir.");
            }
        }


        /*
        public int OyuncuID { get; set; }
        public string OyuncuAdi { get; set; }
        public int Skor { get; set; }
        public List<SavasAraclari> KartListesi { get; set; }

        public Oyuncu(int oyuncuID, string oyuncuAdi)
        {
            OyuncuID = oyuncuID;
            OyuncuAdi = oyuncuAdi;
            Skor = 0;
            KartListesi = new List<SavasAraclari>();
        }

        public List<SavasAraclari> KartSec(bool bilgisayarMi)
        {
            List<SavasAraclari> secilenKartlar = new List<SavasAraclari>();

            if (bilgisayarMi)
            {
                Random rnd = new Random();
                while (secilenKartlar.Count < 3 && KartListesi.Count > 0)
                {
                    int index = rnd.Next(KartListesi.Count);
                    secilenKartlar.Add(KartListesi[index]);
                    KartListesi.RemoveAt(index);
                }
            }
            else
            {
                // Oyuncu Kart secimi 


            }
            return secilenKartlar;

            
        }

        
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
                System.Windows.Forms.MessageBox.Show($"{OyuncuAdi} Skoru: {Skor}");
            }

            // Kart seçme fonksiyonu (Soyut, her oyuncu için farklı uygulanacak)
            public abstract List<SavasAraclari> KartSec();
            */

    }
}
