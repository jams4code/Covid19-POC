using MediatR;
using Microsoft.Extensions.Logging;
using Covid19.Application.Common.Interfaces;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public RequestPerformanceBehaviour(
            ILogger<TRequest> logger, 
            ICurrentUserService currentUserService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                //var userId = _currentUserService.UserId ?? string.Empty;
                //var userName = string.Empty;

                //if (!string.IsNullOrEmpty(userId))
                //{
                //    userName = await _identityService.GetUserNameAsync(userId);
                var userid = "userid";
                var username = "username";
                

                _logger.LogWarning("Covid19 Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                    requestName, elapsedMilliseconds, userid, username, request);
            }

            return response;
        }
    }
}
