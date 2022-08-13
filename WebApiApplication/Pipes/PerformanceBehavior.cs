using MediatR;
using System.Diagnostics;

namespace WebApiApplication.Pipes
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;

        public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
            => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var response = await next();

            stopwatch.Stop();
            _logger.LogInformation($"Request {typeof(TRequest).Name} takes {stopwatch.ElapsedMilliseconds} ms");
            return response;
        }
    }
}
