using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Models;
using VladPC.Common;

namespace VladPC.DAL.DbInitializerSeeds
{
    public class VladPCDBContextSeed
    {
        public static async Task SeedAsync(VladPcdbContext context)
        {
            try
            {
                if (context.Products.Any()) return;

                IEnumerable<Product> ProductData = new List<Product>()
                {
                    new Product() { Name = "Pentium Gold G6405 OEM", Category = (int)Category.Processor, Count = 10, Price = 6599, Manufacturer = (int)Company.Intel, CountCores = 2, CountStreams = 4, Frequency = 4100, Socket = (int)Socket.LGA1200, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 58, FormFactor = null },
                    new Product() { Name = "Core i3-14100F OEM", Category = (int)Category.Processor, Count = 10, Price = 7899, Manufacturer = (int)Company.Intel, CountCores = 4, CountStreams = 8, Frequency = 3500, Socket = (int)Socket.LGA1700, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 110, FormFactor = null },
                    new Product() { Name = "Core i5-11400F BOX", Category = (int)Category.Processor, Count = 10, Price = 10499, Manufacturer = (int)Company.Intel, CountCores = 6, CountStreams = 12, Frequency = 2600, Socket = (int)Socket.LGA1200, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 65, FormFactor = null },
                    new Product() { Name = "Core i7-13700KF OEM", Category = (int)Category.Processor, Count = 10, Price = 32299, Manufacturer = (int)Company.Intel, CountCores = 16, CountStreams = 24, Frequency = 3400, Socket = (int)Socket.LGA1700, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 125, FormFactor = null },
                    new Product() { Name = "Core i9-14900K OEM", Category = (int)Category.Processor, Count = 10, Price = 47999, Manufacturer = (int)Company.Intel, CountCores = 24, CountStreams = 32, Frequency = 3200, Socket = (int)Socket.LGA1700, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 125, FormFactor = null },
                    new Product() { Name = "Ryzen 3 3200G BOX", Category = (int)Category.Processor, Count = 10, Price = 8499, Manufacturer = (int)Company.AMD, CountCores = 4, CountStreams = 4, Frequency = 3600, Socket = (int)Socket.AM4, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 65, FormFactor = null },
                    new Product() { Name = "Ryzen 5 5600X OEM", Category = (int)Category.Processor, Count = 10, Price = 9999, Manufacturer = (int)Company.AMD, CountCores = 6, CountStreams = 12, Frequency = 3700, Socket = (int)Socket.AM4, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 65, FormFactor = null },
                    new Product() { Name = "Ryzen 7 7800X3D", Category = (int)Category.Processor, Count = 10, Price = 44999, Manufacturer = (int)Company.AMD, CountCores = 8, CountStreams = 16, Frequency = 4200, Socket = (int)Socket.AM5, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 120, FormFactor = null },
                    new Product() { Name = "Ryzen 9 9950X3D OEM", Category = (int)Category.Processor, Count = 10, Price = 96999, Manufacturer = (int)Company.AMD, CountCores = 16, CountStreams = 32, Frequency = 4300, Socket = (int)Socket.AM5, CountMemory = null, MemoryType = null, Chipset = null, CountRam = null, CountSsdm2 = null, Power = null, Status80plus = null, HeightCooler = null, Tdp = 170, FormFactor = null },
                    
                    new Product() { Name = "H510M-HVS R2.0", Category = (int)Category.MotherBoard, Count = 10, Price = 6499, Manufacturer = (int)Company.Asrock, CountCores = null, CountStreams = null, Frequency = null, Socket = (int)Socket.LGA1200, CountMemory = null, MemoryType = (int)MemoryType.DDR4, Chipset = (int)Chipset.H510, CountRam = 2, CountSsdm2 = 0, Power = null, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = (int)FormFactor.Micro_ATX },
                    new Product() { Name = "H610M-HVS", Category = (int)Category.MotherBoard, Count = 10, Price = 4399, Manufacturer = (int)Company.Asrock, CountCores = null, CountStreams = null, Frequency = null, Socket = (int)Socket.LGA1700, CountMemory = null, MemoryType = (int)MemoryType.DDR4, Chipset = (int)Chipset.H610, CountRam = 2, CountSsdm2 = 0, Power = null, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = (int)FormFactor.Micro_ATX },
                    new Product() { Name = "PRO B760M-E DDR4", Category = (int)Category.MotherBoard, Count = 10, Price = 7599, Manufacturer = (int)Company.MSI, CountCores = null, CountStreams = null, Frequency = null, Socket = (int)Socket.LGA1700, CountMemory = null, MemoryType = (int)MemoryType.DDR4, Chipset = (int)Chipset.B760, CountRam = 2, CountSsdm2 = 1, Power = null, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = (int)FormFactor.Micro_ATX },
                    new Product() { Name = "PRO Z790-P WIFI", Category = (int)Category.MotherBoard, Count = 10, Price = 18799, Manufacturer = (int)Company.MSI, CountCores = null, CountStreams = null, Frequency = null, Socket = (int)Socket.LGA1700, CountMemory = null, MemoryType = (int)MemoryType.DDR5, Chipset = (int)Chipset.Z790, CountRam = 4, CountSsdm2 = 4, Power = null, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = (int)FormFactor.Standart_ATX },
                    
                    new Product() { Name = "GeForce GT 1030", Category = (int)Category.GraphicsCard, Count = 10, Price = 8999, Manufacturer = (int)Company.Gigabate, CountCores = null, CountStreams = null, Frequency = 1227, Socket = null, CountMemory = 2, MemoryType = (int)MemoryType.GDDR5, Chipset = null, CountRam = null, CountSsdm2 = null, Power = 300, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = null },
                    new Product() { Name = "GeForce RTX 3050 StormX", Category = (int)Category.GraphicsCard, Count = 10, Price = 17999, Manufacturer = (int)Company.Palit, CountCores = null, CountStreams = null, Frequency = 1042, Socket = null, CountMemory = 6, MemoryType = (int)MemoryType.GDDR6, Chipset = null, CountRam = null, CountSsdm2 = null, Power = 300, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = null },
                    new Product() { Name = "GeForce RTX 5070 Ti GamingPro", Category = (int)Category.GraphicsCard, Count = 10, Price = 96999, Manufacturer = (int)Company.Palit, CountCores = null, CountStreams = null, Frequency = 2452, Socket = null, CountMemory = 16, MemoryType = (int)MemoryType.GDDR7, Chipset = null, CountRam = null, CountSsdm2 = null, Power = 750, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = null },
                    new Product() { Name = "Radeon 9070 XT AORUS ELITE", Category = (int)Category.GraphicsCard, Count = 10, Price = 99999, Manufacturer = (int)Company.Gigabate, CountCores = null, CountStreams = null, Frequency = 3100, Socket = null, CountMemory = 16, MemoryType = (int)MemoryType.GDDR6, Chipset = null, CountRam = null, CountSsdm2 = null, Power = 850, Status80plus = null, HeightCooler = null, Tdp = null, FormFactor = null },
                };

                context.AddRange(ProductData);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
