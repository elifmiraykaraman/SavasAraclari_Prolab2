using SavasAraclari_Prolab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;


namespace SavasAraclari_Prolab2

{
    public class Firkateyn : DenizAraclari
    {
        private static int sayac = 0;

        public Firkateyn()
            : base(150, 0, 10, "Deniz", 10)
        {
            sayac++;
            this.KartAdi = "Fırkateyn" + sayac;
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

        public Firkateyn()
            : base(150, 0, 10, "Deniz", 10)
        {
            sayac++;
            this.KartAdi = "Firkateyn" + sayac; 
        }

        public override void DurumGuncelle(int hasar)
        {
            dayaniklilik -= hasar;
            seviyePuani += 5;
        }

        */
        /*
        public override string Sinif => "Deniz";
        public override string AltSinif => "Fırkateyn";
        public override int HavaVurusAvantaji => 5;
        public override int KaraVurusAvantaji => 0;
        public override int VurusGucu => 20;

        public override int Dayaniklilik { get; protected set; }

        public Firkateyn(string isim)
            : base(isim, Properties.Resources.Firkateyn, 25) // Üst sınıfın constructor'ını çağırıyoruz
        {

        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? HavaVurusAvantaji : 0;
        }

        // Dayanıklılığı azaltmak için bir metot ekleyebiliriz
        public void HasarAl(int hasarMiktari)
        {
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }
        
        */

    }
}
