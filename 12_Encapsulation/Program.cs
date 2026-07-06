using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// OOP'nin 4 temel prensibi 
//1- Encapsulation: Bir sınıfın içindeki verileri dış dünyaya karşı korumaya almak, ucu açık bir şekilde yağmalanmasını engellemek ve veriye erişimi kontrollü bir süzgeçten geçirmektir."

#region 🎯 OOP 1. PRENSİBİ: ENCAPSULATION (KAPSÜLLEME) DETAYLI DERS NOTU

/*
    ==================================================================================
    🤖 KAPSÜLLEME (ENCAPSULATION) NEDİR?
    ==================================================================================
    Kapsülleme, bir nesnenin kendi içindeki verilerini (alanlarını/fields) dış dünyadan 
    gizlemesi ve bu verilere dışarıdan doğrudan erişilmesini yasaklamasıdır. 
    Amaç, veriyi körü körüne korumak değil; veriye erişimi KONTROLLÜ HALE GETİRMEKTİR.
    
    Tıpkı eczaneden aldığın bir kapsül ilaç gibidir. İlacın içindeki kimyasal tozlar 
    (veriler) dış etkenlerden korunması için plastik bir çeperle (kapsülle) sarılmıştır. 
    Sen o tozu çıplak elle ellemezsin, kapsülü yutarak kontrollü bir şekilde vücuda alırsın.

    ==================================================================================
    🚨 KAPSÜLLEME OLMASAYDI BAŞIMIZA NE BELALAR AÇILIRDI?
    ==================================================================================
    Eğer bu kodda Km özelliğini "public int Km { get; set; }" şeklinde bıraksaydık:
    Main içinde herhangi biri gelip bodoslama şunu yazabilirdi:
    
        otomobil1.Km = -50000; 
        otomobil1.Km = 99999999;
    
    Bir arabanın kilometresi gerçek dünyada eksi değer alamaz ya da durduğu yerde tavan yapamaz.
    Kapsülleme olmasaydı, projedeki herhangi bir yazılımcı veya dışarıdan gelen kirli bir veri
    sınıfımızın içindeki mantığı felç edebilirdi.

    ==================================================================================
    🛠️ BU KODDA KAPSÜLLEME NASIL UYGULANDI? (2 BÜYÜK SİLAH)
    ==================================================================================
    
    1. SİLAH: "private set" Koruması (Property Kapsüllemesi)
       -------------------------------------------------------------------------------
       public int Km { get; private set; }
       
       * "get" kısmı PUBLIC: Yani dışarıdaki herkes arabanın kaç kilometrede olduğunu görebilir. 
         (Console.WriteLine(otomobil1.Km) aslanlar gibi çalışır.)
       * "set" kısmı PRIVATE: Dış dünyadan hiç kimse arabanın kilometresini bodoslama elle 
         DEĞİŞTİREMEZ! (otomobil1.Km = 500; yazarsan derleyici altını anında kırmızıyla çizer).
       * Bu özellik sayesinde Kilometre verisini dış dünyaya karşı kilitlemiş olduk.

    2. SİLAH: Kontrollü Erişim ve Değişim Metodu (Süzgeç)
       -------------------------------------------------------------------------------
       Madem Km'yi private set ile kilitledik, peki bu araba yol yaptıkça kilometre nasıl artacak? 
       İşte burada devreye kontrollü değişim metodu olan "Sur(int kacKm)" giriyor.
       
       Biz dış dünyaya diyoruz ki: "Kardeşim, Km verisine doğrudan dokunamazsın. Eğer kilometreyi 
       artırmak istiyorsan benim kurallarıma uyacaksın ve SUR metodunu çağıracaksın."
       
       Sur metodunun içine yazdığımız:
       
       if (kacKm <= 0) { ... return; }
       
       Muhafız şartı (Guard Clause) sayesinde, dışarıdan gelen veriyi önce bir süzgeçten geçiriyoruz. 
       Gelen sayı geçerliyse (pozitifse) Km hücresine ekleme yapıyoruz. Kirliyse kapıdan kovuyoruz.

    ==================================================================================
    🎯 ÖZET MÜHENDİSLİK VİZYONU
    ==================================================================================
    Kapsülleme sayesinde:
    1. Sınıfımızın içindeki verilerin güvenliğini %100 garanti altına aldık (Data Hiding).
    2. Hatalı veya kirli verilerin sınıfın iç mantığını bozmasını engelledik.
    3. Verinin nasıl ve hangi şartlarda değişeceğinin anayasasını tek bir merkezde (Sur metodu içinde) yazdık.
*/

#endregion

#region KAPSÜLLEME (ENCAPSULATION) & PROPERTY DERİN KONU ANLATIMI

/*
=======================================================================================
                        KAPSÜLLEME (ENCAPSULATION) & PROPERTY
=======================================================================================

1. ENCAPSULATION (KAPSÜLLEME) NEDİR?
   * Bir sınıfın içindeki verileri (field/değişkenleri) 'private' yaparak dış dünyaya 
     bodoslama kapatma ve koruma altına alma olayıdır. 
   * Amaç: Sınıfın içindeki kritik verilerin, dışarıdan kuralsızca veya mantıksız 
     değerlerle (Örn: notun -5, bakiyenin -500, yaşın 999 yapılması gibi) kirletilmesini engellemektir.

2. PROPERTY (ÖZELLİK) YAPISI NEDİR?
   * private yaptığımız o gizli verilere dışarıdan güvenli bir şekilde erişebilmek için 
     kullandığımız AKILLI GÜVENLİK KAPILARIDIR.
   * Property bir değişken değildir; içinde 'get' (okuma) ve 'set' (yazma) adında iki adet 
     kod bloğu barındıran akıllı bir metot çatısıdır.

3. 'get' VE 'set' BLOKLARININ TÜRKÇE MEALİ

class Student
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname {
            get { return Name; }
            set
            {
                if (value != "")
                {
                    Name = value;
                }
            }
        }
        public string Department { get; set; }

        private double gpa;
        public double Gpa {
            get { return gpa; }
            set
            {
                if(value>= 0 && value <=100)
                {
                    gpa = value;
                }

            }
        }

        public Student(int id, string name, string surname, string department, double gpa)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Department = department;
            Gpa = gpa;
        }
   * get { return gpa; } -> Birisi dışarıdan 'ogrenci.Gpa' diyerek değeri OKUMAK istediğinde,
     arka taraftaki o gizli 'gpa' kasasının içindeki değeri dışarı fırlatır (return eder).
   * set { ... } -> Birisi dışarıdan 'ogrenci.Gpa = 85.5;' diyerek yeni bir değer YAZMAK 
     istediğinde bu kapı tetiklenir ve içerideki filtreleri (IF kontrolünü) çalıştırır.

4. 'value' ANAHTAR KELİMESİ NEREDEN GELİYOR? MANTIĞI NE?
   * 'value', C# dilinin içine önceden gömülmüş gizli bir anahtar kelimedir.
   * Sen Main içinde 'ogrenci.Gpa = 85.5;' yazdığın an, o eşittir sağındaki '85.5' değeri 
     otomatik olarak 'value' kelimesinin içine kaydolur.
   * Sadece double için değil; 'int', 'string', 'bool' dahil C#'taki TÜM veri tiplerinin 
     property yapılarında dışarıdan gelen değeri yakalayan ortak kutunun adı 'value'dur.

5. "public string Name { get; private set; }" KISA YAZIMINDAN FARKI NE?
   * Senin daha önce gördüğün o kısa yazım "Auto-Implemented Property" (Otomatik Özellik) olarak geçer.
   * O kısa yazımda arka plandaki gizli kasayı ve value atamasını C# kendi hafızasında otomatik yapar.
   * Ama ne zaman ki içeriye bir IF KOŞULU (mantıksal denetim) eklemek istersen, o kısa yazım patlar.
   * Mecburen gizli kasayı (private field) elle yazıp, get ve set bloklarının içini bu dersteki gibi doldurman gerekir.

=======================================================================================
             FULL PROPERTY (ELLE DOLDURULAN YAPI) GÖRSEL KOD ŞEMASI (MANTIKSAL AKIŞ)
=======================================================================================

    // A. GİZLİ KASA (Field): Dış dünya bunu asla göremez. Verinin asıl saklandığı güvenli yer.
    private double gpa; 

    // B. GÜVENLİK KAPISI (Property): Dış dünyanın gördüğü ve etkileşime girdiği akıllı arayüz.
    public double Gpa 
    {
        get 
        { 
            return gpa; // Kasadaki değeri dışarı ver.
        }
        set 
        { 
            // 1. Atama yapıldığı an (ogrenci.Gpa = 85.5) sağdaki değer 'value' olur. (value = 85.5)
            // 2. Dedektör çalışır: Gelen değer mantıklı bir not aralığında mı?
            if (value >= 0 && value <= 100) 
            {
                gpa = value; // 3. Şart doğruysa, gelen notu arkadaki o gizli 'gpa' kasasına yazdır/kilitle!
            }
            // 4. Eğer şart yanlışsa (Örn: -5 girildiyse) IF çalışmaz, kasa eski değerini korur, kirlenmez.
        }
    }

=======================================================================================
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

            // şimdi burada else ile de yapabilirdik. 
            // void demek değer döndürmüyor demek ama aynı zamanda return ile kodu durdurabilirsin da yani else gibi
            // void'deki return direkt if'ten cıkarıyor ve o kapsamdakı kodu durduruyor 
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

            FrenDiskDurumu mevcutDurum = (FrenDiskDurumu)1;
            Console.WriteLine(mevcutDurum);

            // aynı şekilde tersten yaparsan da :
            FrenDiskDurumu durum = FrenDiskDurumu.KÖTÜ;

            // Şimdi KÖTÜ etiketini alıp int süzgecinden geçirip sayıya çeviriyoruz:
            int sayiKarsiligi = (int)durum;
            Console.WriteLine(sayiKarsiligi); // Ekran Çıktısı bodoslama: 2


            FrenDiskDurumu durum2 = (FrenDiskDurumu)5;
            Console.WriteLine(durum2); // bunun cıktısı duz 5 olur cunku ıcerıde 3 deger var burada 5 dıyor

            Console.WriteLine("Oto1 güncel km: " + otomobil1.Km);
            otomobil1.Sur(1000);
            otomobil1.Yazdir();
            Console.WriteLine("-1000 km sür dedik");
            otomobil1.Sur(-1000);
            otomobil1.Yazdir();


        }
    }

}
