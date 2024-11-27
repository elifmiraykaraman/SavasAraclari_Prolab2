using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public abstract class DenizAraclari : SavasAraclari
    {
        public abstract string AltSinif { get; }
        public abstract int HavaVurusAvantaji { get; }
        public abstract int KaraVurusAvantaji { get; }

        protected DenizAraclari(string isim, int dayaniklilik)
            : base(isim, dayaniklilik) { }

        public override void KartPuaniGoster()
        {
        }

        public override void DurumGuncelle(int hasar, int kazanilanPuan)
        {
            Dayaniklilik -= hasar;
            SeviyePuani += kazanilanPuan;
        }
    }
}