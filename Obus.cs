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

        private static int sayac = 0;

        public Obus()
            : base(120, 0, 15, "Kara")
        {
            sayac++;
            this.KartAdi = "Obus" + sayac;
        }

        public static void SayacSifirla()
        {
            sayac = 0;
        }
        
    }
}