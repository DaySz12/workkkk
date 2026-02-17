using Microsoft.AspNetCore.Mvc;
using workkkk.Viewmodel;

namespace workkkk.Interface
{
    public interface IOrderService
    {
        Task<List<OrderView>> OrderList(int customerid, string status);
        Task<Response<OrderView>> InsertOrder(OrderView model);
        Task<List<OrderView>> OrderListById(int Id);

    }
}
