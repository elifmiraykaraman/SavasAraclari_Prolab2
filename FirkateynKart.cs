using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class FirkateynKart : Kart
    {
        public override string Sinif => "Deniz";
        public override int VurusGucu => 10;

        public FirkateynKart(string isim)
            : base(isim, Properties.Resources.Firkateyn, 25)
        {
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? 15 : 0; // Hava sınıfına karşı 15 avantaj
        }
    }
}

