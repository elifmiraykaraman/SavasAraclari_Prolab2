using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public class BilgisayarOyuncu : Oyuncu
    {
        private Random rand;

        public BilgisayarOyuncu(int oyuncuID, string oyuncuAdi, int skor)
            : base(oyuncuID, oyuncuAdi, skor)
        {
            rand = new Random();
        }

        // Bilgisayar kart seçimini yönetir
        public override List<SavasAraclari> KartSec()
        {
            List<SavasAraclari> secilenKartlar = new List<SavasAraclari>();
            int kartSayisi = KartListesi.Count;

            if (kartSayisi == 0)
                return secilenKartlar;

            for (int i = 0; i < 3 && KartListesi.Count > 0; i++)
            {
                int index = rand.Next(KartListesi.Count);
                secilenKartlar.Add(KartListesi[index]);
                KartListesi.RemoveAt(index);
            }

            return secilenKartlar;
        }
    }
}
