using System.Net;

namespace Portfolio.Models
{
    public class ExceptionMessage
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public ExceptionMessage(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ExceptionMessage(int statusCode)
        {
            StatusCode = statusCode;
            Message = "Unspecified error";
        }

        public ExceptionMessage()
        {
            StatusCode = 500;
            Message = "Internal server error";
        }
    }
}
