namespace demo_mvc.ViewModels
{
    public class DataResult
    {
        public string? id { get; set; }
        public int status { get; set; }
    }

    public class DataResult<T> : DataResult
    {
        public T data { get; set; }
    }
}
