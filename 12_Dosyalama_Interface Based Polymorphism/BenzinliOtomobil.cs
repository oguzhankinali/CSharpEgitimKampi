using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_AyrıDosyalar_Internal
{
    public class BenzinliOtomobil : Otomobil, IYenidenDoldurulabilir
    //BenzinliOtomobil class'ı IYenidenDoldurulabilir Interface'nin tüm metodlarını içinde barındırır, kurallarını kabul eder.
    {
        public int kalanBenzin { get; set; }
        public BenzinliOtomobil(string color, int firstKm)
            : base(color, firstKm, MotorTipi.Benzinli)
        {
            kalanBenzin = 100;

        }
        public void Doldur() // Interface'den ımplement ettıgımız metod 
        {
            BenziniDoldur();
            Console.WriteLine("Kalan benzin: " + kalanBenzin);
        }
        public void BenziniDoldur()
        {
            kalanBenzin = 100;
        }
        public void BenzinliAracıSur(int km)
        {
            Sur(km);

            kalanBenzin = kalanBenzin - ((km * 6) / 100);
        }
        public void BenzinliYazdir()
        {
            // Önce üst sınıftaki orijinal Yazdir() çalışsın, yanına da benzini ekleyelim:
            Yazdir();
            Console.WriteLine($"Kalan Benzin: {kalanBenzin} Lt.");
        }
        // usttekını vırtualoverrıde ıle yapıyoruz
        public override void Yazdir()
        {
            Console.WriteLine($"Arabanın rengi: {Renk} Km'si: {Km} ve Motor tipi: {Motor} ve Batarya Yüzdesi :{kalanBenzin} Lt.");
        }
    }
}
