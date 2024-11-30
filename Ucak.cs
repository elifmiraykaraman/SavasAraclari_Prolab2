using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class Ucak : HavaAraclari
    {

        private static int sayac = 0;

        public Ucak()
            : base(100, 0, 20, "Hava", 10)
        {
            sayac++;
            this.KartAdi = "Uçak" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }
        /*
        private static int sayac = 0;
        public static void SayacSifirla()
        {
            sayac = 0;
        }
        public override int Dayaniklilik
        {
            get { return dayaniklilik; }
            set { dayaniklilik = value; }
        }

        public override int Vurus
        {
            get { return vurus; }
            set { vurus = value; }
        }

        public override string Sinif
        {
            get { return sinif; }
            set { sinif = value; }
        }

        public Ucak()
            : base(100, 0, 20, "Hava", 10)
        {
            sayac++; 
            this.KartAdi = "Ucak" + sayac; 
        }

        public override void DurumGuncelle(int hasar)
        {
            dayaniklilik -= hasar;
            seviyePuani += 5;
        }

        */
        /*
        public override string Sinif => "Hava";
        public override string AltSinif => "Uçak";
        public override int KaraVurusAvantaji => 5;
        public override int DenizVurusAvantaji => 0; // Deniz vuruş avantajı yok
        public override int VurusGucu => 20;

        private int _dayaniklilik;
        public string Isim { get; private set; }

        public Ucak(string isim)
            : base(isim, Properties.Resources.Ucak, 20) // Üst sınıfın constructor'ını çağırıyoruz
        {
            Isim = isim;
            _dayaniklilik = 20; // Başlangıç dayanıklılığını ayarla
        }
        public override int VurusAvantaji(string rakipSinif)
        {
            int avantaj = 0;
            if (rakipSinif == "Kara")
                avantaj += KaraVurusAvantaji;
            if (rakipSinif == "Deniz")
                avantaj += DenizVurusAvantaji;
            return avantaj;
        }

        public override void HasarAl(int hasarMiktari)
        {
            _dayaniklilik -= hasarMiktari;
            if (_dayaniklilik < 0)
                _dayaniklilik = 0;
        }

        public override int Dayaniklilik => _dayaniklilik;

       // public override int VurusAvantaji(string rakipSinif)
        //{
          //  return rakipSinif == "Kara" ? KaraVurusAvantaji : 0;
        //}
        */
    }
}
