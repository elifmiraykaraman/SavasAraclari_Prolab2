using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class SidaKart : Kart
    {
        public override string Sinif => "Deniz"; // Sınıf: Deniz
        public override int VurusGucu => 15; // Vuruş Gücü: 15

        public SidaKart(string isim)
            : base(isim, Properties.Resources.Sida, 15) // Görsel ve Dayanıklılık
        {
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? 10 : 0; // Kara sınıfına karşı 10 avantaj
        }
    }
}

