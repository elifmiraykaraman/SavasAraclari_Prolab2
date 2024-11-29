using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace SavasAraclari_Prolab2
{
    public abstract class HavaAraclari : SavasAraclari
    {
        public override string Sinif => "Hava";
        public abstract string AltSinif { get; }
        public abstract int KaraVurusAvantaji { get; }
        public abstract int DenizVurusAvantaji { get; }
        public override int Dayaniklilik { get; protected set; }

        protected HavaAraclari(string isim, Image resim, int dayaniklilik)
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

            if (rakipSinif == "Kara")
                avantaj += KaraVurusAvantaji;
            if (rakipSinif == "Deniz")
                avantaj += DenizVurusAvantaji;

            return avantaj;
        }
    }
}


        /*
        public override void KartPuaniGoster()
        {
        }

        public override void DurumGuncelle(int hasar, int kazanilanPuan)
        {
            Dayaniklilik -= hasar;
            SeviyePuani += kazanilanPuan;
        }
        */
