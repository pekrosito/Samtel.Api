using System;
using System.Net.Http;
using System.Web.Http.Controllers;
//using MongoDB.Bson.IO;
using Newtonsoft.Json;
using Samtel.Domain.Models;
using Samtel.Application.BusinessService;
using Samtel.Application.ServiceAgents;
using Samtel.Application.ApplicationServices;
using Samtel.Resources.Common.Cryptography;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Domain.Models;

namespace Samtel.Application.ApplicationServicesProvider
{
    public class SecurityService : ISecurityService
    {
        private readonly IAuthentication _authentication;
        private readonly IUserRepository _userRepository;
        private readonly RequestContext _requestContext;
        private readonly IConfigurationManager _configurationManager;

        public SecurityService(IAuthentication authentication, IUserRepository userRepository, RequestContext requestContext, IConfigurationManager configurationManager)
        {
            _authentication = authentication;
            _userRepository = userRepository;
            _requestContext = requestContext;
            _configurationManager = configurationManager;
        }

        public bool ValidateAuthenticationToken(HttpRequestMessage httpRequest)
        {
            return _authentication.ValidateAuthorizationToken(httpRequest);
        }

        public bool ValidateAuthorization(HttpActionContext actionContext)
        {
            return _requestContext.CurrentSession != null; //&& _userRepository.HasPermission(_requestContext.CurrentSession.UserId, actionContext.Request.Method.Method.ToUpper(), actionContext.ControllerContext.RouteData.Route.RouteTemplate);
        }

        public SessionDTO GenerateToken(User user)
        {
            Session session = new Session();
            //var existsSession = _userRepository.existsActiveSession(user);
            /*if (existsSession != null && existsSession.user_id == user.Id)
            {
                if (existsSession == null || existsSession.session_end_datetime == null) //.Date > DateTime.Now
                    return existsSession;

                //session.session_end_datetime = DateTime.Now;//DateTime.Now + TimeSpan.FromMinutes(10);
                //session.Id = user.Id;
                //_userRepository.Update(session);

                return existsSession;
            }*/
            /*
            if (existsSession != null)
            {
                _userRepository.Logout(existsSession.user_id);
            }
               
            session.user_id = user.Id;
            session.session_token = UniqueToken.GenerateToken();

            _userRepository.CreateSession(session);
            */
            SessionDTO sessionDto = new SessionDTO
            {
                usertype = user.roleName,
                usertype_id = user.roleId,
                //session_token = session.session_token,
                //user_id = session.user_id,
                user_email = user.user_email,
                user_code = user.user_code,
                user_name = user.user_name
            };

            return sessionDto;
        }
    }
}
