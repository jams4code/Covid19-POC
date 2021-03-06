﻿using Covid19.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        //private readonly ICurrentUserService _currentUserService;
        //private readonly IIdentityService _identityService;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;

        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            //var userId = _currentUserService.UserId ?? string.Empty;
            //string userName = string.Empty;

            //if (!string.IsNullOrEmpty(userId))
            //{
            //    userName = await _identityService.GetUserNameAsync(userId);
            //}
            var userid = "userid";
            var username = "username";
            _logger.LogInformation("Covid19 Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userid, username, request);
        }
    }
}
