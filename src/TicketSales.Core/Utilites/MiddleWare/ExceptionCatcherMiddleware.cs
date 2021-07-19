using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSales.Core.Utilites.MiddleWare
{
    public class ExceptionCatcherMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionCatcherMiddleware(RequestDelegate next)
        {
            _next = next;           
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    IsSuccess = false,
                    Message = ex.Message

                };
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
            }
        }
    }
}
