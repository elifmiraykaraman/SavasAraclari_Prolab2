using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SavasAraclari_Prolab2
{
    public abstract class SavasAraclari
    {
        
        public abstract string Sinif { get;}
        public abstract int Dayaniklilik { get; }
        public int SeviyePuani { get; set; }
        public abstract int VurusGucu { get; }
        // public abstract void KartPuaniGoster();
        // public abstract void DurumGuncelle(int hasar, int kazanilanPuan);
        public abstract int VurusAvantaji(string rakipSinif);

     

     
    }
}
