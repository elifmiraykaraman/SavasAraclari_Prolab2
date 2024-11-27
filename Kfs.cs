using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class KFS : KaraAraclari
    {
        public override string Sinif => "Kara";
        public override string AltSinif => "KFS";
        public override int DenizVurusAvantaji => 0;
        public override int HavaVurusAvantaji => 5;
        public override int VurusGucu => 25;

        public KFS(string isim)
            : base(isim, Properties.Resources.KFS, 10) { }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? HavaVurusAvantaji : 0;
        }
    }
}
