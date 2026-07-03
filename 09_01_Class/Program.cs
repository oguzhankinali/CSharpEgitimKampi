using _09_01_Class;
using System;

namespace _09_01_Class
{
    // =================================================================================
    // 📘 KONU ANLATIMI: CLASS (SINIF) VE ENCAPSULATION (KAPSÜLLEME) MİMARİSİ
    // =================================================================================
    public class Otomobil
    {
        // -----------------------------------------------------------------------------
        // 1. FIELD (ALAN) TANIMI:
        // Sınıfın içinde, metotların dışında tanımlanan ve ham veriyi tutan çıplak değişkenlerdir.
        // RAM'in Heap bölgesinde nesneye ayrılan ham hafıza hücreleridir.
        // Standart olarak kurumsal kodda 'private' yapılırlar ve isimleri '_' ile başlar.
        // -----------------------------------------------------------------------------
        public string Renk;


        // -----------------------------------------------------------------------------
        // 2. PROPERTY (ÖZELLİK) VE { get; set; } TANIMI:
        // Property'ler, field'ların dış dünyaya açılan akıllı ve korumalı kapılarıdır.
        // public int Km { get; set; } yazımına "Auto-Implemented Property" denir.
        //
        // GET Nöbetçisi: Dışarıdan biri 'otomobil1.Km' yazıp veriyi OKUMAK istediğinde çalışır.
        // SET Nöbetçisi: Dışarıdan biri 'otomobil1.Km = 1200' yazıp veri YAZMAK istediğinde çalışır.
        //                Dışarıdan gelen o yeni veri içeride 'value' kelimesiyle temsil edilir.
        //
        // NEDEN PROPERTY?: get ve set bloklarının erişim seviyelerini ayrı ayrı yönetebiliriz!
        //Aşağıdaki tanım: "Dışarıdan herkes okuyabilir (public get), ama sadece bu sınıfın içindeki
        // metotlar değiştirebilir (private set)" anlamına gelir. Tam kapsülleme sağlar!
        // -----------------------------------------------------------------------------
        //Başına { get; set; }koyduğun an, o yapı artık bir field(alan) değild  ir; bir Property(Özellik) haline gelir
    
        public int Km { get; private set; }


        // Sınıfın Constructor (Yapıcı) metoduyla Km'ye ilk doğuşta değer verebiliriz
        public Otomobil(int ilkKm)
        {
            this.Km = ilkKm; // Sınıfın içinden olduğu için private set tıkır tıkır çalışır.
        }


        // Nesneye ait yetenek (Metot)
        public void Yazdir()
        {
            // Sınıfın içindeki metot, kendi private set olan Km alanına aslanlar gibi erişir.
            Console.WriteLine("Renk: " + Renk + " Km: " + Km);
        }

        // Kilometreyi güvenli bir şekilde artıracak sınıf içi bir metot örneği
        public void KilometreArttir(int gidilenMesafe)
        {
            if (gidilenMesafe > 0)
            {
                this.Km += gidilenMesafe; // private set içeride geçerlidir.
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // -----------------------------------------------------------------------------
            // 3. NESNE OLUŞTURMA (INSTANCE) VE BELLEK DAVRANIŞI:
            // 'new' kelimesi RAM'in Heap bölgesinde yepyeni bağımsız bir ev (alan) inşa eder.
            // 'otomobil1' ve 'otomobil2' Stack bölgesinde duran ve o evlerin adresini tutan pointer'lardır.
            // -----------------------------------------------------------------------------
            Otomobil otomobil1 = new Otomobil(1200); // Doğarken ilk Km'sini zorunlu verdik.
            var otomobil2 = new Otomobil(500);

            // Renk alanı 'public' bir field olduğu için dışarıdan bodoslama değiştirilebilir:
            otomobil1.Renk = "Kırmızı";
            otomobil2.Renk = "Mavi";

            // ❌ KAPSÜLLEME BARAJINA TAKILMA ANI:
            // Eğer alt satırdaki kodu açmaya çalışırsan Visual Studio hata verir (Altını kırmızı çizer):
            // otomobil1.Km = 2000; 
            // Neden?: Çünkü Km property'sinin set bloku 'private set' olarak mühürlenmiştir!
            // Dışarıdan hiç kimse Km'yi bodoslama değiştiremez, veri güvenliği %100 sağlandı.

            // 🎯 OKUMA İZNİ (GET) AKTİF:
            // public get olduğu için dışarıdan Km bilgisini ekrana aslanlar gibi bastırabiliriz:
            Console.WriteLine($"Otomobil1'in rengi: {otomobil1.Renk} Km: {otomobil1.Km}");
            Console.WriteLine($"Otomobil2'nin rengi: {otomobil2.Renk} Km: {otomobil2.Km}");

            // Renkleri güncelliyoruz (Public olduğu için izin var)
            otomobil1.Renk = "Turuncu";
            otomobil2.Renk = "Sarı";

            // Sınıf içi metotları tetikliyoruz
            otomobil1.Yazdir();
            otomobil2.Yazdir();


            
            // Km'yi bodoslama değiştiremiyoruz ama sınıfın bize izin verdiği güvenli metotla artırabiliyoruz:
            otomobil1.KilometreArttir(300);
            Console.WriteLine($"Otomobil1'in Güncel Km Bilgisi: {otomobil1.Km}"); // Çıktı: 1500
        }
    }
}
//int Km { get; set; } // ❌ bu aslında default olarak private olur. yani private int Km {get;set;} olur dışarıdan kimse erişemez değiştiremez.
//public int Km { get; set; } //  DOĞRU! şu an dışarıya açık değiştirilebilir ve okunabilir.
//public int Km { get; private set; } //  Km dışarıya public ama set özelliği yani değiştirme özelliği private
//Eğer get/set yazmazsan, o değişken ya tamamen dışarıya açıktır ya da tamamen kapalıdır. Arafta kalamaz.

// get ve setliye default değer vermek istiyorsan direkt sonrasında = değer ; yapıyorsun
//public int Km { get; set; } = 1500;
//public string Renk { get; set; } = "Beyaz"; // Rengi de default Beyaz yaptık.

// property sadece private public ayrı ayrı belirlemek için değil aynı zamanda: 
// property yaparsan, yarın bir gün set nöbetçisinin içine tek bir if şartı yazarak eksi değer girilmesini engelleyebilirsin. Property, gelecekte kodu bozmadan kural ekleyebilme esnekliğidir.
//ayrıca veri tabanı araçları çıplak fieldleri ( get ve setsiz ) bağlamayı ( data binding ) kabul etmezler.

//public int Km { get; } = 1500; // Dikkat: İçinde 'set' kelimesi hiç yok!
//Bu durumda bu 1500 değeri o arabanın asla değiştirilemez kaderi olur. Sınıfın içindeki metotlar bile (this.Km = 2000; yazarak) bu değeri bir daha asla değiştiremez! Sadece doğarken 1500 olur ve sonsuza kadar öyle kalır.

//🎯 Özet Altın Kural:
//Bir yapının önüne public yazarsan dışarıdan erişilir, private yazarsan erişilemez. (Erişim Yetkisi).

//Bir yapının sonuna { get; set; } yazarsan akıllı kapı(property) olur, yazmazsan çıplak kutu (field) olur. (Zeka Seviyesi).

//Bir yapının başına static yazarsan Sınıf üzerinden(Otomobil.Km) çağrılır, yazmazsan Nesne üzerinden (otomobil1.Km) çağrılır. (Adres Biçimi).  