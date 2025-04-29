using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;

namespace VladPC.BLL.DTO
{
    public class Filter
    {
        public Category? IdCategory { get; set; }
        public int? MinPrice { get; set; } = 0;
        public int? MaxPrice { get; set; } = 999999;
        public Filter() { }
    }
}
