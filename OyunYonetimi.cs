using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SavasAraclari_Prolab2
{
    public class OyunYonetimi
    {
        public Oyuncu oyuncu;
        public Oyuncu bilgisayar;
        private int hamleSayisi;

        public OyunYonetimi()
        {
            oyuncu = new Oyuncu(1, "Oyuncu");
            bilgisayar = new Oyuncu(2, "Bilgisayar");
            hamleSayisi = 0;
        }

        public void OyunuBaslat()
        {
            SayaclariSifirla();
            KartlariDagit();

            while (hamleSayisi < 5 && oyuncu.ElKartlari.Count > 0 && bilgisayar.ElKartlari.Count > 0)
            {
                hamleSayisi++;
                Console.WriteLine($"\n--- {hamleSayisi}. Hamle ---");

                var oyuncuKartlari = oyuncu.ElKartlari.Except(oyuncu.KullanilmisKartlar).Take(3).ToList();
                var bilgisayarKartlari = bilgisayar.ElKartlari.Except(bilgisayar.KullanilmisKartlar).Take(3).ToList();

                SaldiriHesapla(oyuncuKartlari, bilgisayarKartlari);

                YeniKartVer(oyuncu);
                YeniKartVer(bilgisayar);

                KilitliKartlariKontrolEt(oyuncu);
                KilitliKartlariKontrolEt(bilgisayar);

                oyuncu.KullanilmisKartlariKontrolEt();
                bilgisayar.KullanilmisKartlariKontrolEt();

                if (oyuncu.ElKartlari.Count == 0 || bilgisayar.ElKartlari.Count == 0)
                    break;
            }

            OyunuBitir();
        }

        private void SayaclariSifirla()
        {
            Ucak.SayacSifirla();
            Obus.SayacSifirla();
            Firkateyn.SayacSifirla();
            Siha.SayacSifirla();
            KFS.SayacSifirla();
            Sida.SayacSifirla();
        }

        private void KartlariDagit()
        {
            for (int i = 0; i < 6; i++)
            {
                oyuncu.ElKartlari.Add(RastgeleKartOlustur(false));
                bilgisayar.ElKartlari.Add(RastgeleKartOlustur(false));
            }
        }

        private void YeniKartVer(Oyuncu oyuncu)
        {
            bool kilitliKartlarAcik = oyuncu.Skor >= 20;
            var yeniKart = RastgeleKartOlustur(kilitliKartlarAcik);
            oyuncu.ElKartlari.Add(yeniKart);
        }

        private void KilitliKartlariKontrolEt(Oyuncu oyuncu)
        {
            if (oyuncu.Skor >= 20 && !oyuncu.ElKartlari.Any(k => k is Siha || k is KFS || k is Sida))
            {
                oyuncu.ElKartlari.Add(new Siha());
                oyuncu.ElKartlari.Add(new KFS());
                oyuncu.ElKartlari.Add(new Sida());
            }
        }

        private void SaldiriHesapla(List<SavasAraclari> oyuncuKartlari, List<SavasAraclari> bilgisayarKartlari)
        {
            for (int i = 0; i < oyuncuKartlari.Count; i++)
            {
                var oyuncuKart = oyuncuKartlari[i];
                var bilgisayarKart = bilgisayarKartlari[i];

                int oyuncuHasar = oyuncuKart.Vurus;
                int bilgisayarHasar = bilgisayarKart.Vurus;

                // Sınıf avantajlarını hesaplayın
                oyuncuHasar = SinifAvantajiHesapla(oyuncuKart, bilgisayarKart, oyuncuHasar);
                bilgisayarHasar = SinifAvantajiHesapla(bilgisayarKart, oyuncuKart, bilgisayarHasar);

                // Kartların durumunu güncelleyin
                oyuncuKart.DurumGuncelle(bilgisayarHasar);
                bilgisayarKart.DurumGuncelle(oyuncuHasar);

                // Skorları güncelleyin
                oyuncu.Skor += oyuncuKart.SeviyePuani;
                bilgisayar.Skor += bilgisayarKart.SeviyePuani;

                // Kullanılmış kartlara ekleyin
                oyuncu.KullanilmisKartlar.Add(oyuncuKart);
                bilgisayar.KullanilmisKartlar.Add(bilgisayarKart);
            }
        }

        private int SinifAvantajiHesapla(SavasAraclari saldiranKart, SavasAraclari savunanKart, int hasar)
        {
            // Örnek sınıf avantajları
            if (saldiranKart.Sinif == "Hava" && savunanKart.Sinif == "Kara")
            {
                hasar += saldiranKart.Vurus * 20 / 100;
            }
            else if (saldiranKart.Sinif == "Kara" && savunanKart.Sinif == "Deniz")
            {
                hasar += saldiranKart.Vurus * 20 / 100;
            }
            else if (saldiranKart.Sinif == "Deniz" && savunanKart.Sinif == "Hava")
            {
                hasar += saldiranKart.Vurus * 20 / 100;
            }

            return hasar;
        }

        private SavasAraclari RastgeleKartOlustur(bool kilitliKartlarAcik)
        {
            Random rnd = new Random();
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

        private void OyunuBitir()
        {
            Console.WriteLine("\n--- Oyun Bitti ---");
            Console.WriteLine($"{oyuncu.OyuncuAdi} Skor: {oyuncu.Skor}");
            Console.WriteLine($"{bilgisayar.OyuncuAdi} Skor: {bilgisayar.Skor}");

            if (oyuncu.Skor > bilgisayar.Skor)
                Console.WriteLine("Oyunu Kazandınız!");
            else if (oyuncu.Skor < bilgisayar.Skor)
                Console.WriteLine("Bilgisayar Kazandı!");
            else
                Console.WriteLine("Oyun Berabere!");
        }
        /*
        public Oyuncu oyuncu;
        public Oyuncu bilgisayar;
        private int hamleSayisi;

        public OyunYonetimi()
        {
            oyuncu = new Oyuncu(1, "Oyuncu");
            bilgisayar = new Oyuncu(2, "Bilgisayar");
            hamleSayisi = 0;
        }

        public void OyunuBaslat()
        {
            SayaclariSifirla();
            KartlariDagit();

            while (hamleSayisi < 5 && oyuncu.ElKartlari.Count > 0 && bilgisayar.ElKartlari.Count > 0)
            {
                hamleSayisi++;
                Console.WriteLine($"\n--- {hamleSayisi}. Hamle ---");

                var oyuncuKartlari = oyuncu.ElKartlari.Except(oyuncu.KullanilmisKartlar).Take(3).ToList();
                var bilgisayarKartlari = bilgisayar.ElKartlari.Except(bilgisayar.KullanilmisKartlar).Take(3).ToList();

                SaldiriHesapla(oyuncuKartlari, bilgisayarKartlari);

                YeniKartVer(oyuncu);
                YeniKartVer(bilgisayar);

                KilitliKartlariKontrolEt(oyuncu);
                KilitliKartlariKontrolEt(bilgisayar);

                oyuncu.KullanilmisKartlariKontrolEt();
                bilgisayar.KullanilmisKartlariKontrolEt();

                if (oyuncu.ElKartlari.Count == 0 || bilgisayar.ElKartlari.Count == 0)
                    break;
            }

            OyunuBitir();
        }

        private void SayaclariSifirla()
        {
            Ucak.SayacSifirla();
            Obus.SayacSifirla();
            Firkateyn.SayacSifirla();
            Siha.SayacSifirla();
            KFS.SayacSifirla();
            Sida.SayacSifirla();
        }

        private void KartlariDagit()
        {
            for (int i = 0; i < 6; i++)
            {
                oyuncu.ElKartlari.Add(RastgeleKartOlustur(false));
                bilgisayar.ElKartlari.Add(RastgeleKartOlustur(false));
            }
        }

        private void YeniKartVer(Oyuncu oyuncu)
        {
            bool kilitliKartlarAcik = oyuncu.Skor >= 20;
            var yeniKart = RastgeleKartOlustur(kilitliKartlarAcik);
            oyuncu.ElKartlari.Add(yeniKart);
        }

        private void KilitliKartlariKontrolEt(Oyuncu oyuncu)
        {
            if (oyuncu.Skor >= 20 && !oyuncu.ElKartlari.Any(k => k is Siha || k is KFS || k is Sida))
            {
                oyuncu.ElKartlari.Add(new Siha());
                oyuncu.ElKartlari.Add(new KFS());
                oyuncu.ElKartlari.Add(new Sida());
            }
        }

        private void SaldiriHesapla(List<SavasAraclari> oyuncuKartlari, List<SavasAraclari> bilgisayarKartlari)
        {
            for (int i = 0; i < oyuncuKartlari.Count; i++)
            {
                var oyuncuKart = oyuncuKartlari[i];
                var bilgisayarKart = bilgisayarKartlari[i];

                int oyuncuHasar = oyuncuKart.Vurus;
                int bilgisayarHasar = bilgisayarKart.Vurus;

                // Sınıf avantajlarını hesaplayın
                oyuncuHasar = SinifAvantajiHesapla(oyuncuKart, bilgisayarKart, oyuncuHasar);
                bilgisayarHasar = SinifAvantajiHesapla(bilgisayarKart, oyuncuKart, bilgisayarHasar);

                // Kartların durumunu güncelleyin
                oyuncuKart.DurumGuncelle(bilgisayarHasar);
                bilgisayarKart.DurumGuncelle(oyuncuHasar);

                // Skorları güncelleyin
                oyuncu.Skor += oyuncuKart.SeviyePuani;
                bilgisayar.Skor += bilgisayarKart.SeviyePuani;

                // Kullanılmış kartlara ekleyin
                oyuncu.KullanilmisKartlar.Add(oyuncuKart);
                bilgisayar.KullanilmisKartlar.Add(bilgisayarKart);
            }
        }

        private int SinifAvantajiHesapla(SavasAraclari saldiranKart, SavasAraclari savunanKart, int hasar)
        {
            // Örnek sınıf avantajları
            if (saldiranKart.Sinif == "Hava" && savunanKart.Sinif == "Kara")
            {
                hasar += saldiranKart.Vurus * 20 / 100;
            }
            else if (saldiranKart.Sinif == "Kara" && savunanKart.Sinif == "Deniz")
            {
                hasar += saldiranKart.Vurus * 20 / 100;
            }
            else if (saldiranKart.Sinif == "Deniz" && savunanKart.Sinif == "Hava")
            {
                hasar += saldiranKart.Vurus * 20 / 100;
            }

            return hasar;
        }

        private SavasAraclari RastgeleKartOlustur(bool kilitliKartlarAcik)
        {
            Random rnd = new Random();
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

        private void OyunuBitir()
        {
            Console.WriteLine("\n--- Oyun Bitti ---");
            Console.WriteLine($"{oyuncu.OyuncuAdi} Skor: {oyuncu.Skor}");
            Console.WriteLine($"{bilgisayar.OyuncuAdi} Skor: {bilgisayar.Skor}");

            if (oyuncu.Skor > bilgisayar.Skor)
                Console.WriteLine("Oyunu Kazandınız!");
            else if (oyuncu.Skor < bilgisayar.Skor)
                Console.WriteLine("Bilgisayar Kazandı!");
            else
                Console.WriteLine("Oyun Berabere!");
        }

        */
        /*
        public Oyuncu Oyuncu { get; private set; }
        public Oyuncu Bilgisayar { get; private set; }
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

            // Başlangıç kartları: Uçak, Obüs, Fırkateyn (6'şar adet)
            for (int i = 0; i < 6; i++)
            {
                TumKartlar.Add(new Ucak($"Uçak{i + 1}"));
                TumKartlar.Add(new Obus($"Obüs{i + 1}"));
                TumKartlar.Add(new Firkateyn($"Fırkateyn{i + 1}"));
            }

            // Kilitli kartlar: Siha, KFS, Sida (6'şar adet)
            // Bu kartlar başlangıçta dağıtıma dahil edilmeyecek
        }

        // Başlangıç kartlarını oyunculara dağıtır
        private void DagitBaslangicKartlari()
        {
            // Karıştır
            TumKartlar = TumKartlar.OrderBy(x => rand.Next()).ToList();

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
        public void YeniHamle()
        {
            if (OyunBitti)
                return;

            MevcutHamle++;

            // Kullanıcı kartlarını seçer
            var oyuncuKartlari = OyuncuKartSecimi();

            // Bilgisayar kartlarını seçer
            var bilgisayarKartlari = BilgisayarKartSecimi();

            // Kartları karşılaştır ve skorları güncelle
            CompareCards(oyuncuKartlari, bilgisayarKartlari);

            // Yeni kart dağıt
            DagitYeniKartlar();

            // Oyun bitiş koşullarını kontrol et
            CheckOyunBitis();
        }

        // Kullanıcının kart seçim işlemi
        private List<SavasAraclari> OyuncuKartSecimi()
        {
            // Kullanıcı arayüzü olmadığı için ilk 3 kartı seçiyoruz
            // Gerçek uygulamada kullanıcıdan seçim alınmalıdır

            var secilebilirKartlar = Oyuncu.KartListesi.Where(k => !k.Secildi).ToList();

            // Eğer seçilebilir kart sayısı 3'ten az ise, seçimleri sıfırla
            if (secilebilirKartlar.Count < 3)
            {
                ResetSecim(Oyuncu.KartListesi);
                secilebilirKartlar = Oyuncu.KartListesi;
            }

            var secilenKartlar = secilebilirKartlar.Take(3).ToList();

            MarkKartlarAsSecildi(secilenKartlar);

            return secilenKartlar;
        }

        // Bilgisayarın kart seçim işlemi
        private List<SavasAraclari> BilgisayarKartSecimi()
        {
            var secilebilirKartlar = Bilgisayar.KartListesi.Where(k => !k.Secildi).ToList();

            // Eğer seçilebilir kart sayısı 3'ten az ise, seçimleri sıfırla
            if (secilebilirKartlar.Count < 3)
            {
                ResetSecim(Bilgisayar.KartListesi);
                secilebilirKartlar = Bilgisayar.KartListesi;
            }

            // Rastgele 3 kart seç
            var secilenKartlar = secilebilirKartlar.OrderBy(x => rand.Next()).Take(3).ToList();

            MarkKartlarAsSecildi(secilenKartlar);

            return secilenKartlar;
        }

        // Kart seçimlerini sıfırlar
        private void ResetSecim(List<SavasAraclari> kartListesi)
        {
            foreach (var kart in kartListesi)
            {
                kart.Secildi = false;
            }
        }

        // Kartları seçilmiş olarak işaretler
        private void MarkKartlarAsSecildi(List<SavasAraclari> kartlar)
        {
            foreach (var kart in kartlar)
            {
                kart.Secildi = true;
            }
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
                oyuncuCard.HasarAl(bilgisayarSaldiri);
                bilgisayarCard.HasarAl(oyuncuSaldiri);

                // Kartların elenip elenmediğini kontrol et
                KartElemeKontrolu(oyuncuCard, bilgisayarCard);
            }
        }

        // Kartları karşılaştırır ve skorları günceller
        private void KartElemeKontrolu(SavasAraclari oyuncuCard, SavasAraclari bilgisayarCard)
        {
            if (bilgisayarCard.Dayaniklilik <= 0)
            {
                Bilgisayar.KartListesi.Remove(bilgisayarCard);
                int puanArtisi = Math.Max(bilgisayarCard.SeviyePuani, 10);
                Oyuncu.Skor += puanArtisi;
                oyuncuCard.SeviyePuani += puanArtisi; // Düzeltilmiş: oyuncuCard yerine OyuncuCard yok
            }

            if (oyuncuCard.Dayaniklilik <= 0)
            {
                Oyuncu.KartListesi.Remove(oyuncuCard);
                int puanArtisi = Math.Max(oyuncuCard.SeviyePuani, 10);
                Bilgisayar.Skor += puanArtisi;
                bilgisayarCard.SeviyePuani += puanArtisi; // Düzeltilmiş: bilgisayarCard yerine BilgisayarCard yok
            }
        }

        // Saldırı miktarını hesaplar
        private int HesaplaSaldiri(SavasAraclari atacan, SavasAraclari hedef)
        {
            int saldiri = atacan.VurusGucu;

            // Sınıf avantajını kontrol et ve vuruş avantajını ekle
            saldiri += atacan.VurusAvantaji(hedef.Sinif);

            return saldiri;
        }

        // Yeni kart dağıtır
        private void DagitYeniKartlar()
        {
            // Önce kilitli kartların açılıp açılmadığını kontrol edelim
            KontrolEtKilitliKartlar();

            // Her iki oyuncunun elindeki kart sayısını 6'ya tamamla
            KartlariTamamla(Oyuncu);
            KartlariTamamla(Bilgisayar);
        }

        // Oyuncunun elindeki kartları 6'ya tamamlar
        private void KartlariTamamla(Oyuncu oyuncu)
        {
            while (oyuncu.KartListesi.Count < 6 && TumKartlar.Count > 0)
            {
                oyuncu.KartListesi.Add(TumKartlar[0]);
                TumKartlar.RemoveAt(0);
            }
        }

        // Kilitli kartların açılıp açılmadığını kontrol eder
        private void KontrolEtKilitliKartlar()
        {
            // Oyuncu seviye puanı yeterli ise kilitli kartlar dağıtıma eklenir
            if (Oyuncu.ToplamSeviyePuani >= KilitliKartSeviyePuani && !Oyuncu.KilitliKartlarAcildi)
            {
                TumKartlar.AddRange(GetKilitliKartlar());
                TumKartlar = TumKartlar.OrderBy(x => rand.Next()).ToList();
                Oyuncu.KilitliKartlarAcildi = true;
            }

            // Bilgisayar seviye puanı yeterli ise kilitli kartlar dağıtıma eklenir
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
            List<SavasAraclari> kilitliKartlar = new List<SavasAraclari>();

            for (int i = 0; i < 6; i++)
            {
                kilitliKartlar.Add(new Siha($"Siha{i + 1}"));
                kilitliKartlar.Add(new KFS($"KFS{i + 1}"));
                kilitliKartlar.Add(new Sida($"Sida{i + 1}"));
            }

            return kilitliKartlar;
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
            else
            {
                // Eğer taraflardan birinin elindeki kart sayısı 1 ise, ona fazladan 1 kart daha ver
                if (Oyuncu.KartListesi.Count == 1 && TumKartlar.Count > 0)
                {
                    Oyuncu.KartListesi.Add(TumKartlar[0]);
                    TumKartlar.RemoveAt(0);
                }
                if (Bilgisayar.KartListesi.Count == 1 && TumKartlar.Count > 0)
                {
                    Bilgisayar.KartListesi.Add(TumKartlar[0]);
                    TumKartlar.RemoveAt(0);
                }
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
                    int fark = oyuncuDayaniklilik - bilgisayarDayaniklilik;
                    OyunSonucu = "Skorlar Eşit, Oyuncu Dayanıklılık Avantajıyla Kazandı!";
                    Oyuncu.Skor += fark;
                }
                else if (bilgisayarDayaniklilik > oyuncuDayaniklilik)
                {
                    int fark = bilgisayarDayaniklilik - oyuncuDayaniklilik;
                    OyunSonucu = "Skorlar Eşit, Bilgisayar Dayanıklılık Avantajıyla Kazandı!";
                    Bilgisayar.Skor += fark;
                }
                else
                {
                    OyunSonucu = "Oyun Berabere!";
                }
            }
        }
        */
    }
}
