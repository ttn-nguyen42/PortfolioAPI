using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Portfolio.Extensions.Behaviors
{
    public static class ValidationFailureConfigurer
    {
        public static void ConfigureValidationFailureOptions(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                IEnumerable<string> errors = context.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                ExceptionMessage result = new ExceptionMessage("Bad request", 400)
                {
                    Errors = errors,
                };
                return new ObjectResult(result)
                {
                    ContentTypes = {
                    Application.Json,
                },
                    StatusCode = 400,
                };
            };
        }
    }
}
