using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Списки
/// </summary>
namespace VladPC.Common
{
    public enum Category
    {
        Processor,
        MotherBoard,
        PowerSupply,
        Case,
        GraphicsCard,
        Cooler,
        RAM,
        SSD,
    }

    public enum Company
    {
        Intel,
        AMD,
        NVidia,
        Asus,
        Acer,
        Palit,
    }

    public enum Socket
    {
        LGA1815,
        LGA1700,
        LGA1200,
        LGA1511v2,
        LGA1511,
        LGA2066,
        AM4,
        AM5,
        sWRX8,
    }

    public enum MemoryType
    {
        GDDR6X,
        GDDR6,
        GDDR5,
        GDDR3,
        DDR5,
        DDR4,
        DDR3,
        DDR3L,
        DDR2,
    }

    public enum Chipset
    {
        Z890,
        Z790,
        B760,
        B660,
        H610,
        H510,
        H470,
        H370,
        H310,
        X870,
        X870E,
        B850,
        X670,
        B650,
        A620,
        B550,
        A520,
        B450,
    }

    public enum Status80plus
    {
        None,
        Standart,
        Bronze,
        Silver,
        Gold,
        Platinum,
        Titanium,
    }

    public enum FormFactor
    {
        E_ATX,
        Standart_ATX,
        Micro_ATX,
        Mini_ITX,
    }

    /// <summary>
    /// Класс для словарей характеристик, где численному обозначению соответствует строка
    /// </summary>
    public static class DictionaryLists
    {
        public static Dictionary<Company, string> CompanyMap = new Dictionary<Company, string>()
        {
            { Company.Intel, "Intel" },
            { Company.AMD, "AMD" },
            { Company.NVidia, "NVidia" },
            { Company.Asus, "Asus" },
            { Company.Acer, "Acer" },
            { Company.Palit, "Palit" },
        };

        public static Dictionary<Socket, string> SocketMap = new Dictionary<Socket, string>()
        {
            { Socket.LGA1815, "LGA1815" },
            { Socket.LGA1700, "LGA1700" },
            { Socket.LGA1200, "LGA1200" },
            { Socket.LGA1511v2, "LGA1511v2" },
            { Socket.LGA1511, "LGA1511" },
            { Socket.LGA2066, "LGA2066" },
            { Socket.AM4, "AM4" },
            { Socket.AM5, "AM5" },
            { Socket.sWRX8, "sWRX8" },
        };

        public static Dictionary<MemoryType, string> MemoryTypeMap = new Dictionary<MemoryType, string>()
        {
            { MemoryType.GDDR6X, "GDDR6X" },
            { MemoryType.GDDR6, "GDDR6" },
            { MemoryType.GDDR5, "GDDR5" },
            { MemoryType.GDDR3, "GDDR3" },
            { MemoryType.DDR5, "DDR5" },
            { MemoryType.DDR4, "DDR4" },
            { MemoryType.DDR3, "DDR3" },
            { MemoryType.DDR3L, "DDR3L" },
            { MemoryType.DDR2, "DDR2" },
        };

        public static Dictionary<Chipset, string> ChipsetMap = new Dictionary<Chipset, string>()
        {
            { Chipset.Z890, "Z890" },
            { Chipset.Z790, "Z790" },
            { Chipset.B760, "B760" },
            { Chipset.B660, "B660" },
            { Chipset.H610, "H610" },
            { Chipset.H510, "H510" },
            { Chipset.H470, "H470" },
            { Chipset.H370, "H370" },
            { Chipset.H310, "H310" },
            { Chipset.X870, "X870" },
            { Chipset.X870E, "X870E" },
            { Chipset.B850, "B850" },
            { Chipset.X670, "X670" },
            { Chipset.B650, "B650" },
            { Chipset.A620, "A620" },
            { Chipset.B550, "B550" },
            { Chipset.A520, "A520" },
            { Chipset.B450, "B450" },
        };

        public static Dictionary<Status80plus, string> Status80plusMap = new Dictionary<Status80plus, string>()
        {
            { Status80plus.None, "None" },
            { Status80plus.Standart, "Standart" },
            { Status80plus.Bronze, "Bronze" },
            { Status80plus.Silver, "Silver" },
            { Status80plus.Gold, "Gold" },
            { Status80plus.Platinum, "Platinum" },
            { Status80plus.Titanium, "Titanium" },
        };

        public static Dictionary<FormFactor, string> FormFactorMap = new Dictionary<FormFactor, string>()
        {
            { FormFactor.E_ATX, "E_ATX" },
            { FormFactor.Standart_ATX, "Standart_ATX" },
            { FormFactor.Micro_ATX, "Micro_ATX" },
            { FormFactor.Mini_ITX, "Mini_ITX" },
        };
    }
}
