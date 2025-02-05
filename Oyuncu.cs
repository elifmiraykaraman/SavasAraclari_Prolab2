﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public abstract class Oyuncu
    {
        public int OyuncuID { get; private set; }
        public string OyuncuAdi { get; private set; }
        public int Skor { get; set; }
        public List<SavasAraclari> KartListesi { get; private set; }

        // Parametresiz Constructor
        protected Oyuncu()
        {
            OyuncuID = 0;
            OyuncuAdi = "Bilgisayar"; // default olarak bilgisayar
            Skor = 0;
            KartListesi = new List<SavasAraclari>();
        }

        // Parametreli Constructor
        protected Oyuncu(int oyuncuID, string oyuncuAdi, int skor)
        {
            OyuncuID = oyuncuID;
            OyuncuAdi = oyuncuAdi;
            Skor = skor;
            KartListesi = new List<SavasAraclari>();
        }

        // Skor gösterme fonksiyonu
        public void SkorGoster()
        {
            System.Windows.Forms.MessageBox.Show($"{OyuncuAdi} Skoru: {Skor}");
        }

        // Kart seçme fonksiyonu (Soyut, her oyuncu için farklı uygulanacak)
        public abstract List<SavasAraclari> KartSec();
    }
}
