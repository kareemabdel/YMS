using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using YMS.Core.Exceptions;

namespace YMS.Web.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly JsonSerializerSettings _serializerSettings;

        public ApiExceptionFilterAttribute( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _serializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
                { typeof(ApplicationException), HandleAppException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                _httpContextAccessor.HttpContext.Response.ContentType = "application/json";
                _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            }

            if (context.Exception.Message.Contains("problem from c4c side") &&
                context.Exception.Message.Contains("\"error\":") &&
                context.Exception.Message.Contains("\"value\":"))
            {
                HandleC4CAppException(context);
                return;
            }

            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

       

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            var result = JsonConvert.SerializeObject(new ResultResponse
            {
                ErrorMessage = (string.IsNullOrEmpty(details.Title) ? details.Detail : details.Title) ?? string.Empty,
                IsSuccess = false,
                StatusCode = details.Status ?? StatusCodes.Status400BadRequest,
                Errors = details.Errors.Values.SelectMany(x => x).ToList()
            }, _serializerSettings);

            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var result = JsonConvert.SerializeObject(new ResultResponse
            {
                ErrorMessage = exception.Message,
                IsSuccess = false,
                StatusCode = StatusCodes.Status404NotFound
            }, _serializerSettings);

            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var result = JsonConvert.SerializeObject(new ResultResponse
            {
                ErrorMessage = "Unauthorized",
                IsSuccess = false,
                StatusCode = StatusCodes.Status401Unauthorized
            }, _serializerSettings);

            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);

            context.ExceptionHandled = true;
        }

        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            var exception = context.Exception as ForbiddenAccessException;

            var result = JsonConvert.SerializeObject(new ResultResponse
            {
                ErrorMessage = string.IsNullOrEmpty(exception.Message) ? "Forbidden" : exception.Message,
                IsSuccess = false,
                StatusCode = StatusCodes.Status403Forbidden
            }, _serializerSettings);

            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);

            context.ExceptionHandled = true;
        }

        private void HandleAppException(ExceptionContext context)
        {
            var result = JsonConvert.SerializeObject(new ResultResponse
            {
                ErrorMessage = context.Exception.Message,
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            }, _serializerSettings);

            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);

            context.ExceptionHandled = true;
        }

        private void HandleC4CAppException(ExceptionContext context)
        {
            var start = context.Exception.Message.IndexOf("\"value\":\"") + 9;
            var end = context.Exception.Message.IndexOf("\"}");
            var message = context.Exception.Message.Substring(start, end - start);

            var result = JsonConvert.SerializeObject(new ResultResponse
            {
                ErrorMessage = "HandleC4CAppException",
                IsSuccess = false,
                StatusCode = StatusCodes.Status400BadRequest
            }, _serializerSettings);

            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var result = JsonConvert.SerializeObject(new ResultResponse
            {
                ErrorMessage = "An error occurred while processing your request.",
                IsSuccess = false,
                StatusCode = StatusCodes.Status500InternalServerError
            }, _serializerSettings);

            if (_httpContextAccessor.HttpContext != null)
                _httpContextAccessor.HttpContext.Response.WriteAsync(result);

            context.ExceptionHandled = true;
        }
    }
}
