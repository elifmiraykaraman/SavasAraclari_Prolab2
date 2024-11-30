using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SavasAraclari_Prolab2
{
    public abstract class SavasAraclari : INotifyPropertyChanged
    {
        protected int dayaniklilik;
        protected int seviyePuani;
        protected int vurus;
        protected string sinif;
        protected int maxSeviyePuani;

        private string kartAdi;
        public string KartAdi
        {
            get { return kartAdi; }
            set
            {
                if (kartAdi != value)
                {
                    kartAdi = value;
                    OnPropertyChanged("KartAdi");
                }
            }
        }

        public int Dayaniklilik
        {
            get { return dayaniklilik; }
            set
            {
                if (dayaniklilik != value)
                {
                    dayaniklilik = value;
                    OnPropertyChanged("Dayaniklilik");
                }
            }
        }

        public int SeviyePuani
        {
            get { return seviyePuani; }
            set
            {
                if (seviyePuani != value)
                {
                    seviyePuani = value;
                    OnPropertyChanged("SeviyePuani");
                }
            }
        }

        public int Vurus
        {
            get { return vurus; }
            set
            {
                if (vurus != value)
                {
                    vurus = value;
                    OnPropertyChanged("Vurus");
                }
            }
        }

        public string Sinif
        {
            get { return sinif; }
            set
            {
                if (sinif != value)
                {
                    sinif = value;
                    OnPropertyChanged("Sinif");
                }
            }
        }

        public int MaxSeviyePuani
        {
            get { return maxSeviyePuani; }
            set
            {
                if (maxSeviyePuani != value)
                {
                    maxSeviyePuani = value;
                    OnPropertyChanged("MaxSeviyePuani");
                }
            }
        }

        public bool Kullanilmis { get; set; }

        public SavasAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif, int maxSeviyePuani)
        {
            this.Dayaniklilik = dayaniklilik;
            this.SeviyePuani = seviyePuani;
            this.Vurus = vurus;
            this.Sinif = sinif;
            this.MaxSeviyePuani = maxSeviyePuani;
            this.Kullanilmis = false;
        }

        public abstract void DurumGuncelle(int hasar);

        public void KartPuaniGoster()
        {
            Console.WriteLine($"Dayanıklılık: {Dayaniklilik}, Seviye Puanı: {SeviyePuani}");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    /*
    public abstract class SavasAraclari
    {

        protected int dayaniklilik;
        protected int seviyePuani;
        protected int vurus;
        protected string sinif;

        public abstract int Dayaniklilik { get; set; }
        public abstract int Vurus { get; set; }
        public abstract string Sinif { get; set; }

        public SavasAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif)
        {
            this.dayaniklilik = dayaniklilik;
            this.seviyePuani = seviyePuani;
            this.vurus = vurus;
            this.sinif = sinif;
        }

        public void KartPuaniGoster()
        {
            Console.WriteLine($"Dayanıklılık: {dayaniklilik}, Seviye Puanı: {seviyePuani}");
        }

        public abstract void DurumGuncelle(int hasar);

        private string kartAdi;
        public string KartAdi
        {
            get { return kartAdi; }
            set
            {
                if (kartAdi != value)
                {
                    kartAdi = value;
                    // OnPropertyChanged("KartAdi");
                }
            }
        }
    }
    */



    /*
    public string Isim { get; private set; }
    public Image Resim { get; private set; }
    public int BaslangicDayaniklilik { get; private set; }
    public abstract string Sinif { get;}
    public abstract int Dayaniklilik { get; protected set; }
    public int SeviyePuani { get; set; } = 0;
    public bool Secildi { get; set; } = false;
    public abstract int VurusGucu { get; }
    // public abstract void KartPuaniGoster();
    // public abstract void DurumGuncelle(int hasar, int kazanilanPuan);
    public abstract int VurusAvantaji(string rakipSinif);
    public abstract void HasarAl(int hasarMiktari);

    protected SavasAraclari(string isim, Image resim, int dayaniklilik)
    {
        Isim = isim;
        Resim = resim;
        BaslangicDayaniklilik = dayaniklilik;
    }
    */



}
