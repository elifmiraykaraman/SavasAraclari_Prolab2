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
        private static int sayac = 0;

        public Siha()
            : base(90, 0, 25, "Hava")
        {
            sayac++;
            this.KartAdi = "Siha" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }
    }
}
