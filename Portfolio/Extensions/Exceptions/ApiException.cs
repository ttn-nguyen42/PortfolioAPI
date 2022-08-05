namespace Portfolio.Extensions.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public ICollection<string> Errors { get; set; } = new List<string>();

        public ApiException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public ApiException(int statusCode) : base("Unspecified error")
        {
            StatusCode = statusCode;
        }

        public ApiException() : base("Server error, changes not saved")
        {
            StatusCode = 500;
        }
    }
}
