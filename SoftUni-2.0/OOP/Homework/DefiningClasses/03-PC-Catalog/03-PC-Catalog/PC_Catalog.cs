using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    class PC_Catalog
    {
        static void Main(string[] args)
        {
            Computer afordablePC = new Computer(
                "No case shtaiga",
                new Component("Motherboard", "Asus B85M-E, B85, LGA1150, DDR3, PCI-E 3.0 (CF) (HDMI, DVI & DisplayPort), SB7.1, Lan1000, 4xSATA 6Gb/s, 2xUSB3.0, mATX", 156.86),
                new Component("CPU", "Intel Core i3-4170 @ 3.7GHz, 3.70GHz, Haswell, 3MB, Socket 1150, Box", 269.99),
                new Component("GPU", "Gigabyte NVIDIA GeForce GTX 750 Ti, OC Guru 2 WINDFORCE 2X, 2048MB, GDDR5, 128bit, 2x HDMI, 2x DVI", 269.99),
                new Component("RAM", "Kingston HyperX FURY Red 8GB, DDR3, 1600MHz, CL10, 1.5V", 124.99),
                new Component("RAM", "Kingston HyperX FURY Red 8GB, DDR3, 1600MHz, CL10, 1.5V", 124.99),
                new Component("SSD", "Solid State Drive(SSD) OCZ ARC 100, 2.5\", 240GB, SATA III", 188.99),
                new Component("HDD", "2TB WD Blue WD20EZRZ, 5400 RPM, 64 MB, SATA 3 (6Gb/s)", 177.00)
                );

            Computer cheapPC = new Computer(
                "Lenovo IdeaCentre H30-00",
                514.40,
                new Component("CPU", "Intel® Celeron® Processor J1800(1M Cache, up to 2.58 GHz", 0),
                new Component("RAM", "4GB DDR3 1600MHz", 0),
                new Component("HDD", "500GB SATA 7200 rpm", 0),
                new Component("DVD±RW", 0),
                new Component("VGA", 0),
                new Component("1x USB3.0", 0),
                new Component("4x USB2.0", 0),
                new Component("Ethernet RJ-45 network port", 0),
                new Component("7-in-1 Card Reader", 0),
                new Component("+ keyboard and mouse (USB type)", 0)
                );

            Computer supercomputer = new Computer(
                "Cray's XC30-AC",
                900000.00
                );

            List<Computer> availablePC = new List<Computer>();
            availablePC.Add(afordablePC);
            availablePC.Add(cheapPC);
            availablePC.Add(supercomputer);

            foreach (var pc in availablePC.OrderBy(pc => pc.TotalPrice))
            {
                Console.WriteLine(pc.ToString());
            }
            
        }
    }
}
