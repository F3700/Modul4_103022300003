// See https://aka.ms/new-console-template for more information
using System.Reflection;
class kodeProduk {
    public enum Produk
    {
        Laptop,
        Smartphone,
        Tablet,
        Headset,
        Keyboard,
        Mouse,
        Printer,
        Monitor,
        Smartwatch,
        Kamera
    }

    public string[] kP = { 
        "E100",
        "E101",
        "E102",
        "E103",
        "E104",
        "E105",
        "E106",
        "E107",
        "E108",
        "E109"
 };

    public String getKodeProduk(Produk x) {
        return this.kP[(int)x];
    }
}

public class Program
{
    public static void Main()
    {
        kodeProduk kp = new kodeProduk();
        Console.WriteLine("Kode Produk untuk Laptop : " + kp.getKodeProduk(kodeProduk.Produk.Laptop));
        Console.WriteLine("Kode Produk untuk Smartphone : " + kp.getKodeProduk(kodeProduk.Produk.Smartphone));
        Console.WriteLine("Kode Produk untuk Tablet : " + kp.getKodeProduk(kodeProduk.Produk.Tablet));

    }
}

