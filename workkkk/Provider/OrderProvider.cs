//using workkkk.Viewmodel;

//namespace workkkk.Provider
//{
//    public class OrderProvider
//    {
//        private readonly HttpClient httpClient;
//        public OrderProvider(HttpClient httpClient)
//        {
//            this.httpClient = httpClient;
//        }

//        public async Task<List<OrderView>> OrderList(int customerid, string status)
//        {
//            try
//            {
//                var result = await httpClient
//                    .GetFromJsonAsync<List<OrderView>>
//                    ("$/api/order/OrderList?customerid={customerid}");
//            }
//        }
//    }
//}
