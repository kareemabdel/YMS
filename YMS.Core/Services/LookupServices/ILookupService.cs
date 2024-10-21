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
using YMS.Core.Models.Customers.ViewModels;
using YMS.Core.Models.Container;
using YMS.Core.Enums;

namespace YMS.Core.Services.UserServices
{
    public interface ILookupService
    {
        Task<ApiResponse<List<LookupDto>>> GetAll(LookupEnum filter,int? optionalIdFilterId);
    }
}
