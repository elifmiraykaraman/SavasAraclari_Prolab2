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
        public override string Sinif => "Deniz";
        public override string AltSinif => "Fırkateyn";
        public override int HavaVurusAvantaji => 5;
        public override int KaraVurusAvantaji => 0;
        public override int VurusGucu => 20;

        public override int Dayaniklilik { get; protected set; }

        public Firkateyn(string isim)
            : base(isim, Properties.Resources.Firkateyn, 25) // Üst sınıfın constructor'ını çağırıyoruz
        {

        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? HavaVurusAvantaji : 0;
        }

        // Dayanıklılığı azaltmak için bir metot ekleyebiliriz
        public void HasarAl(int hasarMiktari)
        {
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }
    }
}
