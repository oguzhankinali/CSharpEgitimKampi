using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_AyrıDosyalar_Internal
{
    public class Istasyon
    {
        public void HizliDoldur(IYenidenDoldurulabilir arac)
        {
            Console.WriteLine("İstasyon: dolum başlıyor...");
            arac.Doldur();
            Console.WriteLine("İstasyon: dolum bitti...");

        }
    }
}
