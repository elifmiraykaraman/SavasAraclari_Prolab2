﻿using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavasAraclari_Prolab2
{
    public abstract class KaraAraclari : SavasAraclari
    {
        public KaraAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif, int maxSeviyePuani)
        : base(dayaniklilik, seviyePuani, vurus, sinif, maxSeviyePuani)
        {
        }

        public override void DurumGuncelle(int hasar)
        {
            Dayaniklilik -= hasar;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;

            SeviyePuani += hasar / 10;
            if (SeviyePuani > MaxSeviyePuani)
                SeviyePuani = MaxSeviyePuani;
        }
        /*
        protected int denizVurusAvantaji;

        public KaraAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif, int denizVurusAvantaji)
            : base(dayaniklilik, seviyePuani, vurus, sinif)
        {
            this.denizVurusAvantaji = denizVurusAvantaji;
        }
        */

        /*
        public abstract string AltSinif { get; }
        public abstract int DenizVurusAvantaji { get; }
        public virtual int HavaVurusAvantaji { get; }

        public string Isim { get; private set; }
        public Image Resim { get; private set; }
        public int BaslangicDayaniklilik { get; private set; }

        protected KaraAraclari(string isim, Image resim, int dayaniklilik)
            : base(isim, resim, dayaniklilik)
        {
            Dayaniklilik = dayaniklilik;
        }

        public override void HasarAl(int hasarMiktari)
        {
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            int avantaj = 0;

            if (rakipSinif == "Deniz")
                avantaj += DenizVurusAvantaji;
            if (rakipSinif == "Hava")
                avantaj += HavaVurusAvantaji;

            return avantaj;
        }

        public override void KartPuaniGoster()
        {
        }

        public override void DurumGuncelle(int hasar, int kazanilanPuan)
        {
       Dayaniklilik -= hasar;
       SeviyePuani += kazanilanPuan;
        }
        */
    }
}

