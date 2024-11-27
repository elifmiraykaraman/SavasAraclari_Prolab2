using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public abstract class HavaAraclari : SavasAraclari
    {
        public abstract string AltSinif { get; }
        public abstract int KaraVurusAvantaji { get; }
        public virtual int DenizVurusAvantaji => 5;

        protected HavaAraclari(string isim, int dayaniklilik)
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