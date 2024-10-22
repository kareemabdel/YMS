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
using System.Diagnostics;
using Azure;

namespace YMS.Core.Services.UserServices
{
    public class LookupService : ILookupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LookupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<LookupDto>>> GetAll(LookupEnum filter, int? optionalIdFilterId)
        {
            var apiResponse = new ApiResponse<List<LookupDto>>();
            try
            {
                var res =new List<LookupDto>();
                var x = 1;
                switch (filter)
                {
                    case LookupEnum.Countries:
                        res= _mapper.Map<List<LookupDto>>(_unitOfWork.LookupsRepo.GetContries());
                        break;
                    case LookupEnum.Cities:
                        res = _mapper.Map<List<LookupDto>>(_unitOfWork.LookupsRepo.GetCities(optionalIdFilterId!.Value));
                        break;
                    case LookupEnum.Lines:
                        res = _mapper.Map<List<LookupDto>>(_unitOfWork.LookupsRepo.GetLines());
                        break;
                    case LookupEnum.Currencies:
                        res = _mapper.Map<List<LookupDto>>(_unitOfWork.LookupsRepo.GetCurrencies());
                        break;
                    case LookupEnum.Services:
                        res = _mapper.Map<List<LookupDto>>(_unitOfWork.LookupsRepo.GetServices());
                        break;
                    case LookupEnum.Basis:
                        res = _mapper.Map<List<LookupDto>>(_unitOfWork.LookupsRepo.GetBasises());
                        break;
                    case LookupEnum.ContainerTypes:
                        res = _mapper.Map<List<LookupDto>>(_unitOfWork.LookupsRepo.GetContainerTypes());
                        break;
                    default:
                        break;
                }
                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = res;

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
