using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SavasAraclari_Prolab2
{
    public abstract class SavasAraclari
    {
        public string Isim { get; private set; }
        public Image Resim { get; private set; }
        public int BaslangicDayaniklilik { get; private set; }
        public abstract string Sinif { get;}
        public abstract int Dayaniklilik { get; protected set; }
        public int SeviyePuani { get; set; } = 0;
        public bool Secildi { get; set; } = false;
        public abstract int VurusGucu { get; }
        // public abstract void KartPuaniGoster();
        // public abstract void DurumGuncelle(int hasar, int kazanilanPuan);
        public abstract int VurusAvantaji(string rakipSinif);
        public abstract void HasarAl(int hasarMiktari);

        protected SavasAraclari(string isim, Image resim, int dayaniklilik)
        {
            Isim = isim;
            Resim = resim;
            BaslangicDayaniklilik = dayaniklilik;
        }

    }
}
