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
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerervice;
        public CustomerController(ICustomerService customerervice)
        {
            _customerervice = customerervice;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedList<CustomerListDTO>>> GetAll([FromQuery] CustomerFilter filter)
        {
            var branchId = GetBranchId();

            if (branchId != null)
            {
                filter!.BranchId = branchId;
            }

            var response = await _customerervice.GetAll(filter);
            return GetAPIResponse(response);
        }

        [HttpPost("create-customer")]
        public async Task<ActionResult<Guid>> CreateCustomer([FromBody] CustomerViewModel model)
        {
            var branchId = GetBranchId();

            if (branchId != null)
            {
                model.BranchId = branchId;
            }

            var response = await _customerervice.CreateCustomer(model);
            return GetAPIResponse(response);
        }

        [HttpGet("get-customer-by-id/{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(Guid id)
        {
            var model = new GetCustomerRequestModel { CustomerId = id };

            var branchId = GetBranchId();

            if (branchId != null)
            {
                model.BranchId = branchId;
            }

            var response = await _customerervice.GetCustomerById(model);
            return GetAPIResponse(response);
        }
    }
}
