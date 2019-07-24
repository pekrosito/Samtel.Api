using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Samtel.Application.Exceptions;
using Samtel.Domain.Models.Base;
//using Abastible.Sge.Infrastructure.Common.Log;

namespace Samtel.Api.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //var log = LogFactory.GetLog("GENERAL");
            base.OnException(actionExecutedContext);

            if (actionExecutedContext.Exception is ISamtelException)
            {
                var exception = actionExecutedContext.Exception as ISamtelException;
                var statusCode = HttpStatusCode.BadRequest;
                if (exception.GetType() == typeof(NotFoundException))
                    statusCode = HttpStatusCode.Accepted;
                else if (exception.GetType() == typeof(AutorizationException))
                    statusCode = HttpStatusCode.NotFound;
                else if (exception.GetType() == typeof(AuthenticationException))
                    statusCode = HttpStatusCode.Accepted;
                else if (exception.GetType() == typeof(TransactionException))
                    statusCode = HttpStatusCode.Accepted;
                /*else if (exception.GetType() == typeof(AutorizationException))
                    statusCode = HttpStatusCode.BadRequest;
                else if (exception.GetType() == typeof(AutorizationException))
                    statusCode = (HttpStatusCode)460;
                else if (exception.GetType() == typeof(AutorizationException))
                    statusCode = (HttpStatusCode)461;
                else if (exception.GetType() == typeof(AutorizationException))
                    statusCode = (HttpStatusCode)462;
                else if (exception.GetType() == typeof(AutorizationException))
                    statusCode = HttpStatusCode.Forbidden;
                else if (exception.GetType() == typeof(AutorizationException))
                    statusCode = (HttpStatusCode)463;*/

                //log.Warn(((Exception)exception).Message, (Exception)exception);
                //Create(exception, ((Exception)exception).Message)
                var resp = actionExecutedContext.Request.CreateErrorResponse(statusCode, "");
                actionExecutedContext.Response = resp;
            }
            else
            {
                //log.Fatal(actionExecutedContext.Exception.Message, actionExecutedContext.Exception);
            }
        }

        private static HttpError Create(ISamtelException exception, string message)
        {
            return new HttpError()
            {
                { "Message" , message },
                { "ErrorCode" , exception.ErrorCode},
                { "ErrorType" , exception.ErrorType },
                { "Success" , false }
            };
        }
    }
}