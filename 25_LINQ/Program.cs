using _12_AyrıDosyalar_Internal;
using System;
using System.Collections.Generic;
using System.Linq; // LINQ metotlarının çalışması için bu kütüphane ŞARTTIR!

namespace _25_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ NEDİR?
            /*
             * LINQ (Language Integrated Query): Koleksiyonlar (List, Array vb.) üzerinde 
             * SQL yazar gibi filtreleme, sıralama ve dönüştürme yapmamızı sağlayan muazzam bir .NET teknolojisidir.
             * * BİLİNMESİ GEREKEN REÇETELER:
             * 1. LINQ metotları (Where, OrderBy) geriye geçici bir sorgu veri tipi döner.
             * Bu yüzden sonlarına .ToList() ekleyerek bunu bodoslama yeni bir List nesnesine çeviririz.
             * 2. 'var' anahtar kelimesi sağdaki .ToList() tipini otomatik okur. 
             * İstersek 'var' yerine direkt 'List<Otomobil>' de yazabiliriz, ikisi de aynı kapıya çıkar.
             */
            #endregion

            #region Veri Seti Hazırlığı
            List<Otomobil> garaj = new List<Otomobil>
            {
                new ElektrikliOtomobil("Beyaz", 900),
                new BenzinliOtomobil("Turuncu", 300),
                new ElektrikliOtomobil("Mavi", 2500),
                new BenzinliOtomobil("Yeşil", 7000)
            };
            #endregion
            Console.Write("garaj[0]: ");
            Console.WriteLine(garaj[0]);
            Console.Write("garaj[0].Km: ");
            Console.WriteLine(garaj[0].Km);
            Console.Write("garaj[0].Motor: ");
            Console.WriteLine(garaj[0].Motor);
            Console.Write("garaj[0].Renk: ");
            Console.WriteLine(garaj[0].Renk);
            #region 1. WHERE (Filtreleme)
            /*
             * o => o.Motor == MotorTipi.Elektrikli (LAMBDA EXPRESSION)
             * o: Döngüdeki o anki tek bir arabayı temsil eden girdi parametresidir.
             * =>: "Bu arabayı al ve sağdaki şarta sok" demektir.
             * Şart true dönerse araba yeni listeye alınır, false dönerse elenir.
             */
            var elektrikliArabalar = garaj.Where(o => o.Motor == MotorTipi.Elektrikli).ToList();
            //List <Otomobil> elektrikliArabalar = garaj.Where(o => o.Motor == MotorTipi.Elektrikli).ToList(); şeklinde de yazabilirdin. yani aslında 
            // var dediğimiz şey List <Otomobil>
            /*
             * yani aslında buradaki o şöyle bir şey garaj[0] garaj[1] gibi artan bir index aslında şöyle garaj[0].Motor == MotorTipi.Elektrikli eğer true ise listeye ekle
             * yani aslında o dediğimiz şey direkt 0 1 2 3 4 gitmiyor 
             * mesela sen 4 tane araba olusturdun BenzinliOtomobil opel = new BenzinliOto();
             * ve o aslında bunu tutuyor. 
             */
            #endregion

            #region 2. ORDER BY & ORDER BY DESCENDING (Sıralama)
            /*
             * o => o.Km ifadesinde bir mantıksal koşul (==, >) aranmaz.
             * Buradaki amaç sıralamanın HANGİ ÖZELLİĞE göre yapılacağını belirtmektir.
             * OrderBy: Küçükten Büyüğe (A-Z) sıralar.
             * OrderByDescending: Büyükten Küçüğe (Z-A) sıralar.
             */
            List<Otomobil> kmSiraliKucuktenBuyuge = garaj.OrderBy(o => o.Km).ToList();
            var kmSiraliBuyuktenKucuge = garaj.OrderByDescending(o => o.Km).ToList();
            #endregion
            Console.WriteLine("\nKm büyükten küçüğe sıralama: \n");
            foreach(Otomobil arac in kmSiraliBuyuktenKucuge)
            {
                arac.Yazdir();
            }
            Console.WriteLine();
            Console.WriteLine("\nKm küçükten büyüğe sıralama: \n");
            foreach (Otomobil arac in kmSiraliKucuktenBuyuge)
            {
                arac.Yazdir();
            }
            Console.WriteLine();

            #region 3. SEKTÖRDE EN ÇOK KULLANILAN DİĞER POPÜLER LINQ METOTLARI

            // A. FIRST OR DEFAULT: Şarta uyan İLK TEK BİR elemanı nesne olarak döner. Bulamazsa null döner.
            var ilkMaviAraba = garaj.FirstOrDefault(o => o.Renk == "Mavi");
            Console.WriteLine("Garajdaki ilk mavi araba: " + ilkMaviAraba.Renk + ilkMaviAraba.Km);


            // B. ANY: Listede bu şarta uyan bir tane bile eleman var mı? (Geriye bool döner)
            bool KmAzArabaVarMi = garaj.Any(o => o.Km < 500); // True döner (300 km olan var)
            Console.WriteLine("Km'si 500'den az araç var mı: " + KmAzArabaVarMi);

            // C. COUNT: Şarta uyan kaç tane eleman olduğunu sayar.
            int yuksekKmArabaSayisi = garaj.Count(o => o.Km > 1000); // Geriye 2 döner
            Console.WriteLine("1000 km üstü araç sayısı: " + yuksekKmArabaSayisi);


            // D. SELECT: Listeyi başka bir veri tipine dönüştürür. (Örn: Sadece renkleri string listesi olarak çekmek)
            List<string> garajdakiRenkler = garaj.Select(o => o.Renk).ToList();

            Console.WriteLine("\nGarajdaki renkler: \n");
            foreach (string arac in garajdakiRenkler)
            {
                Console.WriteLine(arac);
            }
            Console.WriteLine();


            // E. MAX / MIN / AVERAGE: Matematiksel hesaplamalar yapar.
            int enYuksekKm = garaj.Max(o => o.Km); // 7000 döner
            Console.WriteLine("En yüksek km'li aracın km'si: " + enYuksekKm);
            double ortalamaKm = garaj.Average(o => o.Km);
            Console.WriteLine("Araçların ortalama km'si: " + ortalamaKm);

            #endregion

            #region Konsol Çıktıları
            Console.WriteLine($"Garajdaki Toplam Yüksek Km'li Araç Sayısı: {yuksekKmArabaSayisi}");
            Console.WriteLine($"En Yüksek Kilometre Değeri: {enYuksekKm}");
            Console.WriteLine("Garajdaki Renklerin Listesi: " + string.Join(", ", garajdakiRenkler));
            #endregion
        }
    }
}