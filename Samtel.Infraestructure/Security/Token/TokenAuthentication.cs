using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Samtel.Application;
using Samtel.Application.Exceptions;
using Samtel.Application.BusinessService;
using Samtel.Application.ServiceAgents;

namespace Samtel.Infraestructure.Security.Token
{
    public class TokenAuthentication : IAuthentication
    {
        private readonly RequestContext _requestContext;
        //private readonly IUserRepository _userRepository;
        //IUserRepository userRepository
        public TokenAuthentication(RequestContext requestContext)
        {
           // _userRepository = userRepository;
            _requestContext = requestContext;
        }

        public bool ValidateAuthorizationToken(HttpRequestMessage httpRequest)
        {
            try
            {
                IEnumerable<string> authList;
                httpRequest.Headers.TryGetValues("Authorization", out authList);
                if (authList != null && authList.Any())
                {
                    var token = authList.FirstOrDefault().Replace("Basic", "").Trim();
                    //var sessions = _userRepository.getSession(token);
                    //_requestContext.CurrentSession = sessions ??  new AutorizationException("Token Not Authorization", ErrorTypes.SessionDontExists);
                    return true;
                }
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            /*
            catch (ArgumentException)
            {
                return false;
            }*/
        }
    }
}
