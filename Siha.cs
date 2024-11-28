using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class Siha : HavaAraclari
    {
        public string isim;
        public override string Sinif => "Hava";
        public override string AltSinif => "SİHA";
        public override int KaraVurusAvantaji => 0;
        public override int DenizVurusAvantaji => 5;
        public override int VurusGucu => 15;

        private int _dayaniklilik;

        public Siha(string isim)
        {
            this.isim = isim;   
            _dayaniklilik = 15;
        }

        public override int Dayaniklilik => _dayaniklilik; 

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Deniz" ? DenizVurusAvantaji : 0;
        }
    }
}
