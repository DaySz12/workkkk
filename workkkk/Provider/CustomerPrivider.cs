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


        public async Task<Response<CustomerView>> InsertCustomer(CustomerView model)
        {
            try
            {
                var result = await httpClient
                    .PostAsJsonAsync("/api/customer/InsertCustomer", model);
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = await result.Content.ReadFromJsonAsync<Response<CustomerView>>();
                    return responseContent ?? new Response<CustomerView>
                    {
                        Status = 500,
                        Message = "An error occurred while processing the response.",
                        Result = null
                    };
                }
                else
                {
                    return new Response<CustomerView>
                    {
                        Status = (int)result.StatusCode,
                        Message = $"Request failed with status code: {result.StatusCode}",
                        Result = null
                    };
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return new Response<CustomerView>
                {
                    Status = 500,
                    Message = "An error occurred while processing your request.",
                    Result = null
                };
            }
        }
    }
}
