using SavasAraclari_Prolab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;


namespace SavasAraclari_Prolab2

{
    public class Firkateyn : DenizAraclari
    {

        public string isim;
        public override string Sinif => "Deniz";
        public override string AltSinif => "Fırkateyn";

        public override int HavaVurusAvantaji => 5;
        public override int KaraVurusAvantaji => 0;
        public override int VurusGucu => 20;

        private int _dayaniklilik;

        public Firkateyn(string isim)
        {
            _dayaniklilik = 25;
            this.isim = isim;   
        }

        public override int Dayaniklilik => _dayaniklilik;



        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? HavaVurusAvantaji : 0;
        }

    }
}
