using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Northwind.Core.Exceptions;

namespace Northwind.WebApi.ExceptionFilters
{
    public class ParameterExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is DataNotFoundException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ExternalArgumentException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }
    }
}
