using System;
using System.Collections.Generic;

namespace Project4.Admin.EntityFramework.Shared.Entities.Tenants
{
    public class Tenant
    {
        public Tenant()
        {
            TenantUsers = new HashSet<TenantUser>();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Uri Website { get; set; }

        public ICollection<TenantUser> TenantUsers { get; set; }
    }
}
