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
using Microsoft.Extensions.Logging;

namespace YMS.Core.Services.UserServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomerService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<PaginatedList<CustomerListDTO>>> GetAll(CustomerFilter filter)
        {
            var apiResponse = new ApiResponse<PaginatedList<CustomerListDTO>>();
            try
            {
                var (items, totalCount) = await _unitOfWork.CustomersRepo.Get(
                filter: query =>
                {
                if ((filter?.BranchId != null))
                {
                    query = query.Where(c => c.BranchId == filter.BranchId);
                }
                if (!string.IsNullOrEmpty(filter?.SearchKey))
                {
                    query = query.Where(c => c.Code.Contains(filter.SearchKey) || c.NameEn.Contains(filter.SearchKey));
                }

                query = query.Where(c => !c.IsDeleted);

                return query;
                },
                orderByField: filter.SortField ?? "CreatedDate",                       
                isDescending: filter.IsDescending,                         
                pageNumber: filter.Page,                      
                pageSize: filter.Size                           
                );

                var customerList = _mapper.Map<List<CustomerListDTO>>(items);

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = new PaginatedList<CustomerListDTO>(customerList, totalCount, filter.Page, filter.Size);



               // var res = await _unitOfWork.CustomersRepo.GetAllCustomersByBranchId(filter!.BranchId, filter!.SearchKey,filter.SortField,filter.SortOrder);
                //var mappedItems = res.ProjectTo<CustomerListDTO>(_mapper.ConfigurationProvider);

                //    apiResponse.StatusCode = HttpStatusCode.OK;
                //    apiResponse.Data = await PaginatedList<CustomerListDTO>.CreateAsync(mappedItems.OrderByDescending(e=>e.CreatedDate), filter.Page, filter.Size);
                //    apiResponse.Data.Items.ForEach(x => x.PaymentType = Enum.GetName(typeof(PaymentTypeEnum), int.Parse(x.PaymentType)));
            }
            catch (Exception ex)
            {
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }
            return apiResponse;
        }
        public async Task<ApiResponse<Guid>> CreateCustomer(CustomerViewModel model)
        {
            var apiResponse = new ApiResponse<Guid>();
            try
            {
                if (model.BranchId == null)
                {
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "BranchId must be provided to create the customer.";

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

                if (model.Tariffs != null && model.Tariffs.Any())
                {
                    if (model.Tariffs.Count > 2)
                    {
                        apiResponse.StatusCode = HttpStatusCode.BadRequest;
                        apiResponse.Errors = "Invalid Tariffs Count. The customer has only two types of tarrifs.";
                        return apiResponse;
                    }

                    var duplicateTariffTypes = model.Tariffs
                                               .GroupBy(t => t.TariffType)
                                               .Where(g => g.Count() > 1)
                                               .Select(g => g.Key)
                                               .ToList();

                    if (duplicateTariffTypes.Any())
                    {
                        apiResponse.StatusCode = HttpStatusCode.BadRequest;
                        apiResponse.Errors = "Invalid Tariffs. Duplicate Tariff Types.";
                        return apiResponse;
                    }
                }

                var currentDate = DateTime.Now;
                var customer = _mapper.Map<Customer>(model);
                customer.CreatedDate = currentDate;

                if (customer.Tariffs != null && customer.Tariffs.Any())
                {
                    foreach (var tariff in customer.Tariffs)
                    {
                        tariff.ValidTo = customer.ValidTo;
                        tariff.CreatedDate = currentDate;
                    }
                }

                await _unitOfWork.CustomersRepo.Insert(customer);
                await _unitOfWork.Save();

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = customer.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateCustomer: {ex.Message}", ex);
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }

            return apiResponse;
        }

        public async Task<ApiResponse<CustomerDTO>> GetCustomerById(GetCustomerRequestModel model)
        {
            var apiResponse = new ApiResponse<CustomerDTO>();

            try
            {
                var customer = await _unitOfWork.CustomersRepo.GetById(model.CustomerId, "Branch,City,City.Country,Line," +
                    "Currency,Tariffs,Tariffs.TariffDataList,Tariffs.TariffDataList.StorageType,Tariffs.TariffServices," +
                    "Tariffs.TariffServices.Service,Tariffs.TariffServices.Basis");

                if (customer == null)
                {
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "Invalid CustomerId. The customer does not exist.";

                    return apiResponse;
                }

                if (model.BranchId != null && customer.BranchId != model.BranchId)
                {
                    apiResponse.StatusCode = HttpStatusCode.Unauthorized;
                    apiResponse.Errors = "Invalid Branch. You are not allowed to see this customer.";

                    return apiResponse;
                }

                var response = _mapper.Map<CustomerDTO>(customer);
                response.City = customer.City.Name;
                response.Country = customer.City.Country.NameEn;
                response.Currency = customer.Currency.NameEn;
                response.Branch = customer.Branch.Name;
                response.Line = customer.Line?.Name;
                response.PaymentType = Enum.GetName(typeof(PaymentTypeEnum), customer.PaymentType);

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = response;

                return apiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetCustomerById: {ex.Message}", ex);
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }

            return apiResponse;
        }
    }
}
