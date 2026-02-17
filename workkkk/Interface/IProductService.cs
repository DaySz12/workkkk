using workkkk.Viewmodel;

namespace workkkk.Interface
{
    public interface IProductService
    {
        Task<List<ProductView>> ProductListById(string productcode);
        Task<Response<ProductView>> InsertProduct(ProductView model);
    }
}
