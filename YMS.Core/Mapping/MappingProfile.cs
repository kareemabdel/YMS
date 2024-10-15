using AutoMapper;
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
                  .ForMember(e => e.HasVat, e => e.MapFrom(e => e.HasVat ? "Yes" : "No"))
                .ReverseMap();
            
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
            
            CreateMap<User, UserCredentialsDTO>();
            CreateMap<UserCredentialsDTO, User>();
            
            CreateMap<EmptyStorageTariff, EmptyStorageTariffDTO>();
            CreateMap<EmptyStorageTariffDTO, EmptyStorageTariff>();

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
