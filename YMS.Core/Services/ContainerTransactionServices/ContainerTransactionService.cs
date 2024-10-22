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
            var apiResponse = new ApiResponse<PaginatedList<GateInDTO>>();
            try
            {
                //sort
                switch(filter.SortField)
                {
                    case "Customer":
                        filter.SortField = "Container.Customer.NameEn";
                        break;

                    case "ContainerNo":
                        filter.SortField = "Container.ContainerNo";
                        break;

                    case "Type":
                        filter.SortField = "Container.ContainerType.NameEn";
                        break;

                    case "Status":
                        filter.SortField = "Container.ShippingStatus";
                        break;

                    case "Line":
                        filter.SortField = "Container.Line.NameEn";
                        break;

                    case "EIRRemark":
                        filter.SortField = "Container.EIRRemarks";
                        break;
                }

                var (items, totalCount) = await _unitOfWork.ContainerTransactionRepo.Get(
                filter: query =>
                {
                    if (filter.BranchId != null)
                    {
                        query = query.Where(c => c.Container.Customer.BranchId == filter.BranchId);
                    }

                    if (!string.IsNullOrEmpty(filter.SearchKey))
                    {
                        query = query.Where(c => c.Container.ContainerNo.Contains(filter.SearchKey) || c.Container.Customer.NameEn.Contains(filter.SearchKey));
                    }

                    if (filter.GateInDateFrom != null)
                    {
                        query = query.Where(c => c.CreatedDate >= filter.GateInDateFrom);
                    }

                    if (filter.GateInDateTo != null)
                    {
                        query = query.Where(c => c.CreatedDate <= filter.GateInDateTo);
                    }

                    query = query.Where(c => !c.IsDeleted);

                    return query;
                },
                orderByField: filter.SortField,
                isDescending: filter.IsDescending,
                includeProperties: "Container,Container.Customer,Container.ContainerType,Container.Line",
                pageNumber: filter.Page,
                pageSize: filter.Size
                );

                var list = new List<GateInDTO>();

                foreach (var item in items) 
                {
                    list.Add(new GateInDTO
                    {
                        Id = item.Id,
                        ContainerNo = item.Container.ContainerNo,
                        Customer = item.Container.Customer.NameEn,
                        Line = item.Container.Line?.NameEn,
                        Type = item.Container.ContainerType.NameEn,
                        CreatedDate = item.CreatedDate.ToString(),
                        EIRRemark = item.Container.EIRRemarks,
                        Status = Enum.GetName(typeof(ContainerShippingStatusEnum), item.Container.ShippingStatus),
                        AllocationStatus = Enum.GetName(typeof(AllocationStatusEnum), item.AllocationStatus)
                    });
                }

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = new PaginatedList<GateInDTO>(list, totalCount, filter.Page, filter.Size);
            }
            catch (Exception ex)
            {
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }

            return apiResponse;
        }
    }
}
