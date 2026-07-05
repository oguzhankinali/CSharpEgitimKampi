using System;
using System.Collections.Generic;
// ====================================================================================
// 💡 POLIMORFIZM FELSEFE NOTU
// ====================================================================================
/*
 * Biz sol tarafı kısıtlamayı sadece ve sadece "Farklı türden nesneleri tek bir çatı altında toplayıp ortak yönetmek" istediğimizde yaparız.
 */

#region 🧪 DENEY 1: ASKER VE BORDO BERELİ ÖRNEĞİ

public abstract class Asker
{
    public string Isim { get; set; }
    public abstract void Nisanal();
}

public class BordoBereli : Asker
{
    // Bordo berelinin herkesin yapamadığı kendine has özel bir yeteneği var:
    public void TersKandilUcusuYap()
    {
        Console.WriteLine("Özel taktik hava harekâtı yapılıyor!");
    }

    public override void Nisanal()
    {
        Console.WriteLine("Hedef %100 hassasiyetle kilitlendi.");
    }
}

// ====================================================================================
// 🧪 DENEY 1 MAIN KODLARI VE NOTLARI
// ====================================================================================
/*
 * şimdi buradaki örnekte şöyle: Asker diye soyut bir sınıf oluşturuyoruz. Bunun da bir alt sınıfı var BordoBereli diye. 
 * Abstract class'ın neleri var: isim ve Nisanal metodu 
 * Normalde biz Asker sınıfından nesne oluşturamıyoruz ya. 
 * Ama şimdi biz main'de gidip
 * Asker asker1 = new BordoBereli(); dediğimiz zaman Asker sınıfının özelliklerine sahip bir BordoBereli nesnesi üretmiş oluruz. 
 */
//Asker asker1 = new BordoBereli();

//asker1.Isim = "Bordo Bereli Ahmet"; // asker1.isim = çalışır
//asker1.Nisanal();                  // asker1.Nisanal() = çalışır 

/*
 * ama asker1.TersKandilUcusuYap() çalışmaz çünkü bu nesne BordoBereli özelliklerine sahip değil Asker özelliklerine sahip. 
 * yani Asker 'den bir nesne türetmiş gibi oluyoruz ama içini BordoBereli'de doldurdugumuz fonksiyonu çalıştırabiliyoruz.
 */
// asker1.TersKandilUcusuYap(); // ❌ HATA VERİR (Derleyici İzin Vermez)

#endregion

#region 🧪 ÖRN 2: INTERFACE VE EJDERHA ÖRNEĞİ

public interface IUçabilir
{
    void Havalan();
}

public class Ejderha : IUçabilir
{
    public string Ad { get; set; } = "Smaug";
    public int AtesGucu { get; set; } = 9000;

    public void Havalan()
    {
        Console.WriteLine("Kanatlar çırpıldı, gökyüzüne çıkılıyor.");
    }
}
// ====================================================================================
// 🧪 ÖRN 2 MAIN KODLARI VE NOTLARI
// ====================================================================================
/*
 * Şimdi burada da IUçabilir diye bir interface tanımladık. aynı sekılde bunda da Havalan() diye bir fonk var. 
 * Ejderha sınıfımızda bu IUçabilir sözleşmesini implement ediyoruz. 
 * şimdi main'e gelelim. 
 * IUçabilir ejderha1 = new Ejderha(); dedik ve interface tipinde bir referans değişken tipi olusturup buna bir nesne atadık. 
 * Bu nesne IUçabilir interface'inin sınırladığı özelliklere sahip. Ama IUçabilir içindeki fonksiyonun gövdesini biz Ejderha sınıfı ıcınde tanımladıgımız için buna erişebiliyoruz. 
 * yani ejderha1.Havalan(); çalışır 
 * ancak ejderha1.Ad ; veya ejder1.AtesGucu hata verir çünkü erişemez. 
// */
//IUçabilir ejderha1 = new Ejderha();
//ejderha1.Havalan(); // 🎯 çalışır

// Console.WriteLine(ejderha1.Ad);       // ❌ HATA VERİR (Erişemez)
// Console.WriteLine(ejderha1.AtesGucu); // ❌ HATA VERİR (Erişemez)

#endregion

#region 🧪 DENEY 3: HAYVAN BARINAĞI VE FOREACH ÖRNEĞİ

public abstract class Hayvan
{
    public abstract void SesCikar();
}

public class Kedi : Hayvan
{
    public override void SesCikar() { Console.WriteLine("Miyav!"); }
}

public class Kopek : Hayvan
{
    public override void SesCikar() { Console.WriteLine("Hav!"); }
}
// ====================================================================================
// 🧪 DENEY 3 MAIN KODLARI VE NOTLARI
// ====================================================================================
/*
 * Buradaki örnekte de Hayvan diye bir Abstract Soyut bir Ana sınıfımız var. 
 * Bu sınıfın ıkı tane alt sınıfı var concrete. Kedi ve Köpek.
 * İkisi de abstract sınıfta tanımlanan abstract metodu kullanmak zorunda. 
 * * şimdi biz main'de tüm hayvanları bir List'e eklemek istiyoruz. 
 */
//List<Hayvan> barınak = new List<Hayvan>();
//barınak.Add(new Kedi());
//barınak.Add(new Kopek());

//foreach (Hayvan x in barınak)
//{
//    x.SesCikar(); // 🎯 BURAYA DİKKAT!
//}

/*
 * yani burada yaptıgı şey aslında yukarıdaki asker ve ejderha örneğindeki gibi. 
 * yani Hayvan hayvan1 = new Kedi(); gibi olusturuyoruz. 
 * * // Döngünün 1. turu (Bilgisayar arka planda x'i kediye eşitler):
 * Hayvan x = new Kedi(); 
 * x.SesCikar(); // 🎯 Ekrana "Miyav!" basar.
 * * // Döngünün 2. turu (Bilgisayar arka planda aynı x'i köpeğe eşitler):
 * x = new Kopek(); 
 * x.SesCikar(); // 🎯 Ekrana "Hav!" basar.
 * * aslında yaptıgımız şeyin arka planı bu. Hayvan sınıfının özelliklerine sahip Kedi Köpek nesneleri olusturuyoruz. ve onları foreach ile yazdırıyoruz. 
 */

#endregion

namespace Interface___Polymorphism___Abstract_Class_Örnek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine(); // Konsol hemen kapanmasın diye
        }
    }
}