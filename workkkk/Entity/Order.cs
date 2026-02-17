using System;
using System.Collections.Generic;

namespace workkkk.Entity;

public partial class Order
{
    public int Id { get; set; }

    public string Orderno { get; set; } = null!;

    public int? Customerid { get; set; }

    public int? Productid { get; set; }

    public int Qty { get; set; }

    public decimal Unitprice { get; set; }

    public decimal Totalamount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Orderdate { get; set; }

    public DateTime Createdat { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
