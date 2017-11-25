
namespace Ecommerce.ViewModels.Common
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T JsonObj { get; set; }
        public long TotalCount { get; set; }
    }

    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public long TotalCount { get; set; }
    }
}
