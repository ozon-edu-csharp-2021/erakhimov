using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OzonEdu.MerchandiseApi.Infrastructure.Filters
{
    internal class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var resultObject = new
            {
                ExceptionType = context.Exception.GetType().FullName,
                context.Exception.StackTrace
            };

            JsonResult jsonResult = new(resultObject)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.Result = jsonResult;
        }
    }
}
