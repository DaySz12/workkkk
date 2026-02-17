using workkkk.Entity;
namespace workkkk.Viewmodel
{
    public class OrderView
    {
        public int Id { get; set; }
        public string Orderno { get; set; } = null!;

        public int? Customerid { get; set; }

        public int? Productid { get; set; }

        public int Qty { get; set; }

        public decimal Unitprice { get; set; }

        public decimal Totalamount { get; set; }
        public string Status { get; set; } = null!;
    }
}
