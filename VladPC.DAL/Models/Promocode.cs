using System;
using System.Collections.Generic;

namespace VladPC.DAL.Models;

public partial class Promocode
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public float? Discount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
