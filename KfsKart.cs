using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class KfsKart : Kart
    {
        public override string Sinif => "Kara"; // Sınıf: Kara
        public override int VurusGucu => 25; // Vuruş Gücü: 25

        public KfsKart(string isim)
            : base(isim, Properties.Resources.KFS, 10) // Görsel ve Dayanıklılık
        {
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? 10 : 0; // Hava sınıfına karşı 10 avantaj
        }
    }
}

