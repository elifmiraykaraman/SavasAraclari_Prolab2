using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SavasAraclari_Prolab2
{
    public abstract class DenizAraclari : SavasAraclari
    {
        public DenizAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif, int maxSeviyePuani)
        : base(dayaniklilik, seviyePuani, vurus, sinif, maxSeviyePuani)
        {
        }

        public override void DurumGuncelle(int hasar)
        {
            Dayaniklilik -= hasar;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;

            SeviyePuani += hasar / 10;
            if (SeviyePuani > MaxSeviyePuani)
                SeviyePuani = MaxSeviyePuani;
        }
        /*
        protected int havaVurusAvantaji;

        public DenizAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif, int havaVurusAvantaji)
            : base(dayaniklilik, seviyePuani, vurus, sinif)
        {
            this.havaVurusAvantaji = havaVurusAvantaji;
        }
        */
        /*
        public override string Sinif => "Deniz";
        public abstract string AltSinif { get; }
        public abstract int HavaVurusAvantaji { get; }
        public abstract int KaraVurusAvantaji { get; }
        public override int Dayaniklilik { get; protected set; }

        protected DenizAraclari(string isim, Image resim, int dayaniklilik)
            : base(isim, resim, dayaniklilik)
        {
            Dayaniklilik = dayaniklilik;
        }

        public override void HasarAl(int hasarMiktari)
        {
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            int avantaj = 0;

            if (rakipSinif == "Hava")
                avantaj += HavaVurusAvantaji;
            if (rakipSinif == "Kara")
                avantaj += KaraVurusAvantaji;

            return avantaj;
        }
        
        public override void KartPuaniGoster()
        {
        }

       public override void DurumGuncelle(int hasar, int kazanilanPuan)
        {
            Dayaniklilik -= hasar;
            SeviyePuani += kazanilanPuan;
        }
       */
    }
}

        

    
