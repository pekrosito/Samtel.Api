using Samtel.Domain.Models;
using Samtel.Application.BusinessService.Base;
using System.Collections.Generic;

namespace Samtel.Application.BusinessService
{
    public interface IUserRepository : IRepository <User>
    {
        Session getSession(string token);
        void Logout(int userId);
    }
}
