using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace VladPC.DAL.Models;

public partial class User : IdentityUser<int>
{
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
