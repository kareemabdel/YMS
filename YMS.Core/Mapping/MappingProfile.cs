﻿using AutoMapper;
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

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Branch, BranchDTO>();
            CreateMap<BranchDTO, Branch>();
            CreateMap<StorageType, StorageTypeDTO>();
            CreateMap<StorageTypeDTO, StorageType>();
            CreateMap<PackageType, PackageTypeDTO>();
            CreateMap<PackageTypeDTO, PackageType>();
            CreateMap<Service, ServiceDTO>();
            CreateMap<ServiceDTO, Service>();

            CreateMap<Basis, BasisDTO>();
            CreateMap<BasisDTO, Basis>();

            CreateMap<Tariff, TariffDTO>();
            CreateMap<TariffDTO, Tariff>();

            CreateMap<TariffData, TariffDataDTO>();
            CreateMap<TariffDataDTO, TariffData>();

            CreateMap<TariffService, TariffServiceDTO>();
            CreateMap<TariffServiceDTO, TariffService>();

            ////////////
            CreateMap<LookupDto, Country>().ReverseMap();
            CreateMap<LookupDto, City>().ReverseMap();
            CreateMap<Line, LookupDto>().ReverseMap();
            CreateMap<LookupDto, Currency>().ReverseMap();
            CreateMap<LookupDto, Service>().ReverseMap();
            CreateMap<LookupDto, Basis>().ReverseMap();
            CreateMap<LookupDto, ContainerType>().ReverseMap();


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
