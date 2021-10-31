using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseApi.Infrastructure.Middlewares
{
    internal sealed class HttpLoggingMiddleware
    {
        private readonly ILogger<HttpLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public HttpLoggingMiddleware(RequestDelegate next, ILogger<HttpLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            if (context.Response.Headers.Count > 0)
            {
                string headersLogString = "Request headers logged:\n";

                foreach (KeyValuePair<string, StringValues> header in context.Response.Headers)
                {
                    headersLogString += $"\t{header.Key}:{header.Value}\n";
                }
                _logger.LogInformation(headersLogString);
            }

            _logger.LogInformation($"Http Request Information:" +
                                   $"{Environment.NewLine}" +
                                   $"Schema: {context.Request.Scheme}" +
                                   $"Host: {context.Request.Host} " +
                                   $"Path: {context.Request.Path} " +
                                   $"QueryString: {context.Request.QueryString} ");

            try
            {
                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering();

                    byte[] buffer = new byte[context.Request.ContentLength.Value];
                    await context.Request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));
                    string bodyAsText = Encoding.UTF8.GetString(buffer);
                    _logger.LogInformation($"Request logged:\n Request Body:{bodyAsText}");

                    context.Request.Body.Position = 0;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request");
            }
        }

        private async Task LogResponse(HttpContext context)
        {
            Stream originalBody = context.Response.Body;
            using MemoryStream newBody = new();
            context.Response.Body = newBody;

            await _next(context);

            if (context.Response.Headers.Count > 0)
            {
                string headersLogString = "Response headers logged:\n";

                foreach (KeyValuePair<string, StringValues> header in context.Response.Headers)
                {
                    headersLogString += $"\t{header.Key}:{header.Value}\n";
                }
                _logger.LogInformation(headersLogString);
            }

            try
            {
                newBody.Seek(0, SeekOrigin.Begin);
                string bodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                _logger.LogInformation($"Response: {bodyText}");
                newBody.Seek(0, SeekOrigin.Begin);
                await newBody.CopyToAsync(originalBody);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }
    }
}
