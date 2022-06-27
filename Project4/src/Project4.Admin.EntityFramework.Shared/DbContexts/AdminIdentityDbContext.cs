// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Project4.Admin.EntityFramework.Shared.Constants;
using Project4.Admin.EntityFramework.Shared.Entities.Identity;
using Project4.Admin.EntityFramework.Shared.Entities.Tenants;

using System;

namespace Project4.Admin.EntityFramework.Shared.DbContexts
{
    public class AdminIdentityDbContext : IdentityDbContext<UserIdentity, UserIdentityRole, string, UserIdentityUserClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken>
    {
        public AdminIdentityDbContext(DbContextOptions<AdminIdentityDbContext> options) : base(options)
        {

        }

        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<TenantUser> TenantUsers => Set<TenantUser>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureIdentityContext(builder);
        }

        private void ConfigureIdentityContext(ModelBuilder builder)
        {
            builder.Entity<UserIdentityRole>().ToTable(TableConsts.IdentityRoles);
            builder.Entity<UserIdentityRoleClaim>().ToTable(TableConsts.IdentityRoleClaims);
            builder.Entity<UserIdentityUserRole>().ToTable(TableConsts.IdentityUserRoles);

            builder.Entity<UserIdentity>().ToTable(TableConsts.IdentityUsers);
            builder.Entity<UserIdentityUserLogin>().ToTable(TableConsts.IdentityUserLogins);
            builder.Entity<UserIdentityUserClaim>().ToTable(TableConsts.IdentityUserClaims);
            builder.Entity<UserIdentityUserToken>().ToTable(TableConsts.IdentityUserTokens);

            builder.Entity<Tenant>(o =>
            {
                o.HasIndex(t => t.Identifier).IsUnique();
                o.Property(t => t.Identifier).IsRequired();
                o.Property(t => t.Name).IsRequired();

                o.Property(t => t.Website)
                    .HasConversion(v => v.ToString(), v => new Uri(v));
            });

            builder.Entity<TenantUser>(o =>
            {
                o.HasKey(o => new { o.UserId, o.TenantId });

                o.HasOne<Tenant>(r => r.Tenant)
                    .WithMany(t => t.TenantUsers)
                    .HasForeignKey(r => r.TenantId);

                o.HasOne<UserIdentity>(r => r.User)
                    .WithMany(t => t.TenantUsers)
                    .HasForeignKey(r => r.UserId);

            });
        }
    }
}







