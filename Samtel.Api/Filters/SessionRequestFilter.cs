using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Practices.ServiceLocation;
using Samtel.Application.BusinessService.Base;

namespace Samtel.Api.Filters
{
    public class SessionRequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfwork>();
            if (!actionContext.ActionDescriptor.GetCustomAttributes<NoTransactionAttribute>().Any() && (actionContext.Request.Method.Method == "POST" || actionContext.Request.Method.Method == "PUT" || actionContext.Request.Method.Method == "DELETE" || unitOfWork.ExistsTransaction()))
                unitOfWork.BeginTransaction();

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfwork>();
            try
            {
                if (!actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<NoTransactionAttribute>().Any() && (actionExecutedContext.Request.Method.Method == "POST" || actionExecutedContext.Request.Method.Method == "PUT" || actionExecutedContext.Request.Method.Method == "DELETE" || unitOfWork.ExistsTransaction()))
                {
                    if (actionExecutedContext.Exception != null)
                        unitOfWork.Rollback();
                    else
                        unitOfWork.Commit();
                }
            }
            finally
            {
                unitOfWork.Dispose();
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}