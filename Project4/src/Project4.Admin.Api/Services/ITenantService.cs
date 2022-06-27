using Project4.Shared.Dtos.Tenants;

using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

using System;
using System.Threading.Tasks;

namespace Project4.Admin.Api.Services
{
    public interface ITenantService
    {
        Task<TenantDto> CreateTenantAsync(TenantDto tenantDto);
        Task DeleteTenantAsync(Guid id);
        Task<TenantDto> GetTenantAsync(Guid id);
        Task<PagedList<TenantDto>> GetTenantsAsync(string search, int page = 1, int pageSize = 10);
        Task<TenantDto> UpdateTenantAsync(TenantDto tenant);
    }
}