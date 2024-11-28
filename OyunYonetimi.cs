using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class OyunYonetimi
    {
        public Oyuncu Oyuncu { get; private set; }
        public Oyuncu Bilgisayar { get; private set; }
        private List<SavasAraclari> TumKartlar;
        private Random rand;

        public int ToplamHamle { get; private set; } = 5;
        public int MevcutHamle { get; private set; } = 0;
        public bool OyunBitti { get; private set; } = false;
        public string OyunSonucu { get; private set; }

        public OyunYonetimi()
        {
            rand = new Random();
            Oyuncu = new KullaniciOyuncu(1, "Kullanıcı", 0);
            Bilgisayar = new BilgisayarOyuncu(2, "Bilgisayar", 0);
            InitializeDeck();
            DagitBaslangicKartlari();
        }

        // Kart destesini başlatır
        private void InitializeDeck()
        {
            TumKartlar = new List<SavasAraclari>();

            // Başlangıç kartları: Uçak, Obüs, Fırkateyn (6'şar adet)
            for (int i = 0; i < 6; i++)
            {
                TumKartlar.Add(new Ucak($"Uçak{i + 1}"));
                TumKartlar.Add(new Obus($"Obüs{i + 1}"));
                TumKartlar.Add(new Firkateyn($"Fırkateyn{i + 1}"));
            }

            // Kilitli kartlar: Siha, KFS, Sida (6'şar adet)
            for (int i = 0; i < 6; i++)
            {
                TumKartlar.Add(new Siha($"Siha{i + 1}"));
                TumKartlar.Add(new KFS($"KFS{i + 1}"));
                TumKartlar.Add(new Sida($"Sida{i + 1}"));
            }

            // Karıştır
            TumKartlar = TumKartlar.OrderBy(x => rand.Next()).ToList();
        }

        // Başlangıç kartlarını oyunculara dağıtır
        private void DagitBaslangicKartlari()
        {
            // Her oyuncuya 6 kart dağıtılır
            for (int i = 0; i < 6; i++)
            {
                if (TumKartlar.Count == 0) break;

                // Kullanıcıya kart dağıt
                Oyuncu.KartListesi.Add(TumKartlar[0]);
                TumKartlar.RemoveAt(0);

                if (TumKartlar.Count == 0) break;

                // Bilgisayara kart dağıt
                Bilgisayar.KartListesi.Add(TumKartlar[0]);
                TumKartlar.RemoveAt(0);
            }
        }

        // Yeni hamle gerçekleştirir
        public void YeniHamle(List<SavasAraclari> oyuncuKartlari, List<SavasAraclari> bilgisayarKartlari)
        {
            if (OyunBitti)
                return;

            MevcutHamle++;

            // Kartları karşılaştır ve skorları güncelle
            CompareCards(oyuncuKartlari, bilgisayarKartlari);

            // Yeni kart dağıt
            DagitYeniKartlar();

            // Oyun bitiş koşullarını kontrol et
            CheckOyunBitis();
        }

        // Kartları karşılaştırır ve skorları günceller
        private void CompareCards(List<SavasAraclari> oyuncuKartlari, List<SavasAraclari> bilgisayarKartlari)
        {
            int karsilastirmaSayisi = Math.Min(oyuncuKartlari.Count, bilgisayarKartlari.Count);

            for (int i = 0; i < karsilastirmaSayisi; i++)
            {
                var oyuncuCard = oyuncuKartlari[i];
                var bilgisayarCard = bilgisayarKartlari[i];

                // Oyuncu'nun saldırısı
                int oyuncuSaldiri = HesaplaSaldiri(oyuncuCard, bilgisayarCard);
                // Bilgisayar'ın saldırısı
                int bilgisayarSaldiri = HesaplaSaldiri(bilgisayarCard, oyuncuCard);

                // Dayanıklılıkların azaltılması
                //      Burda bir düzeltme yapılacak 
                bilgisayarCard.Dayaniklilik-= oyuncuSaldiri;
                oyuncuCard.Dayaniklilik -= bilgisayarSaldiri;

                // Kartların elenip elenmediğini kontrol et
                if (bilgisayarCard.Dayaniklilik <= 0)
                {
                    Bilgisayar.KartListesi.Remove(bilgisayarCard);
                    int puanArtisi = oyuncuCard.SeviyePuani >= 10 ? oyuncuCard.SeviyePuani : 10;
                    Oyuncu.Skor += puanArtisi;
                }

                if (oyuncuCard.Dayaniklilik <= 0)
                {
                    Oyuncu.KartListesi.Remove(oyuncuCard);
                    int puanArtisi = bilgisayarCard.SeviyePuani >= 10 ? bilgisayarCard.SeviyePuani : 10;
                    Bilgisayar.Skor += puanArtisi;
                }
            }
        }

        // Saldırı miktarını hesaplar
        private int HesaplaSaldiri(SavasAraclari atacan, SavasAraclari hedef)
        {
            int saldiri = atacan.VurusGucu;

            // Saldırı avantajını ekle
            saldiri += atacan.VurusAvantaji(hedef.Sinif);

            return saldiri;
        }

        // Yeni kart dağıtır
        private void DagitYeniKartlar()
        {
            // Her iki oyuncunun elindeki kart sayısını 6'ya tamamla
            while (Oyuncu.KartListesi.Count < 6 && TumKartlar.Count > 0)
            {
                Oyuncu.KartListesi.Add(TumKartlar[0]);
                TumKartlar.RemoveAt(0);
            }

            while (Bilgisayar.KartListesi.Count < 6 && TumKartlar.Count > 0)
            {
                Bilgisayar.KartListesi.Add(TumKartlar[0]);
                TumKartlar.RemoveAt(0);
            }
        }

        // Oyun bitiş koşullarını kontrol eder
        private void CheckOyunBitis()
        {
            // Hamle sayısı dolduysa veya bir tarafın elindeki kartlar tükendiyse
            if (MevcutHamle >= ToplamHamle || Oyuncu.KartListesi.Count == 0 || Bilgisayar.KartListesi.Count == 0)
            {
                OyunBitti = true;
                BelirleOyunSonucu();
            }
        }

        // Oyun sonucunu belirler
        private void BelirleOyunSonucu()
        {
            if (Oyuncu.Skor > Bilgisayar.Skor)
            {
                OyunSonucu = "Oyuncu Kazandı!";
            }
            else if (Bilgisayar.Skor > Oyuncu.Skor)
            {
                OyunSonucu = "Bilgisayar Kazandı!";
            }
            else
            {
                // Skorlar eşitse, dayanıklılıklara bak
                int oyuncuDayaniklilik = Oyuncu.KartListesi.Sum(k => k.Dayaniklilik);
                int bilgisayarDayaniklilik = Bilgisayar.KartListesi.Sum(k => k.Dayaniklilik);

                if (oyuncuDayaniklilik > bilgisayarDayaniklilik)
                {
                    OyunSonucu = "Skorlar Eşit, Oyuncu Dayanıklılık Avantajıyla Kazandı!";
                    Oyuncu.Skor += (oyuncuDayaniklilik - bilgisayarDayaniklilik);
                }
                else if (bilgisayarDayaniklilik > oyuncuDayaniklilik)
                {
                    OyunSonucu = "Skorlar Eşit, Bilgisayar Dayanıklılık Avantajıyla Kazandı!";
                    Bilgisayar.Skor += (bilgisayarDayaniklilik - oyuncuDayaniklilik);
                }
                else
                {
                    OyunSonucu = "Oyun Berabere!";
                }
            }
        }
    }
}