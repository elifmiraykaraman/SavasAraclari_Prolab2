using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public abstract class KaraAraclari : SavasAraclari
    {
        public abstract string AltSinif { get; }
        public abstract int DenizVurusAvantaji { get; }
        public virtual int HavaVurusAvantaji { get; }

        public string Isim { get; private set; }
        public Image Resim { get; private set; }
        public int BaslangicDayaniklilik { get; private set; }

        protected KaraAraclari(string isim, Image image, int dayaniklilik)
        {
            Isim = isim;
            Resim = image;
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
