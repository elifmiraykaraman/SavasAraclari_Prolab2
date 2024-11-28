using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public abstract class KaraAraclari : SavasAraclari
    {
        public abstract string AltSinif { get; }
        public abstract int DenizVurusAvantaji { get; }
        public virtual int HavaVurusAvantaji { get; }

        /*
        public override void KartPuaniGoster()
        {
        }

        public override void DurumGuncelle(int hasar, int kazanilanPuan)
        {
            Dayaniklilik -= hasar;
            SeviyePuani += kazanilanPuan;
        }
        */
    }
}
