using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_AyrıDosyalar_Internal
{
    public abstract class Motorsiklet : IYenidenDoldurulabilir
    {
        public int Hiz { get; protected set; }
        // abstract metod -> alt sınıflar bunu yazmak zorunda 
        public abstract void Calistir();
        // Normal metod ->hazır davranış, alt sınıflar yazmak zorunda değil.
        public void GazVer(int artis)
        {
            Hiz += artis;
            Console.WriteLine($"Hız Arttı: {Hiz} km/s.");
        }
    public void Doldur() // Interface'den ımplement ettıgımız metod 
    {
        
        Console.WriteLine("Benzin dolduruldu." );
    }
}
}
