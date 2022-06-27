using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Project4.Admin.Api.Mappers;
using Project4.Admin.EntityFramework.Shared.DbContexts;
using Project4.Admin.EntityFramework.Shared.Entities.Tenants;
using Project4.Shared.Dtos.Tenants;

using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Extensions;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project4.Admin.Api.Services
{
    internal class TenantService : ITenantService
    {
        private readonly AdminIdentityDbContext _identityDbContext;

        public TenantService(AdminIdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public async Task<PagedList<TenantDto>> GetTenantsAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<TenantDto>();

            Expression<Func<Tenant, bool>> searchCondition = x => x.Name.Contains(search);
            var tenants = await _identityDbContext.Tenants.WhereIf(!string.IsNullOrEmpty(search), searchCondition).PageBy(x => x.Id, page, pageSize).ToListAsync();

            var tenantsDto = TenantMappers.Mapper.Map<IEnumerable<Tenant>, List<TenantDto>>(tenants);

            pagedList.Data.AddRange(tenantsDto);
            pagedList.TotalCount = await _identityDbContext.Tenants.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync();
            pagedList.PageSize = pageSize;

            return pagedList;
        }

        public async Task<TenantDto> GetTenantAsync(Guid id)
        {
            var tenant = await _identityDbContext.Tenants.SingleOrDefaultAsync(x => x.Id == id);
            var tenantDto = TenantMappers.Mapper.Map<Tenant, TenantDto>(tenant);
            return tenantDto;
        }


        public async Task<TenantDto> CreateTenantAsync(TenantDto tenantDto)
        {
            var tenant = TenantMappers.Mapper.Map<TenantDto, Tenant>(tenantDto);

            await _identityDbContext.Tenants.AddAsync(tenant);
            await _identityDbContext.SaveChangesAsync();

            TenantMappers.Mapper.Map<Tenant, TenantDto>(tenant, tenantDto);

            return tenantDto;
        }

        public async Task<TenantDto> UpdateTenantAsync(TenantDto tenant)
        {

            var existingTenant = await _identityDbContext.Tenants.SingleOrDefaultAsync(x => x.Id == tenant.Id);


            TenantMappers.Mapper.Map(tenant, existingTenant);

            _identityDbContext.Tenants.Update(existingTenant);
            await _identityDbContext.SaveChangesAsync();


            var tenantDto = TenantMappers.Mapper.Map<Tenant, TenantDto>(existingTenant);

            return tenantDto;
        }

        public virtual async Task DeleteTenantAsync(Guid id)
        {
            var tenant = await _identityDbContext.Tenants.SingleOrDefaultAsync(x => x.Id == id);

            _identityDbContext.Tenants.Remove(tenant);
            await _identityDbContext.SaveChangesAsync();
        }
    }
}
