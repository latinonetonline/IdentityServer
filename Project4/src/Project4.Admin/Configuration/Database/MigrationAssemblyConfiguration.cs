// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Configuration.Configuration;

using System;
using System.Reflection;

using MySqlMigrationAssembly = Project4.Admin.EntityFramework.MySql.Helpers.MigrationAssembly;
using PostgreSQLMigrationAssembly = Project4.Admin.EntityFramework.PostgreSQL.Helpers.MigrationAssembly;
using SqlMigrationAssembly = Project4.Admin.EntityFramework.SqlServer.Helpers.MigrationAssembly;

namespace Project4.Admin.Configuration.Database
{
    public static class MigrationAssemblyConfiguration
    {
        public static string GetMigrationAssemblyByProvider(DatabaseProviderConfiguration databaseProvider)
        {
            return databaseProvider.ProviderType switch
            {
                DatabaseProviderType.SqlServer => typeof(SqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
                DatabaseProviderType.PostgreSQL => typeof(PostgreSQLMigrationAssembly).GetTypeInfo()
                    .Assembly.GetName()
                    .Name,
                DatabaseProviderType.MySql => typeof(MySqlMigrationAssembly).GetTypeInfo().Assembly.GetName().Name,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}







