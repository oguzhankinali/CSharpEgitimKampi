using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

#region 🎯 OOP 3. PRENSİBİ: ABSTRACT CLASS (SOYUT SINIFLAR) DETAYLI DERS NOTU

/*
    ==================================================================================
    🤖 ABSTRACT CLASS (SOYUT SINIF) NEDİR VE NEDEN İHTİYAÇ DUYUYORUZ?
    ==================================================================================
    Abstract Class; kendisinden bodoslama nesne üretilemeyen (new'lenemeyen), sadece 
    alt sınıflara (Child Class) şablon, yol gösterici ve anayasa olmak için yazılan 
    özel sınıflardır.
    
    * Concrete Class (Somut Sınıf): Bugüne kadar yazdığın normal sınıflardır (Otomobil, 
      ElektrikliOtomobil). Bunlardan bodoslama nesne üretilebilir (new Otomobil()).
    * Abstract Class (Soyut Sınıf): Sadece kalıtım vermek için vardır. "new Motorsiklet()" 
      yazarsan derleyici altını kırmızıyla çizer ve sistemi kilitler.

    ==================================================================================
    ⚠️ BİLGİSAYAR MÜHENDİSİNİN BİLMESİ GEREKEN KATI KURAL KİTABI
    ==================================================================================
    
    1. NESNE ÜRETİLEMEZ: 
       Abstract sınıflar RAM'de doğrudan nesneye dönüşemez. Sadece alt sınıfları 
       aracılığıyla RAM katmanına çıkabilirler.
       
    2. İÇERİK KURALI (HAP BİLGİ):
       * Bir Abstract sınıfın içinde abstract metot bulunmak ZORUNDA DEĞİLDİR. Sadece 
         new'lenmeyi engellemek için bile içi boş/normal metotlu abstract class yazabilirsin.
       * Ama eğer bir sınıfın içine tek bir tane bile "abstract metot" yazdıysan, o sınıf 
         MUTLAKA abstract class olmak zorundadır! Normal sınıfın içine abstract metot yazılamaz.

    3. METOT ÇEŞİTLİLİĞİ (ÇİFT SİLAH):
       Abstract sınıfların içine iki çeşit metot yazabilirsin:
       
       A) Abstract Metotlar (Mecburi Şablon):
          * Önüne "public abstract void MetotAdi();" yazılır.
          * Süslü parantezi { } yani GÖVDESİ YOKTUR! Sadece imza atılır.
          * **************Alt sınıf (Child) bu metodu MUTLAKA "override" anahtar kelimesiyle kendi 
            içinde yazmak ZORUNDADIR. Yazmazsa kod derlenmez.
            (Örn: Her motorun bir şekilde çalışması gerekir ama elektrikli sessiz, 
            benzinli gürültülü çalışır. Yol yöntem alt sınıfa bırakılır ama zorunlu tutulur.)
            
       B) Normal Metotlar (Hazır Davranış):
          * Süslü parantezi ve gövdesi vardır, normal kod yazılır. (Örn: GazVer metodu)
          * Alt sınıflar bu metodu bodoslama miras alır, tekrar yazmak ZORUNDA DEĞİLDİR. 
            Çünkü bu metot zaten hazır bir iş yapar.

    ==================================================================================
    🎯 ÖZET MÜHENDİSLİK VİZYONU
    ==================================================================================
    Abstract Class kullanmanın asıl amacı: Büyük projelerde yazılımcıların kafasına göre 
    sınıf üretmesini engellemek, projenin mimari standartlarını (Anayasasını) belirlemek 
    ve "Asla tek başına var olamayacak" soyut kavramların (Araç, Hayvan, İnsan, ÖdemeYöntemi) 
    bodoslama nesneye dönüşmesini engellemektir.

    Örnek: "Hayvan". Tek başına bir hayvan var olamaz; ya "Kedi"dir ya "Köpek". Demek ki Hayvan abstract olmalı.

    Eğer bir isim söylediğinde gözünün önüne direkt gidip satın alabileceğin somut bir nesne geliyorsa, o Concrete Class (Normal sınıf) olmalıdır.

    Abstract Class'lar new'lenemez. Sadece miras bırakır.
    Abstract metotların gövdesi ({ }) olamaz. İçine tek satır bile kod yazılamaz, değişken eşitlenemez. Sonuna bodoslama ; konur.
    Alt sınıf, abstract metodu override etmek ZORUNDADIR. Etmezse kod derlenmez. ( eğer üst sınıfta abstract metodu olusturduysan geçerli bu tabi)
    Constructor'lar (Yapıcı metotlar) ASLA abstract veya override OLA MAZ.
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

            //BenzinliOtomobil otomobil5 = new BenzinliOtomobil("lacivert", 0);
            //otomobil5.BenzinliAracıSur(100);
            //otomobil5.BenzinliYazdir();
            //otomobil5.Yazdir();


            //Otomobil otomobil1 = new ElektrikliOtomobil("pembe", 400);
            //otomobil1.Yazdir();

            ElektrikliMotorsiklet em1 = new ElektrikliMotorsiklet();
            em1.Calistir();
            em1.GazVer(30);

        }
    }

}
