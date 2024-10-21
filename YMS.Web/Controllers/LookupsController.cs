using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Core.Enums;
using YMS.Core.Models;
using YMS.Core.Models.AuthenticationModels;
using YMS.Core.Models.Container;
using YMS.Core.Models.Customers;
using YMS.Core.Models.Customers.ViewModels;
using YMS.Core.Models.Filters;
using YMS.Core.Services.AuthenticationService;
using YMS.Core.Services.UserServices;
using YMS.Web.Filters;

namespace YMS.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class LookupsController : BaseController
    {
        private readonly ILookupService _lookupService;
        public LookupsController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("GetLookupDDLByType")]
        public async Task<ActionResult<List<LookupDto>>> GetLookupDDLByType([FromQuery]LookupEnum filter,[FromQuery]int? optionalIdFilterId)
        {
            var response = await _lookupService.GetAll(filter,optionalIdFilterId);
            return GetAPIResponse(response);
        } 

    }
}
