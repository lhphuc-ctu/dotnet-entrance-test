using System.Diagnostics;

namespace dotnet_entrance_test.Middleware
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(RequestDelegate request, ILogger<RequestTimeMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await _request(context);

            stopwatch.Stop();

            var requestTime = stopwatch.ElapsedMilliseconds;

            if (requestTime > 500) 
            {
                _logger.LogWarning($"Request took {requestTime} ms: {context.Request.Method} {context.Request.Path}");
            }
        }
    }
}
