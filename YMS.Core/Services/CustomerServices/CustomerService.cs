using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Models.Customers;
using YMS.Core.Models;
using YMS.Core.Models.Users;
using YMS.Migrations.Entities;
using YMS.Migrations.UnitOfWorks;
using YMS.Core.Models.Filters;
using Azure.Core;
using AutoMapper.QueryableExtensions;
using System.Net;

namespace YMS.Core.Services.UserServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PaginatedList<CustomerListDTO>>> GetAll(CustomerFilter? filter)
        {
            var res =await _unitOfWork.CustomersRepo.GetAllCustomersByBranchId(filter!.BranchId,filter!.SearchKey);
            var mappedItems = res.ProjectTo<CustomerListDTO>(_mapper.ConfigurationProvider);
            return new ApiResponse<PaginatedList<CustomerListDTO>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = await PaginatedList<CustomerListDTO>.CreateAsync(mappedItems, filter.Page, filter.Size)
            };
        }
    }
}
