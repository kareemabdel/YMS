using AutoMapper;
using YMS.Core.Enums;
using YMS.Core.Models;
using YMS.Core.Models.Customers;
using YMS.Core.Models.Customers.ViewModels;
using YMS.Core.Models.Users;
using YMS.Migrations.Entities;
using YMS.Migrations.Entities.Lookups;

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

            CreateMap<PackageServicesTariff, PackageServicesTariffDTO>();
            CreateMap<PackageServicesTariffDTO, PackageServicesTariff>();

            CreateMap<PackageServiceTariffData, PackageServiceTariffDataDTO>();
            CreateMap<PackageServiceTariffDataDTO, PackageServiceTariffData>();



            CreateMap<Branch, BranchDTO>();
            CreateMap<BranchDTO, Branch>();

            CreateMap<LookupDto, Country>();
            CreateMap<LookupDto, City>();
            CreateMap<Line , LookupDto>();
            CreateMap<LookupDto, Currency>();
            CreateMap<LookupDto, Service>();
            CreateMap<LookupDto, Basis>();
            CreateMap<LookupDto, ContainerType>();


            CreateMap<Tariff, TariffDTO>();
            CreateMap<TariffDTO, Tariff>();

            CreateMap<TariffData, TariffDataDTO>();
            CreateMap<TariffDataDTO, TariffData>();

            CreateMap<TariffService, TariffServiceDTO>();
            CreateMap<TariffServiceDTO, TariffService>();
            ////////////

            CreateMap<Tariff, TariffViewModel>();
            CreateMap<TariffViewModel, Tariff>();

            CreateMap<TariffData, TariffDataViewModel>();
            CreateMap<TariffDataViewModel, TariffData>();

            CreateMap<TariffService, TariffServiceViewModel>();
            CreateMap<TariffServiceViewModel, TariffService>();

            CreateMap<PackageServicesTariff, PackageServicesTariffViewModel>();
            CreateMap<PackageServicesTariffViewModel, PackageServicesTariff>();

            CreateMap<PackageServiceTariffData, PackageServiceTariffDataViewModel>();
            CreateMap<PackageServiceTariffDataViewModel, PackageServiceTariffData>();
        }
    }
}
