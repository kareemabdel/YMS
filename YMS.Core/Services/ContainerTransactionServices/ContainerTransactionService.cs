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
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using YMS.Core.Models.Authentications;
using YMS.Core.Models.Customers.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using YMS.Core.Enums;
using YMS.Core.Models.Container;

namespace YMS.Core.Services.UserServices
{
    public class ContainerTransactionService : IContainerTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContainerTransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> GateIn(AddGateInDto obj)
        {
            var apiResponse = new ApiResponse<Guid>();
            
            return apiResponse;
        }

        public async Task<ApiResponse<PaginatedList<GateInDTO>>> GetAll(GateInFilter filter)
        {
            return null;
            //var apiResponse = new ApiResponse<PaginatedList<GateInDTO>>();
            //try
            //{
            //    var (items, totalCount) = await _unitOfWork.ContainerTransactionRepo.Get(
            //    filter: query =>
            //    {
            //        if ((filter?.BranchId != null))
            //        {
            //            query = query.Where(c => c.BranchId == filter.BranchId);
            //        }
            //        if (!string.IsNullOrEmpty(filter?.SearchKey))
            //        {
            //            query = query.Where(c => c.Code.Contains(filter.SearchKey) || c.NameEn.Contains(filter.SearchKey));
            //        }

            //        query = query.Where(c => !c.IsDeleted);

            //        return query;
            //    },
            //    orderByField: filter?.SortField ?? "CreatedDate",
            //    isDescending: filter.SortOrder == -1 ? true : false,
            //    pageNumber: filter.Page,
            //    pageSize: filter.Size
            //    );

            //    var customerList = _mapper.Map<List<GateInDTO>>(items);

            //    apiResponse.StatusCode = HttpStatusCode.OK;
            //    apiResponse.Data = new PaginatedList<GateInDTO>(customerList, totalCount, filter.Page, filter.Size);
            //}
            //catch (Exception ex)
            //{
            //    apiResponse.StatusCode = HttpStatusCode.BadRequest;
            //    apiResponse.Errors = ex.Message;
            //}

            //return apiResponse;
        }
    }
}
