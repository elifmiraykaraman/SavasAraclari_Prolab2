using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class UcakKart : Kart
    {
        public override string Sinif => "Hava";
        public override int VurusGucu => 20;

        public UcakKart(string isim)
            : base(isim, Properties.Resources.Ucak, 20) // Görsel ve dayanıklılık başlangıç değeri
        {
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? 10 : 0; // Kara sınıfına karşı 10 avantaj
        }
    }
}
