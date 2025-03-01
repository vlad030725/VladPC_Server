using System;
using System.Collections.Generic;

namespace VladPC.DAL.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Category { get; set; }

    public int? Count { get; set; }

    public int? Price { get; set; }

    public int? Manufacturer { get; set; }

    public int? CountCores { get; set; }

    public int? CountStreams { get; set; }

    public int? Frequency { get; set; }

    public int? Socket { get; set; }

    public int? CountMemory { get; set; }

    public int? MemoryType { get; set; }

    public int? Chipset { get; set; }

    public int? CountRam { get; set; }

    public int? CountSsdm2 { get; set; }

    public int? Power { get; set; }

    public int? Status80plus { get; set; }

    public int? HeightCooler { get; set; }

    public int? Tdp { get; set; }

    public int? FormFactor { get; set; }

    public virtual ICollection<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
}
