using AutoMapper;

namespace Project4.Admin.Api.Mappers
{
    public static class TenantMappers
    {
        static TenantMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<TenantMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static T ToTenantDto<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}
