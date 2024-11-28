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
        public string isim; 
        public override string Sinif => "Deniz";
        public override string AltSinif => "SİDA";
        public override int HavaVurusAvantaji => 0;
        public override int KaraVurusAvantaji => 5;
        public override int VurusGucu => 15;

        private int _dayaniklilik;

        public Sida(string isim)
        {
            _dayaniklilik = 15;
            this.isim = isim;
        }

        public override int Dayaniklilik => _dayaniklilik;
        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? KaraVurusAvantaji : 0;
        }
    }
}