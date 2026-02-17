using workkkk.Viewmodel;
using workkkk.Entity;
using workkkk.Interface;
using Microsoft.EntityFrameworkCore;

namespace workkkk.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _db;

        public CustomerService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<CustomerView>> CustomerlistById(string code)
        {
            try
            {
                var customer = await _db.Customers.Where(x => x.Code == code).Select(x => new CustomerView
                {
                    Code = x.Code,
                    Name = x.Name
                }).ToListAsync();

                return customer;
            }
            catch (Exception ex)
            {
                return new List<CustomerView>();
            }
        }

        public async Task<Response<CustomerView>> InsertCustomer(CustomerView model)
        {
            try
            {
                var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Code == model.Code);
                if (customer != null)
                {
                    return new Response<CustomerView>
                    {
                        Status = 400,
                        Message = "ข้อมูลมีแล้ว",
                        Result = model
                    };
                }
                else
                {
                    customer = new Customer
                    {
                        Code = model.Code,
                        Name = model.Name
                    };
                    _db.Customers.Add(customer);
                }
                await _db.SaveChangesAsync();
                return new Response<CustomerView>
                {
                    Status = 200,
                    Message = "ดึงข้อมูลสำเร็จ",
                    Result = model
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerView>
                {
                    Status = 500,
                    Message = ex.Message,
                };
            }
        }
    }
}
