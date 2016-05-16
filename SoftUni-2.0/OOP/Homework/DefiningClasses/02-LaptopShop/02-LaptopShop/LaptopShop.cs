using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LaptopShop
{
    class LaptopShop
    {
        static void Main(string[] args)
        {
            Laptop hp = new Laptop("HP 250 G2", 699.00);

            Laptop asus = new Laptop(
                "Asus N551JX-CN102D",
                "Asus",
                "Intel Core i5-4200H (2.80 - 3.40 GHz, 3 MB cache)",
                "4 GB + 4 GB DDR3L 1600MHz (Low Voltage)",
                "NVIDIA GeForce GTX 950M - 2 GB DDR3",
                "1 TB SATA 5400 rpm",
                @"15.6"" 16:9 Full HD (1920x1080), IPS, Non-Glare LCD Panel",
                new Battery("Li-Ion, 6-cells, 5200 mAh, 56 Wh", 4.5),
                1649.00);

            Laptop lenovo = new Laptop(
                "Lenovo Yoga 2 Pro",
                "Lenovo",
                "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
                "8 GB",
                "Intel HD Graphics 4400",
                "128GB SSD",
                @"13.3""(33.78 cm) – 3200 x 1800(QHD +), IPS sensor display",
                2259.00);

            Console.WriteLine(hp);
            Console.WriteLine();

            Console.WriteLine(asus);
            Console.WriteLine();

            Console.WriteLine(lenovo);
        }
    }
}
