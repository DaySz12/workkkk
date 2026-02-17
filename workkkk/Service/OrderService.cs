using Microsoft.EntityFrameworkCore;
using workkkk.Entity;
using workkkk.Interface;
using workkkk.Viewmodel;

      
namespace workkkk.Service
    {
        public class OrderService : IOrderService
    {
            private readonly AppDbContext _db;

            public OrderService(AppDbContext db)
            {
                _db = db;
            }

            public async Task<List<OrderView>> OrderList(int customerid, string status)
            {
                try
                {
                    var order = await _db.Orders.Where(x => x.Customerid == customerid && x.Status == status).Select(x => new OrderView
                    {
                        Id = x.Id,
                        Orderno = x.Orderno,
                        Status = x.Status,
                        Totalamount = x.Totalamount,
                        Productid = x.Productid,
                        Unitprice = x.Unitprice,
                        Qty = x.Qty,
                        Customerid = x.Customerid
                    }).ToListAsync();

                    return order;
                }
                catch (Exception ex)
                {
                    return new List<OrderView>();
                }
            }

        public async Task<List<OrderView>> OrderListById(int Id)
        {
            try
            {
                var order = await _db.Orders.Where(x => x.Id == Id).Select(x => new OrderView
                {
                    Id = x.Id,
                    Orderno = x.Orderno,
                    Status = x.Status,
                    Totalamount = x.Totalamount,
                    Productid = x.Productid,
                    Unitprice = x.Unitprice,
                    Qty = x.Qty,
                    Customerid = x.Customerid

                }).ToListAsync();

                return order;
            }
            catch (Exception ex)
            {
                return new List<OrderView>();
            }
        }

        public async Task<Response<OrderView>> InsertOrder(OrderView model)
            {
            using var trx = await _db.Database.BeginTransactionAsync();


            try
            {
                    var order = await _db.Orders.FirstOrDefaultAsync(x => x.Orderno == model.Orderno);
                    var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == model.Productid);
                if (order != null)
                    {
                        return new Response<OrderView>
                        {
                            Status = 400,
                            Message = "ข้อมูลมีแล้ว",
                            Result = model
                        };
                    }
                if (product == null)
                    {
                        return new Response<OrderView>
                        {
                            Status = 400,
                            Message = "ไม่พบสินค้า",
                            Result = model
                        };
                }
                else
                    {
                    order = new Order
                        {
                                Orderno = model.Orderno,
                                Status = model.Status,
                                Totalamount = product.Price * model.Qty,
                                Productid = model.Productid,
                                Unitprice = product.Price,
                                Qty = model.Qty,
                                Customerid = model.Customerid,
                                Orderdate = DateTime.Now

                    };
                        _db.Orders.Add(order);
                    product.Stockqty = product.Stockqty - model.Qty;
                }
                    await _db.SaveChangesAsync();
                await trx.CommitAsync();
                return new Response<OrderView>
                    {
                        Status = 200,
                        Message = "ดึงข้อมูลสำเร็จ",
                        Result = model
                    };
                }
                catch (Exception ex)
                {
                await trx.RollbackAsync();
                return new Response< OrderView>
                    {
                        Status = 500,
                        Message = ex.Message,
                    };
                }
            }
        }
    }

