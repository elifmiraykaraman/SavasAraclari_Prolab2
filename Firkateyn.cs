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
        private static int sayac = 0;

        public Firkateyn()
            : base(150, 0, 10, "Deniz")
        {
            sayac++;
            this.KartAdi = "Firkateyn" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }
    }
}
