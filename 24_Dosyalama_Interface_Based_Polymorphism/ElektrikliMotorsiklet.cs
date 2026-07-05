using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_AyrıDosyalar_Internal
{
    public class ElektrikliMotorsiklet : Motorsiklet
    {
        public override void Calistir() // Ana Motosiklet sınıfında olusturdugumuz Abstract metodu burada kullanmak zorundayız. 
        {
            Hiz = 10;
            Console.WriteLine("Elektrikli Motorsiklet sessizce çalıştı.");
        }
    }

}
