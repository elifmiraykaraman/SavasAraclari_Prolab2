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

        

        public bool Kullanilmis { get; set; }

        public SavasAraclari(int dayaniklilik, int seviyePuani, int vurus, string sinif)
        {
            this.Dayaniklilik = dayaniklilik;
            this.SeviyePuani = seviyePuani;
            this.Vurus = vurus;
            this.Sinif = sinif;
            this.Kullanilmis = false;
        }

        public abstract void DurumGuncelle(SavasAraclari kart1, SavasAraclari kart2, int hasar);

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
}
