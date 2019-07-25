using Dapper;
using Samtel.Application;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Domain.Models;
using Samtel.Persistence.BusinessServiceProvider.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IContext context, RequestContext requestContext) : base(context, requestContext)
        {
        }

        public Session getSession(string token)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@token", token);

            return ExecuteStoreProcedure<Session>("sel_validateSession", parametro).SingleOrDefault();
        }

        public User Login(User dataRequest)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@UserName", dataRequest.user_username);

            return ExecuteStoreProcedure<User>("sel_user", parametros).SingleOrDefault();
        }

        public User getUserById(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("userId", userId);

            return ExecuteStoreProcedure<User>("sel_userById", parameters).SingleOrDefault();
        }

        public SessionDTO existsActiveSession(User user)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@UserName", user.user_username);
            return ExecuteStoreProcedure<SessionDTO>("sel_sessionActive", parametros).SingleOrDefault();
        }

        public SessionDTO sessionActiveById(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("userId", userId);
            return ExecuteStoreProcedure<SessionDTO>("sel_sessionActiveById", parameters).SingleOrDefault();
        }

        public Session Update(Session session)
        {
            //return base.Update(session);
            return session;
        }

        public void Logout(int userId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("userId", userId);

            ExecuteStoreProcedure("upd_logout", parametros);
        }

        public Session CreateSession(Session session)
        {
            session.session_start_datetime = DateTime.Now;
            //return base.Save(session);
            return session;
        }


        public bool updateTokenNotification(updateTokenNotification dataRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("userId", dataRequest.user_id);
            parameters.Add("deviceId", dataRequest.session_device_id);
            int emergencyUpdated = ExecuteStoreProcedure<int>("upd_session_device_id", parameters).SingleOrDefault();
            return emergencyUpdated == 1 ? true : false;
        }

        public IEnumerable<User> getTechniciansAvailable()
        {
            return ExecuteStoreProcedure<User>("sel_techniciansAvailable");
        }



    }
}
