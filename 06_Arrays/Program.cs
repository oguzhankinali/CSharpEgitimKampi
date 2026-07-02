using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Arrays
            //// AYNI VERİ TİPİNDEKİ** 

            //string[] colors = new string[4];
            //colors[0] = "red";
            //colors[1] = "blue";
            //colors[2] = "green";
            //colors[3] = "yellow";
            //Console.WriteLine(colors[0]);
            //Console.WriteLine(colors[1]);
            //Console.WriteLine(colors[2]);
            //Console.WriteLine(colors[3]);
            //colors[0] = "black";
            //Console.WriteLine(colors[0]);
            //string[] cities = new String[3] { "Ankara", "Adana", "İstanbul" };
            //// veya da 
            //string[] cities2 = { "Ankara", "Adana", "İstanbul" };


            //int [] numbers = new int[3] { 1, 2, 3 };
            //Console.WriteLine(numbers[1] + numbers[2]);
            //int[] numbers2 = { 2, 3, 5,7,9 };

            ////Console.WriteLine(numbers2[7]); // dizin dizi sınırları dışındaydı der..

            //for(int i=0; i<numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            char[] symbols = { 'a', 'b', '+', '/' };

            string[] persons = { "Ali", "Veli", "Ayşe","Ahmet", "Buse" };
            // dizi metodları
            Console.WriteLine("persons dizi uzunlugu: " + persons.Length);

            Console.WriteLine("\n");
            //----------------------------------------------------
            int[] numbers = { 43, 56, 12, 78, 34, 90, 11 };
            Console.WriteLine("Orijinal dizi sıralaması: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine("\n");
            //----------------------------------------------------
            Console.WriteLine("Kucukten buyuge dizilmis dizi sıralaması: ");
            Array.Sort(numbers); // kucukten buyuge sıralıyor 
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]+ " ");
            }
            Console.WriteLine("\n");
            //----------------------------------------------------
            Console.WriteLine("Buyukten kucuge dızılmıs dizi sıralaması: ");
            //Array.Reverse(numbers) da diziyi komple tersten sıralıyor. yani ters çeviriyor
            Array.Reverse(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            //----------------------------------------------------
            Console.WriteLine("\n");
            int index = Array.IndexOf(numbers, 43); // numbers dizisinde 43 sayısının indexini buluyor.
            Console.WriteLine("43 Sayısının dizideki index numarası: " + index);

            //----------------------------------------------------
            Console.WriteLine("\n");
            Console.WriteLine("Dizinin en büyük elemanı:" +numbers.Max() + "\nDizinin en küçük elemanı: " +numbers.Min());


            string[] countries = new string[4];
            Console.WriteLine();
            for(int i = 0;i < countries.Length; i++)
            {
                Console.Write($"Lütfen seçmek istediğiniz {i+1}. ülkeyi giriniz: "); //?? Template literals??
                countries[i] = Console.ReadLine();
            }
            Console.Write("\nGirdiğiniz ülkeler:");
            for (int i = 0; i < countries.Length; i++)
            {
                Console.Write(countries[i] + " ");
            }
            Console.WriteLine();











        }



















            #endregion
    }
    }

