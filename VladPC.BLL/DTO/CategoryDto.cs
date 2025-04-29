using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.Common;

namespace VladPC.BLL.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryDto(Category id, string name)
        {
            Id = (int)id;
            Name = name;
        }
    }
}
