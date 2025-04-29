using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.BLL.DTO
{
    public abstract class ProductDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Category { get; set; }

        public int? Count { get; set; }

        public int? Price { get; set; }

        public int? Manufacturer { get; set; }

        public string? CatalogString { get; set; }

        protected abstract string CreateCatalogString();
    }
}
