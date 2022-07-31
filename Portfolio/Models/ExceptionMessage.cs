namespace Portfolio.Models
{
    public class ExceptionMessage
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public ExceptionMessage(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
