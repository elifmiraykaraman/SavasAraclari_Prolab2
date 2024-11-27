using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class Obus : KaraAraclari
    {
        public override string Sinif => "Kara";
        public override string AltSinif => "Obüs";
        public override int DenizVurusAvantaji => 5;
        public override int HavaVurusAvantaji => 0;
        public override int VurusGucu => 15;

        public Obus(string isim)
            : base(isim, 20) { }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Deniz" ? DenizVurusAvantaji : 0;
        }
    }
}