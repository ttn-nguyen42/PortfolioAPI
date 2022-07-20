using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Portfolio.Extensions.Exceptions;
using Portfolio.Models;

namespace Portfolio.Extensions.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                ExceptionMessage message = new(exception.StatusCode, exception.Message);
                context.Result = new ObjectResult(message)
                {
                    StatusCode = message.StatusCode,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
