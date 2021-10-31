using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseApi.Infrastructure.Middlewares;
using System;

namespace OzonEdu.MerchandiseApi.Infrastructure.StartupFilters
{
    internal sealed class TerminalStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseMiddleware<HttpLoggingMiddleware>();
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<LiveMiddleware>());
                app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());

                next(app);
            };
        }
    }
}
