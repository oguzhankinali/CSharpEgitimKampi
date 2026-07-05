using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
===================================================================================================
🧠 C# GELİŞMİŞ KOLEKSİYONLAR & LAMBDA FONKSİYONLARI TEKNİK NOTLARI (ARŞİVLİK)
===================================================================================================

---------------------------------------------------------------------------------------------------
1. .NET COLLECTIONS FRAMEWORK: LIST<T> VS ARRAY (DİZİ) FARKLARI
---------------------------------------------------------------------------------------------------
* Boyut Esnekliği: Standart dizilerin (Array) boyutu RAM'de sabit olarak tanımlanır ve sonradan 
  değiştirilemez. List<T> ise "Dinamik Dizi" mimarisindedir; eleman eklendikçe veya silindikçe 
  arkada kendi boyutunu otomatik olarak yönetir ve genişletir.
* Hazır Metotlar: List<T> yapısı; Add(), RemoveAt(), Clear(), Find() ve RemoveAll() gibi karmaşık 
  algoritmaları arkada hazır metot olarak sunar. Dizilerde bu işlemler amele gibi manuel yapılır.
* LINQ Gücü: List<T> koleksiyonları, veri filtreleme ve gruplama işlemlerini tek satıra indiren 
  LINQ mekanizmalarıyla milimetrik olarak uyumlu çalışır.

---------------------------------------------------------------------------------------------------
2. HIGHER-ORDER FUNCTIONS & DELEGATE (PARAMETRE OLARAK METOT ALAN METOTLAR)
---------------------------------------------------------------------------------------------------
* "garaj.RemoveAll(arac => arac is ElektrikliOtomobil);" satırında ne oluyor?
  RemoveAll() metodu bodoslama bir değer (örneğin düz bir string veya int) alarak çalışmaz. 
  Koleksiyondaki elemanları test etmek için bir "test kuralı / kriter" bekler. Yazılım dünyasında 
  argüman olarak metot (kural) kabul eden bu fonksiyonlara Higher-Order Function denir.
* JavaScript (JS) Benzerliği: Bu yazım tarzı, JS dünyasındaki Arrow Function (ok fonksiyonları) 
  mimarisiyle milimetrik olarak tıpatıp aynıdır. Sol taraftaki "arac", o an test edilen nesneyi 
  temsil eden geçici bir isimdir; sağ taraf ise dönen mantıksal kuraldır.

---------------------------------------------------------------------------------------------------
3. REMOVEALL(BENZINLIMI) DÖNGÜSÜZ NASIL ÇALIŞIYOR? (ARKA PLAN SİMÜLASYONU)
---------------------------------------------------------------------------------------------------
Kod bloklarında açıkça bir "foreach" yazılmamış olmasına rağmen, RemoveAll(BenzinliMi) komutu 
tüm listeyi sırayla dönebilir. Çünkü döngü mimarisi RemoveAll() metodunun kendi kaynak kodunda 
(gövdesinde) zaten yazılmıştır. Arka plandaki simülasyon milimetrik olarak şöyle işler:

        static bool BenzinliMi(Otomobil arac)
        {
            return arac is BenzinliOtomobil;
        }

          Sen garaj.RemoveAll(BenzinliMi); dediğin an 

  Adım 1: RemoveAll metodu kendi içindeki gizli döngüyü başlatır ve listenin 0. indeksindeki nesneyi alır.
  Adım 2: Bu nesneyi, senin ona parametre olarak verdiğin "BenzinliMi(Otomobil arac)" metoduna fırlatır.
  Adım 3: BenzinliMi metodu çalışır; nesne eğer bir elektrikli otomobil ise geriye "false" fırlatır.
  Adım 4: RemoveAll bu "false" cevabını alınca "Tamam, bu eleman silinmeyecek, kalıyor" der.
  Adım 5: Döngü bir sonraki indekse geçer. Sıradaki nesneyi yine BenzinliMi metoduna fırlatır.
  Adım 6: BenzinliMi metodu nesneyi inceler; eğer nesne BenzinliOtomobil ise geriye "true" fırlatır.
  Adım 7: RemoveAll bu "true" cevabını aldığı an o nesneyi bodoslama listeden siler.

Özetle; döngü ameleliğini .NET framework üstlenir, sen sadece her elemana sırayla uygulanacak 
olan test cihazını (yani metodunu) ona teslim edersin.

---------------------------------------------------------------------------------------------------
4. TYPE CHECKING: "IS" OPERATÖRÜ NEDİR VE KULLANIMLARI NE?
---------------------------------------------------------------------------------------------------
C# dilinde "is" anahtar kelimesi "Type Checking (Tip Kontrolü)" ve "Pattern Matching" konusudur. 
Bir nesnenin RAM'deki gerçek kimliğini (özünü) sorgulamaya yarar. Geriye bool (true/false) döner.

* Kullanım A (Klasik Kontrol):
  if (arac is BenzinliOtomobil) { // Nesne özünde benzinli mi? }

* Kullanım B (Modern Kontrol - Tip Kontrolü + Anında Değişken Oluşturma):
  if (arac is BenzinliOtomobil benzinli)
  {
      // Bilgisayar nesnenin benzinli olduğunu doğrularsa, "benzinli" isminde alt sınıfa ait 
      // yeni bir kumanda üretir. Böylece tip dönüştürme (cast) yapmadan alt sınıfın özel 
      // metotlarına bodoslama erişebilirsin:
      benzinli.BenzinliAracıSur(50);
  }

---------------------------------------------------------------------------------------------------
5. SYNTAX METOT KURALLARI: NEDEN PROGRAM İÇİNDE, MAIN DIŞINDA VE NEDEN STATIC?
---------------------------------------------------------------------------------------------------
* Neden Program İçinde, Main Dışında?: C# kuralları gereği, bir metodun içine bodoslama isimli 
  başka bir metot yazılamaz (Local function istisnaları hariç kurumsal standart budur). Main de 
  nihayetinde bir metot olduğu için, BenzinliMi metodunu Main ile aynı hizada, yani Program 
  sınıfının bağımsız bir üyesi olarak dışarıya yazmak zorundasın.
* Neden Static olmak zorunda?: C# mimarisinde en temel kural şudur: "Static üyeler, doğrudan 
  sadece static üyeleri çağırabilir." Projenin giriş kapısı olan Main metodu "static" işaretlidir. 
  Eğer BenzinliMi metodunun başına static yazmasaydın, Main içinden ona nesne üretmeden doğrudan 
  ulaşamazdın ve derleyici kırmızı çizgiyi çekerdi. Ayrıca "garaj.RemoveAll(BenzinliMi);" şeklinde 
  doğrudan metot ismini fırlatabilmek için de o metodun static olması şarttır.

===================================================================================================
EK SORULAR: 
🔍 1. is Operatörü ile == Arasındaki Fark Nedir?
C# derleyicisinde if (arac == BenzinliOtomobil) yazarsan bilgisayar derleme hatası fırlatır ve kod çalışmaz. Neden? Çünkü == operatörü iki nesneyi veya iki değeri (RAM'deki adreslerini ya da içeriklerini) karşılaştırmak için kullanılır. BenzinliOtomobil ise bir değer değil, bir sınıftır (yani bir kalıptır). Bilgisayara "Bu elma eşit midir elma kasasının şablonuna?" diyemezsin.

İşte is operatörü tam olarak burada devreye girer. is, bir nesnenin tipini, kimliğini veya kalıtım ağacını sorgular.

🧪 Canlı Simülasyon Odası
Diyelim ki elimizde şöyle bir nesne üretim şeması var:


Otomobil arac1 = new BenzinliOtomobil("Kırmızı", 0);
Otomobil arac2 = new BenzinliOtomobil("Kırmızı", 0);
❌ == Kullanımı (Nesne Karşılaştırma)

if (arac1 == arac2) { // Bu çalışır AMA GERİYE FALSE DÖNER! }
Türkçe Meali: İkisinin de rengi kırmızı ve km'si 0 olsa bile, arac1 ve arac2 RAM'de tamamen farklı iki adreste (farklı koltuklarda) oturan iki ayrı nesnedir. == operatörü bunların RAM'deki adreslerine bakar, "farklı" der ve false döner.

is Kullanımı (Kullanım A - Tip/Kimlik Kontrolü)

if (arac1 is BenzinliOtomobil) { // 🎯 DOĞRU VE ÇALIŞIR: Geriye TRUE döner! }
Türkçe Meali: Bilgisayar sol taraftaki kısıtlanmış Otomobil kumandasına takılmaz. Gider RAM'deki nesnenin özüne bakar: "Kardeşim bu nesnenin fabrikasyon kalıbında BenzinliOtomobil geni var mı?" der. Cevap evet olduğu için true fırlatır.

Bu arada Modern C# ta yeni özellik yani Local Function gelmiş ve bizim fonksiyonu direkt main içine yazdım: 
internal class Program
{
    static void Main(string[] args)
    {
        // 🎯 ÇALIŞIR (Local Function): Başına public/static koymadan, düz isimle tanımladık.
        bool BenzinliMiYerel(Otomobil arac)
        {
            return arac is BenzinliOtomobil;
        }

        // Bu fonksiyon sadece ve sadece bu Main metodunun içinde çağrılabilir, dışarıdan kimse göremez.
        List<Otomobil> garaj = new List<Otomobil>();
        garaj.RemoveAll(BenzinliMiYerel); 
    }
}
*/


namespace _11_Lambda
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
            bool BenzinliMi(Otomobil arac)
            {
                return arac is BenzinliOtomobil;
            }

            Console.WriteLine("ilk hali: ");
            garaj.Add(new ElektrikliOtomobil("Beyaz", 900));
            garaj.Add(new BenzinliOtomobil("Turuncu", 300));
            garaj.Add(new ElektrikliOtomobil("Mavi", 2500));
            garaj.Add(new BenzinliOtomobil("Yeşil", 7000));

            foreach (Otomobil arac in garaj)
            {
                arac.Yazdir();
            }
            // indexi 1 olan (2. sıradaki) aracı sil
            garaj.RemoveAt(0);
            Console.WriteLine("\n 0. indextekini sildikten sonraki hali: ");
            foreach (Otomobil arac in garaj)
            {
                arac.Yazdir();
            }
            //garajdaki tüm araçları sil
            //garaj.Clear();
            //Console.WriteLine("\nTüm araçlar silindikten sonraki hali: ");
            //foreach (Otomobil arac in garaj)
            //{
            //    arac.Yazdir();
            //}
            //ElektrikliOtomobil tesla = new ElektrikliOtomobil("Turuncu", 9000);
            //garaj.Add(tesla);
            //foreach (Otomobil arac in garaj)
            //{
            //    arac.Yazdir();
            //}

            Console.WriteLine("\nElektrikli otomobiller siliniyor...  ");
            Console.WriteLine();
            garaj.RemoveAll(arac => arac is ElektrikliOtomobil); // lambda function
            // ELEKTRİKLİ OLANLARIN TAMAMINI SİL
            // şimdi elektrikli silindi yeni listeyi yazdıralım:
            foreach (Otomobil arac in garaj)
            {
                arac.Yazdir();
            }
            garaj.Add(new ElektrikliOtomobil("Beyaz", 900));
            garaj.Add(new ElektrikliOtomobil("Mavi", 2500));


            Console.WriteLine("\nTekrar eski hale getirelim...");
            Console.WriteLine();
            foreach (Otomobil arac in garaj)
            {
                arac.Yazdir();
            }

            // AYNI FONKSİYONU KENDİMİZ DE YAZABİLİRİZ YUKARIDA benzinliMi diye yazdım. 

            garaj.RemoveAll(BenzinliMi); // şu anda da benzinli olanları döndürüyor True olarak ve her birini tek tek siliyor RemoveAll 
            Console.WriteLine("\nBenzinli araçlar siliniyor...");
            foreach (Otomobil arac in garaj)
            {
                arac.Yazdir();
            }

        }


    }
}
