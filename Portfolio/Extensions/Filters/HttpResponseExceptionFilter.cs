﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Portfolio.Extensions.Exceptions;

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
                ExceptionMessage message = new ExceptionMessage(exception.Message, exception.StatusCode)
                {
                    Errors = exception.Errors,
                };
                context.Result = new ObjectResult(message)
                {
                    StatusCode = message.StatusCode,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
