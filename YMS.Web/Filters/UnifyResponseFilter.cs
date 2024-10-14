using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace YMS.Web.Filters
{
    public class UnifyResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is FileContentResult fileResult)
            {
                // Return directly if the result is a file
                context.Result = fileResult;
                return;
            }

            if (context.Result == null || (IStatusCodeActionResult)context.Result == null)
            {
                return;
            }

            var actionResultStatusCode = ((IStatusCodeActionResult)context.Result).StatusCode;
            var successCodes = new List<int?> { 200, 201 };

            if (successCodes.Contains(actionResultStatusCode))
            {
                var returnObj = (ObjectResult)context.Result;
                context.Result = new ResponseActionResult(new ResultResponse() { Content = returnObj?.Value ?? string.Empty, IsSuccess = true, StatusCode = returnObj?.StatusCode });
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }

    public class ResultResponse
    {
        public bool IsSuccess { get; set; }
        public int? StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public IList<string>? Errors { get; set; }
        public object? Content { get; set; }
    }

    public class ResponseActionResult : IActionResult
    {
        private readonly ResultResponse _responseMessage;
        public ResponseActionResult()
        {
        }

        public ResponseActionResult(ResultResponse responseMessage)
        {
            _responseMessage = responseMessage; // could add throw if null
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_responseMessage);

            await objectResult.ExecuteResultAsync(context);
        }
    }

}
