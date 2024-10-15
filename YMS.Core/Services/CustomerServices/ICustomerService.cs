using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Models.Customers;
using YMS.Core.Models.Filters;
using YMS.Core.Models;
using YMS.Core.Models.Users;

namespace YMS.Core.Services.UserServices
{
    public interface ICustomerService
    {
        Task<ApiResponse<PaginatedList<CustomerListDTO>>> GetAll(CustomerFilter? filter);
    }
}
