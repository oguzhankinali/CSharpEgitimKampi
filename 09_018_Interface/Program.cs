using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



    #region 🎯 OOP 3. PRENSİBİ: INTERFACE (ARAYÜZ) DETAYLI DERS NOTU

/*
    ==================================================================================
    🤖 INTERFACE (ARAYÜZ/SÖZLEŞME) NEDİR VE NEDEN İHTİYAÇ DUYUYORUZ?
    ==================================================================================
    Interface; bir sınıfın dış dünyaya hangi yetenekleri sunacağını garanti eden, 
    içinde SADECE metotların ve özelliklerin imzalarını (tanımlarını) barındıran 
    tamamen saf bir soyutlama yapısıdır.
    
    * Bir sınıfa Interface bağlamak, o sınıfa bir "Yetenek/Ehliyet" kazandırmaktır.
    * Gerçek dünya metaforu: Bir bankanın pos cihazı entegrasyonunu düşün. Akbank, 
      Garanti ve Trendyol bodoslama kendi kafalarına göre metot isimleri yazamazlar. 
      Merkez Bankası bir "IPosEntegrasyonu" sözleşmesi (Interface) koyar; tüm bankalar 
      bu sözleşmeyi imzalar ve içindeki "OdemeYap()" metodunu birebir uygulamak zorunda kalır.

    ==================================================================================
    🚨 ABSTRACT CLASS VARKEN INTERFACE'E NE GEREK VARDI? (BÜYÜK FARK)
    ==================================================================================
    Hatırlarsak C# dilinde tekil kalıtım vardı; bir çocuk sınıf sadece TEK BİR sınıftan 
    miras alabiliyordu. 
    
    Diyelim ki bir "ElektrikliOtomobil" sınıfın var. Bu sınıf zaten "Otomobil" sınıfından 
    miras alıyor. Sistemde bir de "IElektronikCihaz" ve "ISarjEdilebilir" diye kurallar zinciri 
    tanımlamak istiyorsun. Eğer bunlar sınıf (Abstract Class) olsaydı, elektrikli otomobile 
    bunları bağlayamazdın (Çünkü iki babası olamazdı).
    
    * İŞTE INTERFACE SİHİRİ: Bir sınıf bodoslama SADECE TEK BİR sınıftan miras alabilirken, 
      SINIRSIZ SAYIDA Interface'i kendi üzerine uygulayabilir (implement edebilir)!

    ==================================================================================
    🛠️ INTERFACE KURAL KİTABI VE SYNTAX MANTIĞI
    ==================================================================================
    
    1. İSİMLENDİRME STANDARDI:
       Interface isimleri bodoslama her zaman büyük "I" harfi ile başlar. 
       (Örn: IArac, ISurulebilir, IFrenSistemi). Bu bir kural değil, dünya standardıdır.

    2. ERİŞİM BELİRTEÇLERİ VE GÖVDE YASAĞI:
       Interface içindeki her şey varsayılan olarak PUBLIC kabul edilir. 
       * Önüne "public", "private" veya "abstract" yazamazsın, derleyici kızar.
       * Metotların süslü parantezi ({ }) yani GÖVDESİ ASLA OLAMAZ! Sonuna düz ";" çakılır.
       
       IArac interfacesi tanımı:
       public interface IArac 
       {
           void Calis(); // Erişim belirteci yok, gövde yok, tertemiz imza.
       }

    3. IMPLEMENTATION (SÖZLEŞMEYİ YERİNE GETİRME):
       Interface alt sınıfa bağlanırken yine iki nokta üst üste (:) operatörü kullanılır.
       Ama buna "Miras Alma" denmez, "Implement Etme (Uygulama)" denir.
       
       public class Toyota : Otomobil, IArac, IFrenSistemi
       {
           // 🎯 DİKKAT: Interface'den gelen metodu yazarken "override" KELİMESİ KULLANILMAZ! 
           // Bodoslama düz public metot olarak yazılır:
           public void Calis() 
           { 
               Console.WriteLine("Toyota çalıştı."); 
           }
       }

    ==================================================================================
    🆚 ABSTRACT CLASS vs INTERFACE (MÜLAKATLARIN BAŞ TACI)
    ==================================================================================
    +-----------------------------------------+----------------------------------------+
    |           ABSTRACT CLASS                |               INTERFACE                |
    +-----------------------------------------+----------------------------------------+
    | Tekil kalıtım vardır (Sadece 1 tane).   | Çoklu uygulama vardır (Sınırsız).      |
    +-----------------------------------------+----------------------------------------+
    | İçine gövdeli/normal metot yazılabilir. | İçine gövdeli metot yazılamaz (Saf).   |
    +-----------------------------------------+----------------------------------------+
    | İçinde yapıcı metot (Constructor) olur. | İçinde ASLA constructor olamaz.        |
    +-----------------------------------------+----------------------------------------+
    | Değişken (field) barındırabilir.        | İçinde asla field (int x;) olamaz.     |
    +-----------------------------------------+----------------------------------------+

    ==================================================================================
    🎯 ÖZET MÜHENDİSLİK VİZYONU
    ==================================================================================
    * Abstract Class, bir sınıfın **KİMLİĞİNİ** belirler. ("Otomobil bir Taşıttır")
    * Interface ise bir sınıfın **YETENEKLERİNİ** belirler. ("Bu otomobil ŞarjEdilebilir'dir")
    
    Interface sayesinde sistemdeki sınıflar tamamen birbirinden bağımsız (Loosely Coupled) 
    hale gelir. Gelecekte sisteme yepyeni bir banka, yepyeni bir araç veya yepyeni bir 
    özellik ekleneceğinde mevcut kodların hiçbirini bozmadan, sadece yeni bir sınıf oluşturup 
    sözleşmeyi imzalatman yeterli olur.
*/
#endregion


namespace _09_018_Interface
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
    internal class Program
    {
        static void Main(string[] args)
        {
            BenzinliOtomobil astra = new BenzinliOtomobil("Beyaz", 1500);
            astra.Doldur();
            

        }
    }

}
