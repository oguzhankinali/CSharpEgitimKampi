using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // bunlar kütüphaneler 

namespace _01_MainSubjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Yazdırma Komutları
            //Console.Write("Selam"); // mesela .Write yazdıgımız zaman küp çıktı küp çıkınca method anlamına gelir
            //Console.Write(" Dünya");
            ////Console.Write direkt olarak yazdırır ve alt satıra geçmez 
            ////Console.WriteLine ise yazdırır ve alt satıra geçer.
            //Console.Write("\n"); // Ters Slash:  Alt Gr + ?
            //Console.WriteLine("İkinci komut"); // Alt Satıra geçiyor
            //Console.WriteLine("WriteLine sayesinde önceki satır alt satıra geçti");
            //Console.Read(); // bu satırın amacı programın kapanmasını engellemek
            //                // ama vs 2026 surumunde bunu yazmaya gerek yok gibi sanırım direkt console.write ile artık konsol hemen acılıp kapanmmıyor. 
            //                // ama bu arada eğer sen console.read eklersen konsolu kapatmak için enter'a basman gerekir.
            #endregion
            #region Değişkenler
            // değişken(variable): geçici olarak ram'de tutulan ve veriler üzerinde işlem yapmamızı sağlayan programlama değerleridir

            //string

            string name;
            name = "Murat";
            Console.WriteLine(name);
            string customerName, customerSurname;
            customerName = "Ahmet";
            //aynı şekilde Console.Writeline() ile de boşluk bırakılıp alt satıra geçilebilir.


            //int 
            
            int yas = 25;
            int hamburgerCount = 3;
            int hamburgerPrice = 300;
            int totalprice = hamburgerCount * hamburgerPrice;
            Console.WriteLine("Toplam Hamburger Fiyatı: " + totalprice + "TL");


            double number1 = 3.14; // çıktısı 3,14 olur virgül yani
            Console.WriteLine(number1);

            //char
            // normal string " " ile tanımlanırken char ' ' ile tanımlanır
            char symbol = 'a';
            Console.WriteLine(symbol);

            #endregion

            #region input
            //input

            //string firstName, lastName, age;
            //Console.Write("Bilgileri giriniz: \nİsim: ");
            //firstName = Console.ReadLine();
            //Console.Write("Soyisim: ");
            //lastName = Console.ReadLine();
            //Console.Write("Yaş: ");
            //age = Console.ReadLine();
            //Console.WriteLine("İsim: " + firstName + "\nSoyisim: " + lastName + "\nYaş: " + age);


            // C# başlangıçta girilen input değerlerini string olarak kabul eder eğer int veya başka bir şey istersek bunu dönüştürmek gerekiyor
            //int shoesPrice = 800;
            //int computerPrice = 9000;
            //int shoesCount, computerCount;
            //Console.Write("Lütfen Aldığınız Ayakkabı Adetini Giriniz: ");
            //shoesCount = int.Parse(Console.ReadLine());
            //Console.Write("Lütfen Aldığınız Bilgisayar Adetini Giriniz: ");
            //computerCount = int.Parse(Console.ReadLine());

            //Console.WriteLine("Toplam Fiyat: "+ (shoesCount*shoesPrice + computerCount * computerPrice));



            //// aynı şekilde double'a çevirmek için de double.Parse()
            //double exam1, exam2, exam3;

            //Console.Write("1. Sınav Notunuzu Giriniz: ");
            //exam1 = double.Parse(Console.ReadLine());
            //Console.Write("1. Sınav Notunuzu Giriniz: ");
            //exam2 = double.Parse(Console.ReadLine());
            //Console.Write("1. Sınav Notunuzu Giriniz: ");
            //exam3 = double.Parse(Console.ReadLine());
            //Console.WriteLine("Ortalamanız: " + ((exam1+exam2+exam3) / 3));
            //input yazarken eğer . kullanırsan yani 65.40 yazarsan 6540 olarak algılar
            // ama 65,40 yazarsan 65.40 olarak algılar


            //char.Parse()

            char gender;
            Console.Write("Lütfen Cinsiyetinizi Giriniz: ");
            gender = char.Parse(Console.ReadLine());
            Console.WriteLine("Cinsiyetiniz: " + gender);
            //burada da erkek kadın yazamıyorsun yine E K yazıyorsun string'i char'a çeviriyor aslında //
            #endregion

      





        }
    }
}
