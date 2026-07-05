using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 
 .NET Collections Framework
- En popüler sınıf: List<T> (Dinamik Dizi) T: tip 
List<T> ve Array arasındaki farklar: 
--------------------------------------
1. Boyut Esnekliği: Dizilerin boyutu sabittir, bir kez tanımlanınca değişmez.
List<T> ise eleman ekledikçe otomatik olarak büyür. (Dinamik Dizi)

2. Hazır Metotlar: List<T>içinde eleman ekleme (add), silme(remove), arama(Find) ve sıralama(Sort) gibi hazır metodlar gelir. Dizilerde bu işlemleri manuel yapman gerekir.

3. LINQ Entegrasyonu: List<T>, LINQ sorgularıyla (filtreleme,gruplama) çok daha akıcı çalışır.
 */

namespace _09_021_List_Add_Remove_Clear
{
    public enum MotorTipi
    {
        Dizel,
        Benzinli,
        Hibrid,
        Elektrikli
    }

    public enum FrenDiskDurumu
    {
        İYİ,
        ORTA,
        KÖTÜ
    }


    public interface IYenidenDoldurulabilir
    {
        void Doldur();
    }

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
    public class ElektrikliOtomobil : Otomobil, IYenidenDoldurulabilir // otomobil parent, elektrikliOtomobil child
    {
        public int BataryaYuzde { get; private set; }
        public ElektrikliOtomobil(string renk, int baslangicKm)
            : base(renk, baslangicKm, MotorTipi.Elektrikli)
        {
            BataryaYuzde = 100;
        }
        public void Doldur()
        {
            SarjEt(); // Mevcut şarj etme metodunu tetiklesin
        }
        public void SarjEt()
        {
            BataryaYuzde = 100;
            Console.WriteLine("Araç şarj edildi");
        }
        public override void Yazdir()
        {
            Console.WriteLine($"Arabanın rengi: {Renk} Km'si: {Km} ve Motor tipi: {Motor} ve Batarya Yüzdesi:{BataryaYuzde}%");
        }
    }
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

    public abstract class Motorsiklet
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
    }

    public class ElektrikliMotorsiklet : Motorsiklet
    {
        public override void Calistir() // Ana Motosiklet sınıfında olusturdugumuz Abstract metodu burada kullanmak zorundayız. 
        {
            Hiz = 10;
            Console.WriteLine("Elektrikli Motorsiklet sessizce çalıştı.");
        }
    }

    public class Istasyon
    {
        public void HizliDoldur(IYenidenDoldurulabilir arac)
        {
            Console.WriteLine("İstasyon: dolum başlıyor...");
            arac.Doldur();
            Console.WriteLine("İstasyon: dolum bitti...");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Otomobil> garaj = new List<Otomobil>();  // içinde nesneler tutan nesne 
            //garaj bir nesne içinde de Otomobil nesneleri tutuyor 


            Console.WriteLine("ilk hali: ");
            garaj.Add(new ElektrikliOtomobil("Beyaz", 900));
            garaj.Add(new BenzinliOtomobil("Turuncu", 300));
            garaj.Add(new ElektrikliOtomobil("Mavi", 2500));
            garaj.Add(new BenzinliOtomobil("Yeşil", 7000));

            foreach(Otomobil arac in garaj)
            {
                arac.Yazdir();
            }
            // indexi 1 olan (2. sıradaki) aracı sil
            garaj.RemoveAt(1);
            Console.WriteLine("\nsonraki hali: ");
            foreach (Otomobil arac in garaj)
            {
                arac.Yazdir();
            }
            //garajdaki tüm araçları sil
            garaj.Clear();
            Console.WriteLine("\nTüm araçlar silindikten sonraki hali: ");
            foreach (Otomobil arac in garaj)
            {
                arac.Yazdir();
            }




        }


    }
}
