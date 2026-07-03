using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_012__KuryeClass
{

    public class Kurye
    {
        // --- 1. NESNEYE ÖZGÜ (STATIC OLMAYAN) ALANLAR ---
        // Her kuryenin adı ve şahsi dağıtımı kendine özeldir.
        public string KuryeAdi;
        public int SahsiDagitimSayisi;

        // --- 2. SINIFA ÖZGÜ (STATIC) ALAN ---
        // Tüm kuryelerin toplamda kaç paket dağıttığı tektir, şirketin ortak malıdır.
        public static int ToplamSirketDagitimi = 0;


        //Fark şudur:
        //
        //public int SahsiDagitimSayisi; Nesneye özgüdür.Sen new ile 100 tane kurye oluşturursan, RAM'de 100 tane ayrı SahsiDagitimSayisi kutusu oluşur. Her kuryenin kendi kutusu vardır, birbirini bağlamaz. Nesne adı üzerinden erişilir (kurye1.SahsiDagitimSayisi).

        //public static int ToplamSirketDagitimi = 0; Sınıfa özgüdür. Sen 100 tane kurye de oluştursan, RAM'de bu kutudan bodoslama sadece 1 tane oluşur.Tüm kuryeler bu tek kutuyu ortaklaşa kullanır. Sınıf adı üzerinden erişilir (Kurye.ToplamSirketDagitimi).

        // Constructor (Yapıcı Metot): Nesne new'lenirken kuryeye isim veriyoruz
        public Kurye(string ad)
        {
            this.KuryeAdi = ad;
            this.SahsiDagitimSayisi = 0; // Şahsi dağıtımı sıfırla başlıyor
        }

        // 🔥 3. NESNEYE ÖZGÜ (STATIC OLMAYAN) METOT
        // Bu metot sadece o kuryeyi ilgilendirir. Kurye paket dağıttıkça şahsi sayısını artırır.
        public void PaketDagit(int adet)
        {
            this.SahsiDagitimSayisi += adet; // Şahsi sayısını artırdı

            // DİKKAT: Statik olmayan bir metot, içeride statik olan ortak alanı da güncelleyebilir!
            Kurye.ToplamSirketDagitimi += adet; // Şirketin toplam sayısını da artırdı

            Console.WriteLine(KuryeAdi + " isimli kurye " + adet + " paket dağıttı.");
        }

        // 🚀 4. SINIFA ÖZGÜ (STATIC) METOT
        // Bu metodun nesnelerle işi yok! Şirketin genel durum raporunu basar.
        // Başına 'public static' çaktık, geri dönüşü yok (void).
        public static void SirketRaporuYazdir()
        {
            // 🚨 KRİTİK MÜHENDİSLİK KURALI: 
            // Statik bir metodun içinde "this.KuryeAdi" yazamazsın! Derleyici hata verir.
            // Çünkü bu metot çağrıldığında ortada hangi kuryenin olduğu belli değildir.
            // Sadece statik olan ortak alanlara erişebilir:

            Console.WriteLine("=== ŞİRKET GENEL RAPORU ===");
            Console.WriteLine("Şu ana kadar tüm kuryelerin dağıttığı TOPLAM paket: " + Kurye.ToplamSirketDagitimi);
            Console.WriteLine("===========================");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------------------------------
            // ADIM 1: Nesneler RAM'de doğuyor (Constructor çalışıyor)
            // ------------------------------------------------------------------------
            Kurye kurye1 = new Kurye("Ahmet");
            Kurye kurye2 = new Kurye("Mehmet");
            Kurye kurye3 = new Kurye("Can");

            /* 🧠 ŞU AN RAM'DEKİ MANZARA:
               [Kurye Sınıfının Ortak Alanı (Static)]
               └── ToplamSirketDagitimi = 0  <-- Bütün mahallede sadece 1 tane var!

               [kurye1 Nesne Hücresi] ──> KuryeAdi = "Ahmet",  SahsiDagitimSayisi = 0
               [kurye2 Nesne Hücresi] ──> KuryeAdi = "Mehmet", SahsiDagitimSayisi = 0
               [kurye3 Nesne Hücresi] ──> KuryeAdi = "Can",    SahsiDagitimSayisi = 0
            */

            // ------------------------------------------------------------------------
            // ADIM 2: Ahmet (kurye1) işe çıkıyor
            // ------------------------------------------------------------------------
            kurye1.PaketDagit(5);
            // PaketDagit metodu kurye1 üzerinden çağrıldı. Metodun içindeki 'this' artık 'kurye1'dir!
            // this.SahsiDagitimSayisi += 5 ──> kurye1'in şahsi sayısını 5 yaptı.
            // Kurye.ToplamSirketDagitimi += 5 ──> Ortak havuzdaki sayıyı da 5 yaptı.

            // ------------------------------------------------------------------------
            // ADIM 3: Mehmet (kurye2) işe çıkıyor
            // ------------------------------------------------------------------------
            kurye2.PaketDagit(10);
            // Metodun içindeki 'this' artık 'kurye2'dir!
            // this.SahsiDagitimSayisi += 10 ──> kurye2'nin şahsi sayısı 10 oldu.
            // Kurye.ToplamSirketDagitimi += 10 ──> Ortak havuz 5 idi, üstüne 10 eklendi ve 15 oldu!

            // ------------------------------------------------------------------------
            // ADIM 4: Can (kurye3) bodoslama yatıyor, hiç paket dağıtmıyor.
            // ------------------------------------------------------------------------

            // ------------------------------------------------------------------------
            // SON DURUMDA RAM'İ EKRANA BASIP KONTROL EDELİM:
            // ------------------------------------------------------------------------
            Console.WriteLine(kurye1.KuryeAdi + " şahsi paket: " + kurye1.SahsiDagitimSayisi); // Çıktı: 5
            Console.WriteLine(kurye2.KuryeAdi + " şahsi paket: " + kurye2.SahsiDagitimSayisi); // Çıktı: 10
            Console.WriteLine(kurye3.KuryeAdi + " şahsi paket: " + kurye3.SahsiDagitimSayisi); // Çıktı: 0 (Hiç paket dağıtmadı)

            // Şirketin toplam ortak kutusuna bakıyoruz:
            Console.WriteLine("Şirket Toplam Paket: " + Kurye.ToplamSirketDagitimi); // Çıktı: 15
        }
    }
}
