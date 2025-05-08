using System;
using System.Collections.Generic;

namespace VladPC.DAL.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PromocodeId { get; set; }

    public int? Status { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();

    public virtual Promocode? Promocode { get; set; }

    public virtual User? User { get; set; }
}
