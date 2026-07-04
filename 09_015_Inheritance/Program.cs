using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// OOP'nin 4 temel prensibi 
//1- Encapsulation: Bir sınıfın içindeki verileri dış dünyaya karşı korumaya almak, ucu açık bir şekilde yağmalanmasını engellemek ve veriye erişimi kontrollü bir süzgeçten geçirmektir."
//2- Inheritance: 


#region 🎯 OOP 2. PRENSİBİ: INHERITANCE (KALITIM / MİRAS ALMA) DETAYLI DERS NOTU

/*
    ==================================================================================
    🤖 KALITIM (INHERITANCE) NEDİR?
    ==================================================================================
    Kalıtım; bir sınıfın (Class), başka bir sınıfın sahip olduğu tüm özellikleri (Properties)
     ve metotları (Methods) bodoslama kendi üzerine miras almasıdır.
    
    * Miras VEREN tarafa: Base Class (Ata / Ebeveyn Sınıf) veya Parent Class denir.
    * Miras ALAN tarafa: Derived Class (Türemiş / Çocuk Sınıf) veya Child Class denir.
    
    Gerçek dünya metaforu: Babanın bir evi ve arabası varsa, sen doğduğun an sıfırdan ev 
    ve araba inşa etmekle uğraşmazsın; babanın malları otomatik olarak senin de kullanımına 
    açılır. İşte kalıtım tam olarak budur.

    ==================================================================================
    🚨 KALITIM OLMASAYDI BAŞIMIZA NE BELALAR AÇILIRDI? (Amelelik Senaryosu)
    ==================================================================================
    Diyelim ki bir galeri uygulaması yazıyorsun. Projede "Otomobil", "Motosiklet" ve 
    "Kamyon" diye 3 farklı sınıfın var. Kalıtım olmasaydı:
    
    * Üç sınıfın içine de gidip tek tek: Renk, Km, Fiyat, UretimYili özelliklerini yazacaktın.
    * Üç sınıfın içine de gidip tek tek: Calis(), Dur(), FasilaliSilecek() metotlarını yazacaktın.
    
    Günün birinde müdür gelip "Kanka, tüm araçlara 'Plaka' diye bir özellik ekleyelim" dediğinde 
    projedeki 3 sınıfı da tek tek gezip elinle amele gibi modifiye etmek zorunda kalacaktın. 
    Kod tekrarı (Code Duplication) yüzünden proje çöplüğe dönecekti.

    ==================================================================================
    🛠️ C# SYNTAX MANTIĞI VE KURAL KİTABI
    ==================================================================================
    C# dilinde miras alma işlemi bodoslama iki nokta üst üste (:) operatörü ile yapılır.
    
    // ATA SINIF (Tüm araçların ortak noktası)
    public class Tasit 
    {
        public string Renk { get; set; }
        public int Km { get; set; }
        public void Calis() { Console.WriteLine("Taşıt çalıştı."); }
    }

    // ÇOCUK SINIF (Taşıt sınıfının üstüne çöküyor)
    public class Otomobil : Tasit 
    {
        // Buranın içi BOMBOŞ olsa bile, Otomobil artık otomatik olarak Renk ve Km'ye sahiptir!
        // Üstüne bir de kendine has özel bir yetenek ekleyebilir:
        public bool BagajHavuzuVarMi { get; set; } 
    }

    ==================================================================================
    ⚠️ BİLGİSAYAR MÜHENDİSİNİN ASLA UNUTMAMASI GEREKEN 3 ALTIN KURAL
    ==================================================================================
    
    1. C# TEKİL KALITIMI DESTEKLER (Single Inheritance):
       Bir çocuk sınıf bodoslama sadece ve sadece TEK BİR sınıftan miras alabilir. 
       Yani "public class Otomobil : Tasit, ElektronikCihaz" şeklinde iki babalı bir 
       kod YAZAMAZSIN! C# derleyicisi anında kafana vurur. (Bunun istisnası ileride 
       göreceğin Interface yapılarıdır).

    2. "IS-A" (Bir ...-dır) İLİŞKİSİ:
       Kalıtım kurarken sınıflar arasında mantıklı bir bağ olmalıdır. 
       * Otomobil bir Taşıt-tır. (Mantıklı, Kalıtım yapılabilir).
       * Kamyon bir Taşıt-tır. (Mantıklı, Kalıtım yapılabilir).
       * Ama "Masa bir Taşıt-tır" diyemezsin. Sırf ortak özellikleri (ayak sayısı, renk vs.) 
         benziyor diye alakasız sınıfları birbirine miras bağlama!

    3. PRIVATE ve PROTECTED Nöbetçileri:
       * Bir Ata sınıftaki özellik "private" ise, çocuk sınıf onu miras ALAMAZ, gözüyle bile göremez.
       * Eğer bir özelliğin dış dünyaya kapalı (private) ama sadece benim çocuklarıma açık 
         olmasını istiyorsan, erişim belirtecini bodoslama "protected" yapacaksın.

    ==================================================================================
    🎯 EN BÜYÜK FAYDASI NEDİR?
    ==================================================================================
    * Reusability (Yeniden Kullanılabilirlik): Kodu bir kere yaz, her yerde miras alıp tepe tepe kullan.
    * Kolay Bakım: Ortak bir kodu değiştirmek istediğinde sadece Ata sınıfa (Base Class) 
      müdahale etmen yeterlidir. Tüm çocuk sınıflar güncellemeyi anında devralır.
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
    //    base kelimesi C# dilinde "Benim hemen üstümdeki ebeveynim, yani Ata sınıfım (Base Class)" anlamına gelen sihirli bir kısayoldur. Sen ElektrikliOtomobil için bir nesne oluşturduğunda, bu sınıfın kendi başına bir nesne olabilmesi için önce onun atasının (Otomobil) RAM'de doğması gerekir.

    //Eğer :base(...) mühürünü koymasaydın, C# derleyicisi bodoslama gidip Otomobil sınıfının içindeki paramatresiz (boş) constructor'ı çalıştırmaya çalışacaktı. Ama senin Otomobil sınıfında boş constructor yok! Hepsi parametre istiyor.

    //İşte :base(renk, baslangicKm, MotorTipi.Elektrikli) yazarak ebeveynine şu emri veriyorsun:

    //"Ey ata sınıfım Otomobil! Ben bir elektrikli arabayım. Benim için RAM'de ayağa kalkarken, sana zahmet kendi içindeki 3 parametreli constructor'ını tetikle. Al sana renk, al sana başlangıç km'si, motor tipini de ben zaten kendim bodoslama Elektrikli olarak buraya mühürledim, onu da al ve önce kendini yarat!"

    public class BenzinliOtomobil : Otomobil
    {
        public int kalanBenzin { get; set; }
        public BenzinliOtomobil(string color, int firstKm)
            :base(color, firstKm, MotorTipi.Benzinli)
        {
            kalanBenzin = 100;

        }
        public void BenzinliAracıSur(int km)
        {
            // 1. Üst sınıftan miras aldığımız o orijinal Sur() metodunu bodoslama çağırıyoruz.
            // Böylece arabanın Km'si aslanlar gibi güncelleniyor:
            Sur(km);

            // 2. Hemen alt satırda benzini düşürüp senkronize ediyoruz:
            kalanBenzin = kalanBenzin - ((km * 6) / 100);
        }
        public void BenzinliYazdir()
        {
            // Önce üst sınıftaki orijinal Yazdir() çalışsın, yanına da benzini ekleyelim:
            Yazdir();
            Console.WriteLine($"Kalan Benzin: {kalanBenzin} Lt.");
        }
    }







    public class ElektrikliOtomobil : Otomobil // otomobil parent, elektrikliOtomobil child
    {
        public int BataryaYuzde { get; private set; }
        public ElektrikliOtomobil(string renk, int baslangicKm)
            : base(renk, baslangicKm, MotorTipi.Elektrikli)
        // ust sınıfın constructor'ının verılerını alıyoruz
        // ==================================================================================
        // 💊 HAP BİLGİ: CONSTRUCTOR VE :base() EŞLEŞME ANAYASASI
        // ==================================================================================
        // 1. SIRALAMA KATIDIR: :base(x, y, z) içindeki parametrelerin yazılış sırası ve veri tipleri, 
        //    üst sınıfın constructor parametre sırasıyla (string, int, enum) milimetrik olarak AYNI olmalıdır. 
        //    Sırayı karıştırırsan derleyici anında çöker.
        //
        // 2. İSİMLER ÖZGÜRDÜR: Alt sınıftaki parametre isimleri (Örn: color, firstKm) ile üst sınıftaki 
        //    parametre isimlerinin (Örn: renk, baslangicKm) aynı olması ŞART DEĞİLDİR. 
        //    Bilgisayar isimlere bakmaz; alt sınıftan fırlatılan ham değerleri, üst sınıftaki 
        //    kutulara sırasına göre bodoslama eşleştirir.
        // yani ben şöyle de yazabilirdim:
        //public ElektrikliOtomobil(string color, int firstKm)
        //    :base(color, firstKm, MotorTipi.Elektrikli)  mevzu matching eşleşme
        // ==================================================================================
        // ayrıca biz burada şöyle de yapabilirdik base kullanmadan: 
        //public ElektrikliOtomobil(string color, int firstKm)
        //{
        //    BataryaYuzde = 100;
        //    Renk = color;
        //    Km = baslangicKm;
        //    Motor = MotorTipi.Elektrikli;
        //}
        //ama burada da şuna dikkat etmen gerekiyor: mesela ana sınıfta public int x { get; private set; } yaparsan
        //    alt sınıftan buradaki bilgileri değiştiremiyorsun. o yuzden private değil protected set; yaparsan alt sınıflardan da erişip değiştirebilirsin.
        // ***** AMA BUNUN İÇİN ANA SINIFTA BOŞ BİR CONSTRUCTOR OLUŞTURMAN LAZIM YOKSA OLMAZ 
        // Çünkü protected, "Dış dünyaya kapalı ama sadece benim alt sınıflarıma açık" demektir.


        {
            BataryaYuzde = 100;
        }
        public void SarjEt()
        {
            BataryaYuzde = 100;
            Console.WriteLine("Araç şarj edildi");
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
        public void Yazdir()
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

            Otomobil otomobil1 = new Otomobil("turuncu"); // 1 parametreli constructor'dan olusturma
            Otomobil otomobil2 = new Otomobil("kırmızı", 500);// 2 parametreli constructor'dan olusturma
            Otomobil otomobil3 = new Otomobil("kırmızı", 600, MotorTipi.Hibrid);// 3 parametreli (1'i enum) constructor'dan olusturma
            //otomobil1.Yazdir();
            //otomobil2.Yazdir();
            //otomobil3.Yazdir();

            //ElektrikliOtomobil otomobil4 = new ElektrikliOtomobil("sarı", 500);
            //otomobil4.Yazdir(); // Elektrikli Oto sınıfında yazdır metodu yok ama parentınde var onu da alıyor 
            //otomobil4.SarjEt(); // Bu direkt Elektrikli Oto sınıfına ait 
            //Console.WriteLine("Batarya: "+ otomobil4.BataryaYuzde + "% ");



            BenzinliOtomobil otomobil5 = new BenzinliOtomobil("lacivert", 0);
            // Bizim yazdığımız yeni metodu çağırıyoruz:
            otomobil5.BenzinliAracıSur(100);
            // Bu tek satır arkada hem üst sınıfın Km'sini artırdı, hem benzini düşürdü!

            // Güncel durumu yeni metotla yazdırıyoruz:
            otomobil5.BenzinliYazdir();

        }
    }
//    // ayrıca composite formatting örneği: 
//        string isim = "Oğuzhan";
//        int yas = 26;
//        string sehir = "Sakarya";

//// Koltukları (indeksleri) metnin içine diziyoruz:                           0    1     2
//Console.WriteLine("Selam, benim adım {0}, yaşım {1} ve {2}'da yaşıyorum.", isim, yas, sehir);
}
