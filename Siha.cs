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
        public override string AltSinif => "Siha";
        public override int KaraVurusAvantaji => 10;
        public override int DenizVurusAvantaji => 10;
        public override int VurusGucu => 10;

        public override int Dayaniklilik { get; protected set; }

        public Siha(string isim)
            : base(isim, Properties.Resources.Siha, 15)
        {
            Dayaniklilik = 15;
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            int avantaj = 0;
            if (rakipSinif == "Kara")
                avantaj += KaraVurusAvantaji;
            if (rakipSinif == "Deniz")
                avantaj += DenizVurusAvantaji;
            return avantaj;
        }

        public override void HasarAl(int hasarMiktari)
        {
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }
    }
}
