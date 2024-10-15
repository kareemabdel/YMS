using AutoMapper;
using YMS.Core.Models.Customers;
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
            
            CreateMap<User, UserCredentialsDTO>();
            CreateMap<UserCredentialsDTO, User>();
        }
    }
}
