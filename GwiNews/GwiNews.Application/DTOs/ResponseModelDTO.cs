namespace GwiNews.Application.DTOs
{
    public class ResponseModelDTO<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
