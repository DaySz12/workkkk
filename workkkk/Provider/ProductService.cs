using Microsoft.AspNetCore.Mvc;
using workkkk.Interface;
using workkkk.Viewmodel;

namespace workkkk.Provider
{
    public class ProductProvider
    {
        private readonly HttpClient httpClient;

        public ProductProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<List<ProductView>> ProductListById(string productcode)
        {
            try
            {
                var result = await httpClient
                    .GetFromJsonAsync<List<ProductView>>
                    ($"/api/product/ProductListById?productcode={productcode}");

                return result ?? new List<ProductView>();
            }
            catch
            {
                return new List<ProductView>();
            }
        }



    }
}
