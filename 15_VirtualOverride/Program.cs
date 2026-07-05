using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



#region 🎯 VİRTUAL OVERRİDE DERS NOTU

/*
   Virtual override: override(üzerine yazmak) şimdi mesela ana sınıf Otomobil'de yazdır metodu sadece km renk ve motor tipi yazdırıyor ama ben alt sınıf olusturdum ElektrikliOtomobil diye ve onda batarya yüzdesi diye bir değişken de var. Yazdir() cagırdıgımda batarya yuzdesı de yazsın ıstıyorum. O yuzden Yazdır() fonksıyonuna override yaparız.
(Benzinli araba için ben bunu ayrıca BenzinliYazdir() diyerek yapmıstım ama her bırıne tek tek bunu mu ypaıcan.
Bunu yapabilmek için public virtual void Yazdir() olarak düzenleriz fonksiyonu kı vırtual a ızın verılsın 
    
     Ana sınıftaki: 
        public virtual void Yazdir()
        {
            Console.WriteLine($"Arabanın rengi: {Renk} Km'si: {Km} ve Motor tipi: {Motor}");
        }

    ElektrikliOtomobil Sınıfında da override diyerek şöyle yazarsın:
 public override void Yazdir()
        {
            Console.WriteLine($"Arabanın rengi: {Renk} Km'si: {Km} ve Motor tipi: {Motor} ve Batarya Yüzdesi :{BataryaYuzde}");
        }
ElektrikliOtomobil sınıfında nesne türetilirse ve Yazdır cagırırsa ana sınıfa gıtme buradakıne gel. 

*/

#endregion


namespace _09_013_Class_Enum_Enumeration
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

    public class BenzinliOtomobil : Otomobil
    {
        public int kalanBenzin { get; set; }
        public BenzinliOtomobil(string color, int firstKm)
            : base(color, firstKm, MotorTipi.Benzinli)
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
    public class ElektrikliOtomobil : Otomobil // otomobil parent, elektrikliOtomobil child
    {
        public int BataryaYuzde { get; private set; }
        public ElektrikliOtomobil(string renk, int baslangicKm)
            : base(renk, baslangicKm, MotorTipi.Elektrikli)
        {
            BataryaYuzde = 100;
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


        //2 parametreli Constructor
        public Otomobil(string renk, int baslangicKm)
        {
            this.Renk = renk;
            this.Km = baslangicKm;

        }
        //1 parametreli Constructor
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
    internal class Program
    {
        static void Main(string[] args)
        {

            BenzinliOtomobil otomobil5 = new BenzinliOtomobil("lacivert", 0);
            otomobil5.BenzinliAracıSur(100);
            otomobil5.BenzinliYazdir();
            otomobil5.Yazdir();


            Otomobil otomobil1 = new ElektrikliOtomobil("pembe", 400);
            otomobil1.Yazdir();

        }
    }
 
}
