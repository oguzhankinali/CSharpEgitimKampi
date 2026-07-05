using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#region 🎯 OOP 4. PRENSİBİ: POLYMORPHISM (ÇOK BİÇİMLİLİK) DETAYLI DERS NOTU

/*
    ==================================================================================
    🤖 POLYMORPHISM (ÇOK BİÇİMLİLİK) NEDİR?
    ==================================================================================
    Polymorphism, nesne yönelimli programlamanın en büyük felsefelerinden biridir. 
    Kelime anlamı "Çok Biçimlilik"tir. 
    
    Yazılım dünyasındaki karşılığı şudur: Bir nesnenin veya bir metodun, farklı durumlarda 
    ve farklı alt sınıflarda FARKLI DAVRANIŞLAR sergileyebilme yeteneğidir.
    
    * Felsefe: "Aynı komut, farklı nesnelerde farklı sonuçlar doğurur."
    * Gerçek dünya metaforu: Bir orkestra şefinin tüm müzisyenlere bodoslama "ÇAL!" 
      komutu verdiğini düşün. Şef herkes için tek bir kelime kullanır ("Çal"). Ama flütçü 
      flüt çeker, davulcu davula vurur, gitarist tellere basar. Tek bir komut, her müzisyende 
      farklı bir biçimde (Çok Biçimli) hayat bulur.

    ==================================================================================
    🚨 KOD DÜNYASINDA İKİ ÇEŞİT POLYMORPHISM VARDIR (MÜLAKAT BOMBASI)
    ==================================================================================
    
    1. RUNTIME POLYMORPHISM (Dinamik / Çalışma Zamanı Çok Biçimliliği)
       -------------------------------------------------------------------------------
       * Senin kodda aslanlar gibi kullandığın "virtual" ve "override" mekanizmasıdır!
       * Ata sınıfta (Otomobil) virtual bir metot (Yazdir) tanımlarsın. Çocuk sınıflar 
         (Benzinli, Elektrikli) bu metodu override ederek ezer.
       * Program ÇALIŞIRKEN (Runtime), bilgisayar o an hangi nesne aktifse onun override 
         edilmiş metodunu bodoslama tetikler.

    2. COMPILE TIME POLYMORPHISM (Statik / Derleme Zamanı Çok Biçimliliği)
       -------------------------------------------------------------------------------
       * Bu da senin daha önceki derslerde kesinlikle kullandığın "Method Overloading" 
         (Metot Aşırı Yüklemesi) mekanizmasıdır!
       * Aynı isimde ama farklı parametre alan metotlar yazmaktır.
       * Örn: Otomobil sınıfındaki 1 parametreli, 2 parametreli ve 3 parametreli constructor'lar 
         buna en net örnektir. İsim aynıdır ama gelen parametreye göre biçim değiştirir.

    ==================================================================================
    🛠️ BİLGİSAYAR MÜHENDİSİNİN ASLA UNUTMAMASI GEREKEN BÜYÜK SİHİR
    ==================================================================================
    Polymorphism'in en büyük sihri, çocuk nesneleri ata sınıfın (Parent) referansıyla 
    ayakta tutabilmektir. 
    
    Senin kodundan gidelim:
    Otomobil oto1 = new ElektrikliOtomobil("Kırmızı", 0);
    Otomobil oto2 = new BenzinliOtomobil("Mavi", 100);
    
    * Dikkat ettiysen sol taraflar düz "Otomobil", yani ata sınıf. Ama sağ taraflar çocuk sınıflar.
    * Ben bir liste yapsam: "List<Otomobil> garaj = new List<Otomobil>();"
    * Bu listenin içine hem ElektrikliOtomobil'i hem BenzinliOtomobil'i bodoslama atabilirim!
    * Sonra bir foreach döngüsüyle garajı gezip "oto.Yazdir();" dediğimde; bilgisayar runtime'da 
      kendisi anlar, elektrikli olan için bataryalı yazıyı, benzinli olan için benzinli yazıyı basar.
      İşte bu esnekliğin kod dünyasındaki adı Polymorphism'dir.

    ==================================================================================
    🎯 EN BÜYÜK FAYDASI NEDİR?
    ==================================================================================
    * Esneklik ve Genişletilebilirlik: Yarın bir gün projeye "HidrojenliOtomobil" diye yeni 
      bir sınıf eklendiğinde, ana kodlarındaki döngüleri, listeleri veya metotları zerre 
      değiştirmek zorunda kalmazsın. O yeni sınıf da Otomobil'den türediği ve Yazdir'ı 
      override ettiği sürece sisteme çat diye entegre olur.
    * Kod Karmaşasını Engeller: Devasa if-else bloklarından projenin mimarisini kurtarır.
*/

#endregion

namespace _09_019_Polymorphism
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
            BenzinliOtomobil astra = new BenzinliOtomobil("Beyaz", 1500);
            //astra.Doldur();
            ElektrikliOtomobil tesla = new ElektrikliOtomobil("Kırmızı", 2000);

            //IYenidenDoldurulabilir arac;
            //arac = new ElektrikliOtomobil("Beyaz", 2000);
            //arac.Doldur();

            //arac = new BenzinliOtomobil("Mavi", 50000);
            //arac.Doldur();


            Istasyon istasyon1 = new Istasyon();    
            istasyon1.HizliDoldur(tesla);
            istasyon1.HizliDoldur(astra);

            Otomobil oto;
            oto = new ElektrikliOtomobil("Kahverengi", 2000);
            oto.Yazdir();

            oto = new BenzinliOtomobil("Siyah", 3500);
            oto.Yazdir();
        }

    }

}
