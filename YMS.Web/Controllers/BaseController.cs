using Microsoft.AspNetCore.Mvc;
using System.Net;
using YMS.Core.Models;

namespace YMS.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult GetAPIResponse<T>(ApiResponse<T> apiResponse)
        {
            if (apiResponse == null)
                return StatusCode(500);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(apiResponse.Data);

                case HttpStatusCode.Created:
                    return StatusCode(201, apiResponse.Data);

                case HttpStatusCode.BadRequest:
                    return BadRequest(apiResponse.Errors);

                case HttpStatusCode.Unauthorized:
                    return Unauthorized(apiResponse.Errors);
            }

            return StatusCode(500, apiResponse.Errors);
        }

        protected Guid? GetBranchId()
        {
            var branchId = User.FindFirst("BranchId")?.Value;

            if(string.IsNullOrEmpty(branchId))
            {
                return null;
            }

            return new Guid(branchId);
        }
    }
}
