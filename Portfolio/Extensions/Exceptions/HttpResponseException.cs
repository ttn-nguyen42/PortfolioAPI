namespace Portfolio.Extensions.Exceptions
{
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; set; }

        public ICollection<string> Errors { get; set; } = new List<string>();

        public HttpResponseException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpResponseException(int statusCode) : base("Unspecified error")
        {
            StatusCode = statusCode;
        }

        public HttpResponseException() : base("Internal server error")
        {
            StatusCode = 500;
        }
    }
}
