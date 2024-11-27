using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class ObusKart : Kart
    {
        public override string Sinif => "Kara";
        public override int VurusGucu => 15;

        public ObusKart(string isim)
            : base(isim, Properties.Resources.Obus, 20)
        {
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Deniz" ? 10 : 0; // Deniz sınıfına karşı 10 avantaj
        }
    }
}