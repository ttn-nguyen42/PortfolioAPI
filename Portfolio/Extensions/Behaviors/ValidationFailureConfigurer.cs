using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Portfolio.Extensions.Behaviors
{
    public static class ValidationFailureConfigurer
    {
        public static void ConfigureValidationFailureOptions(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context => new ObjectResult(context.ModelState)
            {
                ContentTypes = {
                    Application.Json,
                },
                StatusCode = 400,
            };
        }
    }
}
