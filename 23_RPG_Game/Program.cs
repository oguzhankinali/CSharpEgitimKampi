using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public enum KarakterTipi
{
    Savasci,
    Buyucu,
    Okcu
}
public interface IIsinlanabilir
{
    void Isinlan(int meter);
}

public abstract class Karakter
{
    public string Isim { get; private set; }
    public int Can { get; protected set; }
    public KarakterTipi Tip { get; private set; }
    public int zirhGucu { get; protected set; }


    public Karakter(string isim, KarakterTipi tip)
    {
        Isim = isim;
        Tip = tip;
        Can = 100;
    }
    public abstract void Savas();
    public virtual void Yazdir()
    {
        Console.Write($"{Isim} isimli {Tip} aramıza katıldı. Can: {Can}, Zırh Gücü: ");
    }

}

public class Savasci : Karakter
{
    public override void Yazdir()
    {
        base.Yazdir();
        Console.WriteLine(zirhGucu);
    }
    public Savasci(string isim)
        : base(isim, KarakterTipi.Savasci)
    {
        zirhGucu = 50;
        Yazdir();

    }
    public override void Savas()
    {
        Can -= 20;
        zirhGucu -= 4;
        Console.WriteLine($"{Isim} kılıcını çekti ve bodoslama saldırdı! Kalan can: {Can}, Zırh Gücü: {zirhGucu}");
    }
}
public class Buyucu : Karakter, IIsinlanabilir
{
    public override void Yazdir()
    {
        base.Yazdir();
        Console.WriteLine(zirhGucu);
    }
    // zirhGucu  = 30; HATA1
    // C# dilinde süslü parantezlerin içi (Scope) iki farklı bölgedir ve ikisinin kuralları tamamen farklıdır:

    //Sınıfın Doğrudan İçi(Constructor veya Metot Dışı): Burası sadece "Doğum Belgesi" düzenleme(değişken/mülk tanımlama) alanıdır.Bilgisayara "Şöyle bir özelliğim olsun, tipi de şu olsun" dersin.Buraya bodoslama zirhGucu = 30; gibi bir işlem(değer atama / kod yürütme) satırı yazamazsın.C# derleyicisi bu satırı görünce çıldırır ve "Kardeşim metot dışında ne yapmaya çalışıyorsun, işlem yapacaksan bir metodun veya constructor'ın içine gir" der.

    //Constructor veya Metotların İçi: Burası ise "İş Yapma" alanıdır.Değişkenleri güncellemek, matematiksel işlemler yapmak, ekrana yazı basmak gibi tüm eylemler sadece bodoslama bu parantezlerin içinde gerçekleşebilir.

    public Buyucu(string isim)
        : base(isim, KarakterTipi.Buyucu)
    {
        zirhGucu = 30;
        Yazdir();
    }
    public override void Savas()
    {
        Can -= 25;
        zirhGucu -= 6;
        Console.WriteLine($"{Isim} alev topu büyüsü fırlattı! Muazzam hasar! Kalan can: {Can}, Zırh Gücü: {zirhGucu}");
    }
    public void Isinlan(int meter)
    {
        Console.WriteLine($"{Isim} Düşmandan {meter} metre uzağa ışınlanıldı. Güvendesin!");
    }
}


namespace RPG_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Buyucu buyucu1 = new Buyucu("Harry");
            Savasci savasci1 = new Savasci("Ragnar");

            List<Karakter> Karakterler = new List<Karakter>();
            Karakterler.Add(savasci1);
            Karakterler.Add(buyucu1);

            foreach (Karakter krktr in Karakterler)
            {
                krktr.Savas();
            }
            buyucu1.Isinlan(300);
        }
    }
}
