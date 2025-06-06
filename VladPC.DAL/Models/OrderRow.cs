﻿using System;
using System.Collections.Generic;

namespace VladPC.DAL.Models;

public partial class OrderRow
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Price { get; set; }

    public int? Count { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
