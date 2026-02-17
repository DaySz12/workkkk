using Microsoft.EntityFrameworkCore;
using workkkk.Entity;
using workkkk.Interface;
using workkkk.Viewmodel;

namespace workkkk.Service
{
    public class ProductService : IProductService
    {

        public readonly AppDbContext db;
        public ProductService(AppDbContext Context)
        {
            this.db = Context;
        }

        public async Task<List<ProductView>> ProductListById(string productcode)
        {
            try
            {
                var product = await db.Products.Where(x => x.Productcode == productcode).Select(x => new ProductView
                {
                    Productcode = x.Productcode,
                    //Isactive = x.Isactive,
                    Name = x.Name,
                    Price = x.Price,
                    Stockqty = x.Stockqty,
                    Createat = x.Createat
                }).ToListAsync();

                return product;
            }
            catch (Exception ex)
            {
                return new List<ProductView>();
            }

        }

        public async Task<Response<ProductView>> InsertProduct(ProductView model)
        {
            try
            {
                var product = await db.Products.FirstOrDefaultAsync(x => x.Productcode == model.Productcode);
                if (product != null)
                {
                    return new Response<ProductView>
                    {
                        Status = 400,
                        Message = "ข้อมูลมีแล้ว",
                        Result = model
                    };
                }
                else
                {
                    product = new Product
                    {
                        Productcode = model.Productcode,
                        Name = model.Name,
                        Price = model.Price,
                        Stockqty = model.Stockqty,
                        //Isactive = model.Isactive,
                        Createat = DateTime.Now
                    };
                    db.Products.Add(product);
                }

                await db.SaveChangesAsync();
                return new Response<ProductView>
                {
                    Status = 200,
                    Message = "ดึงข้อมูลสำเร็จ",
                    Result = model
                };
            }
            catch (Exception ex)
            {
                return new Response<ProductView>
                {
                    Status = 500,
                    Message = ex.Message,
                };
            }
        }
    }
}
