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
        public string Isim { get; set; }
        public abstract string Sinif { get; }
        public int Dayaniklilik { get; set; }
        public int SeviyePuani { get; set; }
        public abstract int VurusGucu { get; }
        public abstract void KartPuaniGoster();
        public abstract void DurumGuncelle(int hasar, int kazanilanPuan);
        public abstract int VurusAvantaji(string rakipSinif);
        //   public abstract Image resim(get

        protected SavasAraclari(string isim, int dayaniklilik)
        {
            Isim = isim;
            Dayaniklilik = dayaniklilik;
            SeviyePuani = 0;
        }

        public override string ToString()
        {
            return $"{Isim} ({Sinif}), Dayanıklılık: {Dayaniklilik}, Seviye Puanı: {SeviyePuani}";
        }
    }
}
