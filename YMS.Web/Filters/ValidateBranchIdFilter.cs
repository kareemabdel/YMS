using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YMS.Web.Filters
{
    public class ValidateBranchIdFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userClaims = context.HttpContext.User;

            // Extract branchId from token (claims)
            var branchIdFromToken = userClaims.FindFirst("branchId")?.Value;

            var requestBody = await new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync();
            // Check if the branchId is passed in the customer model (action arguments)
            if (context.ActionArguments.TryGetValue("customerModel", out var customerModel))
            {
                var branchIdFromModel = customerModel?.GetType().GetProperty("BranchId")?.GetValue(customerModel, null)?.ToString();

                // If branchId exists in token, assign it
                if (!string.IsNullOrEmpty(branchIdFromToken))
                {
                    // Assign the branchId from token to the customer model
                    customerModel?.GetType().GetProperty("BranchId")?.SetValue(customerModel, branchIdFromToken);
                }
                // If no branchId in token & model, return an error
                else if (string.IsNullOrEmpty(branchIdFromToken) && string.IsNullOrEmpty(branchIdFromModel))
                {
                    context.Result = new BadRequestObjectResult("BranchId must be provided to create the customer.");
                    return;
                }
            }

            // Proceed to the next action in the pipeline
            await next();
        }
    }
}
