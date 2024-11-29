using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class Sida : DenizAraclari
    {
       // public override string Sinif => "Deniz";
        public override string AltSinif => "SİDA";
        public override int HavaVurusAvantaji =>10;
        public override int KaraVurusAvantaji => 10;
        public override int VurusGucu => 10;

        public override int Dayaniklilik { get; protected set; }

        public Sida(string isim)
            : base(isim, Properties.Resources.Sida, 15)
        {
            Dayaniklilik = 15;
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? KaraVurusAvantaji : 0;
        }
    }
}
