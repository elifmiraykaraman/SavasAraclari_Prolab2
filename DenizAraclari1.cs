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
        public override string Sinif => "Deniz";
        public abstract string AltSinif { get; }
        public abstract int HavaVurusAvantaji { get; }
        public abstract int KaraVurusAvantaji { get; }


        public string Isim { get; private set; }
        public Image Resim { get; private set; }
        public int BaslangicDayaniklilik { get; private set; }

        protected DenizAraclari(string isim, Image resim, int dayaniklilik)
        {
            Isim = isim;
            Resim = resim;
            BaslangicDayaniklilik = dayaniklilik;
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

    }
}