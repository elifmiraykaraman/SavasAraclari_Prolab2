using SavasAraclari_Prolab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2

{
    public class Firkateyn : DenizAraclari
    {
        public override string Sinif => "Deniz";
        public override string AltSinif => "Fırkateyn";
        public override int HavaVurusAvantaji => 5;
        public override int KaraVurusAvantaji => 0;
        public override int VurusGucu => 20;

        public Firkateyn(string isim)
            : base(isim, Properties.Resources.Firkateyn, 25) { }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? HavaVurusAvantaji : 0;
        }

    }
}
