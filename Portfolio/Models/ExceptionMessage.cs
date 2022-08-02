namespace Portfolio.Models
{
    public class ExceptionMessage
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public ExceptionMessage(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
