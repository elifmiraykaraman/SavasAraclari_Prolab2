using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace SavasAraclari_Prolab2
{
    
    public class Siha : HavaAraclari
    {
        private static int sayac = 0;

        public Siha()
            : base(90, 0, 25, "Hava")
        {
            sayac++;
            this.KartAdi = "Siha" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }

        /*
        protected int denizVurusAvantaji;
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

        public Siha()
            : base(90, 0, 25, "Hava", 10)
        {
            this.denizVurusAvantaji = 15;
            sayac++;
            this.KartAdi = "Siha" + sayac; 
        }

        public override void DurumGuncelle(int hasar)
        {
            dayaniklilik -= hasar;
            seviyePuani += 10;
        }

        */
        /*
        public override string Sinif => "Hava";
        public override string AltSinif => "Siha";
        public override int KaraVurusAvantaji => 10;
        public override int DenizVurusAvantaji => 10;
        public override int VurusGucu => 10;

        public override int Dayaniklilik { get; protected set; }

        public Siha(string isim)
            : base(isim, Properties.Resources.Siha, 15)
        {
            Dayaniklilik = 15;
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
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }
        */
    }
}
