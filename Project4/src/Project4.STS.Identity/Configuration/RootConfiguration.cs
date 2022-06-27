// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Project4.STS.Identity.Configuration.Interfaces;

using Skoruba.Duende.IdentityServer.Shared.Configuration.Configuration.Identity;

namespace Project4.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}







