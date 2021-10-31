using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.Infrastructure.Middlewares
{
    internal sealed class ReadyMiddleware
    {
        private readonly RequestDelegate _next;
        public ReadyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
        }

    }
}
