using System;
using System.Collections;
using System.Collections.Generic;

namespace workkkk.Entity;

public partial class Product
{
    public int Id { get; set; }

    public string Productcode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stockqty { get; set; }

    public BitArray Isactive { get; set; } = null!;

    public DateTime Createat { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
