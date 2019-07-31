using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace Samtel.Api.Filters
{
    public class RestfulModelStateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest, new ApiResourceValidationErrorWrapper(actionContext.ModelState));
            }
        }
    }

    public class ApiResourceValidationErrorWrapper
    {
        private const string ErrorMessage = "The request is invalid.";

        private const string MissingPropertyError = "Undefined error.";

        public ApiResourceValidationErrorWrapper(ModelStateDictionary modelState)
        {
            Message = ErrorMessage;
            SerializeModelState(modelState);
        }

        public ApiResourceValidationErrorWrapper(string message, ModelStateDictionary modelState)
        {
            Message = message;
            SerializeModelState(modelState);
        }

        public string Message { get; private set; }

        public IDictionary<string, IEnumerable<string>> Errors { get; private set; }

        private void SerializeModelState(ModelStateDictionary modelState)
        {
            Errors = new Dictionary<string, IEnumerable<string>>();

            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key;

                var errors = keyModelStatePair.Value.Errors;

                if (errors != null && errors.Count > 0)
                {
                 /*   IEnumerable<string> errorMessages = errors.Select(
                        error => string.IsNullOrEmpty(error.ErrorMessage)
                            ? error.Exception?.Message ?? MissingPropertyError
                            : error.ErrorMessage).ToArray();
                    */
                    Errors.Add(key, null);
                }
            }
        }
    }
}