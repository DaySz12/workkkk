using workkkk.Viewmodel;

namespace workkkk.Provider
{
    public class CustomerProivider
    {
        private readonly HttpClient httpClient;
        public CustomerProivider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CustomerView>> CustomerlistById(string code)
        {
            try
            {
                var result = await httpClient
                    .GetFromJsonAsync<List<CustomerView>>
                    ($"/api/customer/CustomerlistById?code={code}");
                return result ?? new List<CustomerView>();
            }
            catch
            {
                return new List<CustomerView>();
            }
        }
    }
}
