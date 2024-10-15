using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Core.Models;
using YMS.Core.Models.AuthenticationModels;
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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerervice;
        public CustomerController(ICustomerService customerervice)
        {
            _customerervice = customerervice;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] CustomerFilter? filter, int page = 1, int size = 10)
        {
            var response = await _customerervice.GetAll(filter,page,size);
            return GetAPIResponse(response);
        }

        [Authorize]
        [HttpPost("create-customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerViewModel model)
        {
            var branchId = GetBranchId();

            if (branchId != null)
            {
                model.BranchId = branchId;
            }

            var response = await _customerervice.CreateCustomer(model);
            return GetAPIResponse(response);
        }
    }
}
