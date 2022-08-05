using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Portfolio.Utils;

namespace Portfolio.Extensions.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        private const string APIKEY_HEADER = "XApiKey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IKeyRepository keyRepository)
        {
            if (context.Request.Method.ToUpper().Equals("GET"))
            {
                await _next(context);
                return;
            }
            if (context.Request.Headers.TryGetValue(APIKEY_HEADER, out StringValues requestKey) is false)
            {
                ExceptionMessage message = new ExceptionMessage("No API header", 406);
                context.Response.StatusCode = StatusCodes.Status406NotAcceptable;
                await context.Response.WriteAsJsonAsync(message);
                return;
            }
            string hashedKey = KeyHasher.Hash(requestKey.ToString());
            Key? key = await keyRepository.FindKeyAsync(hashedKey);
            if (key is null)
            {
                ExceptionMessage message = new ExceptionMessage("Invalid API key", 401);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(message);
                return;
            }
            if (key!.Authorization == KeyAuthorization.READONLY)
            {
                if (!context.Request.Method.ToUpper().Equals("GET"))
                {
                    ExceptionMessage message = new ExceptionMessage("Method not allowed", 405);
                    context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                    await context.Response.WriteAsJsonAsync(message);
                    return;
                }
            }
            await _next(context);
        }
    }
}
