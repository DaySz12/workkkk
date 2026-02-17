namespace workkkk.Viewmodel
{
    public class Response<T>
    {
        public T? Result { get; set; }
        public int? Status { get; set; }

        public string? Message { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
