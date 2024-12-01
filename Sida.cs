using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class Sida : DenizAraclari
    {
        private static int sayac = 0;

        public Sida()
            : base(140, 0, 18, "Deniz")
        {
            sayac++;
            this.KartAdi = "Sida" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }
    }
}
