using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace SavasAraclari_Prolab2
{
    public class KFS : KaraAraclari
    {
        private static int sayac = 0;

        public KFS()
            : base(130, 0, 20, "Kara")
        {
            sayac++;
            this.KartAdi = "KFS" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }
    }
}
