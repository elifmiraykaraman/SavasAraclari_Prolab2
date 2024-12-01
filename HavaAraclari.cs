﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace SavasAraclari_Prolab2
{
    public abstract class HavaAraclari : SavasAraclari
    {
        public HavaAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif)
        : base(dayaniklilik, seviyePuani, vurus, sinif)
        {
        }

        public override void DurumGuncelle(SavasAraclari kart1, SavasAraclari kart2, int hasar)
        {
            kart1.Dayaniklilik -= hasar;
            if (kart1.Dayaniklilik <= 0)
            {
                kart1.Dayaniklilik = 0;
                kart2.SeviyePuani = seviyePuani + 10;
            }
        }
    }
}


       