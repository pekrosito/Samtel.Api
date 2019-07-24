using System.Net.Http;

namespace Samtel.Application.ServiceAgents
{
    public interface IAuthentication
    {
        bool ValidateAuthorizationToken(HttpRequestMessage httpRequest);
    }
}
