using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SavasAraclari_Prolab2
{
    public abstract class Kart
    {
        public string Isim { get; set; }
        public int Dayaniklilik { get; set; } // Kartın dayanıklılığı
        public Image Image { get; set; }
        public abstract string Sinif { get; } // Hava, Kara, Deniz sınıfları
        public abstract int VurusGucu { get; } // Vuruş gücü


        protected Kart(string isim, Image image, int dayaniklilik)
        {
            Isim = isim;
            Image = image;
            Dayaniklilik = dayaniklilik;
        }

        public abstract int VurusAvantaji(string rakipSinif);
    }
}

