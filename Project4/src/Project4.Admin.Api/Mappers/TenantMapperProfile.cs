using AutoMapper;

using Project4.Admin.EntityFramework.Shared.Entities.Tenants;
using Project4.Shared.Dtos.Tenants;

namespace Project4.Admin.Api.Mappers
{
    public class TenantMapperProfile : Profile
    {
        public TenantMapperProfile()
        {
            CreateMap<Tenant, TenantDto>();
            CreateMap<TenantDto, Tenant>();
        }
    }
}
