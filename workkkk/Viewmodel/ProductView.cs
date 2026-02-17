using System.Collections;

namespace workkkk.Viewmodel
{
    public class ProductView
    {
        public string Productcode { get; set; } = null!;

        public string Name { get; set; } = null!; 

        public decimal Price { get; set; }

        public int Stockqty { get; set; }

        

        public DateTime Createat { get; set; }

    }
}
