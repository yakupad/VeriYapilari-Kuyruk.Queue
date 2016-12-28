using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZM2116_ODEV2
{
    public class Musteri
    {
        int musterino = 0;
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int MusteriNo { get; set; }
        public int IslemSuresi { get; set; }
        
        Random rasgeleislemsuresi = new Random();

        public int IslemSuresiOlustur()
        {
            return rasgeleislemsuresi.Next(60, 600);
        }
        public int BenzersizMusteriNoOlustur()
        {
            musterino++;
            return musterino;
        }
 
    }
}
