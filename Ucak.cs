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
        public override string Sinif => "Hava";
        public override string AltSinif => "Uçak";
        public override int KaraVurusAvantaji => 5;
        public override int DenizVurusAvantaji => 0; // Deniz vuruş avantajı yok
        public override int VurusGucu => 20;

        private int _dayaniklilik;
        public string Isim { get; private set; }

        public Ucak(string isim)
            : base(isim, Properties.Resources.Ucak, 20) // Üst sınıfın constructor'ını çağırıyoruz
        {
            Isim = isim;
            _dayaniklilik = 20; // Başlangıç dayanıklılığını ayarla
        }

        public override int Dayaniklilik => _dayaniklilik;

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Kara" ? KaraVurusAvantaji : 0;
        }
    }
}
