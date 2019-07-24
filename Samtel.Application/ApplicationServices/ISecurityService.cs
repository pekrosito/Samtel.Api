using System.Net.Http;
using System.Web.Http.Controllers;
using Samtel.Domain.Models;
using Samtel.Application.ApplicationServices.DTOs;

namespace Samtel.Application.ApplicationServices
{
    public interface ISecurityService
    {
        bool ValidateAuthenticationToken(HttpRequestMessage httpRequest);
        bool ValidateAuthorization(HttpActionContext actionContext);
        SessionDTO GenerateToken(User user);
    }
}
