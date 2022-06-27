using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Project4.Admin.Api.Configuration.Constants;
using Project4.Admin.Api.ExceptionHandling;
using Project4.Admin.Api.Services;
using Project4.Shared.Dtos.Tenants;

using System;
using System.Threading.Tasks;

namespace Project4.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tenant = await _tenantService.GetTenantAsync(id);

            return Ok(tenant);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string searchText, int page = 1, int pageSize = 10)
        {
            var tenants = await _tenantService.GetTenantsAsync(searchText, page, pageSize);

            return Ok(tenants);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] TenantDto tenant)
        {
            //if (!EqualityComparer<TKey>.Default.Equals(role.Id, default))
            //{
            //    return BadRequest(_errorResources.CannotSetId());
            //}

            var tenantDto= await _tenantService.CreateTenantAsync(tenant);

            return CreatedAtAction(nameof(Get), new { id = tenantDto.Id }, tenantDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TenantDto tenant)
        {
            var tenantDto = await _tenantService.UpdateTenantAsync(tenant);

            return Ok(tenantDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tenantService.DeleteTenantAsync(id);

            return Ok();
        }

        //[HttpGet("{id}/Users")]
        //public async Task<IActionResult> GetRoleUsers(string id, string searchText, int page = 1, int pageSize = 10)
        //{
        //    var usersDto = await _identityService.GetRoleUsersAsync(id, searchText, page, pageSize);

        //    return Ok(usersDto);
        //}

    }
}
