using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class Ucak : HavaAraclari
    {
        public override string Sinif => "Hava";
        public override string AltSinif => "Uçak";
        public override int KaraVurusAvantaji => 5;
        public override int VurusGucu => 20;

        public Ucak(string isim)
            : base(isim, 20) { }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? KaraVurusAvantaji : 0;
        }
    }
}
