using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ForeachLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Foreach döngüsü
            //foreach döngüsü ile dizinin içindeki elemanı değiştiremezsin.

            //Eğer foreach (int number in numbers) bloğunun içinde number = 0; dersen, o sadece o anki "kopyayı" değiştirir, dizinin orijinalindeki sayıyı değiştirmez. Dizinin içindeki veriyi güncellemen gerekiyorsa(örneğin dizideki tüm sayıları 5 artıracaksan), o zaman mecbur for döngüsüne döneceksin.

            //foreach aslında for'un "okuma modu"dur. Sadece okuyorsan foreach kullan, yazacaksan/değiştireceksen for.

            //Foreach(1;2;3;4) 
            //1: Değişken türü
            //2: Değişken adı
            //3: In 
            //4: Liste, Koleksiyon, Dizi
            //Foreach döngüsü, bir koleksiyonun veya dizinin her bir öğesi üzerinde işlem yapmak için kullanılır.

            string[] cities = { "ankara", "istanbul", "izmir", "antalya" };
            foreach (string x in cities)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
            // sadece çift sayıları yazdır
            int[] numbers = { 13, 235, 76, 423, 78, 23, 98, 14, 19 };
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                }
            }
            Console.WriteLine();
            //toplamını yazdır 
            int total = 0;
            foreach (int number in numbers)
            {
                total += number;
                Console.WriteLine("şimdilik total: " + total);
            }
            Console.WriteLine();

            // Liste olusturma 
            List<int> numberList = new List<int>()
            {
                1,6,98,123,54,66
            };
            //foreach ile listeyi de yazdıraiblirsin

            foreach (int number in numberList)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
            string word = "merhaba";
            foreach (char harf in word)
            {
                Console.WriteLine(harf); // bu da merhaba string'ini parçalayıp her harfi yazdırır 
            }
























            #endregion
        }
    }
}
