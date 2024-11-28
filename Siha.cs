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
        public override string Sinif => "Hava";
        public override string AltSinif => "SİHA";
        public override int KaraVurusAvantaji => 0;
        public override int DenizVurusAvantaji => 5;
        public override int VurusGucu => 15;

        private int _dayaniklilik;
        public string Isim { get; private set; } // İsim özelliği düzgün bir şekilde tanımlandı.

        public Siha(string isim)
            : base(isim, Properties.Resources.Siha, 15) // Üst sınıfın constructor'ını çağırıyoruz
        {
            Isim = isim;
            _dayaniklilik = 15; // Başlangıç dayanıklılığını ayarla
        }

        public override int Dayaniklilik => _dayaniklilik;

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Deniz" ? DenizVurusAvantaji : 0;
        }
    }
}
