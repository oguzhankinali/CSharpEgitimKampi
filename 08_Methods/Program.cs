using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //geriye değer döndürmeyen metotlar void ile tanımlanır. Geriye değer döndüren metotlar ise return ile tanımlanır.

            //geriye değer döndürmeyen (void) parametresiz metodlar:
            void CustomerList()
            {
                Console.WriteLine("Ali Yıldız");
                Console.WriteLine("Ayşe Yıldız");
                Console.WriteLine("as Yıldız");
            }

            CustomerList();

            Console.WriteLine();

            //geriye değer döndürmeyen (void) parametreli metodlar:

            void WriteMethod(string customerName)
            {
                Console.WriteLine(customerName);
            }

            WriteMethod("Mehmet Yıldız");

            void customerCard(string name, string surName, int yas)
            {
                Console.WriteLine("Müşteri: " + name + " " +surName + " Yaşı:  " + yas);
            }

            customerCard("Mehmet", "Yıldız", 25);
               

            void Sum(int n1, int n2, int n3)
            {
                Console.WriteLine(n1+n2+n3);
            }
            Sum(3, 5, 7);

            // Geriye değer döndüren metodlar
            // geriye döndürdüğü değere bağlı olarak metotlar farklı türlerde olabilir. Örneğin int, string, bool gibi. Geriye değer döndüren metotlar return ile tanımlanır.
            //string döndürüyorsa string diye tanımlayacaksın

            string CustomerName()
            {
                return "Buse Kenan";
            }
            Console.WriteLine(CustomerName());

            string CountryCard(string countryName, string Capital, string color)
            {
                string cardInfo = ("ülke: " + countryName + Capital + color);
                return cardInfo;
            }
            Console.WriteLine(CountryCard("TR", "Ankara", "Red"));




            //geriye değer döndüren Int parametreli metotlar 

            int Summ(int n1, int n2, int n3)
            {
                int total = n1 + n2 + n3;
                return total;
            }

            Console.WriteLine(Summ(3,5,7));



        }
    }
}
