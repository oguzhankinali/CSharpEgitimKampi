using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Yazdıgımız sınıfları dırekt Add - Class diyerek yeni dosya actık oraya yapıstırdık 
 * Eğer internal yazarsan: projeye özgü olur sadece o projedeki diğer sınıflar görür 
 * Eğer public yazarsan diğer projelerden de erişebilirsin sınıfa.
 * Ayrıca tüm dosyaların aynı namespace olması lazım
 * 
 * /*
===================================================================================================
🏛️ C# NAMESPACE (İSİM ALANI) MİMARİSİ VE EKİP ÇALIŞMASI TEKNİK NOTLARI
===================================================================================================

---------------------------------------------------------------------------------------------------
1. NAMESPACE NEDİR VE GERÇEK DÜNYADAKİ KARŞILIĞI NE?
---------------------------------------------------------------------------------------------------
* Tanım: Namespace (İsim Alanı), kod içerisindeki sınıfları (Class), arayüzleri (Interface) ve 
  enumları mantıksal olarak gruplamaya yarayan devasa birer "Ülke" veya "Klasör" gibidir.
* Temel Ameliyat: C# derleyicisi için bir sınıfın tam adı sadece "Otomobil" değildir; onun 
  bulunduğu namespace ile birleşimidir (Örn: _12_AyrıDosyalar_Internal.Otomobil). 
  Buna yazılım dünyasında "Fully Qualified Name" (Tam Nitelikli İsim) denir.

---------------------------------------------------------------------------------------------------
2. BÜYÜK PROJELERDE EKİP ÇALIŞMASI VE "İSİM ÇAKIŞMASI (NAMING COLLISION)" KRİZİ
---------------------------------------------------------------------------------------------------
Diyelim ki bir ekiple devasa bir kurumsal bankacılık veya e-ticaret projesi (Örn: Akbank mimarisi) 
geliştiriyorsun. Ekipte iki farklı yazılımcı var:
  * Ahmet: Kullanıcıların log-in işlemlerini kodluyor.
  * Mehmet: Kullanıcıların veri tabanındaki profil kartlarını kodluyor.

Kriz Senaryosu: Ahmet de kendi klasöründe "User" adında bir sınıf açtı, Mehmet de "User" adında 
bir sınıf açtı. Eğer namespace mimarisi olmasaydı, proje derlenirken derleyici çıldırır ve 
"Kardeşim aynı isimde iki sınıf olamaz!" diyerek projeyi patlatırdı.

Namespace Çözümü: Ekip projeyi namespace'lere böler:
  * Ahmet'in sınıfı:  "namespace Banka.Auth" içerisindeki User sınıfı olur.
  * Mehmet'in sınıfı: "namespace Banka.DataAccess" içerisindeki User sınıfı olur.

Böylece tek bir proje içinde, birbirini ezmeyen, tamamen bağımsız iki farklı "User" sınıfı 
aslanlar gibi yan yana yaşayabilir. Main içinde çağırırken de kim karışıklık istemiyorsa bodoslama 
"Banka.Auth.User" diyerek nokta atışı çağırır.

---------------------------------------------------------------------------------------------------
3. MODÜLER DÜZEN VE "USING" MEKANİZMASININ TÜRKÇE MEALİ
---------------------------------------------------------------------------------------------------
* Aynı Namespace Gücü: Eğer oluşturduğun farklı `.cs` dosyalarının en tepesindeki namespace 
  isimleri milimetrik olarak aynıysa (Örn: _12_AyrıDosyalar_Internal), bu dosyalar birbirini 
  doğrudan tanır. Araya hiçbir import/export ameleliği girmeden tak tak birbirini çağırırlar.
* Farklı Namespace Durumu (USING): Eğer bir sınıf farklı bir namespace altındaysa (Örn: Başka bir 
  ekip arkadaşının yazdığı kodlar), derleyiciye o ülkeye giriş vizesi vermen gerekir. 
  Dosyanın en tepesine "using Banka.Auth;" yazdığın an, o ülkenin içindeki tüm sınıfların kapısını 
  kendi dosyana bodoslama açmış olursun.

===================================================================================================
*/



namespace _12_AyrıDosyalar_Internal
{
    internal class Program
    {


        static void Main(string[] args)
        {

            bool BenzinliMi(Otomobil arac)
            {
                return arac is BenzinliOtomobil;
            }



            //List<Otomobil> garaj = new List<Otomobil>(); 
            Console.WriteLine("ilk hali: ");
            List<IYenidenDoldurulabilir> garaj = new List<IYenidenDoldurulabilir>();

            garaj.Add(new ElektrikliOtomobil("Beyaz", 900));
            garaj.Add(new BenzinliOtomobil("Turuncu", 300));
            garaj.Add(new ElektrikliOtomobil("Mavi", 2500));
            garaj.Add(new BenzinliOtomobil("Yeşil", 7000));
            garaj.Add(new ElektrikliMotorsiklet());
            // garaj.Add(new ElektrikliMotorsiklet()); Bu hata verir çünkü List<Otomobil> dedik
            // eğer bunu List<IYenidenDoldurabilir> Olarak düzenlersek ElektrikliMotorsiklet e de erişebiliriz.
            // aslında burada yaptığımız şey IYenidenDoldurulabilir sözleşmesini imzalayan herkesi ...

            Console.WriteLine("Tüm yeniden doldurulabilir araçlar dolduruluyor. \n");

            foreach (IYenidenDoldurulabilir arac in garaj)
            {
                arac.Doldur();
            }
            /*
===================================================================================================
🔌 INTERFACE TABANLI ÇOK BİÇİMLİLİK (INTERFACE POLYMORPHISM) TEKNİK NOTLARI
===================================================================================================

---------------------------------------------------------------------------------------------------
1. LİST<OTOMOBİL> VS LİST<IYENİDENDOLDURULABİLİR> FARKI NEDİR?
---------------------------------------------------------------------------------------------------
* Sınıf Sınırlandırması (Eski Hali): List<Otomobil> dediğimizde, listenin içine sadece Otomobil 
  genetiği taşıyan nesneleri alabiliyorduk. Bu yüzden IYenidenDoldurulabilir sözleşmesini imzalamış 
  olsa bile bir "Motosiklet" bu listeye giremiyordu (Derleme hatası veriyordu).
* Sözleşme Sınırlandırması (Yeni Hali): List<IYenidenDoldurulabilir> yaptığımızda ise aralarındaki 
  soy bağını, akrabalığı tamamen çöpe attık. Bilgisayara şu emri verdik: "Bu listeye giren varlığın 
  araba mı, motor mu, yoksa şarjlı matkap mı olduğu beni ilgilendirmez. Tek bir kuralım var; bu 
  nesne IYenidenDoldurulabilir sözleşmesini (Interface) imzalamış olmak zorunda!"

---------------------------------------------------------------------------------------------------
2. ARKA PLANDAKİ KISITLAMA SİHRİ VE DÖNGÜ DAVRANIŞI
---------------------------------------------------------------------------------------------------
* Tıpkı "Otomobil oto = new ElektrikliOtomobil();" yazımındaki gibi, burada da listenin elemanlarına 
  tamamen interface gözlüğüyle bakıyoruz. 
* Kısıtlama Kuralı: Döngü dönerken "arac" değişkeni üzerinden nesnelerin kendi özel mülklerine 
  (Örn: Otomobilin rengine, kilometresine veya motor tipine) ASLA ERİŞEMEYİZ. Bilgisayar nesnelerin 
  tüm kimliğini gizler.
* Güçlü Tarafı: Erişim sadece ve sadece IYenidenDoldurulabilir interface'inin getirdiği "Doldur()" 
  metodu ile sınırlandırılır. Bu sayede tek satırda ("arac.Doldur();") hem elektrikli arabayı 
  şarj edebilir, hem benzinli arabaya yakıt alabilir, hem de elektrikli motosikleti sessizce 
  doldurabiliriz. Her nesne, arka planda kendi sınıfında ezdiği (implement ettiği) gövdeyi tetikler.

===================================================================================================
*/
        }


    }
}
