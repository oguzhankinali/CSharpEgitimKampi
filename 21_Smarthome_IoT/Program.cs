using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum OdaAdi
{
    Mutfak,
    OturmaOdası,
    Salon,
    CocukOdasi,
    YatakOdasi
}
public enum KanalListesi
{
    TRT,
    ATV,
    SHOW,
    KANALD,
    FOX,
    TV8
}
public enum RenkListesi
{
    Sarı,
    Kırmızı,
    Mavi,
    Yeşil,
    Turuncu,
    Beyaz
}

public interface IInternetBaglantisi
{
    void GuncellemeYap();
}

public abstract class Cihaz
{
    public string Marka { get; private set; }
    public OdaAdi BulunduguOda { get; protected set; }
    public bool Durum { get; protected set; }

    public Cihaz(string marka, OdaAdi odaAdi)
    {
        Marka = marka;
        BulunduguOda = odaAdi;
        Durum = false;
    }
    public abstract void Ac();
    public abstract void Kapat();

}

public class Ampul : Cihaz
{
    public RenkListesi Renk { get; private set; }

    public Ampul(string marka,RenkListesi renk, OdaAdi odaAdi)
        :base(marka,odaAdi) // sadece iki tanesini marka ve odaAdi'ni ana sınıfa fırlattık 
        //buradaki marka ve odaAdi sadece kurye oraya x, y de yazabilirdik. Ampul'den nesne olusturulurken gelen değerler sırasıyla ana sınıf Cihaz'ın Constructor'ına gidiyor. mesela 1. sırada ne gelmiş? philips. o zaman üst sınıfta şöyle oluyor: Marka = "Philips"; o yuzden bu sınıfta kullanırken bız marka değil Ana sınıfın Marka değişkenini ve BulunduguOda'yı kullanıyoruz.
    {
        Renk = renk;
    }
    public override void Ac()
    {
        Durum = true;
        Console.WriteLine($"{BulunduguOda} odasında {Marka} cihaz açıldı. Işık rengi: {Renk}");
    }
    public override void Kapat()
    {
        Durum = false;
        Console.WriteLine($" {BulunduguOda} odasında {Marka} cihaz kapandı");
    }
    public void renkDegistir(RenkListesi renk)
    {
        Renk = renk;
        Console.WriteLine($"{BulunduguOda}'daki ampülün rengi {renk} ile değiştirildi.");
    }
}

public class Televizyon : Cihaz, IInternetBaglantisi
{
    public KanalListesi Kanal { get; private set; }
    public void GuncellemeYap()
    {
        Console.WriteLine($"{Marka} TV internete bağlandı ve son yazılım güncellemesi başarıyla yüklendi.");
    }

    public Televizyon(string marka, OdaAdi odaAdi)
        :base(marka,odaAdi)
    {
     Kanal = (KanalListesi)1;
    }
    public override void Ac()
    {
        Durum = true;
        Console.WriteLine($"{BulunduguOda} odasında {Marka} TV açıldı. Şu an açık olan kanal: {Kanal}.");
    }
    public override void Kapat()
    {
        Durum = false;
        Console.WriteLine($"{BulunduguOda} odasında {Marka} TV kapandı.");
    }
    public void kanalDegistir(int kanalNo)
    {
        Kanal = (KanalListesi)(kanalNo);
        Console.WriteLine($"{BulunduguOda} 'daki TV'de {Kanal} kanalı açıldı...");
    }
}






namespace Akıllı_Ev___IoT_Yönetim_Sistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ampul salonAmpulu = new Ampul("Philips", RenkListesi.Turuncu, OdaAdi.Salon);
            Televizyon oturmaOdasiTv = new Televizyon("Samsung", OdaAdi.OturmaOdası);
            oturmaOdasiTv.Ac();
            Ampul mutfakAmpulu = new Ampul("CATA", RenkListesi.Kırmızı, OdaAdi.Mutfak);

            Cihaz akilliCihaz; // 1. Adım: Boş bir Cihaz referansı (kumanda) ürettik.
            akilliCihaz = new Ampul("Philips", RenkListesi.Mavi, OdaAdi.Mutfak); // 2. Adım: İçine Ampul bağladık.
            akilliCihaz.Ac(); // 🎯 DİKKAT: Ekrana Ampulün açılış yazısı basılacak!

            akilliCihaz = new Televizyon("LG", OdaAdi.Salon); // 3. Adım: Aynı kumandaya bu sefer TV bağladık!
            akilliCihaz.Ac(); // 🎯 DİKKAT: Aynı satır bu sefer TV'nin açılış yazısını basacak!

            //Console.WriteLine(akilliCihaz.Kanal); burası hata verir çünkü Sen sol tarafa Cihaz akilliCihaz; yazdığın an, bilgisayara dedin ki: "Ben bu değişkene genel bir Cihaz gözlüğüyle bakacağım."
            //Bilgisayar Cihaz sınıfının içine gidip bakıyor. Sınıfın içinde Marka var, BulunduguOda var, Ac() var.Ama Kanal diye bir şey YOK. Kanal sadece Televizyon sınıfının kendi içinde tanımladığı, ona özel(spesifik) bir mülktür.
            oturmaOdasiTv.GuncellemeYap();
            oturmaOdasiTv.kanalDegistir(3);

            salonAmpulu.renkDegistir(RenkListesi.Turuncu);

            //List<Cihaz> evdekiSistemler = new List<Cihaz>();

            //evdekiSistemler.Add(salonAmpulu);
            //evdekiSistemler.Add(oturmaOdasiTv);
            //evdekiSistemler.Add(mutfakAmpulu);
            //foreach (Cihaz oAnkiCihaz in evdekiSistemler)
            //{
            //    oAnkiCihaz.Kapat();
            //    // 🚀 SİHRE BAK: oAnkiCihaz sırayla her elemanı temsil ediyor.
            //    // Döngü dönerken ampulün sırası gelince ampul kapanıyor, TV gelince TV kapanıyor.
            //    // Kimse kaybolmadı, herkes listede aslanlar gibi yaşıyor!
            //}
           
        }
    }
}

/*
 * Sen Cihaz akilliCihaz; yazdığında bilgisayara şu emri verirsin: "Ben bir değişken oluşturuyorum. Bu değişkenin içine sadece Cihaz sınıfından türemiş nesneler girebilir. Ve bu değişken üzerinden sadece Cihaz sınıfının içinde yazan metotlara erişilmesine izin ver, alt sınıfların kendi özel mülklerini engelle." Sınırlandırma mantığı tamamen budur.
 * akilliCihaz = new Ampul(...);  Girebilir. Çünkü Ampul, Cihaz'dan türemiş (miras almış) somut bir çocuktur.
 * akilliCihaz = new Televizyon(...);  Girebilir. Çünkü Televizyon, Cihaz'dan türemiş somut bir çocuktur.
 * akilliCihaz = new Kurye(...); ASLA GİREMEZ! Çünkü Kurye sınıfının Cihaz ile hiçbir soybağı (kalıtımı) yoktur.
 */
