using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ContainerTransactionController : BaseController
    {
        private readonly IContainerTransactionService _containerTransactionService;
        public ContainerTransactionController(IContainerTransactionService containerTransactionService)
        {
            _containerTransactionService = containerTransactionService;
        }

        [HttpPost("get-gate-in")]
        public async Task<ActionResult<PaginatedList<GateInDTO>>> GetAll([FromQuery] GateInFilter filter)
        {
            var branchId = GetBranchId();

            if (branchId != null)
            {
                filter!.BranchId = branchId;
            }

            var response = await _containerTransactionService.GetAll(filter);
            return GetAPIResponse(response);
        }

        [HttpPost("GateIn")]
        public async Task<ActionResult<bool>> GateIn([FromBody] AddGateInDto model)
        {
            return null;
        }

    }
}
