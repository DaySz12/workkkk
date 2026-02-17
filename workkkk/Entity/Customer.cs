using System;
using System.Collections;
using System.Collections.Generic;

namespace workkkk.Entity;

public partial class Customer
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public BitArray Isactive { get; set; } = null!;

    public DateTime Createdat { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
