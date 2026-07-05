using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MakingDecision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region If

            //Console.Write("Lütfen şifrenizi giriniz: ");
            //string password = Console.ReadLine();
            //if(password == "abcd")
            //{
            //    Console.WriteLine("Doğru girdiniz.");
            //}
            //else
            //{
            //    Console.WriteLine("Şifre yanlış.");
            //}

            //string capital, country;
            //Console.Write("Başkenti Giriniz: ");
            //capital = Console.ReadLine();
            //Console.Write("Ülkeyi Giriniz: ");
            //country = Console.ReadLine();
            //if(capital == "Ankara" & country == "türkiye")
            //{
            //    Console.WriteLine("Veriler doğrulandı");
            //}
            //else
            //{
            //    Console.WriteLine("Hata");
            //}


            //int sayi;
            //Console.Write("Sayıyı giriniz: ");
            //sayi = int.Parse(Console.ReadLine());
            //if (sayi > 0)
            //{
            //    Console.WriteLine("Pozitif sayı");
            //}
            //else if (sayi == 0)
            //{
            //    Console.WriteLine("Sayı 0'dır.");
            //}
            //else 
            //{
            //    Console.WriteLine("Negatif Sayı");
            //}

            //Console.Write("Sınıfınızı Giriniz: ");
            //string sinif = Console.ReadLine();
            //if(sinif == "10a" | sinif =="10b" | sinif == "10c"){
            //    Console.WriteLine("10. Sınıf");
            //}
            //else
            //{
            //    Console.WriteLine("10. sınıf değil");
            //}

            //int nmbr = 26;
            //int result = nmbr % 5;
            //Console.WriteLine(result);

            ////switch case

            //Console.Write("Ayı giriniz: ");
            //int Month = int.Parse(Console.ReadLine());

            //switch (Month)
            //{
            //    case 1: Console.WriteLine("Ocak"); break;
            //    case 2: Console.WriteLine("Şubat"); break;
            //    case 3: Console.WriteLine("Mart"); break;
            //    case 4: Console.WriteLine("Nisan"); break;
            //    case 5: Console.WriteLine("Mayıs"); break;
            //    case 6: Console.WriteLine("Haziran"); break;
            //    case 7: Console.WriteLine("Temmuz"); break;
            //    case 8: Console.WriteLine("Ağustos"); break;
            //    case 9: Console.WriteLine("Eylül"); break;
            //    case 10: Console.WriteLine("Ekim"); break;
            //    case 11: Console.WriteLine("Kasım"); break;
            //    case 12: Console.WriteLine("Aralık"); break;

            #endregion

            #region loops
            //break: döngüyü tamamen bitirip dışarı çıkar.
            //continue: döngünün o turunu atlayıp bir sonraki tura geçer.

            ////For(x;y;z) x: başlangıç y: bitiş z: artış-azalış

            //for (int i = 1; i < 5; i++)
            //{
            //    Console.WriteLine("slm ya");
            //}

            //While(şart){

            //}
            //int x = 1;
            //while (x <= 5)
            //{
            //    Console.WriteLine("aslm ya");
            //    x++;
            //}
            //for(int a=1; a<=5; a++)
            //{
            //    for(int b=5; b>=a; b--)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //// Üst kısım (Artan Yıldızlar)
            //for (int i = 1; i <= 4; i++) // 4 satır dönecek
            //{
            //    // Boşluklar (Satır arttıkça boşluk azalıyor: 3, 2, 1, 0 gibi)
            //    for (int j = 1; j <= 5 - i; j++) { Console.Write(" "); }
            //    // Yıldızlar (Tek sayılarla artıyor: 1, 3, 5, 7)
            //    for (int k = 1; k <= 2 * i - 1; k++) { Console.Write("*"); }

            //    Console.WriteLine(); // Satırı bitir, aşağı in
            //}

            //// Alt kısım (Azalan Yıldızlar)
            //for (int i = 3; i >= 1; i--) // 3 satır dönecek
            //{
            //    // Boşluklar (Satır azaldıkça boşluk artıyor: 3, 4, 5)
            //    for (int j = 1; j <= 5 - i; j++) { Console.Write(" "); }
            //    // Yıldızlar (Tek sayılarla azalıyor: 5, 3, 1)
            //    for (int k = 1; k <= 2 * i - 1; k++) { Console.Write("*"); }

            //    Console.WriteLine();
            //}

            string s = "Merhaba";

            Console.WriteLine(s.Length);
            Console.WriteLine(s.ToUpper());
            Console.WriteLine(s.ToLower());

            //contains: bir stringin içinde başka bir stringin olup olmadığını kontrol eder. True veya False döner.
            string text = "C# string metodları";
            Console.WriteLine(text.Contains("string"));


            //startsWith: bir stringin belirli bir string ile başlayıp başlamadığını kontrol eder. True veya False döner.
            string url = "https://www.example.com";
            Console.WriteLine(url.StartsWith("https://"));
            Console.WriteLine(url.EndsWith("https://"));

            //Substring: bir stringin belirli bir kısmını almak için kullanılır. Başlangıç indexi ve uzunluk parametreleri alır.
            string tarih = "2024-06-15";
            string yil = tarih.Substring(0, 4); // 0. indexten başla ve 4 karakter al
            Console.WriteLine(yil);
            string ay = tarih.Substring(5, 2); // 5. indexten başla ve 2 karakter al
            Console.WriteLine(ay);


            //replace: bir stringin belirli bir kısmını başka bir string ile değiştirmek için kullanılır. İlk parametre değiştirilecek kısmı, ikinci parametre ise yeni değeri belirtir.
            string metin = "Merhaba dünya";
            Console.WriteLine(metin.Replace("Dünya", "C#"));
            Console.WriteLine(metin.Replace("a","q")); // a ları q ile değiştirir


            //split: bir stringi belirli bir karaktere göre parçalara ayırmak için kullanılır. Parametre olarak ayırıcı karakteri alır ve string dizisi döner.

            string csv = "Ali, Veli, Ayşe";
            string[] isimler = csv.Split(','); // yani , e göre ayır diziye at
            Console.WriteLine(isimler.Length);


            //Join: bir string dizisini belirli bir karakter ile birleştirmek için kullanılır. İlk parametre olarak birleştirici karakteri alır ve tek bir string döner.

            string[] kelimeler = { "C#", "C++", "Python" };
            Console.WriteLine(string.Join(" - ", kelimeler));


            //Equals: iki stringin eşit olup olmadığını kontrol etmek için kullanılır. True veya False döner.
            string s1 = "Admin";
            string s2 = "admin";
            Console.WriteLine(s1.Equals(s2));

            //Trim(): bir stringin başındaki ve sonundaki boşlukları temizlemek için kullanılır. Yeni bir string döner.
            string ad = "       Batuhan    ";
            Console.WriteLine(ad.Trim());


            //






            #endregion

        }


























    }
    
}
