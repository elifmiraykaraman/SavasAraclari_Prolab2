using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class Sida : DenizAraclari
    {
        private static int sayac = 0;

        public Sida()
            : base(140, 0, 18, "Deniz", 10)
        {
            sayac++;
            this.KartAdi = "SİDA" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }

        /*
        protected int karaVurusAvantaji;
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

        public Sida()
            : base(140, 0, 18, "Deniz", 10)
        {
            this.karaVurusAvantaji = 15;
            sayac++;
            this.KartAdi = "Sida" + sayac;
        }

        public override void DurumGuncelle(int hasar)
        {
            dayaniklilik -= hasar;
            seviyePuani += 10;
        }
        */
        /*
        // public override string Sinif => "Deniz";
        public override string AltSinif => "SİDA";
        public override int HavaVurusAvantaji =>10;
        public override int KaraVurusAvantaji => 10;
        public override int VurusGucu => 10;

        public override int Dayaniklilik { get; protected set; }

        public Sida(string isim)
            : base(isim, Properties.Resources.Sida, 15)
        {
            Dayaniklilik = 15;
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? KaraVurusAvantaji : 0;
        }
        */
    }
}
