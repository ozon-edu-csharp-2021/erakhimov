using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.Infrastructure.Middlewares
{
    internal sealed class VersionMiddleware
    {
        private readonly RequestDelegate _next;
        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var json = new
            {
                version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version",
                serviceName = Assembly.GetExecutingAssembly().GetName().Name
            };

            await context.Response.WriteAsJsonAsync(json);
        }

    }
}
