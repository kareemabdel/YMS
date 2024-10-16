using AutoMapper;
using YMS.Core.Enums;
using YMS.Core.Models.Customers;
using YMS.Core.Models.Customers.ViewModels;
using YMS.Core.Models.Users;
using YMS.Migrations.Entities;

namespace YMS.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create your mappings here
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerListDTO>()
                .ForMember(dest => dest.HasVat, opt => opt.MapFrom(src => src.HasVat ? "Yes" : "No"));
                //.ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => Enum.GetName(typeof(PaymentTypeEnum), src.PaymentType)));

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
            
            CreateMap<User, UserCredentialsDTO>();
            CreateMap<UserCredentialsDTO, User>();
            
            CreateMap<EmptyStorageTariff, EmptyStorageTariffDTO>();
            CreateMap<EmptyStorageTariffDTO, EmptyStorageTariff>();

            CreateMap<EmptyStorageTariffData, EmptyStorageTariffDataDTO>();
            CreateMap<EmptyStorageTariffDataDTO, EmptyStorageTariffData>();

            CreateMap<FullStorageTariff, FullStorageTariffDTO>();
            CreateMap<FullStorageTariffDTO, FullStorageTariff>();

            CreateMap<FullStorageTariffData, FullStorageTariffDataDTO>();
            CreateMap<FullStorageTariffDataDTO, FullStorageTariffData>();

            CreateMap<ServicesTariff, ServicesTariffDTO>();
            CreateMap<ServicesTariffDTO, ServicesTariff>();

            CreateMap<ServiceTariffData, ServiceTariffDataDTO>();
            CreateMap<ServiceTariffDataDTO, ServiceTariffData>();

            CreateMap<PackageServicesTariff, PackageServicesTariffDTO>();
            CreateMap<PackageServicesTariffDTO, PackageServicesTariff>();

            CreateMap<PackageServiceTariffData, PackageServiceTariffDataDTO>();
            CreateMap<PackageServiceTariffDataDTO, PackageServiceTariffData>();

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Branch, BranchDTO>();
            CreateMap<BranchDTO, Branch>();
            
            CreateMap<FullStorageDataType, FullStorageDataTypeDTO>();
            CreateMap<FullStorageDataTypeDTO, FullStorageDataType>(); 
            
            CreateMap<PackageType, PackageTypeDTO>();
            CreateMap<PackageTypeDTO, PackageType>(); 
            
            CreateMap<Service, ServiceDTO>();
            CreateMap<ServiceDTO, Service>();

            CreateMap<Basis, BasisDTO>();
            CreateMap<BasisDTO, Basis>();

            ////////////
            CreateMap<EmptyStorageTariff, EmptyStorageTariffViewModel>();
            CreateMap<EmptyStorageTariffViewModel, EmptyStorageTariff>();

            CreateMap<EmptyStorageTariffData, EmptyStorageTariffDataViewModel>();
            CreateMap<EmptyStorageTariffDataViewModel, EmptyStorageTariffData>();

            CreateMap<FullStorageTariff, FullStorageTariffViewModel>();
            CreateMap<FullStorageTariffViewModel, FullStorageTariff>();

            CreateMap<FullStorageTariffData, FullStorageTariffDataViewModel>();
            CreateMap<FullStorageTariffDataViewModel, FullStorageTariffData>();

            CreateMap<ServicesTariff, ServicesTariffViewModel>();
            CreateMap<ServicesTariffViewModel, ServicesTariff>();

            CreateMap<PackageServicesTariff, PackageServicesTariffViewModel>();
            CreateMap<PackageServicesTariffViewModel, PackageServicesTariff>();

            CreateMap<ServiceTariffData, ServiceTariffDataViewModel>();
            CreateMap<ServiceTariffDataViewModel, ServiceTariffData>();

            CreateMap<PackageServiceTariffData, PackageServiceTariffDataViewModel>();
            CreateMap<PackageServiceTariffDataViewModel, PackageServiceTariffData>();
        }
    }
}
