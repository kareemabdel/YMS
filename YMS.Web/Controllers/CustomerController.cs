using Microsoft.AspNetCore.Mvc;
using YMS.Core.Models;
using YMS.Core.Models.AuthenticationModels;
using YMS.Core.Models.Customers;
using YMS.Core.Models.Filters;
using YMS.Core.Services.AuthenticationService;
using YMS.Core.Services.UserServices;

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
    }
}
