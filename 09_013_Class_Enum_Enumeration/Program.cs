using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//Enum(Enumeration / Numaralandırma) Nedir ?: Enum'lar arka planda bodoslama tam sayılardan (int) oluşan, sadece bizim gibi insanların kodu okurken kafası karışmasın diye o sayılara metinsel etiketler yapıştırdığımız minik listelerdir.

//C# derleyicisi (Roslyn) sen yukarıdaki kodu yazıp derlediğinde, arka planda o kelimeleri bodoslama siler ve yerlerine şu tam sayıları yazar:

//Dizel = 0
//Benzinli = 1
//Hibrid = 2
//Elektrikli = 3

//Ama sen oraya veri tipi olarak kendi ürettiğin MotorTipi tipini çaktığın an, o property'nin içine bodoslama o 4 seçenek dışında hiçbir şey yazılamaz!

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

    public class Otomobil
    {
        public string Renk { get; set; }
        public int Km { get; private set; }

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
            //ANCAK C# da JS gibi this.Renk diye yazmana gerek yok çunku zaten field'da değişkeni tanımlıyorsun.
            // o yüzden direkt Renk = renk; de yazabilirsin. 
            //birden fazla constructor da tanımlayabilirsin. örn: 1 tane renk parametresi alan cons 
            // 1 tane hem renk hem km alan constructor tanımlarsın. ve bir nesne olustururken 2 parametre
            // gönderdiysen 2 parametreli constructorda olusur 1 parametrelı gonderdıysen 1 parametrelıde
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



    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Otomobil otomobil1 = new Otomobil("turuncu"); // 1 parametreli constructor'dan olusturma
            Otomobil otomobil2 = new Otomobil("kırmızı", 500);// 2 parametreli constructor'dan olusturma
            Otomobil otomobil3 = new Otomobil("kırmızı", 600, MotorTipi.Hibrid);// 3 parametreli (1'i enum) constructor'dan olusturma
            otomobil1.Yazdir();
            otomobil2.Yazdir();
            otomobil3.Yazdir();

            //burada otomobil1.Yazdir()'in sonucunda Motor Tipi: Dizel çıkacak çünkü motor tipini biz vermediğimiz için o kendi motor tipi olarak 0. value'deki Dizel'i koydu o yüzden sen gidip Enum u şöyle de düzenleyebilirdin:

            //Bilinmiyor
            //Dizel 
            //Benzinli şeklinde bu sefer eğer motor tipi verilmemişse default olarak 0 yani bilinmiyor alırdı.



            // ASLINDA BURADA BİR TYPE CASTİNG YAPILIYOR. int("merhaba") gibi? bu ornegı ben salladım altta gercek ornegı var yanı tam tersı durumu 
            // FrenDiskDurumu bir enum, yani artık bir değişken tipi. değerleri de belli iyi orta kötü. sen bu değişkenin değerine diyorsun ki 1 tam sayısını al bunu FrenDiskDurumu'na dönüştür. orada da 0 iyi 1 orta 2 kötü o zaman 1 olan iyi 1'in FrenDiskDurumu karsılıgına donustureyım dıyorsun.

            FrenDiskDurumu mevcutDurum = (FrenDiskDurumu)1;
            Console.WriteLine(mevcutDurum);

            // aynı şekilde tersten yaparsan da :
            FrenDiskDurumu durum = FrenDiskDurumu.KÖTÜ;

            // Şimdi KÖTÜ etiketini alıp int süzgecinden geçirip sayıya çeviriyoruz:
            int sayiKarsiligi = (int)durum;
            Console.WriteLine(sayiKarsiligi); // Ekran Çıktısı bodoslama: 2


            FrenDiskDurumu durum2 = (FrenDiskDurumu)5;
            Console.WriteLine(durum2); // bunun cıktısı duz 5 olur cunku ıcerıde 3 deger var burada 5 dıyor

            ////--- yani enum dediğimiz şey: int türündeki sayıların üzerine yapıştırdığımız metinsel etiketlerdir.
            ///0 : iyi 1: orta 2: kötü
            ///




            /// enumun değerleri 
            //Enum içine yazdığın o kelimeler(Dizel, Benzinli, İYİ), C# dilinde "Identifier" (Tanımlayıcı/Değişken Adı) olarak geçer. Yani tıpkı bir değişken tanımlarken verdiğin isimler gibidir. Sen nasıl gidip int ++ = 5; veya string 34534 = "Oğuzhan"; yazamıyorsan, enum içine de bunları yazamazsın. C#'ta değişken ismi tanımlama kuralları neyse, enum içine yazacağın etiketlerin kuralları da birebir aynıdır.            {
            //  merhaba, 🎯 DOĞRU: Yasal bir tanımlayıcı isimdir.
            // ++,❌ HATA: Özel karakterler (++, --, +, *, /) değişken adı OLA MAZ!
            //34534, ❌ HATA: Bir değişken veya etiket adı asla SAYI İLE BAŞLAYAMAZ/SAYIDAN OLUŞAMAZ!
            //true, ❌ HATA: C# dilinin kendi rezerve kelimeleri (true, false, class, int, switch) isim olarak KULLANILAMAZ!

            // bunu statik nesne olarak olusturdugmuz ıcın Otomobil.rnd diye erişiyoruz da burada olusturup dırekt rnd.Next diyerek de yapabilirdik. 

            int x = Otomobil.rnd.Next(0, 100); // 0, 99 arasında bir random sayı üret
            Console.WriteLine(x);

            double sans = Otomobil.rnd.NextDouble(); // 0.0 ile 1.0 arası sayı fırlatır
            // 0.0 dahil 1.0 hariç
            if (sans < 0.35)
            {
                Console.WriteLine("KRİTİK VURUŞ!"); // %35 ihtimalle buraya düşer
            }

            Random rnd2 = new Random();
            byte[] sepet = new byte[5]; // 5 elemanlı boş byte dizisi

            rnd2.NextBytes(sepet); // Sepeti bodoslama rastgele sayılarla doldurdu!
                                   // İçindekiler artık şansına göre şöyle olur: [45, 233, 12, 89, 174]

            //            🧠 1.Boyut ve Kapasite Farkı(RAM Katmanı)
            //float(Single - Precision): RAM'de 4 byte (32 bit) yer kaplar.

            //double(Double - Precision): RAM'de 8 byte (64 bit) yer kaplar. Yani tam iki katı. C# dünyasında ondalıklı bir sayı yazdığında (örn: 12.5) bilgisayar bunu varsayılan olarak double kabul eder. float yapmak istiyorsan sonuna 12.5f diye mühür çakman gerekir.

            //🔍 2.Hassasiyet Farkı(Matematik Katmanı)
            //RAM'deki yer azaldıkça, virgülden sonra güvenle tutabileceğin basamak sayısı da bodoslama azalır.

            //float: Virgülden sonra en fazla 6 - 9 basamak arasında güvenli(kesin) sonuç verir. Sonrasını bodoslama yuvarlar veya sallar.

            //double: Virgülden sonra 15 - 17 basamak boyunca milimetrik olarak doğru sonuç verir.

            //    Finansal işlemlerde, para, kur ve muhasebe hesaplarında asla ne float ne de double kullanılır!İkisi de arka planda ikilik(binary) sistemde çalıştığı için ufak yuvarlama hataları yapar.Para işlerinde virgülden sonra % 100 kesinlik sağlayan decimal(128 - bit) tipi kullanılır.
            //

            //            decimal x = 0.3123124512412m; // 🎯 Sonundaki 'm' veya 'M' harfi ZORUNLUDUR!
            //            Nasıl ki float tanımlarken sonuna f koyuyorsak, decimal tanımlarken de sonuna m(Money'den aklında kalsın) koymak zorundasın. Koymazsan C# onu bodoslama double sanır ve derleme hatası verir.
            //                Peki decimal'ın Float ve Double'dan Farkı Ne ?
            //Devasa Boyut: RAM'de tam 16 byte (128 bit) yer kaplar! Yani float'ın 4 katı, double'ın 2 katı büyüklüktedir.

            //Muazzam Hassasiyet: Virgülden sonra tam 28 - 29 basamağı milimetrik olarak hiçbir yuvarlama hatası yapmadan tutabilir.
        }
    }

}
