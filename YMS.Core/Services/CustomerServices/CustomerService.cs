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
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Claims;
using YMS.Core.Models.Authentications;
using YMS.Core.Models.Customers.ViewModels;

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

        public async Task<ApiResponse<bool>> CreateCustomer(CustomerViewModel model)
        {
            var apiResponse = new ApiResponse<bool>();
            try
            {
                if (model.BranchId == null) 
                { 
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "BranchId must be provided to create the customer.";

                    return apiResponse;
                }

                if (model.EmptyStorageTariffViewModel == null && 
                    model.FullStorageTariffViewModel == null &&
                    model.ServicesTariffViewModel == null &&
                    model.PackageServicesTariffViewModel == null)
                {
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "Tarrif is required.";
                    return apiResponse;
                }

                var existedCustomer = await _unitOfWork.CustomersRepo.GetCustomerByCode(model.Code, model.BranchId.Value);

                if (existedCustomer != null)
                {
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "The customer already exists in this branch.";

                    return apiResponse;
                }

                // Check if the branch, city, and currency exist in the database
                var branchExists = await _unitOfWork.BranchesRepo.GetById(model.BranchId.Value);
                var cityExists = await _unitOfWork.CitiesRepo.GetById(model.CityId);
                var currencyExists = await _unitOfWork.CurrenciesRepo.GetById(model.CurrencyId);

                if (branchExists == null)
                {
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "Invalid BranchId. The branch does not exist.";
                    return apiResponse;
                }

                if (cityExists == null)
                {
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "Invalid CityId. The city does not exist.";
                    return apiResponse;
                }

                if (currencyExists == null)
                {
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "Invalid CurrencyId. The currency does not exist.";
                    return apiResponse;
                }

                var customer = _mapper.Map<Customer>(model);
                customer.CreatedDate = DateTime.Now;
                await _unitOfWork.CustomersRepo.Insert(customer);

                if (model.EmptyStorageTariffViewModel != null)
                {
                    var emptyStorageTariff = _mapper.Map<EmptyStorageTariff>(model.EmptyStorageTariffViewModel);
                    emptyStorageTariff.CustomerId = customer.Id;

                    await _unitOfWork.EmptyStorageTariffsRepo.Insert(emptyStorageTariff);
                }

                if (model.FullStorageTariffViewModel != null)
                {
                    var fullStorageTariff = _mapper.Map<FullStorageTariff>(model.FullStorageTariffViewModel);
                    fullStorageTariff.CustomerId = customer.Id;

                    await _unitOfWork.FullStorageTariffsRepo.Insert(fullStorageTariff);
                }

                if (model.ServicesTariffViewModel != null)
                {
                    var servicesTariff = _mapper.Map<ServicesTariff>(model.ServicesTariffViewModel);
                    servicesTariff.CustomerId = customer.Id;

                    await _unitOfWork.ServicesTariffsRepo.Insert(servicesTariff);
                }

                if (model.PackageServicesTariffViewModel != null)
                {
                    var packageServicesTariff = _mapper.Map<PackageServicesTariff>(model.PackageServicesTariffViewModel);
                    packageServicesTariff.CustomerId = customer.Id;

                    await _unitOfWork.PackageServicesTariffsRepo.Insert(packageServicesTariff);
                }

                await _unitOfWork.Save();

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = true;
            }
            catch (Exception ex)
            {
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }

            return apiResponse;
        }

        public Task<ApiResponse<PaginatedList<CustomerListDTO>>> GetAll(CustomerFilter? filter, int page, int size)
        {
            throw new NotImplementedException();
        }
    }
}
