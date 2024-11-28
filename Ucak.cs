using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class Ucak : HavaAraclari
    {
        public string isim; 
        public override string Sinif => "Hava";
        public override string AltSinif => "Uçak";
        public override int KaraVurusAvantaji => 5;
        public override int VurusGucu => 20;

        private int _dayaniklilik;

        public Ucak(string isim)
        {
            _dayaniklilik = 20;
            this.isim = isim;
        }

        public override int Dayaniklilik => _dayaniklilik;
        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? KaraVurusAvantaji : 0;
        }
    }
}
