using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TransactionExchange.Api.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILoggerFactory _loggerFactory )
        {
            _next = next;
            _logger = _loggerFactory.CreateLogger("LoggingMiddleware");
        }

        public async Task Invoke(HttpContext context)
        {
                try
                {
                    await _next(context);
                }
                finally
                {
                    _logger.LogInformation(
                        "Request{method}{url} => {statusCode}",
                        context.Request?.Method,
                        context.Request.Path.Value,
                        context.Response.StatusCode);
                }
        }
    }
}
