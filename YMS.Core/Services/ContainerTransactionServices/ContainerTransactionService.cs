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

        public async Task<ApiResponse<bool>> GateIn(AddGateInDto obj)
        {
            var apiResponse = new ApiResponse<bool>();
            
            return apiResponse;
        }

    }
}
