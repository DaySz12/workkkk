using workkkk.Viewmodel;

namespace workkkk.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerView>> CustomerlistById(string code);
        Task<Response<CustomerView>> InsertCustomer(CustomerView model);
    }
}
