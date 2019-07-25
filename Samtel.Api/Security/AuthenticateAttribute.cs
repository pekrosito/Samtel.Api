using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Microsoft.Practices.ServiceLocation;
using Samtel.Application.Exceptions;
using Samtel.Application.ApplicationServices;
//using Samtel.Infrastructure.Common.Log;

namespace Samtel.Api.Security
{
    public class AuthenticateAttribute : Attribute, IAuthenticationFilter
    {
        //private readonly ILog _log = LogFactory.GetLog<AuthenticateAttribute>();
        public bool AllowMultiple { get; private set; }
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var securityService = ServiceLocator.Current.GetInstance<ISecurityService>();
            try
            {
                //_log.Debug("Start AuthenticateAttribute");
                if (!securityService.ValidateAuthenticationToken(context.Request))
                {
                    //_log.Debug("Validation Token is false, return UnAuthenticated");
                    context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
                }
                //_log.Debug("User has permission, save last login");
            }
            catch (AutorizationException exception)
            {
                //_log.Error("AutorizationException exception. Generate Error Response", exception);
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
            }
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new ResultWithChallenge(context.Result);
            return Task.FromResult(0);
        }

        public class ResultWithChallenge : IHttpActionResult
        {
            private readonly IHttpActionResult next;
            public ResultWithChallenge(IHttpActionResult next)
            {
                this.next = next;
            }

            public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return await next.ExecuteAsync(cancellationToken);
            }
        }
    }
}