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

        /*
        protected int havaVurusAvantaji;
        private static int sayac = 0;

        public static void SayacSifirla()
        {
            sayac = 0;
        }
        public override int Dayaniklilik
        {
            get { return dayaniklilik; }
            set { dayaniklilik = value; }
        }

        public override int Vurus
        {
            get { return vurus; }
            set { vurus = value; }
        }

        public override string Sinif
        {
            get { return sinif; }
            set { sinif = value; }
        }

        public KFS()
            : base(130, 0, 20, "Kara", 10)
        {
            this.havaVurusAvantaji = 15;
            sayac++;
            this.KartAdi = "KFS" + sayac;
        }

        public override void DurumGuncelle(int hasar)
        {
            dayaniklilik -= hasar;
            seviyePuani += 10;
        }

        */
        /*
        public override string Sinif => "Kara";
        public override string AltSinif => "KFS";
        public override int DenizVurusAvantaji => 0;
        public override int HavaVurusAvantaji => 5;
        public override int VurusGucu => 25;
        public override int Dayaniklilik { get; protected set; }


        public KFS(string isim)
            : base(isim, Properties.Resources.KFS, 10)
        {
           
        }

        public override int VurusAvantaji(string rakipSinif)
        {
            return rakipSinif == "Hava" ? HavaVurusAvantaji : 0;
        }

        // Dayanıklılığı azaltmak veya değiştirmek için bir metot ekleyebilirsiniz
        public void HasarAl(int hasarMiktari)
        {
            Dayaniklilik -= hasarMiktari;
            if (Dayaniklilik < 0)
                Dayaniklilik = 0;
        }
        */
    }
}
