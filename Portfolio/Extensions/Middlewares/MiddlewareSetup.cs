namespace Portfolio.Extensions.Middlewares
{
    public class MiddlewareSetup
    {
        private readonly WebApplication _application;

        public MiddlewareSetup(WebApplication application)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public void RegisterMiddleware()
        {
            /*
             * Authentication
             */
            _application.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
