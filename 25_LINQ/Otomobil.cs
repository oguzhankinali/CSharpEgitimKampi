using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_AyrıDosyalar_Internal
{
    public class Otomobil
    {
        public string Renk { get; set; }
        public int Km { get; protected set; }
        public static Random rnd = new Random(); // random nesnesi üretiyoruz sınıf ıcınde kullanmak ıcın
        public MotorTipi Motor { get; } // set yazmadıgımız ıcın sınıf ıcerısınde de degıstılemıyor

        public Otomobil(string renk, int baslangicKm, MotorTipi motor)
        {
            Renk = renk;
            Km = baslangicKm;
            Motor = motor;
        }
        public Otomobil(string renk, int baslangicKm)
        {
            this.Renk = renk;
            this.Km = baslangicKm;

        }
        public Otomobil(string renk)
        {
            this.Renk = renk;
            this.Km = 0; // eğer sadece renk parametreli bir nesne olusturursan Km oto 0 geliyor 
        }
        public virtual void Yazdir()
        {
            Console.WriteLine($"Arabanın rengi: {Renk} Km'si: {Km} ve Motor tipi: {Motor}");
        }
        public FrenDiskDurumu frendiskdurumu() //enum da int string gibi bir veri tipi oldugu ıcın enum donduruyor
        {
            int deger = rnd.Next(0, 3); // rnd nesnesinin Next diye bir metodu var ve girdiğin aralıkta random sayı üretiyor 0,3 aralıgında da uretecegı random sayılar 0,1,2
            return (FrenDiskDurumu)deger;
        }
        public void Sur(int kacKm)
        {
            if (kacKm <= 0)
            {
                Console.WriteLine("Geçersiz Sürüş Mesafesi!");
                return;
            }
            Km += kacKm;
            Console.WriteLine($"{kacKm} km sürüldü.");
        }
    }
}
