using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class Obus : KaraAraclari
    {
        public override string Sinif => "Kara";
        public override string AltSinif => "Obüs";
        public override int DenizVurusAvantaji => 5;
        public override int HavaVurusAvantaji => 0; // Eğer gerekliyse
        public override int VurusGucu => 15;

        public override int Dayaniklilik { get; protected set; }

        public Obus(string isim)
            : base(isim, Properties.Resources.Obus, 20)
        {
            Dayaniklilik = 20; // Başlangıç dayanıklılığını ayarla
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Deniz" ? DenizVurusAvantaji : 0;
        }

        public void HasarAl(int hasarMiktari)
        {
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }
    }
}