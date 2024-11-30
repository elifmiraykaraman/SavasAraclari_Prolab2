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
        public Oyuncu BilgisayarOyuncu { get; private set; }


        private List<SavasAraclari> TumKartlar;
        private Random rand;

        public int ToplamHamle { get; private set; } = 5;
        public int MevcutHamle { get; private set; } = 0;
        public bool OyunBitti { get; private set; } = false;
        public string OyunSonucu { get; private set; }

        private const int KilitliKartSeviyePuani = 20;

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

            // Başlangıç kartları: Uçak, Obüs, Fırkateyn
            for (int i = 0; i < 6; i++)
            {
                TumKartlar.Add(new Ucak($"Uçak{i + 1}"));
                TumKartlar.Add(new Obus($"Obüs{i + 1}"));
                TumKartlar.Add(new Firkateyn($"Fırkateyn{i + 1}"));
            }
        }

        // Başlangıç kartlarını oyunculara dağıtır
        private void DagitBaslangicKartlari()
        {
            TumKartlar = TumKartlar.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < 6; i++)
            {
                if (TumKartlar.Count > 0)
                {
                    Oyuncu.KartListesi.Add(TumKartlar[0]);
                    TumKartlar.RemoveAt(0);
                }

                if (TumKartlar.Count > 0)
                {
                    Bilgisayar.KartListesi.Add(TumKartlar[0]);
                    TumKartlar.RemoveAt(0);
                }
            }
        }

        // Yeni hamle gerçekleştirir
        public void YeniHamle(List<SavasAraclari> secilenKartlar, List<SavasAraclari> bilgisayarKartlari)
        {
            if (OyunBitti)
                return;

            MevcutHamle++;

            // Kartları karşılaştır ve skorları güncelle
            CompareCards(secilenKartlar, bilgisayarKartlari);

            // Yeni kart dağıt
            DagitYeniKartlar();

            // Oyun bitiş koşullarını kontrol et
            CheckOyunBitis();
        }

        // Kartları karşılaştırır
        private void CompareCards(List<SavasAraclari> oyuncuKartlari, List<SavasAraclari> bilgisayarKartlari)
        {
            int karsilastirmaSayisi = Math.Min(oyuncuKartlari.Count, bilgisayarKartlari.Count);

            for (int i = 0; i < karsilastirmaSayisi; i++)
            {
                var oyuncuCard = oyuncuKartlari[i];
                var bilgisayarCard = bilgisayarKartlari[i];

                int oyuncuSaldiri = HesaplaSaldiri(oyuncuCard, bilgisayarCard);
                int bilgisayarSaldiri = HesaplaSaldiri(bilgisayarCard, oyuncuCard);

                oyuncuCard.HasarAl(bilgisayarSaldiri);
                bilgisayarCard.HasarAl(oyuncuSaldiri);

                KartElemeKontrolu(oyuncuCard, bilgisayarCard);
            }
        }

        // Kartların durumunu kontrol eder
        private void KartElemeKontrolu(SavasAraclari oyuncuCard, SavasAraclari bilgisayarCard)
        {
            if (bilgisayarCard.Dayaniklilik <= 0)
            {
                Bilgisayar.KartListesi.Remove(bilgisayarCard);
                int puanArtisi = Math.Max(bilgisayarCard.SeviyePuani, 10);
                Oyuncu.Skor += puanArtisi;
            }

            if (oyuncuCard.Dayaniklilik <= 0)
            {
                Oyuncu.KartListesi.Remove(oyuncuCard);
                int puanArtisi = Math.Max(oyuncuCard.SeviyePuani, 10);
                Bilgisayar.Skor += puanArtisi;
            }
        }

        // Saldırı miktarını hesaplar
        private int HesaplaSaldiri(SavasAraclari atacan, SavasAraclari hedef)
        {
            int saldiri = atacan.VurusGucu;
            saldiri += atacan.VurusAvantaji(hedef.Sinif);
            return saldiri;
        }

        // Yeni kart dağıtır
        private void DagitYeniKartlar()
        {
            KontrolEtKilitliKartlar();
            KartlariTamamla(Oyuncu);
            KartlariTamamla(Bilgisayar);
        }

        // Kartları tamamlar
        private void KartlariTamamla(Oyuncu oyuncu)
        {
            while (oyuncu.KartListesi.Count < 6 && TumKartlar.Count > 0)
            {
                oyuncu.KartListesi.Add(TumKartlar[0]);
                TumKartlar.RemoveAt(0);
            }
        }

        // Kilitli kartların durumunu kontrol eder
        private void KontrolEtKilitliKartlar()
        {
            if (Oyuncu.ToplamSeviyePuani >= KilitliKartSeviyePuani && !Oyuncu.KilitliKartlarAcildi)
            {
                TumKartlar.AddRange(GetKilitliKartlar());
                TumKartlar = TumKartlar.OrderBy(x => rand.Next()).ToList();
                Oyuncu.KilitliKartlarAcildi = true;
            }

            if (Bilgisayar.ToplamSeviyePuani >= KilitliKartSeviyePuani && !Bilgisayar.KilitliKartlarAcildi)
            {
                TumKartlar.AddRange(GetKilitliKartlar());
                TumKartlar = TumKartlar.OrderBy(x => rand.Next()).ToList();
                Bilgisayar.KilitliKartlarAcildi = true;
            }
        }

        // Kilitli kartları oluşturur
        private List<SavasAraclari> GetKilitliKartlar()
        {
            var kilitliKartlar = new List<SavasAraclari>();
            for (int i = 0; i < 6; i++)
            {
                kilitliKartlar.Add(new Siha($"Siha{i + 1}"));
                kilitliKartlar.Add(new KFS($"KFS{i + 1}"));
                kilitliKartlar.Add(new Sida($"Sida{i + 1}"));
            }
            return kilitliKartlar;
        }

        // Oyun bitişini kontrol eder
        private void CheckOyunBitis()
        {
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
                OyunSonucu = "Oyun Berabere!";
            }
        }
    }
}
