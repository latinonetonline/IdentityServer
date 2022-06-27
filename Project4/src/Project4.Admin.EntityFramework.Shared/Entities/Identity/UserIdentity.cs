// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Identity;

using Project4.Admin.EntityFramework.Shared.Entities.Tenants;

using System.Collections.Generic;

namespace Project4.Admin.EntityFramework.Shared.Entities.Identity
{
    public class UserIdentity : IdentityUser
    {
        public UserIdentity()
        {
            TenantUsers = new HashSet<TenantUser>();
        }
        public ICollection<TenantUser> TenantUsers { get; set; }

    }
}







