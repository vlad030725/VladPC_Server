using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.Common
{
    enum Company
    {
        Intel,
        AMD,
        NVidia,
        Asus,
        Acer,
        Palit,
    }

    enum Socket
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

    enum MemoryType
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

    enum Chipset
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

    enum Status80plus
    {
        None,
        Standart,
        Bronze,
        Silver,
        Gold,
        Platinum,
        Titanium,
    }

    enum FormFactor
    {
        E_ATX,
        Standart_ATX,
        Micro_ATX,
        Mini_ITX,
    }
}
