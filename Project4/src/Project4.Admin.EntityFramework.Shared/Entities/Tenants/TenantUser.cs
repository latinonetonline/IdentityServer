using Project4.Admin.EntityFramework.Shared.Entities.Identity;

using System;

namespace Project4.Admin.EntityFramework.Shared.Entities.Tenants
{
    public class TenantUser
    {
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public string UserId { get; set; }
        public virtual UserIdentity User { get; set; }

    }
}
