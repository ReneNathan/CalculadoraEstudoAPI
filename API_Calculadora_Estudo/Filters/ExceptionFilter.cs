using API_Calculadora_Estudo.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API_Calculadora_Estudo.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = context.Exception is NoOperationError;

            if (result) {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new NoOperationError(context.Exception.Message));
                context.ExceptionHandled = true;
            }
        }
    }
}
